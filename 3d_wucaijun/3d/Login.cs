using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
using _3d.Function;
using _3d.Others;
using System.Runtime.InteropServices;
using System.Threading;

namespace _3d
{
    public partial class Login : Form
    {
        MachineCode mc = new MachineCode();

        LinkMySql lms = new LinkMySql();

        Thread threadLogin;

        #region 防止控件或图像过多卡
        [DllImport("user32.dll")]
        static extern bool LockWindowUpdate(IntPtr hWndLock);

        private void Login_ResizeBegin(object sender, EventArgs e)
        {
            LockWindowUpdate(this.Handle);
        }

        private void Login_ResizeEnd(object sender, EventArgs e)
        {
            LockWindowUpdate(IntPtr.Zero);
        }

        //双缓冲
        public void EnableDoubleBuffering()
        {
            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);
            this.UpdateStyles();
        }
        #endregion


        public Login()
        {
            InitializeComponent();
            tLabelMove = new System.Timers.Timer();
            tLabelMove.Interval = 100;
            tLabelMove.Elapsed += new System.Timers.ElapsedEventHandler(time1_Tick);
            tLabelMove.Enabled = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.label3.Text = "";
            this.label4.Text = "";
            this.pictureBox1.Width = this.Width;
            loadCheckSavePass();//检查保存密码
            getLoadMsgT();//读取跑马灯信息
            EnableDoubleBuffering();//设定双缓冲
        }

        /// <summary>
        /// 实现无标题窗体点击任务栏图标正常最小化或还原
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | 0x20000;
                return cp;
            }
        }


        //读取“保存密码”的配置
        private void loadCheckSavePass()
        {
            string url = Application.StartupPath + "\\UserProfile.xml";
            if (File.Exists(url))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(url);
                XmlNode xmlNode = doc.SelectSingleNode("UserProfile/UserName");//得到根节点
                XmlNode xmlNode2 = doc.SelectSingleNode("UserProfile/UserPass");//得到根节点
                if (!string.IsNullOrEmpty(xmlNode.InnerText) && !string.IsNullOrEmpty(xmlNode2.InnerText))
                {
                    textBox1.Text = xmlNode.InnerText;
                    textBox2.Text = xmlNode2.InnerText;
                    this.savePass.Checked = true;
                }
            }
        }

        #region 页面所有控件点击事件


        #region 用户名、密码登录
        //“登录”按钮点击
        private void button1_Click(object sender, EventArgs e)
        {
            threadLogin = new Thread(new ThreadStart(loginStart));
            threadLogin.Name = "loginStartThread";
            threadLogin.Start();
        }

        private void loginStart()
        {
            setLoginResult("正在登录中...请稍后");

            string user_name = textBox1.Text.Trim();
            string user_pass = textBox2.Text.Trim();

            try
            {
                if (loginValidate(user_name, user_pass) == true)
                {
                    lms.conn("UPDATE "+Global.sqlUserTable+" SET `online`='1',lastloginip='" + getIP.GetWebIP() + "',lastlogintime=now(),lastloginplace='" + getIP.GetWebCity() + "' where user_name='" + user_name + "'");

                    string url = Application.StartupPath;
                    if (savePass.Checked == true)
                    {
                        if (!File.Exists(url + "\\UserProfile.xml"))
                        {
                            XmlDocument doc = new XmlDocument();
                            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);

                            doc.AppendChild(dec);
                            //创建一个根节点（一级）
                            //创建节点（二级）
                            XmlNode node = doc.CreateElement("UserProfile");
                            //创建节点（三级）
                            XmlElement element1 = doc.CreateElement("UserName");
                            element1.InnerText = user_name;
                            node.AppendChild(element1);

                            XmlElement element2 = doc.CreateElement("UserPass");
                            element2.InnerText = user_pass;
                            node.AppendChild(element2);
                            doc.AppendChild(node);

                            doc.Save(url + "\\UserProfile.xml");
                        }

                        if (File.Exists(url + "\\UserProfile.xml"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(url + "\\UserProfile.xml");
                            XmlNode xmlNode = doc.SelectSingleNode("UserProfile/UserName");//得到根节点
                            XmlNode xmlNode2 = doc.SelectSingleNode("UserProfile/UserPass");//得到根节点
                            xmlNode.InnerText = user_name;
                            xmlNode2.InnerText = user_pass;
                            doc.Save(url + "\\UserProfile.xml");
                        }
                    }

                    while (Global.main_msg.Length > 0)//确保main界面上方滚动条的文字已经读入
                    {
                        this.DialogResult = DialogResult.OK;
                        break;
                    }
                }

            }
            catch
            {
                MessageBox.Show("登录失败，请检查网络连接或者稍后重试，如果还不可以请联系管理员。", "友情提示");
            }
        }

        //点击“登录”按钮以后的文本框输入验证操作
        private Boolean loginValidate(string user_name, string user_pass)
        {
            ToMD5 md5 = new ToMD5();

            if (string.IsNullOrEmpty(user_name))
            {
                setLabel3Text("请输入用户名！");
                setLoginResult("请输入用户名！");
                return false;
            }
            if (string.IsNullOrEmpty(user_pass))
            {
                setLabel4Text("请输入密码！");
                setLoginResult("请输入密码！");
                return false;
            }
            user_pass = md5.Encrypt(user_pass);

            DataSet ds1 = lms.conn("select * from "+Global.sqlUserTable+" where user_name='" + user_name + "' and isdel='1'");
            DataTable dt1 = ds1.Tables[0];

            if (dt1 == null || dt1.Rows.Count == 0)//如果没有返回来数据，证明用户名错了
            {
                setLabel3Text("用户名错误或者该用户未找到，请检查！");
                setLoginResult("用户名错误或者该用户未找到，请检查！");
                return false;
            }

            setLabel3Text("");
            DataRow dr1 = dt1.Rows[0];
            if (!dr1["user_pass"].Equals(user_pass))
            {
                setLabel4Text("密码不正确，请检查！");
                setLoginResult("密码不正确，请检查！");
                return false;

            }

            setLabel4Text("");
            if (dr1["allowlogin"].Equals("0"))
            {
                setLabel3Text("您没有使用权限！");
                setLoginResult("您没有使用权限！");
                return false;
            }

            if (dr1["online"].Equals("1"))
            {
                setLabel3Text("该账号已在别处登录！");
                setLoginResult("该账号已在别处登录！");
                return false;
            }

            Global.user_name = dr1["user_name"].ToString();
            Global.user_realname = dr1["user_realname"].ToString();
            Global.user_province = dr1["user_province"].ToString();
            Global.user_vali = dr1["user_vali"].ToString();
            Global.allowlogin = dr1["allowlogin"].ToString();
            Global.loginType = "1";
            return true;
        }

        #endregion

        #region 机器码登录

        //“机器码登录”按钮点击
        private void button3_Click(object sender, EventArgs e)
        {
            threadLogin = new Thread(new ThreadStart(machineLoginStart));
            threadLogin.Name = "machineLoginStartThread";
            threadLogin.Start();
        }

        private void machineLoginStart()
        {
            setLoginResult("正在登录中...请稍后");
            string d = mc.GetCpuID();
            string g = mc.GetMacAddress();
            string machinecode = d + g;
            for (int i = 4; i < machinecode.Length; i += 5)
            {
                machinecode = machinecode.Insert(i, "-");
            }

            DataSet ds1 = lms.conn("select * from "+Global.sqlUserTable+" where machinecode='" + machinecode + "'and registtime=(select min(registtime) from "+Global.sqlUserTable+" where machinecode='" + machinecode + "') and isdel='1'");
            DataTable dt1 = ds1.Tables[0];

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                DataRow dr1 = dt1.Rows[0];
                Global.user_name = dr1["user_name"].ToString();
                Global.user_realname = dr1["user_realname"].ToString();
                Global.user_province = dr1["user_province"].ToString();
                Global.user_vali = dr1["user_vali"].ToString();
                Global.allowlogin = dr1["allowlogin"].ToString();
                Global.loginType = "2";

                if (dr1["allowlogin"].ToString().Equals("1"))
                {
                    string mysql = "UPDATE "+Global.sqlUserTable+" SET `online`='2',lastloginip='" + getIP.GetWebIP() + "',lastlogintime=now(),lastloginplace='" + getIP.GetWebCity() + "' where user_name='" + Global.user_name + "'";
                    lms.conn(mysql);
                    clearUserProfile();

                    while (Global.main_msg.Length > 0)//确保main界面上方滚动条的文字已经读入
                    {
                        this.DialogResult = DialogResult.OK;
                        break;
                    }
                }
                else
                {
                    setLoginResult("您没有使用权限！");
                }
            }
            else
            {
                setLoginResult("请您进行申请，并由管理员为您开通以后再进行此项操作。");
            }
        }

        #endregion

        #region 写label3，label4，label5控件委托

        private delegate void WriteLabelText(string args);

        private void setLabel3Text(string args)
        {
            if (this.IsHandleCreated)
            {
                this.label3.Invoke(new WriteLabelText(writeLabel3Text), args);
            }
        }

        private void writeLabel3Text(string args)
        {
            this.label3.Text = args;
        }

        private void setLabel4Text(string args)
        {
            if (this.IsHandleCreated)
            {
                this.label4.Invoke(new WriteLabelText(writeLabel4Text), args);
            }
        }

        private void writeLabel4Text(string args)
        {
            this.label4.Text = args;
        }

        private void setLabel5Text(string args)
        {
            if (this.IsHandleCreated)
            {
                this.label5.Invoke(new WriteLabelText(writeLabel5Text), args);
            }
        }

        private void writeLabel5Text(string args)
        {
            this.label5.Text = args;
        }

        #endregion

        #region “申请按钮”

        //“申请”按钮点击
        private void button2_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(registStart));
            t.Start();
        }

        private void registStart()
        {
            Regist reg = new Regist();
            reg.ShowDialog();
        }

        #endregion

        //关闭按钮
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //最小化按钮
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region 标题菜单点击“选项”下拉列表项目

        //标题菜单下拉的“软件更新”点击
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openUpdateExe();
        }

        private void openUpdateExe()
        {
            string path = System.Windows.Forms.Application.StartupPath;
            Process MyProcess = new Process();
            MyProcess.StartInfo.FileName = path + "\\AutoUpdate.exe";
            MyProcess.StartInfo.Verb = "Open";
            MyProcess.StartInfo.CreateNoWindow = true;
            MyProcess.Start();
            this.Close();
        }

        //标题菜单下拉的“获取机器码”点击
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //string a = mc.GetCpuInfo();
            string b = mc.GetHDid();
            //string c = mc.GetMoAddress();
            string d = mc.GetCpuID();
            //string ee = mc.GetHardDiskID();
            //string f = mc.GetHostName();
            string g = mc.GetMacAddress();
            string machinecode = d + g;
            for (int i = 4; i < machinecode.Length; i += 5)
                machinecode = machinecode.Insert(i, "-");

            Clipboard.SetText(machinecode);//复制到剪切板
            MessageBox.Show("本机机器码为：" + machinecode + "\t\r已经帮您复制，您可以直接在别处粘贴", "机器码", MessageBoxButtons.OK);
        }

        private void 清空登录信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearUserProfile();
        }

        private void clearUserProfile()
        {
            string url = Application.StartupPath + "\\UserProfile.xml";
            getSavePassCheck();
            if (File.Exists(url))
            {
                File.Delete(url);
            }
        }

        #region 保存密码取消委托
        private delegate void SavePassCheck();

        private void getSavePassCheck()
        {
            if (this.savePass.IsHandleCreated)
            {
                this.savePass.Invoke(new SavePassCheck(setSavePassCheck));
            }
        }

        private void setSavePassCheck()
        {
            this.savePass.Checked = false;
        }
        #endregion

        private void 常见问题解答ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAnswerForm();
        }

        private void openAnswerForm()
        {
            AnswerWebBrowser awb = new AnswerWebBrowser();
            awb.Show();
        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAboutSoftForm();
        }

        private void openAboutSoftForm()
        {
            AboutSoft ast = new AboutSoft();
            ast.Show();
        }

        #endregion

        #region 登录界面滚动文字

        System.Timers.Timer tLabelMove = null;//跑马灯文字

        //跑马灯线程
        private void getLoadMsgT()
        {
            Thread t = new Thread(new ThreadStart(getLoadMsg));
            t.Name = "getLoadMsgThread";
            t.IsBackground = true;
            t.Start();
        }

        //得到跑马灯文字信息
        private void getLoadMsg()
        {
            try
            {
                DataSet ds1 = lms.conn("select * from msg");
                DataTable dt1 = ds1.Tables[0];
                DataRow dr1 = dt1.Rows[0];
                setLabel5Text(dr1["msg_login"].ToString());
                Global.main_msg = dr1["msg_main"].ToString();
            }
            catch
            {
                setLabel5Text("无法连接到服务器，请检查网络或者稍后重试，如果还不可以请联系管理员。");
            }
        }

        private void time1_Tick(object sender, EventArgs e)
        {
            setRunWord();
        }

        private delegate void RunWordDelegate();

        private void setRunWord()
        {
            if (this.label5.IsHandleCreated)
            {
                this.label5.Invoke(new RunWordDelegate(runWord));
            }
        }

        private void runWord()
        {
            if (label5.Left > -label5.Width)
            {
                label5.Left -= 3;
            }
            else
            {
                label5.Left = this.Width;
            }
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            tLabelMove.Enabled = false;
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            tLabelMove.Enabled = false;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            tLabelMove.Enabled = true;
        }
        #endregion

        //用户名输入框变更事件
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox1.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$"))
                    {
                        textBox1.Text = textBox1.Text.Remove(i, 1);
                    }
                }
                textBox1.SelectionStart = textBox1.Text.Length;
            }
            setLabel3Text("");
        }

        //密码输入框变更事件
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            setLabel4Text("");
        }

        private void savePass_CheckedChanged(object sender, EventArgs e)
        {
            if (savePass.Checked == false)
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        #region 登录结果状态委托

        private delegate void WriteLoginResultDelegate(string args);

        private void setLoginResult(string args)
        {
            if (this.statusStrip1.IsHandleCreated)
            {
                this.statusStrip1.Invoke(new WriteLoginResultDelegate(writeLoginResult), args);
            }
        }

        private void writeLoginResult(string args)
        {
            this.toolStripStatusLabel1.Text = args;
        }

        #endregion

        #region 拖动窗体功能
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool ReleaseCapture();

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HTCAPTION = 2;
            if (e.Button == MouseButtons.Left)  // 按下的是鼠标左键
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero);    // 拖动窗体
            }
        }
        #endregion

        #region 附加隐藏功能

        //隐藏按钮
        private void pictureBox5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show(pictureBox5, 0, pictureBox5.Height);
        }

        //隐藏登录
        private void 用户名登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threadLogin = new Thread(new ThreadStart(hideLoginStart));
            threadLogin.Name = "hideLoginStartThread";
            threadLogin.Start();
        }

        private void hideLoginStart()
        {
            setLoginResult("正在登录中...请稍后");
            string user_name = textBox1.Text.Trim();
            string user_pass = textBox2.Text.Trim();

            try
            {
                if (lValidate(user_name, user_pass) == true)
                {
                    lms.conn("UPDATE "+Global.sqlUserTable+" SET `online`='1',lastloginip='" + getIP.GetWebIP() + "',lastlogintime=now(),lastloginplace='" + getIP.GetWebCity() + "' where user_name='" + user_name + "'");

                    string UserName = textBox1.Text;
                    string UserPass = textBox2.Text;
                    string url = Application.StartupPath;
                    if (savePass.Checked == true)
                    {
                        if (!File.Exists(url + "\\UserProfile.xml"))
                        {
                            XmlDocument doc = new XmlDocument();
                            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);

                            doc.AppendChild(dec);
                            //创建一个根节点（一级）
                            //创建节点（二级）
                            XmlNode node = doc.CreateElement("UserProfile");
                            //创建节点（三级）
                            XmlElement element1 = doc.CreateElement("UserName");
                            element1.InnerText = UserName;
                            node.AppendChild(element1);

                            XmlElement element2 = doc.CreateElement("UserPass");
                            element2.InnerText = UserPass;
                            node.AppendChild(element2);
                            doc.AppendChild(node);

                            doc.Save(url + "\\UserProfile.xml");
                        }

                        if (File.Exists(url + "\\UserProfile.xml"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(url + "\\UserProfile.xml");
                            XmlNode xmlNode = doc.SelectSingleNode("UserProfile/UserName");//得到根节点
                            XmlNode xmlNode2 = doc.SelectSingleNode("UserProfile/UserPass");//得到根节点
                            xmlNode.InnerText = UserName;
                            xmlNode2.InnerText = UserPass;
                            doc.Save(url + "\\UserProfile.xml");
                        }
                    }

                    while (Global.main_msg.Length > 0)//确保main界面上方滚动条的文字已经读入
                    {
                        this.DialogResult = DialogResult.OK;
                        break;
                    }
                }

            }
            catch
            {
                MessageBox.Show("登录失败，请检查网络连接以后重试。", "友情提示");
            }
        }

        //点击“用户名登录”按钮以后的文本框输入验证操作
        private Boolean lValidate(string user_name, string user_pass)
        {
            ToMD5 md5 = new ToMD5();

            if (string.IsNullOrEmpty(user_name))
            {
                setLabel3Text("请输入用户名！");
                setLoginResult("请输入用户名！");
                return false;
            }


            if (string.IsNullOrEmpty(user_pass))
            {
                setLabel4Text("请输入密码！");
                setLoginResult("请输入密码！");
                return false;
            }

            DataSet ds1 = lms.conn("select * from "+Global.sqlUserTable+" where user_name='" + user_name + "' and isdel='1'");
            DataTable dt1 = ds1.Tables[0];

            if (dt1 == null || dt1.Rows.Count == 0)
            {
                setLabel3Text("用户名不正确，请检查！");
                setLoginResult("用户名不正确，请检查！");
                return false;
            }

            setLabel3Text("");
            DataRow dr1 = dt1.Rows[0];
            user_pass = md5.Encrypt(user_pass);
            if (!dr1["user_pass"].Equals(user_pass))
            {
                setLabel4Text("密码不正确，请检查！");
                setLoginResult("密码不正确，请检查！");
                return false;
            }

            setLabel4Text("");
            if (dr1["allowlogin"].Equals("0"))
            {
                MessageBox.Show("您没有使用权限！");
                setLoginResult("您没有使用权限！");
                return false;
            }

            Global.user_name = dr1["user_name"].ToString();
            Global.user_realname = dr1["user_realname"].ToString();
            Global.user_province = dr1["user_province"].ToString();
            Global.user_vali = dr1["user_vali"].ToString();
            Global.allowlogin = dr1["allowlogin"].ToString();
            return true;
        }

        #endregion

    }
}