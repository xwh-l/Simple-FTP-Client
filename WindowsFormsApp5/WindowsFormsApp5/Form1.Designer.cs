namespace WindowsFormsApp5
{
    partial class Form1
    {
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lsb_server = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tvDir = new System.Windows.Forms.TreeView();
            this.lvList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_conn = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsb_status = new System.Windows.Forms.ListBox();
            this.lb_IP = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnGetPath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel1.Controls.Add(this.lsb_server);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 141);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(437, 462);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lsb_server
            // 
            this.lsb_server.FormattingEnabled = true;
            this.lsb_server.ItemHeight = 15;
            this.lsb_server.Location = new System.Drawing.Point(3, 3);
            this.lsb_server.Name = "lsb_server";
            this.lsb_server.Size = new System.Drawing.Size(434, 454);
            this.lsb_server.TabIndex = 0;
            this.lsb_server.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lsb_server_MouseClick);
            this.lsb_server.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lsb_server_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            // 
            // 下载ToolStripMenuItem
            // 
            this.下载ToolStripMenuItem.Name = "下载ToolStripMenuItem";
            this.下载ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.下载ToolStripMenuItem.Text = "下载";
            this.下载ToolStripMenuItem.Click += new System.EventHandler(this.下载ToolStripMenuItem_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel2.Controls.Add(this.tvDir);
            this.flowLayoutPanel2.Controls.Add(this.lvList);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(446, 140);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(599, 462);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // tvDir
            // 
            this.tvDir.Location = new System.Drawing.Point(3, 3);
            this.tvDir.Name = "tvDir";
            this.tvDir.Size = new System.Drawing.Size(301, 459);
            this.tvDir.TabIndex = 0;
            this.tvDir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDir_AfterSelect);
            // 
            // lvList
            // 
            this.lvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvList.GridLines = true;
            this.lvList.HideSelection = false;
            this.lvList.Location = new System.Drawing.Point(310, 3);
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(275, 455);
            this.lvList.TabIndex = 1;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.View = System.Windows.Forms.View.Details;
            this.lvList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvList_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "扩展名";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "文件大小";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "文件全路径";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_conn);
            this.panel1.Controls.Add(this.tb_password);
            this.panel1.Controls.Add(this.tb_username);
            this.panel1.Controls.Add(this.tb_port);
            this.panel1.Controls.Add(this.tb_IP);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 45);
            this.panel1.TabIndex = 2;
            // 
            // btn_conn
            // 
            this.btn_conn.Location = new System.Drawing.Point(903, 6);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(104, 34);
            this.btn_conn.TabIndex = 8;
            this.btn_conn.Text = "连接";
            this.btn_conn.UseVisualStyleBackColor = true;
            this.btn_conn.Click += new System.EventHandler(this.btn_conn_Click);
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(700, 13);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(151, 25);
            this.tb_password.TabIndex = 7;
            this.tb_password.Text = "123";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(500, 13);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(151, 25);
            this.tb_username.TabIndex = 6;
            this.tb_username.Text = "xwh";
            this.tb_username.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(285, 13);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(151, 25);
            this.tb_port.TabIndex = 5;
            this.tb_port.Text = "21";
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(85, 13);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(151, 25);
            this.tb_IP.TabIndex = 4;
            this.tb_IP.Text = "172.19.176.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(657, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTP地址";
            // 
            // lsb_status
            // 
            this.lsb_status.FormattingEnabled = true;
            this.lsb_status.ItemHeight = 15;
            this.lsb_status.Location = new System.Drawing.Point(-1, 648);
            this.lsb_status.Name = "lsb_status";
            this.lsb_status.Size = new System.Drawing.Size(1042, 79);
            this.lsb_status.TabIndex = 3;
            // 
            // lb_IP
            // 
            this.lb_IP.AutoSize = true;
            this.lb_IP.Location = new System.Drawing.Point(3, 119);
            this.lb_IP.Name = "lb_IP";
            this.lb_IP.Size = new System.Drawing.Size(0, 15);
            this.lb_IP.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "上级目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上传ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(109, 28);
            // 
            // 上传ToolStripMenuItem
            // 
            this.上传ToolStripMenuItem.Name = "上传ToolStripMenuItem";
            this.上传ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.上传ToolStripMenuItem.Text = "上传";
            this.上传ToolStripMenuItem.Click += new System.EventHandler(this.上传ToolStripMenuItem_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(492, 109);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(386, 25);
            this.txtPath.TabIndex = 6;
            this.txtPath.Click += new System.EventHandler(this.txtPath_Click);
            // 
            // btnGetPath
            // 
            this.btnGetPath.Location = new System.Drawing.Point(901, 101);
            this.btnGetPath.Name = "btnGetPath";
            this.btnGetPath.Size = new System.Drawing.Size(94, 32);
            this.btnGetPath.TabIndex = 7;
            this.btnGetPath.Text = "获取";
            this.btnGetPath.UseVisualStyleBackColor = true;
            this.btnGetPath.Click += new System.EventHandler(this.btnGetPath_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(389, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "本地文件目录";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 620);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "状态信息：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 757);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGetPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_IP);
            this.Controls.Add(this.lsb_status);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "FTP_Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_conn;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TreeView tvDir;
        private System.Windows.Forms.ListBox lsb_status;
        private System.Windows.Forms.ListBox lsb_server;
        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 下载ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 上传ToolStripMenuItem;
        private System.Windows.Forms.ListView lvList;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnGetPath;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

