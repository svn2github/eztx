using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;
using System.Xml;

namespace _3d
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private zst z = null;
        private OutputForm otForm = null;

        /// <summary>
        /// 设置期号为最新一期
        /// </summary>
        /// <returns></returns>
        private string setIssueNew()
        {
            bool isTrue = true;
            DataTable dt = LinkMyMDB.operatingQuery("select * from numberGroup order by id desc", ref isTrue);
            if (isTrue == false || dt == null || dt.Rows.Count == 0)
            {
                return "";
            }

            return Convert.ToInt64(dt.Rows[0]["issue"].ToString()) + 1 + "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (!Global.user_vali.Equals("2"))
            {
                linkLabel3.Visible = true;
            }

            this.comboBox1.SelectedIndex = 0;

            //页面控件文字颜色
            foreach (Control ctl in this.Controls)
            {
                if (ctl is GroupBox)
                {
                    ctl.ForeColor = Color.DarkBlue;
                    foreach (Control ckb in ctl.Controls)
                    {
                        if (ckb is CheckBox || ckb is Label || ckb is TextBox || ckb is Button)
                        {
                            ckb.ForeColor = Color.Black;
                        }
                        if (ckb is GroupBox)
                        {
                            ckb.ForeColor = Color.DarkBlue;
                            foreach (Control ckbb in ckb.Controls)
                            {
                                if (ckbb is CheckBox || ckbb is RadioButton)
                                {
                                    ckbb.ForeColor = Color.Black;
                                }
                            }
                        }
                    }
                }
            }

            this.issueTxt.Text = setIssueNew();
        }

        /// <summary>
        /// 计算字符串中子串出现的次数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="substring">子串</param>
        /// <returns>出现的次数</returns>
        static int SubstringCount(string str, string substring)
        {
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }

            return 0;
        }

        //设置全局每组数之间使用的分隔符
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string txt = this.comboBox1.Text;
            if (txt.Equals("空格"))
            {
                txt = " ";
            }
            if (txt.Equals("中文逗号，"))
            {
                txt = "，";
            }
            if (txt.Equals("英文逗号,"))
            {
                txt = ",";
            }
            if (txt.Equals("中文分号；"))
            {
                txt = "；";
            }
            if (txt.Equals("英文分号;"))
            {
                txt = ";";
            }
            Global.splitRegex = txt;
        }

        #region 按钮点击、标签

        //两位数生成按钮click事件
        private void liangWeiShuGenerateBtn_Click(object sender, EventArgs e)
        {
            if (otForm == null || otForm.IsDisposed)//判断窗口是否打开
            {
                otForm = new OutputForm();
            }
            liangWeiShuGenerate();
        }

        //插入号码组按钮click事件
        private void numGroupBtn_Click(object sender, EventArgs e)
        {
            int txtLength = this.numGroupTxt.Text.Trim().Length;
            if (txtLength == 0 || txtLength < 3)
            {
                this.numGroupTxt.Focus();
                return;
            }

            addNumGroupToMDB();
        }

        //两码差中“生成”按钮点击事件
        private void liangMaChaGenerateBtn_Click(object sender, EventArgs e)
        {

            if (otForm == null || otForm.IsDisposed)//判断窗口是否打开
            {
                otForm = new OutputForm();
            }

            liangMaChaGenerate();
        }


        //软件走势图 开始
        private void zstBtn_Click(object sender, EventArgs e)
        {
            if (z == null || z.IsDisposed)//判断窗口是否打开
            {
                z = new zst();
            }
            z.Show();
        }
        //软件走势图 结束

        //“密码修改”链接标签 开始
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ModifyPasswordPanel));
            t.IsBackground = true;
            t.Start();
        }

        private void ModifyPasswordPanel()
        {
            ModifyPass mp = new ModifyPass();
            mp.ShowDialog();
        }
        //“密码修改”链接标签 结束

        //“信息修改”链接标签 开始
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ModifyInfoPanel));
            t.IsBackground = true;
            t.Start();
        }

        private void ModifyInfoPanel()
        {
            ModifyInfo mi = new ModifyInfo();
            mi.ShowDialog();
        }
        //“信息修改”链接标签 结束

        //“用户信息”链接标签 开始
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(adminPanel));
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
        }

        private AdminCtrl ac = null;//超级管理员面板
        private AdminCtrlProvince acer = null;//省代面板
        private AdminCtrlCity acera = null;//市代面板
        private AdminCtrlArea aarea = null;//区域代理面板
        private void adminPanel()
        {
            if (Global.user_vali.Equals("1"))
            {
                if (ac == null || ac.IsDisposed)
                {
                    ac = new AdminCtrl();
                    ac.ShowDialog();
                }
            }
            if (Global.user_vali.Equals("3"))
            {
                if (acer == null || acer.IsDisposed)
                {
                    acer = new AdminCtrlProvince();
                    acer.ShowDialog();
                }
            }
            if (Global.user_vali.Equals("4"))
            {
                if (acera == null || acera.IsDisposed)
                {
                    acera = new AdminCtrlCity();
                    acera.ShowDialog();
                }
            }
            if (Global.user_vali.Equals("5"))
            {
                if (aarea == null || aarea.IsDisposed)
                {
                    aarea = new AdminCtrlArea();
                    aarea.ShowDialog();
                }
            }
        }
        //“用户信息”链接标签 结束

        //两码差清空按钮
        private void liangMaChaClearBtn_Click(object sender, EventArgs e)
        {
            foreach (Control ctls in this.liangMaChaGpb.Controls)
            {
                if (ctls is CheckBox)
                {
                    (ctls as CheckBox).Checked = false;
                }
            }
        }

        #endregion

        #region Groupbox重绘

        //添加号码组gpb
        private void addNumGroupGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(addNumGroupGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(addNumGroupGpb.Text, addNumGroupGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(addNumGroupGpb.Text, addNumGroupGpb.Font).Width + 8, 7, addNumGroupGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, addNumGroupGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, addNumGroupGpb.Height - 2, addNumGroupGpb.Width - 2, addNumGroupGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, addNumGroupGpb.Width - 2, 7, addNumGroupGpb.Width - 2, addNumGroupGpb.Height - 2);//右边那条竖线
        }

        //两码差gpb
        private void liangMaChaGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(liangMaChaGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(liangMaChaGpb.Text, liangMaChaGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(liangMaChaGpb.Text, liangMaChaGpb.Font).Width + 8, 7, liangMaChaGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, liangMaChaGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, liangMaChaGpb.Height - 2, liangMaChaGpb.Width - 2, liangMaChaGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, liangMaChaGpb.Width - 2, 7, liangMaChaGpb.Width - 2, liangMaChaGpb.Height - 2);//右边那条竖线
        }

        //其他选项gpb
        private void otherOptionGpb_Paint(object sender, PaintEventArgs e)//otherOptionGpb
        {
            e.Graphics.Clear(otherOptionGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(otherOptionGpb.Text, otherOptionGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(otherOptionGpb.Text, otherOptionGpb.Font).Width + 8, 7, otherOptionGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, otherOptionGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, otherOptionGpb.Height - 2, otherOptionGpb.Width - 2, otherOptionGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, otherOptionGpb.Width - 2, 7, otherOptionGpb.Width - 2, otherOptionGpb.Height - 2);//右边那条竖线
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(number1Gpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(number1Gpb.Text, number1Gpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(number1Gpb.Text, number1Gpb.Font).Width + 8, 7, number1Gpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, number1Gpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, number1Gpb.Height - 2, number1Gpb.Width - 2, number1Gpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, number1Gpb.Width - 2, 7, number1Gpb.Width - 2, number1Gpb.Height - 2);//右边那条竖线
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(number2Gpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(number2Gpb.Text, number2Gpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(number2Gpb.Text, number2Gpb.Font).Width + 8, 7, number2Gpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, number2Gpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, number2Gpb.Height - 2, number2Gpb.Width - 2, number2Gpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, number2Gpb.Width - 2, 7, number2Gpb.Width - 2, number2Gpb.Height - 2);//右边那条竖线
        }

        //两位数大Gpb
        private void liangWeiShuGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(liangWeiShuGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(liangWeiShuGpb.Text, liangWeiShuGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(liangWeiShuGpb.Text, liangWeiShuGpb.Font).Width + 8, 7, liangWeiShuGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, liangWeiShuGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, liangWeiShuGpb.Height - 2, liangWeiShuGpb.Width - 2, liangWeiShuGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, liangWeiShuGpb.Width - 2, 7, liangWeiShuGpb.Width - 2, liangWeiShuGpb.Height - 2);//右边那条竖线
        }

        #endregion

        //插入号码组文本框textchanged事件，功能：为了只能输入数字
        private void numGroupTxt_TextChanged(object sender, EventArgs e)
        {
            if (numGroupTxt.Text.Trim().Length > 0)
            {
                // 將 TextBox1.Text.Trim() 的中文字刪除
                for (int i = numGroupTxt.Text.Trim().Length - 1; i >= 0; i--)
                {
                    //只能输入
                    if (!System.Text.RegularExpressions.Regex.IsMatch(numGroupTxt.Text.Trim().Substring(i, 1), @"^[0-9]*$"))
                    {
                        numGroupTxt.Text = numGroupTxt.Text.Trim().Remove(i, 1);
                    }
                }
                numGroupTxt.SelectionStart = numGroupTxt.Text.Trim().Length;
            }
        }

        //插入期号文本框textchanged事件，功能：为了只能输入数字
        private void issueTxt_TextChanged(object sender, EventArgs e)
        {
            if (issueTxt.Text.Trim().Length > 0)
            {
                // 將 TextBox1.Text.Trim() 的中文字刪除
                for (int i = issueTxt.Text.Trim().Length - 1; i >= 0; i--)
                {
                    //只能输入
                    if (!System.Text.RegularExpressions.Regex.IsMatch(issueTxt.Text.Trim().Substring(i, 1), @"^[0-9]*$"))
                    {
                        issueTxt.Text = issueTxt.Text.Trim().Remove(i, 1);
                    }
                }
                issueTxt.SelectionStart = issueTxt.Text.Trim().Length;
            }
        }

        //将号码组插入到mdb数据库
        private void addNumGroupToMDB()
        {
            bool isTrue = true;
            DataTable dt = LinkMyMDB.ReadAllData("numberGroup", ref isTrue);
            string isscue = this.issueTxt.Text.Trim();
            string numGroup = this.numGroupTxt.Text.Trim();
            bool addOK = LinkMyMDB.insertData("numberGroup", isscue, numGroup);//是否添加成功

            if (addOK == false)
            {
                MessageBox.Show("添加失败");
                return;
            }
            this.issueTxt.Text = Convert.ToInt64(this.issueTxt.Text) + 1 + "";
            this.numGroupTxt.Text = "";
        }

        private string[] a = { "1", "2" };

        //两码差运算
        private void liangMaChaGenerate()
        {
            string checkedName = "";//拿到所有选中的checkbox的name
            string tempResult = "";//临时存储结果
            foreach (Control ctls in this.liangMaChaGpb.Controls)
            {
                if (ctls is CheckBox && (ctls as CheckBox).Checked)
                {
                    checkedName += ctls.Name + ",";
                }
            }

            if (checkedName.Length == 0)
            {
                return;
            }
            string[] checkedNames = checkedName.Split(',');

            //xml操作 开始
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.ResourceManager.GetObject("liangmacha") as string);//读取资源中的xml
            XmlNodeList nodes = doc.SelectSingleNode("//liangMaCha").ChildNodes;
            foreach (XmlElement node in nodes)
            {
                string node_id = node.Attributes["id"].Value;
                string node_text = node.InnerText.Trim();
                for (int i = 0; i < checkedNames.Length; i++)
                {
                    string _checkedName = checkedNames[i];
                    if (node_id.Equals(_checkedName))
                    {
                        tempResult += node_text + ",";
                    }
                }
            }
            tempResult = tempResult.Substring(0, tempResult.Length - 1);
            //xml操作 结束

            string[] resultSplit = tempResult.Split(',');
            List<string> result = new List<string>();
            for (int i = 0; i < resultSplit.Length; i++)
            {
                result.Add(resultSplit[i] + Global.splitRegex);//拼成最终list结果
            }
            result.Sort();

            generateData(result);
        }

        /// <summary>
        /// 最终生成
        /// </summary>
        /// <param name="li">传入List<string>结果</param>

        private void generateData(List<string> li)
        {
            string ans = "";
            for (int i = 0; i < li.Count(); i++)
            {
                ans += li[i];
            }
            ans = ans.Substring(0, ans.Length - 1);

            try { otForm.Text = "共计  " + li.Count + "   注 - 恩泽天下"; otForm.textBox1.Text = ans; }
            catch { otForm.Text = "出错"; otForm.textBox1.Text = "运算出错，请您检查您设置的条件！"; }
            otForm.Show();
        }

        //两位数运算
        private void liangWeiShuGenerate()
        {
            string num_1 = "";
            string num_2 = "";

            //拿第一个数字
            foreach (Control ctls in this.number1Gpb.Controls)
            {
                if ((ctls as RadioButton).Checked)
                {
                    num_1 = ctls.Text;
                }
            }

            //拿第二个数字
            foreach (Control ctls in this.number2Gpb.Controls)
            {
                if ((ctls as RadioButton).Checked)
                {
                    num_2 = ctls.Text;
                }
            }

            if (num_1.Length == 0 || num_2.Length == 0)
            {
                return;
            }
            List<string> result = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                result.Add(Tools.sort3D(num_1 + num_2 + i) + Global.splitRegex);
            }
            result.Sort();

            generateData(result);
        }

        //两位数中清空
        private void LiangWeiShuClearBtn_Click(object sender, EventArgs e)
        {
            foreach (Control ctls in this.number1Gpb.Controls) 
            {
                (ctls as RadioButton).Checked = false;
            }
            foreach (Control ctls in this.number2Gpb.Controls)
            {
                (ctls as RadioButton).Checked = false;
            }
        }
    }
}