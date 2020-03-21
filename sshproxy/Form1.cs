using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace sshproxy
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        // vars
        private string username = "";
        private string host = "";
        private string port = "22";
        private string localport = "7070";
        private Process cmd;
        private bool isProxyOn = false;

        // 声明两个委托，用于处理子进程中的事件
        private delegate void logDelegate(string msg);
        private delegate void sshExitDelegate(string msg);

        // 窗体加载时的钩子函数
        private void mainForm_Load(object sender, EventArgs e)
        {
            loadInfo();
            tbUser.Text = username;
            tbHost.Text = host;
            tbPort.Text = port;
            tbLocalPort.Text = localport;
        }

        // 自定义的一些方法
        // 最小化时缩小到托盘
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
               
            }
        }
        
        // 关闭时缩小到托盘
        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (isProxyOn)
            {
                e.Cancel = true;
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }
            
        }

        // 子进程日志处理
        public void WriteLog(string msg)
        {
            if (this.textBox1.InvokeRequired)
            {
                logDelegate md = new logDelegate(WriteLog);
                this.Invoke(md, new object[] { msg });
            }
            else
                this.textBox1.Text += msg;
        }
        
        // 子进程退出时的处理
        public void SSHExit(string msg)
        {
            if (this.textBox1.InvokeRequired)
            {
                sshExitDelegate md = new sshExitDelegate(SSHExit);
                this.Invoke(md, new object[] { msg });
            }
            else
                this.textBox1.Text += msg;
            setProxyStatus(false);
        }
        
        // 从文件中加载配置信息
        private void loadInfo()
        {
            string filePath = Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%"), ".sshproxy");
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (line.Contains("="))
                    {
                        string[] parts = line.Split("=".ToCharArray());
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        switch (key)
                        {
                            case "Host":
                                host = value;
                                break;
                            case "User":
                                username = value;
                                break;
                            case "Port":
                                port = value;
                                break;
                            case "LocalPort":
                                localport = value;
                                break;
                            default:
                                break;
                        }
                    }

                }
            }
        }

        // 把配置信息写入文件
        private void writeInfo()
        {
            string filePath = Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%"), ".sshproxy");
            string[] lines =
            {
                $"Host = {host}",
                $"User = {username}",
                $"Port = {port}",
                $"LocalPort = {localport}"
            };
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                   
                   file.WriteLine(line);
                   
                }
            }
            
        }

        // 点击托盘上的退出菜单退出程序
        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((object)cmd != null)
                {
                    if (cmd.HasExited == false)
                    {
                        cmd.Kill();
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"cmd is not running, {ex.Message}");
            }

            notifyIcon.Dispose();
            Application.ExitThread();
            Application.Exit();
            System.Environment.Exit(0);
        }

        // 双击托盘显示主界面
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

        // 打开子进程，连接ssh
        private void ConnectSSH()
        {
            try
            {
                cmd = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "C:\\Windows\\System32\\OpenSSH\\ssh.exe",
                        Arguments = $"-D {localport} {username}@{host} -p {port}",  // 
                        UseShellExecute = false,
                        RedirectStandardInput = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    }
                };
                textBox1.Text = cmd.StartInfo.FileName + " " + cmd.StartInfo.Arguments + "\n";
                cmd.Start();
                cmd.OutputDataReceived += (s, _e) => WriteLog(_e.Data);
                cmd.ErrorDataReceived += (s, _e) => WriteLog(_e.Data);
                cmd.Exited += (s, _e) => SSHExit("Exited with " + cmd.ExitCode);
                cmd.EnableRaisingEvents = true;
                cmd.BeginOutputReadLine();
                cmd.BeginErrorReadLine();
            }
            catch(Exception ex)
            {
                textBox1.Text = ex.Message;
                cmd.Close();
            }
            
        }

        // 捕获用户输入
        private void tbUser_TextChanged(object sender, EventArgs e)
        {
            username = tbUser.Text;
        }
        private void tbHost_TextChanged(object sender, EventArgs e)
        {
            host = tbHost.Text;
        }
        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            port = tbPort.Text;
        }
        private void tbLocalPort_TextChanged(object sender, EventArgs e)
        {
            localport = tbLocalPort.Text;
        }

        // 打开代理的一系统操作 
        private void openProxy()
        {
            setProxyStatus(true);
            writeInfo();
            ConnectSSH();
        }

        // 关闭代理的一系统操作
        private void closeProxy()
        {
            try
            {
                cmd.Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Turn off failed, {ex.Message}");
            }
            this.setProxyStatus(false);
        }

        // 代理状态改变时处理界面改变
        private void setProxyStatus(bool st)
        {
            this.isProxyOn = st;
            if (this.isProxyOn)
            {
                this.状态ToolStripMenuItem.Text = "状态: On";
                this.操作ToolStripMenuItem.Text = "关闭";
                this.btnOn.Enabled = false;
                this.btnOff.Enabled = true;
            }
            else
            {
                this.状态ToolStripMenuItem.Text = "状态: Off";
                this.操作ToolStripMenuItem.Text = "打开";
                this.btnOn.Enabled = true;
                this.btnOff.Enabled = false;
            }
        }

        // 点击打开按钮触发打开代理
        private void btnOn_Click(object sender, EventArgs e)
        {
            openProxy();
        }

        // 点击关闭按钮触发关闭代理
        private void btnOff_Click(object sender, EventArgs e)
        {
            closeProxy();
        }

        // 点击托盘菜单中的操作按钮的动作
        private void 操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isProxyOn)
            {
                closeProxy();
            }
            else
            {
                openProxy();
            }
        }
    }
}
