namespace sshproxy
{
    partial class mainForm
    {
        private const string Prog = "SSH Proxy";

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.strayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblAt = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lblComma = new System.Windows.Forms.Label();
            this.btnOn = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbLocalPort = new System.Windows.Forms.TextBox();
            this.lblArray = new System.Windows.Forms.Label();
            this.strayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.strayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = Prog;
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // strayMenu
            // 
            this.strayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.状态ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.退出ToolStripMenuItem1});
            this.strayMenu.Name = "strayMenu";
            this.strayMenu.Size = new System.Drawing.Size(131, 70);
            // 
            // 状态ToolStripMenuItem
            // 
            this.状态ToolStripMenuItem.Enabled = false;
            this.状态ToolStripMenuItem.Name = "状态ToolStripMenuItem";
            this.状态ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.状态ToolStripMenuItem.Text = "状态：Off";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.操作ToolStripMenuItem.Text = "打开";
            this.操作ToolStripMenuItem.Click += new System.EventHandler(this.操作ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.退出ToolStripMenuItem1.Text = "退出";
            this.退出ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem1_Click);
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(34, 43);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(108, 21);
            this.tbUser.TabIndex = 1;
            this.tbUser.Text = "user";
            this.tbUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbUser.TextChanged += new System.EventHandler(this.tbUser_TextChanged);
            // 
            // lblAt
            // 
            this.lblAt.AutoSize = true;
            this.lblAt.Location = new System.Drawing.Point(158, 47);
            this.lblAt.Name = "lblAt";
            this.lblAt.Size = new System.Drawing.Size(11, 12);
            this.lblAt.TabIndex = 2;
            this.lblAt.Text = "@";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(175, 43);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(119, 21);
            this.tbHost.TabIndex = 3;
            this.tbHost.Text = "host";
            this.tbHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHost.TextChanged += new System.EventHandler(this.tbHost_TextChanged);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(326, 43);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(34, 21);
            this.tbPort.TabIndex = 4;
            this.tbPort.Text = "22";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
            // 
            // lblComma
            // 
            this.lblComma.AutoSize = true;
            this.lblComma.Location = new System.Drawing.Point(300, 47);
            this.lblComma.Name = "lblComma";
            this.lblComma.Size = new System.Drawing.Size(11, 12);
            this.lblComma.TabIndex = 5;
            this.lblComma.Text = ":";
            // 
            // btnOn
            // 
            this.btnOn.Location = new System.Drawing.Point(438, 43);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(51, 23);
            this.btnOn.TabIndex = 6;
            this.btnOn.Text = "On";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // btnOff
            // 
            this.btnOff.Enabled = false;
            this.btnOff.Location = new System.Drawing.Point(495, 43);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(56, 23);
            this.btnOff.TabIndex = 7;
            this.btnOff.Text = "Off";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 103);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(469, 169);
            this.textBox1.TabIndex = 8;
            // 
            // tbLocalPort
            // 
            this.tbLocalPort.Location = new System.Drawing.Point(389, 44);
            this.tbLocalPort.Name = "tbLocalPort";
            this.tbLocalPort.Size = new System.Drawing.Size(43, 21);
            this.tbLocalPort.TabIndex = 9;
            this.tbLocalPort.Text = "7070";
            this.tbLocalPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLocalPort.TextChanged += new System.EventHandler(this.tbLocalPort_TextChanged);
            // 
            // lblArray
            // 
            this.lblArray.AutoSize = true;
            this.lblArray.Location = new System.Drawing.Point(366, 48);
            this.lblArray.Name = "lblArray";
            this.lblArray.Size = new System.Drawing.Size(17, 12);
            this.lblArray.TabIndex = 10;
            this.lblArray.Text = "->";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 300);
            this.Controls.Add(this.lblArray);
            this.Controls.Add(this.tbLocalPort);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnOff);
            this.Controls.Add(this.btnOn);
            this.Controls.Add(this.lblComma);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.lblAt);
            this.Controls.Add(this.tbUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = Prog;
            this.FormClosing += this.MainForm_FormClosing;
            this.Resize += this.MainForm_Resize;
            this.Load += new System.EventHandler(this.mainForm_Load);
            
            this.strayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip strayMenu;
        private System.Windows.Forms.ToolStripMenuItem 状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label lblAt;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lblComma;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbLocalPort;
        private System.Windows.Forms.Label lblArray;
    }
}

