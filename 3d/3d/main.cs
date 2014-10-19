using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _3d.Function;
using System.Runtime.InteropServices;

namespace _3d
{
    public partial class main : Form
    {
        Timer tLabelMove = null;
        Timer marqueeLabelMove = null;
        private Form1 f1 = new Form1();
        private Form3 f3 = new Form3();
        private Form4 f4 = new Form4();

        private one11xuan5 o11 = new one11xuan5();

        private OutputForm f2 = null;
        LinkMySql lms = new LinkMySql();

        Login l = new Login();

        #region Timer控件设置
        System.Windows.Forms.Timer t = new Timer();//Form标题栏文字
        //标题栏时间
        private void time_Tick(object sender, EventArgs e)
        {
            string us = "";//
            string ub = "";
            if (Global.user_province.IndexOf("省") >= 0)
            {
                us = Global.user_province.Substring(0, Global.user_province.IndexOf("省") + 1);
            }
            else
            {
                us = Global.user_province.Substring(0, Global.user_province.IndexOf("市") + 1);
            }

            if (Global.user_province.Contains("省") && Global.user_province.Contains("市"))
            {
                int us1 = 0;
                int us2 = 0;
                us1 = Global.user_province.IndexOf("省") + 1;
                us2 = Global.user_province.IndexOf("市") + 1;
                if (us2 > us1)
                {
                    ub = Global.user_province.Substring(us1, us2 - us1);
                }
            }

            string un = Global.user_realname;
            string uv = "尊敬的：";
            if (Global.user_vali.Equals("1"))
                uv = "尊贵的市场总监：";
            if (Global.user_vali.Equals("3"))
                uv = "尊贵的" + us + "代理：";
            if (Global.user_vali.Equals("4"))
                uv = "尊贵的" + ub + "代理：";
            if (Global.user_vali.Equals("5"))
                uv = "尊贵的区域代理：";
            if (un == null || un.Equals(""))
                un = "您";
            setFormText("恩泽天下 - 辅助运算软件 - 欢迎" + uv + un + "，系统现在时间：" + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
        }

        private delegate void WriteFormTextDelegate(string args);

        private void setFormText(string args)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(new WriteFormTextDelegate(writeFormText), args);
            }
        }

        private void writeFormText(string args)
        {
            this.Text = args;
        }

        #endregion

        #region 页面滚动文字

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label8.Left > -this.label8.Width)
            {
                label8.Left -= 3;
            }
            else
            {
                label8.Left = this.panel2.Width;
            }
        }

        private void marqueeTimer_Tick(object sender, EventArgs e)
        {
            if (marqueeLabel.Left > -this.marqueeLabel.Width)
            {
                marqueeLabel.Left -= 3;
            }
            else
            {
                marqueeLabel.Left = this.marqueePanel.Width;
            }
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            tLabelMove.Enabled = false;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            tLabelMove.Enabled = true;
        }

        private void label8_MouseMove(object sender, MouseEventArgs e)
        {
            tLabelMove.Enabled = false;
        }

        private void marqueeLabel_MouseHover(object sender, EventArgs e)
        {
            marqueeLabelMove.Enabled = false;
        }

        private void marqueeLabel_MouseLeave(object sender, EventArgs e)
        {
            marqueeLabelMove.Enabled = true;
        }

        private void marqueeLabel_MouseMove(object sender, MouseEventArgs e)
        {
            marqueeLabelMove.Enabled = false;
        }

        #endregion

        public main()
        {
            InitializeComponent();

            //设置时时彩及十一选五页面最上方的滚动文字
            tLabelMove = new Timer();
            tLabelMove.Interval = 100;
            tLabelMove.Tick += new EventHandler(timer2_Tick);
            tLabelMove.Enabled = true;
            marqueeLabelMove = new Timer();
            marqueeLabelMove.Interval = 100;
            marqueeLabelMove.Tick += new EventHandler(marqueeTimer_Tick);
            marqueeLabelMove.Enabled = true;

            //启用标题栏计时
            t.Tick += new EventHandler(time_Tick);
            t.Interval = 1000;//设置是执行一次（false）还是一直执行(true)； 
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；

            //启用内存回收
            timer3.Enabled = true;
            timer3.Interval = 5000;
            l.Close();

            //将tabpage隐藏
            customTabControl1.TabPages[1].Parent = null;

            //启动下线机制
            this.offlineUserTimer.Interval = 1800000;//30分钟 1800000
            this.offlineUserTimer.Enabled = true;
        }

        //时时彩“生成”按钮点击
        private void button1_Click(object sender, EventArgs e)
        {
            if (f2 == null || f2.IsDisposed)//判断窗口是否打开
            {
                f2 = new OutputForm();

            }

            if (f1.chuHaoGeShu() == true && f3.chuHaoGeShu() == true && f4.chuHaoGeShu() == true)
            {
                getData();
            }
        }

        //时时彩最终生成
        private void getData()
        {
            //将第二个页面f3与第一个页面f1的数据传递结合
            f3.getF1Data(f1.fenJieShi());//f1.fenJieShi()       f3.noLocHeExecute()

            //将第三个页面f4与第二个页面f3的数据传递结合
            f4.getF3Data(f3.sumZhi());
            string ans = "";
            string[] allNum = f4.pingHengZhiShu();
            for (int i = 0; i < allNum.Count(); i++)
            {
                ans += allNum[i];
            }
            //f2.Text = "共计  " + (ans.Length / 4).ToString() + "   注"; f2.textBox1.Text = ans.Substring(0, ans.Length - 1);

            try { f2.Text = "共计  " + (ans.Length / 4).ToString() + "   注,当前运算结果为 时时彩 - 3D - 排列三 - 快乐3 - 时时乐"; f2.textBox1.Text = ans.Substring(0, ans.Length - 1); }
            catch { f2.Text = "出错"; f2.textBox1.Text = "运算出错，请您检查您设置的条件！"; }
            f2.Show();
        }

        //“时时彩清空”按钮点击  
        private void button2_Click(object sender, EventArgs e)
        {
            f1.clearCheckbox();
            f3.clearCheckBox();
            f4.clearCheckBox();
        }

        //十一选五“生成”按钮点击
        private void computingButton_Click(object sender, EventArgs e)
        {
            if (f2 == null || f2.IsDisposed)//判断窗口是否打开
            {
                f2 = new OutputForm();
            }

            get11Data();
        }
        //十一选五按钮点击
        private void clearButton_Click(object sender, EventArgs e)
        {

        }
        //十一选五最终生成
        private void get11Data()
        {
            string res = o11.sendData();
            int countNum = res.Split('\n').Length;
            if (res == "")
            {
                countNum = 0;
                res = "运算出错，请您检查您设置的条件！";
            }
            try { f2.Text = "共计  " + countNum + "   注,当前运算结果为 十一选五"; f2.textBox1.Text = res; }
            catch { f2.Text = "出错"; f2.textBox1.Text = "运算出错，请您检查您设置的条件！"; }
            f2.Show();
        }

        //选取form页面的改变事件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (f1 != null)
                {
                    f1.FormBorderStyle = FormBorderStyle.None; // 无边框
                    f1.TopLevel = false; // 不是最顶层窗体
                    panel1.Controls.Add(f1);  // 添加到 Panel中
                    f3.Hide();
                    f4.Hide();
                    f1.Show();
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (f3 != null)
                {
                    f3.FormBorderStyle = FormBorderStyle.None; // 无边框
                    f3.TopLevel = false; // 不是最顶层窗体
                    panel1.Controls.Add(f3);  // 添加到 Panel中
                    f1.Hide();
                    f4.Hide();
                    f3.Show();
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                if (f4 != null)
                {
                    f4.FormBorderStyle = FormBorderStyle.None; // 无边框
                    f4.TopLevel = false; // 不是最顶层窗体
                    panel1.Controls.Add(f4);  // 添加到 Panel中
                    f1.Hide();
                    f3.Hide();
                    f4.Show();
                }
            }
            this.button1.Focus();
        }

        private void changeMainPanelCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changeMainPanelCbx.SelectedIndex == 0)
            {
                if (o11 != null)
                {
                    o11.FormBorderStyle = FormBorderStyle.None; // 无边框
                    o11.TopLevel = false; // 不是最顶层窗体
                    mainPanel.Controls.Add(o11);  // 添加到 Panel中
                    //f3.Hide();
                    //f4.Hide();
                    o11.Show();
                }
            }
        }

        //清内存
        private void timer3_Tick(object sender, EventArgs e)
        {
            ClearMemory.Clear();
        }

        private void main_Load(object sender, EventArgs e)
        {
            EnableDoubleBuffering();//启用双缓冲
            this.label8.Text = Global.main_msg;//获取时时彩界面跑马灯文字信息
            this.marqueeLabel.Text = Global.main_msg;//获取时时彩界面跑马灯文字信息
            this.comboBox1.SelectedIndex = 0;//将时时彩选项卡切到第一个页面
            this.changeMainPanelCbx.SelectedIndex = 0;//将十一选五选项卡切到第一个页面
        }

        #region 防止控件或图像过多卡

        [DllImport("user32.dll")]
        static extern bool LockWindowUpdate(IntPtr hWndLock);
        private void main_ResizeBegin(object sender, EventArgs e)
        {
            LockWindowUpdate(this.Handle);
        }

        private void main_ResizeEnd(object sender, EventArgs e)
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

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox1.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox1.Text, groupBox1.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox1.Text, groupBox1.Font).Width + 8, 7, groupBox1.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox1.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox1.Height - 2, groupBox1.Width - 2, groupBox1.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox1.Width - 2, 7, groupBox1.Width - 2, groupBox1.Height - 2);//右边那条竖线
        }

        #region Tab2页面的LinkLabel点击

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickMethod("iexplore.exe", "http://tool.cailele.com/zs/14_125.htm");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickMethod("iexplore.exe", "http://zst.cjcp.com.cn/cjwssc_3xing/view/ssc_aotu.php?lotteryType=ssc");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickMethod("iexplore.exe", "http://tool.cailele.com/zs/13_121.htm");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickMethod("iexplore.exe", "http://tool.cailele.com/zs/1_1.htm");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickMethod("iexplore.exe", "http://tool.cailele.com/zs/2_14.htm");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickMethod("iexplore.exe", "http://tool.cailele.com/zs/16_132.htm");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickMethod("iexplore.exe", "http://tool.cailele.com/zs/4_26.htm");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickMethod("iexplore.exe", "http://tool.cailele.com/zs/31_214.htm");
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickMethod("iexplore.exe", "http://www.eztx.cn");
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickMethod("iexplore.exe", "http://tool.cailele.com/zs/18_141.htm");
        }

        /// <summary>
        /// linkLabel点击方法
        /// </summary>
        /// <param name="startProgram"></param>
        /// <param name="url"></param>
        private void clickMethod(string startProgram, string url)
        {
            try
            {
                System.Diagnostics.Process.Start(startProgram, url);
            }
            catch {
                Clipboard.SetText(url);
                MessageBox.Show("打开网址失败，可能是您的IE浏览器存在问题，现已将网址复制，您可以直接打开浏览器粘贴进行浏览。");
            }
        }
        #endregion

        //启动下线机制
        private void offlineUserTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = lms.conn("select allowlogin,`online`,isdel from " + Global.sqlUserTable + " where user_name='" + Global.user_name + "'");
                DataTable tb = ds.Tables[0];
                if (tb != null && tb.Rows.Count > 0)
                {
                    DataRow dr = tb.Rows[0];
                    string allowlogin = dr["allowlogin"].ToString();
                    string online = dr["online"].ToString();
                    string isdel = dr["isdel"].ToString();

                    //如果是用户名密码登录但是发现数据库有机器码登录史，则下线
                    /*if ((online.Equals("2") && Global.loginType.Equals("1")))
                    {
                        MessageBox.Show("已使用机器码登录，软件即将关闭。");
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }*/

                    if (allowlogin.Equals("0")
                        ||
                        isdel.Equals("-1")
                        ||
                        online.Equals("0"))
                    {
                        MessageBox.Show("软件即将关闭，请联系管理员。");
                        this.Dispose();
                        this.Close();
                    }
                }
            }
            catch { 
            
            }
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //offline_User(sender,e);
        }

        /// <summary>
        /// 下线的时候写入数据库
        /// </summary>
        private void offline_User(object sender, FormClosingEventArgs e)
        {
            try
            {
                WebConnect wc = new WebConnect();
                string result = wc.sendStringMessage("http://eztx.cn/eztx/eztx_offline.php?username=" + Global.user_name + "");
                Application.Exit();
            }
            catch {
                MessageBox.Show("程序关闭时遇到问题，如果无法再次登录软件，请联系售后", "温馨提示");
            }
        }
     }
}
