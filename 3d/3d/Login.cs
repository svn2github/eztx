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
        
        Thread threadLogin = null;
        bool startThreadLogin = true;

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
        }

        /// <summary>
        /// 查找软件是否有更新
        /// </summary>
        private void findUpdate()
        {
            ServerVersion sv = new ServerVersion();
            string localVersion = Global.version;
            string serverVersion = sv.GetServerVersion();

            int verCha = Convert.ToInt32(serverVersion.Replace(".", "")) - Convert.ToInt32(localVersion.Replace(".", ""));

            if (verCha > 0)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("软件有更新，需要更新吗?", "软件更新", messButton);

                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    openUpdateExe();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

            tLabelMove = new System.Timers.Timer();
            tLabelMove.Interval = 100;
            tLabelMove.Elapsed += new System.Timers.ElapsedEventHandler(time1_Tick);
            tLabelMove.Enabled = true;

            this.label3.Text = "";
            this.label4.Text = "";
            this.pictureBox1.Width = this.Width;
            getLoadMsgT();//读取跑马灯信息
            EnableDoubleBuffering();//设定双缓冲
            userXML();//创建用户列表
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            savePass.Checked = false;

            this.textBox1.SelectedIndexChanged += new System.EventHandler(this.textBox1_SelectedIndexChanged);
            findUpdate();
        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valueMember = textBox1.SelectedValue.ToString().Trim();
            this.textBox2.Text = valueMember;
            if (valueMember.Length > 0)
            {
                savePass.Checked = true;
            }
            else
            {
                savePass.Checked = false;
            }
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

        /// <summary>
        /// 创建用户列表
        /// </summary>
        private void userXML()
        {
            string url = Application.StartupPath;

            if (File.Exists(url + "\\UserProfile.xml"))
            {
                XmlDocument d = new XmlDocument();
                d.Load(url + "\\UserProfile.xml");
                XmlNode xmlNode = d.SelectSingleNode("UserProfile");//得到根节点
                XmlNodeList nodelist = xmlNode.ChildNodes;//得到根节点的所有子节点

                DataTable data = new DataTable();
                data.Columns.Add("user_name");//要保存表里面的列
                data.Columns.Add("user_pass");//要保存表里面的列

                foreach (XmlNode item in nodelist)
                {
                    DataRow row = data.NewRow();
                    row["user_name"] = item.Attributes["user_name"].Value;//将xml里的所有子节点nodelist遍历出单个item，将每个item赋值给表里面的Name列
                    row["user_pass"] = item.Attributes["user_pass"].Value;
                    data.Rows.Add(row);
                }

                this.textBox1.DataSource = data;//数据源为刚建好的表
                this.textBox1.DisplayMember = "user_name";//设置显示名称为Name
                this.textBox1.ValueMember = "user_pass";//设置属性值为Code

                d.Save(url + "\\UserProfile.xml");
                return;
            }
            //如果没有文件那么创建
            Tools.writeFile(url + "\\UserProfile.xml", _3d.Properties.Resources.UserProfile);
        }

        #region 页面所有控件点击事件


        #region 用户名、密码登录

        private delegate void GetLoginNameDelegate();//代理

        //“登录”按钮点击
        private void button1_Click(object sender, EventArgs e)
        {
            threadLogin = new Thread(new ThreadStart(loginStartThreadSet));
            threadLogin.Name = "用户名登录中";
            threadLogin.Start();
        }

        /// <summary>
        /// 跨线程异步调用
        /// </summary>
        private void loginStartThreadSet()
        {
            GetLoginNameDelegate fc = new GetLoginNameDelegate(loginStart);
            //fc.BeginInvoke(null,null); //通过代理调用刷新方法
            this.Invoke(fc);
        }

        private void loginStart()
        {
            try
            {
                //用来终止登录线程
                while (startThreadLogin)
                {
                    setLoginResult("正在登录中...请稍后");
                    disabledControls();

                    string user_name = textBox1.Text.Trim();//textBox1.Text.Trim();
                    string user_pass = textBox2.Text.Trim();
                    if (loginValidate(user_name, user_pass) == true)
                    {
                        int res = LinkMySql.MySqlExcute("UPDATE " + Global.sqlUserTable +
                            " SET `online`='1',lastloginip='" + getIP.GetWebIP() + "',lastlogintime=now(),lastloginplace='" + getIP.GetWebCity() + "',soft_version='" + Global.version + "',onlinetime=now() " +
                            " where user_name='" + user_name + "'");

                        if (res == 0)
                        {
                            MessageBox.Show("登录失败，请检查网络连接或者稍后重试。", "友情提示");
                            return;
                        }

                        writeToUserXML(user_name, user_pass);//写入到用户配置文件
                        loginToMain();
                    }
                    enabledControls();
                    startThreadLogin = false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("登录失败，请检查网络连接或者稍后重试。", "友情提示");
                throw err;
            }
        }

        /// <summary>
        /// 写入到用户配置文件
        /// </summary>
        private void writeToUserXML(string uName, string uPass)
        {

            if (savePass.Checked == false)
            {
                uPass = "";
            }

            string url = Application.StartupPath;
            XmlDocument doc = new XmlDocument();
            doc.Load(url + "\\UserProfile.xml");
            XmlNodeList xnList = doc.SelectNodes("//user[@user_name='" + uName + "']");
            //MessageBox.Show(xnList.Count.ToString());//.Attributes["user_name"].Value
            if (xnList.Count > 0)
            {
                xnList[0].Attributes["user_pass"].Value = uPass;
            }
            else
            {
                XmlNode xmlNode = doc.SelectSingleNode("UserProfile");

                //创建节点（二级）
                XmlElement element1 = doc.CreateElement("user");
                element1.InnerText = uName;
                element1.SetAttribute("user_name", uName);
                element1.SetAttribute("user_pass", uPass);
                xmlNode.AppendChild(element1);
            }

            doc.Save(url + "\\UserProfile.xml");
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

            DataTable dt1 = LinkMySql.MySqlQuery("select * from " + Global.sqlUserTable + " where user_name='" + user_name + "' and isdel='1'");

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

            if (dr1["online"].Equals("1") || dr1["online"].Equals("2"))
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
            threadLogin.Name = "机器码登录";
            threadLogin.Start();
        }

        private void machineLoginStart()
        {
            try
            {
                //用来终止登录线程
                while (startThreadLogin)
                {
                    setLoginResult("正在登录中...请稍后");
                    disabledControls();
                    string d = mc.GetCpuID();
                    string g = mc.GetMacAddress();
                    string machinecode = d + g;
                    for (int i = 4; i < machinecode.Length; i += 5)
                    {
                        machinecode = machinecode.Insert(i, "-");
                    }

                    DataTable dt1 = LinkMySql.MySqlQuery("select * from " + Global.sqlUserTable + " where machinecode='" + machinecode + "' and registtime=(select min(registtime) from " + Global.sqlUserTable + " where machinecode='" + machinecode + "') and isdel='1'");

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
                            string mysql = "UPDATE " + Global.sqlUserTable +
                                " SET `online`='2',lastloginip='" + getIP.GetWebIP() + "',lastlogintime=now(),lastloginplace='" + getIP.GetWebCity() + "',soft_version='" + Global.version + "',onlinetime=now() " +
                                " where user_name='" + Global.user_name + "'";
                            int res = LinkMySql.MySqlExcute(mysql);
                            if (res == 0) {
                                setLoginResult("登录失败，请稍后重试！");
                                return;
                            }
                            //clearUserProfile();//清空用户配置文档
                            loginToMain();
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

                    enabledControls();
                    startThreadLogin = false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("登录失败，请检查网络连接或者稍后重试。", "友情提示");
                throw err;
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
            Application.Exit();
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

            //清空下拉列表
            this.textBox1.DataSource = null;//数据源为空
        }

        /// <summary>
        /// 清空配置文件
        /// </summary>
        private void clearUserProfile()
        {
            string url = Application.StartupPath + "\\UserProfile.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            XmlNodeList xnl = xmlDoc.SelectSingleNode("UserProfile").ChildNodes;
            XmlNode xn = xmlDoc.SelectSingleNode("UserProfile");
            xn.RemoveAll();
            xmlDoc.Save(url);
        }

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

        Thread tPMD = null;
        bool startTPMD = true;

        //跑马灯线程
        private void getLoadMsgT()
        {
            tPMD = new Thread(new ThreadStart(getLoadMsg));
            tPMD.Name = "跑马灯文字获取";
            tPMD.IsBackground = true;
            tPMD.Start();
        }

        //得到跑马灯文字信息
        private void getLoadMsg()
        {
            try
            {
                //用来外部终止跑马灯线程
                while (startTPMD)
                {
                    DataTable dt1 = LinkMySql.MySqlQuery("select * from msg");
                    DataRow dr1 = dt1.Rows[0];
                    setLabel5Text(dr1["msg_login"].ToString());
                    Global.main_msg = dr1["msg_main"].ToString();
                    startTPMD = false;
                }
            }
            catch
            {
                setLabel5Text("无法连接到服务器，请重新打开软件或者检查网络。");
            }
            finally {
                //启用相关控件
                enabledControls();
            }
        }

        private delegate void EnabledControls();

        private void enabledControls()
        {
            _ec(this.button1, new EnabledControls(_enabledLoginButton));
            _ec(this.button3, new EnabledControls(_enabledMachineLoginButton));
            _ec(this.button2, new EnabledControls(_enabledRegistButton));
            _ec(this.textBox1, new EnabledControls(_enabledUsernameTextbox));
            _ec(this.textBox2, new EnabledControls(_enabledPasswordTextbox));
            _ec(this.savePass, new EnabledControls(_enabledSavepassTextbox));
        }

        private void _ec(Control ctr,Delegate de)
        {
            if (ctr.IsHandleCreated)
            {
                ctr.Invoke(de);
            }
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        private void _enabledLoginButton()
        {
            _checkEnabled(this.button1);
        }

        /// <summary>
        /// 机器码登录按钮
        /// </summary>
        private void _enabledMachineLoginButton() {
            _checkEnabled(this.button3);
        }

        /// <summary>
        /// 申请按钮
        /// </summary>
        private void _enabledRegistButton()
        {
            _checkEnabled(this.button2);
        }

        /// <summary>
        /// 用户名输入框
        /// </summary>
        private void _enabledUsernameTextbox()
        {
            _checkEnabled(this.textBox1);
        }

        /// <summary>
        /// 密码输入框
        /// </summary>
        private void _enabledPasswordTextbox()
        {
            _checkEnabled(this.textBox2);
        }

        /// <summary>
        /// 保存密码选择框
        /// </summary>
        private void _enabledSavepassTextbox()
        {
            _checkEnabled(this.savePass);
        }

        private void _checkEnabled(Control ctr)
        {
            //启用登录和机器码登录按钮
            if (!string.IsNullOrEmpty(Global.main_msg))
            {
                ctr.Enabled = true;
            }
        }

        private delegate void DisabledControls();

        private void disabledControls()
        {
            _dc(this.button1, new DisabledControls(_disabledLoginButton));
            _dc(this.button3, new DisabledControls(_disabledMachineLoginButton));
            _dc(this.button2, new DisabledControls(_disabledRegistButton));
            _dc(this.textBox1, new DisabledControls(_disabledUsernameTextbox));
            _dc(this.textBox2, new DisabledControls(_disabledPasswordTextbox));
            _dc(this.savePass, new DisabledControls(_disabledSavepassTextbox));
        }

        private void _dc(Control ctr, Delegate de)
        {
            if (ctr.IsHandleCreated)
            {
                ctr.Invoke(de);
            }
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        private void _disabledLoginButton()
        {
            _checkDisabled(this.button1);
        }

        /// <summary>
        /// 机器码登录按钮
        /// </summary>
        private void _disabledMachineLoginButton()
        {
            _checkDisabled(this.button3);
        }

        /// <summary>
        /// 申请按钮
        /// </summary>
        private void _disabledRegistButton()
        {
            _checkDisabled(this.button2);
        }

        /// <summary>
        /// 用户名输入框
        /// </summary>
        private void _disabledUsernameTextbox()
        {
            _checkDisabled(this.textBox1);
        }

        /// <summary>
        /// 密码输入框
        /// </summary>
        private void _disabledPasswordTextbox()
        {
            _checkDisabled(this.textBox2);
        }

        /// <summary>
        /// 保存密码选择框
        /// </summary>
        private void _disabledSavepassTextbox()
        {
            _checkDisabled(this.savePass);
        }

        private void _checkDisabled(Control ctr)
        {
            //启用登录和机器码登录按钮
            if (Global.main_msg.Length != 0)
            {
                ctr.Enabled = false;
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

        #region 验证成功以后用来打开main界面  委托
        private void loginToMain()
        {
            setLoginToMain();
        }

        private delegate void WriteLoginToMainDelegate();

        private void setLoginToMain()
        {
            if (this.statusStrip1.IsHandleCreated)
            {
                this.statusStrip1.Invoke(new WriteLoginToMainDelegate(writeLoginToMain));
            }
        }

        private void writeLoginToMain()
        {
            tLabelMove.Close();//关闭跑马灯文字线程
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            savePass.Checked = false;
        }

    }
}