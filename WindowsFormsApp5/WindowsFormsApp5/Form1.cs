using System;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        #region  Private variable
        private TcpClient cmdServer;
        private TcpClient dataServer;
        private NetworkStream cmdStrmWtr;
        private StreamReader cmdStrmRdr;
        private NetworkStream dataStrmWtr;
        private StreamReader dataStrmRdr;
        private String cmdData;
        private byte[] szData;
        private const String CRLF = "\r\n";
        #endregion


        #region  Private Functions

        /// <summary>
        /// 获取命令端口返回结果，并记录在lsb_status上
        /// </summary>
        private String getSatus()
        {

            String ret = cmdStrmRdr.ReadLine();
            lsb_status.Items.Add(ret);
            lsb_status.SelectedIndex = lsb_status.Items.Count - 1;
            return ret;
        }

        /// <summary>
        /// 进入被动模式，并初始化数据端口的输入输出流
        /// </summary>
        private void openDataPort()
        {
            string retstr;
            string[] retArray;
            int dataPort;

            // Start Passive Mode 
            cmdData = "PASV" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            retstr = this.getSatus();

            // Calculate data's port
            retArray = Regex.Split(retstr, ",");
            if (retArray[5][2] != ')') retstr = retArray[5].Substring(0, 3);
            else retstr = retArray[5].Substring(0, 2);
            dataPort = Convert.ToInt32(retArray[4]) * 256 + Convert.ToInt32(retstr);
            lsb_status.Items.Add("Get dataPort=" + dataPort);

            string IP = tb_IP.Text;

            //Connect to the dataPort
            //dataServer = new TcpClient(tb_IP.Text, dataPort);
            dataServer = new TcpClient(IP, dataPort);
            dataStrmRdr = new StreamReader(dataServer.GetStream());
            dataStrmWtr = dataServer.GetStream();
        }

        /// <summary>
        /// 断开数据端口的连接
        /// </summary>
        private void closeDataPort()
        {
            dataStrmRdr.Close();
            dataStrmWtr.Close();
            this.getSatus();

            cmdData = "ABOR" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.getSatus();

        }

        /// <summary>
        /// 获得/刷新 右侧的服务器文件列表
        /// </summary>
        private void freshFileBox_Right()
        {

            openDataPort();

            string absFilePath;

            //List
            cmdData = "LIST" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.getSatus();

            lsb_server.Items.Clear();
            while ((absFilePath = dataStrmRdr.ReadLine()) != null)
            {
                string type;
                string prefix;
                string[] temp = Regex.Split(absFilePath, " ");
                //string[] a = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                type = temp[0].Substring(0, 1);
                switch (type)
                {
                    case "d":
                        prefix = "[目录] ";
                        break;
                    case "-":
                        prefix = "[文件] ";
                        break;
                    case "l":
                        prefix="[连接] " ; // 符号链接
                        break;

                    case "b":
                        prefix = "[设备] ";
                        break;
                    case "c":
                        prefix = "[设备] ";
                        break;
                    default:
                        prefix = "[未知] ";
                        break;
                }
                    
                        

                lsb_server.Items.Add(prefix+temp[temp.Length - 1]);
            }

            closeDataPort();
        }

        #endregion



        public Form1()
        {
            InitializeComponent();
            int i = int.Parse(ConfigurationManager.AppSettings["able"]);
            if (i == 0)
            {
                //默认
                ConfigurationManager.AppSettings["local"] = Environment.CurrentDirectory;
                ConfigurationManager.AppSettings["able"] = "1";

            }
            

            //CpuMessage();
        }
        
        


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        
        
        #region  Button:  Connect & Disconnect

        private void btn_conn_Click(object sender, EventArgs e)
        {
            if (btn_conn.Text == "连接")
            {
                Cursor cr = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    cmdServer = new TcpClient(tb_IP.Text, Convert.ToInt32(tb_port.Text));
                    lsb_status.Items.Clear();
                    cmdStrmRdr = new StreamReader(cmdServer.GetStream());
                    cmdStrmWtr = cmdServer.GetStream();
                    this.getSatus();

                    string retstr;

                    //Login
                    cmdData = "USER " + tb_username.Text + CRLF;
                    szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                    cmdStrmWtr.Write(szData, 0, szData.Length);
                    this.getSatus();

                    cmdData = "PASS " + tb_password.Text + CRLF;
                    szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                    cmdStrmWtr.Write(szData, 0, szData.Length);
                    retstr = this.getSatus().Substring(0, 3);
                    if (Convert.ToInt32(retstr) == 530) throw new InvalidOperationException("帐号密码错误");

                    this.freshFileBox_Right();

                    lb_IP.Text = tb_IP.Text + ":";
                    btn_conn.Text = "断开";
                    //btn_upload.Enabled = true;
                    //btn_download.Enabled = true;
                }
                catch (InvalidOperationException err)
                {
                    lsb_status.Items.Add("ERROR: " + err.Message.ToString());
                }
                finally
                {
                    Cursor.Current = cr;
                }
            }
            else
            {
                Cursor cr = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                //Logout

                cmdData = "QUIT" + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                this.getSatus();


                cmdStrmWtr.Close();
                cmdStrmRdr.Close();

                lb_IP.Text = "";
                btn_conn.Text = "连接";                
                lsb_server.Items.Clear();

                Cursor.Current = cr;
            }
        }

        #endregion


        /// <summary>
        /// 进入服务器文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsb_server_MouseClick(object sender, MouseEventArgs e)
        {

            string retstr;
            string type;
            int index = lsb_server.IndexFromPoint(e.X, e.Y);
            lsb_server.SelectedIndex = index;
            if (lsb_server.SelectedIndex != -1)
            {
                MessageBox.Show(lsb_server.SelectedItem.ToString());

                type = lsb_server.SelectedItem.ToString().Substring(1, 2);
                if (type == "目录")
                {
                    cmdData = "CWD " + lsb_server.SelectedItem.ToString().Substring(5) + CRLF;
                    lb_IP.Text += "/" + lsb_server.SelectedItem.ToString().Substring(5);
                    szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                    cmdStrmWtr.Write(szData, 0, szData.Length);
                    retstr = this.getSatus();
                    lsb_status.Items.Add(retstr);
                    freshFileBox_Right();

                }

                else
                {
                    MessageBox.Show("目标不是目录，无法进入！");

                }
            }
            


        }


        /// <summary>
        /// 返回上级目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string pa = lb_IP.Text;
            string retstr;
            cmdData = "CWD .." + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            retstr = this.getSatus();
            lsb_status.Items.Add(retstr);
            freshFileBox_Right();
            lb_IP.Text = pa.Substring(0, pa.LastIndexOf("/"));


        }

        private void lsb_server_MouseUp(object sender, MouseEventArgs e)
        {


            if (e.Button == MouseButtons.Right)
            {
                lsb_server.SelectedIndex = lsb_server.IndexFromPoint(e.X, e.Y);
                
                
                string abc = lsb_server.SelectedItem.ToString();

                string type = abc.Substring(1, 2);
                if (type == "文件")
                {
                    contextMenuStrip1.Show(Control.MousePosition.X, Control.MousePosition.Y);
                }
                
            }
        }

        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //默认下载地址
            string path=ConfigurationManager.AppSettings["local"];
            
            if (path == "" || lsb_server.SelectedIndex < 0)
            {
                MessageBox.Show("请选择目标文件和下载路径", "ERROR");
                return;
            }
            
            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string fileName = Regex.Split(lsb_server.Items[lsb_server.SelectedIndex].ToString(), " ")[1];
            string filePath = path + "\\" + fileName;

            this.openDataPort();

            cmdData = "RETR " + fileName + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            cmdStrmWtr.Write(szData, 0, szData.Length);
            this.getSatus();

            FileStream fstrm = new FileStream(filePath,FileMode.OpenOrCreate);
            char[] fchars = new char[1030];
            byte[] fbytes = new byte[1030];
            int cnt = 0;
            while ((cnt = dataStrmWtr.Read(fbytes, 0, 1024)) > 0)
            {
                fstrm.Write(fbytes, 0, cnt);
            }
            fstrm.Close();

            this.closeDataPort();
            Cursor.Current = cr;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        #region 选择路径  -void txtPath_Click(object sender, EventArgs e)

        ///   <summary>
        ///  选择路径 
        ///   </summary>
        ///   <param name="sender"></param>
        ///   <param name="e"></param>
        private void txtPath_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fbd.SelectedPath;
            }
        }
        #endregion

        #region 获取指定目录子目录和子文件 -void btnGetPath_Click(object sender, EventArgs e)

        ///   <summary>
        ///  获取指定目录子目录和子文件
        ///   </summary>
        ///   <param name="sender"></param>
        ///   <param name="e"></param>
        private void btnGetPath_Click(object sender, EventArgs e)
        {
            tvDir.Nodes.Clear();
            if (txtPath.Text.Trim().Length == 0)
            {
                return;
            }
            else
            {
                LoadData(txtPath.Text, null);
                LoadFiles(txtPath.Text);
            }
        }

        #endregion

        #region 树控件节点点击之后触发  -void tvDir_AfterSelect(object sender, TreeViewEventArgs e)

        ///   <summary>
        ///  树控件节点点击之后触发
        ///   </summary>
        ///   <param name="sender"></param>
        ///   <param name="e"></param>
        private void tvDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 获取当前所选择的节点
            TreeNode node = this.tvDir.SelectedNode;
            if (node == null)  // 判断有没有选择某一个节点
            {
                return;
            }
            // 再将之前存储到Tag值的全路径取出来使用
            string path = node.Tag.ToString();
            LoadData(path, node);
            LoadFiles(path);
        }
        #endregion

        #region 加载树节点和listview控件的项  - void LoadData(string path, TreeNode parentNode)

        ///   <summary>
        ///  加载树节点和listview控件的项
        ///   </summary>
        ///   <param name="path"></param>
        ///   <param name="parentNode"></param>
        void LoadData(string path, TreeNode parentNode)
        {
            // tvDir.Nodes.Clear();
            if (path.Trim().Length == 0)
            {
                MessageBox.Show(" 路径为空 ");
                return;
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                DirectoryInfo[] dirs = dir.GetDirectories();
                // 将得到的目录生成为树节点添加给刚刚点击的节点对象
                foreach (DirectoryInfo d in dirs)
                {
                    TreeNode subNode = new TreeNode(d.Name);  // 目录名称
                    subNode.Tag = d.FullName;  // 全路径 
                                               // 任何一个节点都会有一个了节点集合
                    if (parentNode == null)  // 为null说明当前是为树的根节点添加
                    {
                        tvDir.Nodes.Add(subNode);
                    }
                    else
                    {
                        parentNode.Nodes.Add(subNode); 
                    }
                    // 加载一个目录，立刻来加载它的子目录
                    LoadData(subNode.Tag.ToString(), subNode);
                }
            }
        }
        #endregion

        #region 加载文件  ListView- void LoadFiles(string path)

        ///   <summary>
        ///  加载文件
        ///   </summary>
        ///   <param name="path"></param>
        void LoadFiles(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            this.tvDir.ExpandAll();
            this.lvList.Items.Clear();
            // 获取子文件
            FileInfo[] myFiles = dir.GetFiles();
            foreach (FileInfo f in myFiles)
            {
                ListViewItem lv = new ListViewItem(f.Name);
                lv.SubItems.AddRange(new string[] { f.Extension, (f.Length / 1024).ToString() + " KB ", f.FullName });
                lv.Tag = f.FullName;
                this.lvList.Items.Add(lv);
            }
        }


        #endregion

        /// <summary>
        /// 上传
        /// </summary>
        private void 上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            if (btn_conn.Text == "断开")
            {
                string fileName = lvList.SelectedItems[0].Text;
                string filePath = lvList.SelectedItems[0].SubItems[3].Text;

                this.openDataPort();

                cmdData = "STOR " + fileName + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                cmdStrmWtr.Write(szData, 0, szData.Length);
                this.getSatus();

                FileStream fstrm = new FileStream(filePath, FileMode.Open);
                byte[] fbytes = new byte[1030];
                int cnt = 0;
                while ((cnt = fstrm.Read(fbytes, 0, 1024)) > 0)
                {
                    dataStrmWtr.Write(fbytes, 0, cnt);
                }
                fstrm.Close();

                this.closeDataPort();

                this.freshFileBox_Right();
            }
            else
            {
                MessageBox.Show("请先连接！");
            }
            Cursor.Current = cr;

        }

        private void lvList_MouseUp(object sender, MouseEventArgs e)
        {

            //Object obj = lvList.SelectedIndices;


            if (e.Button == MouseButtons.Right&&lvList.SelectedIndices.Count!=0)
            {
                
                contextMenuStrip2.Show(Control.MousePosition.X, Control.MousePosition.Y);


            }
        }
    }
}
