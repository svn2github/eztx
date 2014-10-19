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

namespace _3d
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

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
                            if (ckb != linMaShaQuCbx)
                                ckb.ForeColor = Color.Black;
                        }
                        if (ckb is GroupBox)
                        {
                            ckb.ForeColor = Color.DarkBlue;
                            foreach (Control ckbb in ckb.Controls)
                            {
                                if (ckbb is CheckBox)
                                {
                                    ckbb.ForeColor = Color.Black;
                                }
                            }
                        }
                    }
                }
            }
        }

        //设置“胆码”区域的出号个数是否勾选
        public Boolean chuHaoGeShu()
        {
            string a = "", aa = "";
            foreach (Control ctl in this.groupBox2.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                    {
                        if (!ctl.Name.Contains("oneZu"))
                        {
                            a += ((ctl as CheckBox).Text);
                        }
                        if (ctl.Name.Contains("oneZu"))
                        {
                            aa += ((ctl as CheckBox).Text);
                        }
                    }
                }
            }

            string b = "", bb = "";
            foreach (Control ctl in this.groupBox9.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                    {
                        if (!ctl.Name.Contains("twoZu"))
                        {
                            b += ((ctl as CheckBox).Text);
                        }
                        if (ctl.Name.Contains("twoZu"))
                        {
                            bb += ((ctl as CheckBox).Text);
                        }
                    }
                }
            }

            string c = "", cc = "";
            foreach (Control ctl in this.groupBox10.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                    {
                        if (!ctl.Name.Contains("threeZu"))
                        {
                            c += ((ctl as CheckBox).Text);
                        }
                        if (ctl.Name.Contains("threeZu"))
                        {
                            cc += ((ctl as CheckBox).Text);
                        }
                    }
                }
            }

            string d = "", dd = "";
            foreach (Control ctl in this.groupBox11.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                    {
                        if (!ctl.Name.Contains("fourZu"))
                        {
                            d += ((ctl as CheckBox).Text);
                        }
                        if (ctl.Name.Contains("fourZu"))
                        {
                            dd += ((ctl as CheckBox).Text);
                        }
                    }
                }
            }

            //临码区
            string e = "";
            foreach (Control ctl in this.lmGpb.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        e += ((ctl as CheckBox).Text);
                }
            }

            string ee = "";
            foreach (Control ctl in this.groupBox19.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        ee += ((ctl as CheckBox).Text);
                }
            }

            if (a != "" && aa.Equals(""))
            {
                MessageBox.Show("请在您设置的一号号码组后面勾选上要出的个数", "温馨提示");
                return false;
            }
            else if (b != "" && bb.Equals(""))
            {
                MessageBox.Show("请在您设置的二号号码组后面勾选上要出的个数", "温馨提示");
                return false;
            }
            else if (c != "" && cc.Equals(""))
            {
                MessageBox.Show("请在您设置的三号号码组后面勾选上要出的个数", "温馨提示");
                return false;
            }
            else if (d != "" && dd.Equals(""))
            {
                MessageBox.Show("请在您设置的四号号码组后面勾选上要出的个数", "温馨提示");
                return false;
            }
            else if (e != "" && ee.Equals(""))
            {
                MessageBox.Show("临码区域设置完毕后\t\r请勾选“临码计算方式”区域中的“包含”或者“杀去”才能生效！", "温馨提示");
                return false;
            }
            else
            {
                return true;
            }
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

        #region 按钮点击、标签

        //出组合“清”按钮点击
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
        }

        //杀组合“清”按钮点击
        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        //杀期号“清”按钮点击
        private void button5_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
        }

        //临码区域“清”按钮点击
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.lmGpb.Controls)
            {
                if (ctl is CheckBox)
                {
                    (ctl as CheckBox).Checked = false;
                }
            }
        }

        //“密码修改”链接标签
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

        //“信息修改”链接标签
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

        //“用户信息”链接标签
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

        #endregion

        #region 主数据组

        #region 基础1000底

        string[] ttt()//1000注大底
        {
            string txt = Global.splitRegex;
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            for (int i = 0; i < 1000; i++)
            {
                string tmp = i.ToString("d3") + txt;
                result.Add(tmp);
            }
            return result.ToArray();
        }

        #endregion

        #region 杀码系列

        private string[] liTiShaMaBai()//杀立体百位
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string shaNum = "";

            foreach (Control ctl in this.groupBox4.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        shaNum += (ctl as CheckBox).Text;
                }
            }
            string[] allNum = ttt();
            if (shaNum.Equals(""))
            {
                result.AddRange(allNum);
            }
            if (shaNum != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (allNum[i].Substring(0, 1).IndexOfAny(shaNum.ToCharArray(0, shaNum.Length)) < 0)
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            return result.ToArray();
        }

        private string[] liTiShaMaShi()//杀立体十位
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string shaNum = "";

            foreach (Control ctl in this.groupBox6.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        shaNum += (ctl as CheckBox).Text;
                }
            }
            string[] allNum = liTiShaMaBai();
            if (shaNum.Equals(""))
            {
                result.AddRange(allNum);
            }
            if (shaNum != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (allNum[i].Substring(1, 1).IndexOfAny(shaNum.ToCharArray(0, shaNum.Length)) < 0)
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            return result.ToArray();
        }

        private string[] liTiShaMaGe()//杀立体个位
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string shaNum = "";

            foreach (Control ctl in this.groupBox5.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        shaNum += (ctl as CheckBox).Text;
                }
            }
            string[] allNum = liTiShaMaShi();
            if (shaNum.Equals(""))
            {
                result.AddRange(allNum);
            }
            if (shaNum != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (allNum[i].Substring(2, 1).IndexOfAny(shaNum.ToCharArray(0, shaNum.Length)) < 0)
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            return result.ToArray();
        }

        private string[] pingMianShaMa()//平面杀码
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string shaNum = "";

            foreach (Control ctl in this.groupBox1.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        shaNum += (ctl as CheckBox).Text;
                }
            }
            string[] allNum = liTiShaMaGe();
            if (shaNum.Equals(""))
            {
                result.AddRange(allNum);
            }
            if (shaNum != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (allNum[i].IndexOfAny(shaNum.ToCharArray(0, shaNum.Length)) < 0)
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            return result.ToArray();
        }

        #endregion

        #region 平面胆码系列

        private string[] pingMianBiChu1()//平面胆码组一
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            List<string> pingMianBiChu = new List<string>();
            List<string> pingMianBiChuGeShu = new List<string>();
            foreach (Control ctl in this.groupBox2.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                    {
                        if (!ctl.Name.Contains("oneZu"))
                        {
                            pingMianBiChu.Add((ctl as CheckBox).Text);
                        }
                        if (ctl.Name.Contains("oneZu"))
                        {
                            pingMianBiChuGeShu.Add((ctl as CheckBox).Text);
                        }
                    }
                }
            }

            List<string> allNum = new List<string>();
            allNum.AddRange(pingMianShaMa());
            result.AddRange(pingMianDanMaOutput(allNum, pingMianBiChu, pingMianBiChuGeShu));


            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] pingMianBiChu2()//平面胆码组二
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            List<string> pingMianBiChu = new List<string>();
            List<string> pingMianBiChuGeShu = new List<string>();
            foreach (Control ctl in this.groupBox9.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                    {
                        if (!ctl.Name.Contains("twoZu"))
                        {
                            pingMianBiChu.Add((ctl as CheckBox).Text);
                        }
                        if (ctl.Name.Contains("twoZu"))
                        {
                            pingMianBiChuGeShu.Add((ctl as CheckBox).Text);
                        }
                    }
                }
            }

            List<string> allNum = new List<string>();
            allNum.AddRange(pingMianBiChu1());
            result.AddRange(pingMianDanMaOutput(allNum, pingMianBiChu, pingMianBiChuGeShu));


            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] pingMianBiChu3()//平面胆码组三
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            List<string> pingMianBiChu = new List<string>();
            List<string> pingMianBiChuGeShu = new List<string>();
            foreach (Control ctl in this.groupBox10.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                    {
                        if (!ctl.Name.Contains("threeZu"))
                        {
                            pingMianBiChu.Add((ctl as CheckBox).Text);
                        }
                        if (ctl.Name.Contains("threeZu"))
                        {
                            pingMianBiChuGeShu.Add((ctl as CheckBox).Text);
                        }
                    }
                }
            }

            List<string> allNum = new List<string>();
            allNum.AddRange(pingMianBiChu2());
            result.AddRange(pingMianDanMaOutput(allNum, pingMianBiChu, pingMianBiChuGeShu));

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] pingMianBiChu4()//平面胆码组四
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            List<string> pingMianBiChu = new List<string>();
            List<string> pingMianBiChuGeShu = new List<string>();
            foreach (Control ctl in this.groupBox11.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                    {
                        if (!ctl.Name.Contains("fourZu"))
                        {
                            pingMianBiChu.Add((ctl as CheckBox).Text);
                        }
                        if (ctl.Name.Contains("fourZu"))
                        {
                            pingMianBiChuGeShu.Add((ctl as CheckBox).Text);
                        }
                    }
                }
            }

            List<string> allNum = new List<string>();
            allNum.AddRange(pingMianBiChu3());
            result.AddRange(pingMianDanMaOutput(allNum, pingMianBiChu, pingMianBiChuGeShu));

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        #region 平面胆码计算
        /// <summary>
        /// 平面胆码计算
        /// </summary>
        /// <param name="allNum"></param>
        /// <param name="pingMianBiChu"></param>
        /// <param name="pingMianBiChuGeShu"></param>
        /// <returns></returns>
        private List<string> pingMianDanMaOutput(List<string> allNum, List<string> pingMianBiChu, List<string> pingMianBiChuGeShu)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();

            if (pingMianBiChu.Count == 0)
            {
                result.AddRange(allNum);
            }
            if (pingMianBiChu.Count == 1)
            {
                for (int i = 0; i < pingMianBiChu.Count; i++)
                {
                    for (int j = 0; j < pingMianBiChuGeShu.Count; j++)
                    {
                        for (int k = 0; k < allNum.Count(); k++)
                        {
                            if (SubstringCount(allNum[k], pingMianBiChu[i]) == Convert.ToInt16(pingMianBiChuGeShu[j]))
                            {
                                result.Add(allNum[k]);
                            }
                        }
                    }
                }
            }
            #region 平面必出选数多余1个
            if (pingMianBiChu.Count > 1)
            {
                string ppm = "";
                for (int i = 0; i < pingMianBiChu.Count; i++)
                {
                    ppm += pingMianBiChu[i];
                }

                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("0") && pingMianBiChuGeShu.Contains("1") && pingMianBiChuGeShu.Contains("2") && pingMianBiChuGeShu.Contains("3"))//选2个或以上出0,1,2,3个
                    {
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                result.Add(allNum[i]);
                            }
                        }
                        if (allNum[i].IndexOfAny(ppm.ToCharArray(0, ppm.Length)) < 0)
                        {
                            result.Add(allNum[i]);
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("0") && pingMianBiChuGeShu.Contains("1") && pingMianBiChuGeShu.Contains("2") && pingMianBiChuGeShu.Count == 3)//选2个或以上出0,1,2个
                    {
                        string x = allNum[i].Substring(0, 1), y = allNum[i].Substring(1, 1), z = allNum[i].Substring(2, 1);
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                if (!((pingMianBiChu.Contains(x)) && (pingMianBiChu.Contains(y)) && (pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                        if (allNum[i].IndexOfAny(ppm.ToCharArray(0, ppm.Length)) < 0)
                        {
                            result.Add(allNum[i]);
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("1") && pingMianBiChuGeShu.Contains("2") && pingMianBiChuGeShu.Contains("3"))//选2个或以上出1,2,3个
                    {
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("1") && pingMianBiChuGeShu.Contains("2") && pingMianBiChuGeShu.Count == 2)//选2个或以上出1,2个
                    {
                        string x = allNum[i].Substring(0, 1), y = allNum[i].Substring(1, 1), z = allNum[i].Substring(2, 1);
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                if (!((pingMianBiChu.Contains(x)) && (pingMianBiChu.Contains(y)) && (pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }

                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("0") && pingMianBiChuGeShu.Count == 1)//选2个或以上出0个
                    {
                        if (allNum[i].IndexOfAny(ppm.ToCharArray(0, ppm.Length)) < 0)
                        {
                            result.Add(allNum[i]);
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("0") && pingMianBiChuGeShu.Contains("1") && pingMianBiChuGeShu.Count == 2)//选2个或以上出0,1个
                    {
                        string x = allNum[i].Substring(0, 1);
                        string y = allNum[i].Substring(1, 1);
                        string z = allNum[i].Substring(2, 1);


                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                if (!((pingMianBiChu.Contains(x) && pingMianBiChu.Contains(y)) || (pingMianBiChu.Contains(x) && pingMianBiChu.Contains(z)) || (pingMianBiChu.Contains(y) && pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                        if (allNum[i].IndexOfAny(ppm.ToCharArray(0, ppm.Length)) < 0)
                        {
                            result.Add(allNum[i]);
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("0") && pingMianBiChuGeShu.Contains("2") && pingMianBiChuGeShu.Count == 2)//选2个或以上出0,2个
                    {
                        string x = allNum[i].Substring(0, 1);
                        string y = allNum[i].Substring(1, 1);
                        string z = allNum[i].Substring(2, 1);
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                if (((pingMianBiChu.Contains(x) && pingMianBiChu.Contains(y)) || (pingMianBiChu.Contains(x) && pingMianBiChu.Contains(z)) || (pingMianBiChu.Contains(y) && pingMianBiChu.Contains(z))) && !((pingMianBiChu.Contains(x)) && (pingMianBiChu.Contains(y)) && (pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                        if (allNum[i].IndexOfAny(ppm.ToCharArray(0, ppm.Length)) < 0)
                        {
                            result.Add(allNum[i]);
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("0") && pingMianBiChuGeShu.Contains("3") && pingMianBiChuGeShu.Count == 2)//选2个或以上出0,3个
                    {
                        string x = allNum[i].Substring(0, 1);
                        string y = allNum[i].Substring(1, 1);
                        string z = allNum[i].Substring(2, 1);
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                if (((pingMianBiChu.Contains(x)) && (pingMianBiChu.Contains(y)) && (pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                        if (allNum[i].IndexOfAny(ppm.ToCharArray(0, ppm.Length)) < 0)
                        {
                            result.Add(allNum[i]);
                        }
                    }

                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("1") && pingMianBiChuGeShu.Count == 1)//选2个或以上出1个
                    {
                        string x = allNum[i].Substring(0, 1);
                        string y = allNum[i].Substring(1, 1);
                        string z = allNum[i].Substring(2, 1);


                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                if (!((pingMianBiChu.Contains(x) && pingMianBiChu.Contains(y)) || (pingMianBiChu.Contains(x) && pingMianBiChu.Contains(z)) || (pingMianBiChu.Contains(y) && pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("2") && pingMianBiChuGeShu.Count == 1)//选2个或以上出2个
                    {
                        string x = allNum[i].Substring(0, 1);
                        string y = allNum[i].Substring(1, 1);
                        string z = allNum[i].Substring(2, 1);
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                if (((pingMianBiChu.Contains(x) && pingMianBiChu.Contains(y)) || (pingMianBiChu.Contains(x) && pingMianBiChu.Contains(z)) || (pingMianBiChu.Contains(y) && pingMianBiChu.Contains(z))) && !((pingMianBiChu.Contains(x)) && (pingMianBiChu.Contains(y)) && (pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("3") && pingMianBiChuGeShu.Count == 1)//选2个或以上出3个
                    {
                        string x = allNum[i].Substring(0, 1);
                        string y = allNum[i].Substring(1, 1);
                        string z = allNum[i].Substring(2, 1);
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                if (((pingMianBiChu.Contains(x)) && (pingMianBiChu.Contains(y)) && (pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("1") && pingMianBiChuGeShu.Contains("3") && pingMianBiChuGeShu.Count == 2)//选2个或以上出1,3个
                    {
                        string x = allNum[i].Substring(0, 1);
                        string y = allNum[i].Substring(1, 1);
                        string z = allNum[i].Substring(2, 1);
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if ((allNum[i].Contains(jbk)))
                            {
                                if ((!((pingMianBiChu.Contains(x) && pingMianBiChu.Contains(y)) || (pingMianBiChu.Contains(x) && pingMianBiChu.Contains(z)) || (pingMianBiChu.Contains(y) && pingMianBiChu.Contains(z)))) || ((pingMianBiChu.Contains(x)) && (pingMianBiChu.Contains(y)) && (pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("0") && pingMianBiChuGeShu.Contains("1") && pingMianBiChuGeShu.Contains("3") && pingMianBiChuGeShu.Count == 3)//选2个或以上出0,1,3个
                    {
                        string x = allNum[i].Substring(0, 1);
                        string y = allNum[i].Substring(1, 1);
                        string z = allNum[i].Substring(2, 1);
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if ((allNum[i].Contains(jbk)))
                            {
                                if ((!((pingMianBiChu.Contains(x) && pingMianBiChu.Contains(y)) || (pingMianBiChu.Contains(x) && pingMianBiChu.Contains(z)) || (pingMianBiChu.Contains(y) && pingMianBiChu.Contains(z)))) || ((pingMianBiChu.Contains(x)) && (pingMianBiChu.Contains(y)) && (pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                        if (allNum[i].IndexOfAny(ppm.ToCharArray(0, ppm.Length)) < 0)
                        {
                            result.Add(allNum[i]);
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("2") && pingMianBiChuGeShu.Contains("3") && pingMianBiChuGeShu.Count == 2)//选2个或以上出2,3个
                    {
                        string x = allNum[i].Substring(0, 1);
                        string y = allNum[i].Substring(1, 1);
                        string z = allNum[i].Substring(2, 1);
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                if (((pingMianBiChu.Contains(x) && pingMianBiChu.Contains(y)) || (pingMianBiChu.Contains(x) && pingMianBiChu.Contains(z)) || (pingMianBiChu.Contains(y) && pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                    }
                    if (pingMianBiChu.Count > 1 && pingMianBiChuGeShu.Contains("0") && pingMianBiChuGeShu.Contains("2") && pingMianBiChuGeShu.Contains("3") && pingMianBiChuGeShu.Count == 3)//选2个或以上出0,2,3个
                    {
                        string x = allNum[i].Substring(0, 1);
                        string y = allNum[i].Substring(1, 1);
                        string z = allNum[i].Substring(2, 1);
                        for (int j = 0; j < pingMianBiChu.Count; j++)
                        {
                            string jbk = pingMianBiChu[j];
                            if (allNum[i].Contains(jbk))
                            {
                                if (((pingMianBiChu.Contains(x) && pingMianBiChu.Contains(y)) || (pingMianBiChu.Contains(x) && pingMianBiChu.Contains(z)) || (pingMianBiChu.Contains(y) && pingMianBiChu.Contains(z))))
                                    result.Add(allNum[i]);
                            }
                        }
                        if (allNum[i].IndexOfAny(ppm.ToCharArray(0, ppm.Length)) < 0)
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            #endregion
            }
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1;
        }
        #endregion

        #endregion

        #region 组合系列

        private string[] biXiaZu()//必下组合(定位组合)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string zu1 = textBox1.Text;
            string zu2 = textBox2.Text;
            string zu3 = textBox3.Text;
            string zu4 = textBox8.Text;
            string zu5 = textBox9.Text;
            string zu6 = textBox10.Text;
            string zu7 = textBox11.Text;
            string zu8 = textBox12.Text;
            string zu9 = textBox13.Text;
            string zu10 = textBox14.Text;
            string[] allNum = pingMianBiChu4();
            if (zu1.Equals("") && zu2.Equals("") && zu3.Equals(""))
            {
                result.AddRange(allNum);
            }
            if (zu1 != "" && zu2.Equals("") && zu3.Equals("") && zu4.Equals("") && zu5.Equals(""))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if ((allNum[i].IndexOf(zu1.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu1.Substring(1, 1)) >= 0))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu2 != "" && zu3.Equals("") && zu4.Equals("") && zu5.Equals(""))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((allNum[i].IndexOf(zu1.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu1.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu2.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu2.Substring(1, 1)) >= 0)))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu2 != "" && zu3 != "" && zu4.Equals("") && zu5.Equals(""))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((allNum[i].IndexOf(zu1.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu1.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu2.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu2.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu3.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu3.Substring(1, 1)) >= 0)))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu2 != "" && zu3 != "" && zu4 != "" && zu5.Equals(""))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((allNum[i].IndexOf(zu1.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu1.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu2.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu2.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu3.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu3.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu4.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu4.Substring(1, 1)) >= 0)))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu2 != "" && zu3 != "" && zu4 != "" && zu5 != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((allNum[i].IndexOf(zu1.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu1.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu2.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu2.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu3.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu3.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu4.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu4.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu5.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu5.Substring(1, 1)) >= 0)))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu2 != "" && zu3 != "" && zu4 != "" && zu5 != "" && zu6 != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((allNum[i].IndexOf(zu1.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu1.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu2.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu2.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu3.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu3.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu4.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu4.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu5.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu5.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu6.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu6.Substring(1, 1)) >= 0)))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu2 != "" && zu3 != "" && zu4 != "" && zu5 != "" && zu6 != "" && zu7 != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((allNum[i].IndexOf(zu1.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu1.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu2.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu2.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu3.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu3.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu4.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu4.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu5.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu5.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu6.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu6.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu7.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu7.Substring(1, 1)) >= 0)))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu2 != "" && zu3 != "" && zu4 != "" && zu5 != "" && zu6 != "" && zu7 != "" && zu8 != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((allNum[i].IndexOf(zu1.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu1.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu2.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu2.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu3.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu3.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu4.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu4.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu5.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu5.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu6.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu6.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu7.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu7.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu8.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu8.Substring(1, 1)) >= 0)))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu2 != "" && zu3 != "" && zu4 != "" && zu5 != "" && zu6 != "" && zu7 != "" && zu8 != "" && zu9 != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((allNum[i].IndexOf(zu1.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu1.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu2.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu2.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu3.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu3.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu4.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu4.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu5.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu5.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu6.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu6.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu7.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu7.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu8.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu8.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu9.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu9.Substring(1, 1)) >= 0)))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu2 != "" && zu3 != "" && zu4 != "" && zu5 != "" && zu6 != "" && zu7 != "" && zu8 != "" && zu9 != "" && zu10 != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((allNum[i].IndexOf(zu1.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu1.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu2.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu2.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu3.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu3.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu4.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu4.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu5.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu5.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu6.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu6.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu7.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu7.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu8.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu8.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu9.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu9.Substring(1, 1)) >= 0)) || ((allNum[i].IndexOf(zu10.Substring(0, 1)) >= 0) && (allNum[i].IndexOf(zu10.Substring(1, 1)) >= 0)))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            return result.ToArray();
        }

        private string[] biShaZu()//必杀组合(杀组合)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string zu1 = textBox4.Text;
            string zu2 = textBox5.Text;
            string zu3 = textBox6.Text;
            string[] allNum = biXiaZu();
            if (zu1.Equals("") && zu2.Equals("") && zu3.Equals(""))
            {
                result.AddRange(allNum);
            }
            if (zu1 != "" && zu2.Equals("") && zu3.Equals(""))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if ((!(allNum[i].Contains(zu1))) && !(allNum[i].Contains(zu1.Substring(1, 1) + zu1.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu1.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu1.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu1.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu1.Substring(0, 1)))))
                        ))
                    {
                        result.Add(allNum[i]);
                    }
                    //((allNum[i].Substring(0, 1).IndexOf(zu1.Substring(0, 1)) < 0) && (allNum[i].Substring(2, 1).IndexOf(zu1.Substring(1, 1)) < 0))
                }
            }
            if (zu1 != "" && zu2 != "" && zu3.Equals(""))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((!(allNum[i].Contains(zu1))) && !(allNum[i].Contains(zu1.Substring(1, 1) + zu1.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu1.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu1.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu1.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu1.Substring(0, 1)))))
                        ))

                        &&

                        ((!(allNum[i].Contains(zu2))) && !(allNum[i].Contains(zu2.Substring(1, 1) + zu2.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu2.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu2.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu2.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu2.Substring(0, 1)))))
                        )))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu3 != "" && zu2.Equals(""))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((!(allNum[i].Contains(zu1))) && !(allNum[i].Contains(zu1.Substring(1, 1) + zu1.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu1.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu1.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu1.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu1.Substring(0, 1)))))
                        ))

                        &&

                        ((!(allNum[i].Contains(zu3))) && !(allNum[i].Contains(zu3.Substring(1, 1) + zu3.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu3.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu3.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu3.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu3.Substring(0, 1)))))
                        )))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            if (zu1 != "" && zu2 != "" && zu3 != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((!(allNum[i].Contains(zu1))) && !(allNum[i].Contains(zu1.Substring(1, 1) + zu1.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu1.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu1.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu1.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu1.Substring(0, 1)))))
                        ))

                        &&

                        ((!(allNum[i].Contains(zu2))) && !(allNum[i].Contains(zu2.Substring(1, 1) + zu2.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu2.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu2.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu2.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu2.Substring(0, 1)))))
                        ))

                        &&

                        ((!(allNum[i].Contains(zu3))) && !(allNum[i].Contains(zu3.Substring(1, 1) + zu3.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu3.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu3.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu3.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu3.Substring(0, 1)))))
                        )))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            return result.ToArray();
        }

        private string[] shaQiHao()//杀期号
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string zu1 = "";
            string zu2 = "";
            string zu3 = "";
            if (textBox7.Text.Length == 3)
            {
                zu1 = textBox7.Text.Substring(0, 2);
                zu2 = textBox7.Text.Substring(1, 2);
                zu3 = textBox7.Text.Substring(0, 1) + textBox7.Text.Substring(2, 1);
            }
            string[] allNum = biShaZu();
            if (zu1.Equals("") && zu2.Equals("") && zu3.Equals(""))
            {
                result.AddRange(allNum);
            }

            if (zu1 != "" && zu2 != "" && zu3 != "")
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if (((!(allNum[i].Contains(zu1))) && !(allNum[i].Contains(zu1.Substring(1, 1) + zu1.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu1.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu1.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu1.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu1.Substring(0, 1)))))
                        ))

                        &&

                        ((!(allNum[i].Contains(zu2))) && !(allNum[i].Contains(zu2.Substring(1, 1) + zu2.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu2.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu2.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu2.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu2.Substring(0, 1)))))
                        ))

                        &&

                        ((!(allNum[i].Contains(zu3))) && !(allNum[i].Contains(zu3.Substring(1, 1) + zu3.Substring(0, 1))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu3.Substring(0, 1))) && (allNum[i].Substring(2, 1).Contains(zu3.Substring(1, 1)))) &&
                        (!((allNum[i].Substring(0, 1).Contains(zu3.Substring(1, 1))) && (allNum[i].Substring(2, 1).Contains(zu3.Substring(0, 1)))))
                        )))
                    {
                        result.Add(allNum[i]);
                    }
                }
            }
            return result.ToArray();
        }

        #endregion

        #region 临码组

        private string[] daLin()//临码之大临
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = shaQiHao();
            string[] bigNum = { "5", "6", "7", "8", "9" };

            for (int i = 0; i < allNum.Count(); i++)
            {
                for (int j = 0; j < bigNum.Count(); j++)
                {
                    if (
                        (
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        )
                        )
                    {
                        result.Add(allNum[i]);
                    }
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] xiaoLin()//临码之小临
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = shaQiHao();
            string[] bigNum = { "0", "1", "2", "3", "4" };

            for (int i = 0; i < allNum.Count(); i++)
            {
                for (int j = 0; j < bigNum.Count(); j++)
                {
                    if (
                        (
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        )
                        )
                    {
                        result.Add(allNum[i]);
                    }
                }
            }


            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] daXiao()//临码之大小
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = shaQiHao();
            string[] bigNum = { "4", "5" };
            if (daXiaoCbx.Checked == false)
            {
                result.AddRange(allNum);
            }

            for (int i = 0; i < allNum.Count(); i++)
            {
                for (int j = 0; j < bigNum.Count(); j++)
                {
                    if (
                        (
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        )
                        )
                    {
                        result.Add(allNum[i]);
                    }
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] zhiLin()//临码之质临
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = shaQiHao();
            string[] bigNum = { "1", "2", "3" };//,"5","7"

            for (int i = 0; i < allNum.Count(); i++)
            {
                for (int j = 0; j < bigNum.Count(); j++)
                {
                    if (
                        (
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        )
                        )
                    {
                        result.Add(allNum[i]);
                    }
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] heLin()//临码之和临
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = shaQiHao();
            string[] bigNum = { "8", "9" };//"0", "4", "6", 

            for (int i = 0; i < allNum.Count(); i++)
            {
                for (int j = 0; j < bigNum.Count(); j++)
                {
                    if (
                        (
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        )
                        )
                    {
                        result.Add(allNum[i]);
                    }
                }
            }


            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] zhiHe()//临码之质合
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = shaQiHao();
            string[] bigNum = { "0", "1", "3", "4", "5", "6", "7", "8" };
            if (zhiHeCbx.Checked == false)
            {
                result.AddRange(allNum);
            }
            if (zhiHeCbx.Checked && linMaBaoHanCbx.Checked)//质合包含
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < bigNum.Count(); j++)
                    {
                        if (
                            (
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }

            if (zhiHeCbx.Checked && linMaShaQuCbx.Checked)//质合杀去
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < bigNum.Count(); j++)
                    {
                        if (
                            !(
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] duanLin()//临码之断临
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = shaQiHao();
            string[] bigNum = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            for (int i = 0; i < allNum.Count(); i++)
            {
                for (int j = 0; j < bigNum.Count(); j++)
                {
                    if (
                        (
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                        ||
                        ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                        )
                        )
                    {
                        result.Add(allNum[i]);
                    }
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        //--------------------------------------------------

        private string[] daLinSha()//临码之大临
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = shaQiHao();
            string[] bigNum = { "5", "6", "7", "8", "9" };
            if (daLinCbx.Checked == false)
            {
                result.AddRange(allNum);
            }


            if (daLinCbx.Checked && linMaShaQuCbx.Checked)//大临杀去
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < bigNum.Count(); j++)
                    {
                        if (
                            !(
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] xiaoLinSha()//临码之小临
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = daLinSha();
            string[] bigNum = { "0", "1", "2", "3", "4" };
            if (xiaoLinCbx.Checked == false)
            {
                result.AddRange(allNum);
            }


            if (xiaoLinCbx.Checked && linMaShaQuCbx.Checked)//小临杀去
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < bigNum.Count(); j++)
                    {
                        if (
                            !(
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] daXiaoSha()//临码之大小
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = xiaoLinSha();
            string[] bigNum = { "4", "5" };
            if (daXiaoCbx.Checked == false)
            {
                result.AddRange(allNum);
            }


            if (daXiaoCbx.Checked && linMaShaQuCbx.Checked)//大小杀去
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < bigNum.Count(); j++)
                    {
                        if (
                            !(
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] zhiLinSha()//临码之质临
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = daXiaoSha();
            string[] bigNum = { "1", "2", "3", "5", "7" };
            if (zhiLinCbx.Checked == false)
            {
                result.AddRange(allNum);
            }

            if (zhiLinCbx.Checked && linMaShaQuCbx.Checked)//质临杀去
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < bigNum.Count(); j++)
                    {
                        if (
                            !(
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] heLinSha()//临码之和临
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = zhiLinSha();
            string[] bigNum = { "0", "4", "6", "8", "9" };
            if (heLinCbx.Checked == false)
            {
                result.AddRange(allNum);
            }

            if (heLinCbx.Checked && linMaShaQuCbx.Checked)//和临杀去
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < bigNum.Count(); j++)
                    {
                        if (
                            !(
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] zhiHeSha()//临码之质合
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = heLinSha();
            string[] bigNum = { "0", "1", "3", "4", "5", "6", "7", "8" };
            if (zhiHeCbx.Checked == false)
            {
                result.AddRange(allNum);
            }


            if (zhiHeCbx.Checked && linMaShaQuCbx.Checked)//质合杀去
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < bigNum.Count(); j++)
                    {
                        if (
                            !(
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] duanLinSha()//临码之断临
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = zhiHeSha();
            string[] bigNum = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            if (duanLinCbx.Checked == false)
            {
                result.AddRange(allNum);
            }

            if (duanLinCbx.Checked && linMaShaQuCbx.Checked)//断临杀去
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < bigNum.Count(); j++)
                    {
                        if (
                            !(
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(1, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(1, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1)) == 1))
                            ||
                            ((bigNum.Contains(allNum[i].Substring(0, 1)) && bigNum.Contains(allNum[i].Substring(2, 1))) && (Convert.ToInt32(allNum[i].Substring(2, 1)) - Convert.ToInt32(allNum[i].Substring(0, 1)) == 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        /// <summary>
        /// 临码综合控制
        /// </summary>
        /// <returns></returns>
        private string[] linMa()
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();

            if (linMaBaoHanCbx.Checked == false && linMaShaQuCbx.Checked == false)
            {
                result.AddRange(shaQiHao());
            }

            string nums = "";
            foreach (Control ctls in this.lmGpb.Controls)
            {
                if (ctls is CheckBox)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums += ctls.Text;
                    }
                }
            }

            if (nums.Length > 0 && (linMaBaoHanCbx.Checked == true || linMaShaQuCbx.Checked == true))
            {

                //勾选“包含”
                if (linMaBaoHanCbx.Checked == true)
                {
                    if (daLinCbx.Checked == true)
                    {
                        result.AddRange(daLin());
                    }

                    if (xiaoLinCbx.Checked == true)
                    {
                        result.AddRange(xiaoLin());
                    }

                    if (daXiaoCbx.Checked == true)
                    {
                        result.AddRange(daXiao());
                    }

                    if (zhiLinCbx.Checked == true)
                    {
                        result.AddRange(zhiLin());
                    }

                    if (heLinCbx.Checked == true)
                    {
                        result.AddRange(heLin());
                    }

                    if (zhiHeCbx.Checked == true)
                    {
                        result.AddRange(zhiHe());
                    }

                    if (duanLinCbx.Checked == true)
                    {
                        result.AddRange(duanLin());
                    }
                }

                //勾选“杀去”
                if (linMaShaQuCbx.Checked == true)
                {
                    result.AddRange(duanLinSha());
                }
            }
            else
            {

                result.AddRange(shaQiHao());
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        #endregion

        #region 凹凸状态


        /// <summary>
        /// 凹凸升降平综合控制
        /// </summary>
        /// <returns></returns>
        private string[] allAoTu()
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();

            if (aoCbx.Checked == true)
            {
                result.AddRange(ao());
            }

            if (tuCbx.Checked == true)
            {
                result.AddRange(tu());
            }

            if (shengCbx.Checked == true)
            {
                result.AddRange(sheng());
            }

            if (jiangCbx.Checked == true)
            {
                result.AddRange(jiang());
            }

            if (pingCbx.Checked == true)
            {
                result.AddRange(ping());
            }

            if (aoCbx.Checked == false && tuCbx.Checked == false && shengCbx.Checked == false && jiangCbx.Checked == false && pingCbx.Checked == false)
            {
                result.AddRange(linMa());
            }


            List<string> result1 = result.Distinct().ToList();//去除重复项
            result1.Sort();//排序
            return result1.ToArray();
        }

        private string[] ao()//凹凸之凹
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = linMa();

            for (int i = 0; i < allNum.Count(); i++)
            {
                if (
                    Convert.ToInt32(allNum[i].Substring(0, 1)) > Convert.ToInt32(allNum[i].Substring(1, 1))
                    &&
                    Convert.ToInt32(allNum[i].Substring(2, 1)) > Convert.ToInt32(allNum[i].Substring(1, 1))
                    )
                {
                    result.Add(allNum[i]);
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] tu()//凹凸之凸
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = linMa();
            for (int i = 0; i < allNum.Count(); i++)
            {
                if (
                    Convert.ToInt32(allNum[i].Substring(0, 1)) < Convert.ToInt32(allNum[i].Substring(1, 1))
                    &&
                    Convert.ToInt32(allNum[i].Substring(2, 1)) < Convert.ToInt32(allNum[i].Substring(1, 1))
                    )
                {
                    result.Add(allNum[i]);
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] sheng()//凹凸之升
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = linMa();
            for (int i = 0; i < allNum.Count(); i++)
            {
                if (
                    (
                    Convert.ToInt32(allNum[i].Substring(0, 1)) < Convert.ToInt32(allNum[i].Substring(1, 1))
                    &&
                    Convert.ToInt32(allNum[i].Substring(1, 1)) <= Convert.ToInt32(allNum[i].Substring(2, 1))
                    )
                    ||
                    (
                    Convert.ToInt32(allNum[i].Substring(0, 1)) <= Convert.ToInt32(allNum[i].Substring(1, 1))
                    &&
                    Convert.ToInt32(allNum[i].Substring(1, 1)) < Convert.ToInt32(allNum[i].Substring(2, 1))
                    )
                    )
                {
                    result.Add(allNum[i]);
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] jiang()//凹凸之降
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = linMa();
            for (int i = 0; i < allNum.Count(); i++)
            {
                if (
                    (
                    Convert.ToInt32(allNum[i].Substring(0, 1)) >= Convert.ToInt32(allNum[i].Substring(1, 1))
                    &&
                    Convert.ToInt32(allNum[i].Substring(1, 1)) > Convert.ToInt32(allNum[i].Substring(2, 1))
                    )
                    ||
                    (
                    Convert.ToInt32(allNum[i].Substring(0, 1)) > Convert.ToInt32(allNum[i].Substring(1, 1))
                    &&
                    Convert.ToInt32(allNum[i].Substring(1, 1)) >= Convert.ToInt32(allNum[i].Substring(2, 1))
                    )
                    )
                {
                    result.Add(allNum[i]);
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] ping()//凹凸之平
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = linMa();
            for (int i = 0; i < allNum.Count(); i++)
            {
                if (
                    Convert.ToInt32(allNum[i].Substring(0, 1)) == Convert.ToInt32(allNum[i].Substring(1, 1))
                    &&
                    Convert.ToInt32(allNum[i].Substring(1, 1)) == Convert.ToInt32(allNum[i].Substring(2, 1))
                    )
                {
                    result.Add(allNum[i]);
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        #endregion

        #region 分解式系列

        private string[] cusFJS1()//自定义分解式1
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = allAoTu();
            if (cusFJTbx1.Text.Length == 0 && cusFJTbx1Auto.Text.Length == 0)
            {
                result.AddRange(allNum);
            }
            if (cusFJTbx1.Text.Length > 0 && cusFJTbx1Auto.Text.Length > 0)
            {
                string cusFJtxt = cusFJTbx1.Text;
                string cusFJtxtAuto = cusFJTbx1Auto.Text;
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < cusFJtxt.Length; j++)
                        if (
                            //必须只能出现1,2次
                            (allNum[i].Replace(cusFJtxt.Substring(j, 1), "|").Split('|').Length - 1 == 1 || allNum[i].Replace(cusFJtxt.Substring(j, 1), "|").Split('|').Length - 1 == 2)
                            &&
                            //所出数字不同同时都满足属于输入分解式的数字
                            !(cusFJtxt.Contains(allNum[i].Substring(0, 1)) && cusFJtxt.Contains(allNum[i].Substring(1, 1)) && cusFJtxt.Contains(allNum[i].Substring(2, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] cusFJS2()//自定义分解式2
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = cusFJS1();
            if (cusFJTbx2.Text.Length == 0 && cusFJTbx2Auto.Text.Length == 0)
            {
                result.AddRange(allNum);
            }
            if (cusFJTbx2.Text.Length > 0 && cusFJTbx2Auto.Text.Length > 0)
            {
                string cusFJtxt = cusFJTbx2.Text;
                string cusFJtxtAuto = cusFJTbx2Auto.Text;
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < cusFJtxt.Length; j++)
                        if (
                            //必须只能出现1,2次
                            (allNum[i].Replace(cusFJtxt.Substring(j, 1), "|").Split('|').Length - 1 == 1 || allNum[i].Replace(cusFJtxt.Substring(j, 1), "|").Split('|').Length - 1 == 2)
                            &&
                            //所出数字不同同时都满足属于输入分解式的数字
                            !(cusFJtxt.Contains(allNum[i].Substring(0, 1)) && cusFJtxt.Contains(allNum[i].Substring(1, 1)) && cusFJtxt.Contains(allNum[i].Substring(2, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        public string[] fenJieShi()//分解式
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string fenJieShi = "";
            foreach (Control ctl in this.groupBox3.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        fenJieShi += (ctl as CheckBox).Text;
                }
            }

            string[] allNum = cusFJS2();
            string ans = "";
            if (fenJieShi.Equals(""))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    ans += allNum[i];
                    result.Add(allNum[i]);
                }
            }

            if (fenJieShi.Equals("单双分解"))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    if ((((Convert.ToInt32(allNum[i].Substring(0, 1)) % 2) == 0) && ((Convert.ToInt32(allNum[i].Substring(1, 1)) % 2) == 0) && ((Convert.ToInt32(allNum[i].Substring(2, 1)) % 2) == 0))
                        || (((Convert.ToInt32(allNum[i].Substring(0, 1)) % 2) == 1) && ((Convert.ToInt32(allNum[i].Substring(1, 1)) % 2) == 1) && ((Convert.ToInt32(allNum[i].Substring(2, 1)) % 2) == 1)))
                    {
                        allNum[i] = "";
                    }
                    ans += allNum[i];
                    result.Add(allNum[i]);
                }
            }

            if (fenJieShi.Equals("大小分解"))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    int a1 = Convert.ToInt32(allNum[i].Substring(0, 1)), b1 = Convert.ToInt32(allNum[i].Substring(1, 1)), c1 = Convert.ToInt32(allNum[i].Substring(2, 1));
                    int a2 = Convert.ToInt32(allNum[i].Substring(0, 1)), b2 = Convert.ToInt32(allNum[i].Substring(1, 1)), c2 = Convert.ToInt32(allNum[i].Substring(2, 1));
                    if (((a1 < 5) && (b1 < 5) && (c1 < 5)) || ((a2 > 4) && (b2 > 4) && (c2 > 4)))
                    {
                        allNum[i] = "";
                    }
                    ans += allNum[i];
                    result.Add(allNum[i]);
                }
            }

            if (fenJieShi.Equals("质合分解"))
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    int a1 = Convert.ToInt32(allNum[i].Substring(0, 1)), b1 = Convert.ToInt32(allNum[i].Substring(1, 1)), c1 = Convert.ToInt32(allNum[i].Substring(2, 1));
                    int a2 = Convert.ToInt32(allNum[i].Substring(0, 1)), b2 = Convert.ToInt32(allNum[i].Substring(1, 1)), c2 = Convert.ToInt32(allNum[i].Substring(2, 1));

                    if ((((a1 == 1) || (a1 == 2) || (a1 == 3) || (a1 == 5) || (a1 == 7))
                        && ((b1 == 1) || (b1 == 2) || (b1 == 3) || (b1 == 5) || (b1 == 7))
                        && ((c1 == 1) || (c1 == 2) || (c1 == 3) || (c1 == 5) || (c1 == 7)))
                        ||
                        (((a2 == 0) || (a2 == 4) || (a2 == 6) || (a2 == 8) || (a2 == 9))
                        && ((b2 == 0) || (b2 == 4) || (b2 == 6) || (b2 == 8) || (b2 == 9))
                        && ((c2 == 0) || (c2 == 4) || (c2 == 6) || (c2 == 8) || (c2 == 9))))
                    {
                        allNum[i] = "";
                    }
                    ans += allNum[i];
                    result.Add(allNum[i]);
                }
            }

            if (fenJieShi.Contains("单双分解") && fenJieShi.Contains("质合分解") && fenJieShi.Length == 8)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    int a1 = Convert.ToInt32(allNum[i].Substring(0, 1)), b1 = Convert.ToInt32(allNum[i].Substring(1, 1)), c1 = Convert.ToInt32(allNum[i].Substring(2, 1));
                    int a2 = Convert.ToInt32(allNum[i].Substring(0, 1)), b2 = Convert.ToInt32(allNum[i].Substring(1, 1)), c2 = Convert.ToInt32(allNum[i].Substring(2, 1));

                    if ((((Convert.ToInt32(allNum[i].Substring(0, 1)) % 2) == 0) && ((Convert.ToInt32(allNum[i].Substring(1, 1)) % 2) == 0) && ((Convert.ToInt32(allNum[i].Substring(2, 1)) % 2) == 0))
                        || (((Convert.ToInt32(allNum[i].Substring(0, 1)) % 2) == 1) && ((Convert.ToInt32(allNum[i].Substring(1, 1)) % 2) == 1) && ((Convert.ToInt32(allNum[i].Substring(2, 1)) % 2) == 1))
                        || (((a1 == 1) || (a1 == 2) || (a1 == 3) || (a1 == 5) || (a1 == 7))
                        && ((b1 == 1) || (b1 == 2) || (b1 == 3) || (b1 == 5) || (b1 == 7))
                        && ((c1 == 1) || (c1 == 2) || (c1 == 3) || (c1 == 5) || (c1 == 7)))
                        ||
                        (((a2 == 0) || (a2 == 4) || (a2 == 6) || (a2 == 8) || (a2 == 9))
                        && ((b2 == 0) || (b2 == 4) || (b2 == 6) || (b2 == 8) || (b2 == 9))
                        && ((c2 == 0) || (c2 == 4) || (c2 == 6) || (c2 == 8) || (c2 == 9))))
                    {
                        allNum[i] = "";
                    }
                    ans += allNum[i];
                    result.Add(allNum[i]);
                }
            }

            if (fenJieShi.Contains("单双分解") && fenJieShi.Contains("大小分解") && fenJieShi.Length == 8)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    int a1 = Convert.ToInt32(allNum[i].Substring(0, 1)), b1 = Convert.ToInt32(allNum[i].Substring(1, 1)), c1 = Convert.ToInt32(allNum[i].Substring(2, 1));
                    int a2 = Convert.ToInt32(allNum[i].Substring(0, 1)), b2 = Convert.ToInt32(allNum[i].Substring(1, 1)), c2 = Convert.ToInt32(allNum[i].Substring(2, 1));

                    if ((((Convert.ToInt32(allNum[i].Substring(0, 1)) % 2) == 0) && ((Convert.ToInt32(allNum[i].Substring(1, 1)) % 2) == 0) && ((Convert.ToInt32(allNum[i].Substring(2, 1)) % 2) == 0))
                        || (((Convert.ToInt32(allNum[i].Substring(0, 1)) % 2) == 1) && ((Convert.ToInt32(allNum[i].Substring(1, 1)) % 2) == 1) && ((Convert.ToInt32(allNum[i].Substring(2, 1)) % 2) == 1))
                        || ((a1 < 5) && (b1 < 5) && (c1 < 5)) || ((a2 > 4) && (b2 > 4) && (c2 > 4))
                        )
                    {
                        allNum[i] = "";
                    }
                    ans += allNum[i];
                    result.Add(allNum[i]);
                }
            }

            if (fenJieShi.Contains("大小分解") && fenJieShi.Contains("质合分解") && fenJieShi.Length == 8)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    int a1 = Convert.ToInt32(allNum[i].Substring(0, 1)), b1 = Convert.ToInt32(allNum[i].Substring(1, 1)), c1 = Convert.ToInt32(allNum[i].Substring(2, 1));
                    int a2 = Convert.ToInt32(allNum[i].Substring(0, 1)), b2 = Convert.ToInt32(allNum[i].Substring(1, 1)), c2 = Convert.ToInt32(allNum[i].Substring(2, 1));
                    if (((a1 < 5) && (b1 < 5) && (c1 < 5)) || ((a2 > 4) && (b2 > 4) && (c2 > 4))
                        || (((a1 == 1) || (a1 == 2) || (a1 == 3) || (a1 == 5) || (a1 == 7))
                        && ((b1 == 1) || (b1 == 2) || (b1 == 3) || (b1 == 5) || (b1 == 7))
                        && ((c1 == 1) || (c1 == 2) || (c1 == 3) || (c1 == 5) || (c1 == 7)))
                        ||
                        (((a2 == 0) || (a2 == 4) || (a2 == 6) || (a2 == 8) || (a2 == 9))
                        && ((b2 == 0) || (b2 == 4) || (b2 == 6) || (b2 == 8) || (b2 == 9))
                        && ((c2 == 0) || (c2 == 4) || (c2 == 6) || (c2 == 8) || (c2 == 9)))
                        )
                    {
                        allNum[i] = "";
                    }
                    ans += allNum[i];
                    result.Add(allNum[i]);
                }
            }

            if (fenJieShi.Contains("单双分解") && fenJieShi.Contains("大小分解") && fenJieShi.Contains("质合分解") && fenJieShi.Length == 12)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    int a1 = Convert.ToInt32(allNum[i].Substring(0, 1)), b1 = Convert.ToInt32(allNum[i].Substring(1, 1)), c1 = Convert.ToInt32(allNum[i].Substring(2, 1));
                    int a2 = Convert.ToInt32(allNum[i].Substring(0, 1)), b2 = Convert.ToInt32(allNum[i].Substring(1, 1)), c2 = Convert.ToInt32(allNum[i].Substring(2, 1));
                    if ((((Convert.ToInt32(allNum[i].Substring(0, 1)) % 2) == 0) && ((Convert.ToInt32(allNum[i].Substring(1, 1)) % 2) == 0) && ((Convert.ToInt32(allNum[i].Substring(2, 1)) % 2) == 0))
                        || (((Convert.ToInt32(allNum[i].Substring(0, 1)) % 2) == 1) && ((Convert.ToInt32(allNum[i].Substring(1, 1)) % 2) == 1) && ((Convert.ToInt32(allNum[i].Substring(2, 1)) % 2) == 1))
                        || ((a1 < 5) && (b1 < 5) && (c1 < 5)) || ((a2 > 4) && (b2 > 4) && (c2 > 4))
                        || (((a1 == 1) || (a1 == 2) || (a1 == 3) || (a1 == 5) || (a1 == 7))
                        && ((b1 == 1) || (b1 == 2) || (b1 == 3) || (b1 == 5) || (b1 == 7))
                        && ((c1 == 1) || (c1 == 2) || (c1 == 3) || (c1 == 5) || (c1 == 7)))
                        ||
                        (((a2 == 0) || (a2 == 4) || (a2 == 6) || (a2 == 8) || (a2 == 9))
                        && ((b2 == 0) || (b2 == 4) || (b2 == 6) || (b2 == 8) || (b2 == 9))
                        && ((c2 == 0) || (c2 == 4) || (c2 == 6) || (c2 == 8) || (c2 == 9)))
                        )
                    {
                        allNum[i] = "";
                    }
                    ans += allNum[i];
                    result.Add(allNum[i]);
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            result1.Sort();

            for (int i = 0; i < result1.Count; i++)
            {
                if (result1[i].Equals(""))
                {
                    result1.Remove(result1[i]);
                }
            }
            return result1.ToArray();
        }

        #endregion

        #endregion

        #region checkedChanged

        //凹凸状态区域“全选”勾
        private void aotuAllCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (aotuAllCbx.Checked)
            {
                aoCbx.Checked = true;
                tuCbx.Checked = true;
                shengCbx.Checked = true;
                jiangCbx.Checked = true;
                pingCbx.Checked = true;
            }
            else
            {
                aoCbx.Checked = false;
                tuCbx.Checked = false;
                shengCbx.Checked = false;
                jiangCbx.Checked = false;
                pingCbx.Checked = false;
            }
        }

        //0
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox20.Enabled = false;
                checkBox33.Enabled = false;
                checkBox53.Enabled = false;
                checkBox43.Enabled = false;
                checkBox63.Enabled = false;
                checkBox73.Enabled = false;
                checkBox83.Enabled = false;

                checkBox20.Checked = false;
                checkBox33.Checked = false;
                checkBox53.Checked = false;
                checkBox43.Checked = false;
                checkBox63.Checked = false;
                checkBox73.Checked = false;
                checkBox83.Checked = false;
            }
            else
            {
                checkBox20.Enabled = true;
                checkBox33.Enabled = true;
                checkBox53.Enabled = true;
                checkBox43.Enabled = true;
                checkBox63.Enabled = true;
                checkBox73.Enabled = true;
                checkBox83.Enabled = true;
            }
        }

        //1
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox19.Enabled = false;
                checkBox32.Enabled = false;
                checkBox52.Enabled = false;
                checkBox42.Enabled = false;
                checkBox62.Enabled = false;
                checkBox72.Enabled = false;
                checkBox82.Enabled = false;

                checkBox19.Checked = false;
                checkBox32.Checked = false;
                checkBox52.Checked = false;
                checkBox42.Checked = false;
                checkBox62.Checked = false;
                checkBox72.Checked = false;
                checkBox82.Checked = false;
            }
            else
            {
                checkBox19.Enabled = true;
                checkBox32.Enabled = true;
                checkBox52.Enabled = true;
                checkBox42.Enabled = true;
                checkBox62.Enabled = true;
                checkBox72.Enabled = true;
                checkBox82.Enabled = true;
            }
        }

        //2
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox18.Enabled = false;
                checkBox31.Enabled = false;
                checkBox51.Enabled = false;
                checkBox41.Enabled = false;
                checkBox61.Enabled = false;
                checkBox71.Enabled = false;
                checkBox81.Enabled = false;

                checkBox18.Checked = false;
                checkBox31.Checked = false;
                checkBox51.Checked = false;
                checkBox41.Checked = false;
                checkBox61.Checked = false;
                checkBox71.Checked = false;
                checkBox81.Checked = false;
            }
            else
            {
                checkBox18.Enabled = true;
                checkBox31.Enabled = true;
                checkBox51.Enabled = true;
                checkBox41.Enabled = true;
                checkBox61.Enabled = true;
                checkBox71.Enabled = true;
                checkBox81.Enabled = true;
            }
        }

        //3
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox17.Enabled = false;
                checkBox30.Enabled = false;
                checkBox50.Enabled = false;
                checkBox40.Enabled = false;
                checkBox60.Enabled = false;
                checkBox70.Enabled = false;
                checkBox80.Enabled = false;

                checkBox17.Checked = false;
                checkBox30.Checked = false;
                checkBox50.Checked = false;
                checkBox40.Checked = false;
                checkBox60.Checked = false;
                checkBox70.Checked = false;
                checkBox80.Checked = false;
            }
            else
            {
                checkBox17.Enabled = true;
                checkBox30.Enabled = true;
                checkBox50.Enabled = true;
                checkBox40.Enabled = true;
                checkBox60.Enabled = true;
                checkBox70.Enabled = true;
                checkBox80.Enabled = true;
            }
        }

        //4
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox16.Enabled = false;
                checkBox29.Enabled = false;
                checkBox49.Enabled = false;
                checkBox39.Enabled = false;
                checkBox59.Enabled = false;
                checkBox69.Enabled = false;
                checkBox79.Enabled = false;

                checkBox16.Checked = false;
                checkBox29.Checked = false;
                checkBox49.Checked = false;
                checkBox39.Checked = false;
                checkBox59.Checked = false;
                checkBox69.Checked = false;
                checkBox79.Checked = false;
            }
            else
            {
                checkBox16.Enabled = true;
                checkBox29.Enabled = true;
                checkBox49.Enabled = true;
                checkBox39.Enabled = true;
                checkBox59.Enabled = true;
                checkBox69.Enabled = true;
                checkBox79.Enabled = true;
            }
        }

        //5
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox11.Enabled = false;
                checkBox24.Enabled = false;
                checkBox44.Enabled = false;
                checkBox34.Enabled = false;
                checkBox54.Enabled = false;
                checkBox64.Enabled = false;
                checkBox74.Enabled = false;

                checkBox11.Checked = false;
                checkBox24.Checked = false;
                checkBox44.Checked = false;
                checkBox34.Checked = false;
                checkBox54.Checked = false;
                checkBox64.Checked = false;
                checkBox74.Checked = false;
            }
            else
            {
                checkBox11.Enabled = true;
                checkBox24.Enabled = true;
                checkBox44.Enabled = true;
                checkBox34.Enabled = true;
                checkBox54.Enabled = true;
                checkBox64.Enabled = true;
                checkBox74.Enabled = true;
            }
        }

        //6
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                checkBox13.Enabled = false;
                checkBox26.Enabled = false;
                checkBox46.Enabled = false;
                checkBox36.Enabled = false;
                checkBox56.Enabled = false;
                checkBox66.Enabled = false;
                checkBox76.Enabled = false;

                checkBox13.Checked = false;
                checkBox26.Checked = false;
                checkBox46.Checked = false;
                checkBox36.Checked = false;
                checkBox56.Checked = false;
                checkBox66.Checked = false;
                checkBox76.Checked = false;
            }
            else
            {
                checkBox13.Enabled = true;
                checkBox26.Enabled = true;
                checkBox46.Enabled = true;
                checkBox36.Enabled = true;
                checkBox56.Enabled = true;
                checkBox66.Enabled = true;
                checkBox76.Enabled = true;
            }
        }

        //7
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                checkBox14.Enabled = false;
                checkBox27.Enabled = false;
                checkBox47.Enabled = false;
                checkBox37.Enabled = false;
                checkBox57.Enabled = false;
                checkBox67.Enabled = false;
                checkBox77.Enabled = false;

                checkBox14.Checked = false;
                checkBox27.Checked = false;
                checkBox47.Checked = false;
                checkBox37.Checked = false;
                checkBox57.Checked = false;
                checkBox67.Checked = false;
                checkBox77.Checked = false;
            }
            else
            {
                checkBox14.Enabled = true;
                checkBox27.Enabled = true;
                checkBox47.Enabled = true;
                checkBox37.Enabled = true;
                checkBox57.Enabled = true;
                checkBox67.Enabled = true;
                checkBox77.Enabled = true;
            }
        }

        //8
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                checkBox15.Enabled = false;
                checkBox28.Enabled = false;
                checkBox48.Enabled = false;
                checkBox38.Enabled = false;
                checkBox58.Enabled = false;
                checkBox68.Enabled = false;
                checkBox78.Enabled = false;

                checkBox15.Checked = false;
                checkBox28.Checked = false;
                checkBox48.Checked = false;
                checkBox38.Checked = false;
                checkBox58.Checked = false;
                checkBox68.Checked = false;
                checkBox78.Checked = false;
            }
            else
            {
                checkBox15.Enabled = true;
                checkBox28.Enabled = true;
                checkBox48.Enabled = true;
                checkBox38.Enabled = true;
                checkBox58.Enabled = true;
                checkBox68.Enabled = true;
                checkBox78.Enabled = true;
            }
        }

        //9
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                checkBox12.Enabled = false;
                checkBox25.Enabled = false;
                checkBox45.Enabled = false;
                checkBox35.Enabled = false;
                checkBox55.Enabled = false;
                checkBox65.Enabled = false;
                checkBox75.Enabled = false;

                checkBox12.Checked = false;
                checkBox25.Checked = false;
                checkBox45.Checked = false;
                checkBox35.Checked = false;
                checkBox55.Checked = false;
                checkBox65.Checked = false;
                checkBox75.Checked = false;
            }
            else
            {
                checkBox12.Enabled = true;
                checkBox25.Enabled = true;
                checkBox45.Enabled = true;
                checkBox35.Enabled = true;
                checkBox55.Enabled = true;
                checkBox65.Enabled = true;
                checkBox75.Enabled = true;
            }
        }

        //临码“含”
        private void linMaBaoHanCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (linMaBaoHanCbx.Checked)
            {
                linMaShaQuCbx.Enabled = false;
            }
            else
            {
                linMaShaQuCbx.Enabled = true;
            }
        }

        //临码“杀”
        private void linMaShaQuCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (linMaShaQuCbx.Checked)
            {
                linMaBaoHanCbx.Enabled = false;
            }
            else
            {
                linMaBaoHanCbx.Enabled = true;
            }
        }

        #endregion

        #region textChanged
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox2.Enabled = true;

                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox1.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.Substring(i, 1), @" ")))
                    {
                        textBox1.Text = textBox1.Text.Remove(i, 1);
                    }
                }
                textBox1.SelectionStart = textBox1.Text.Length;
            }
            if (textBox1.Text.Length != 2 || textBox1.Text.Length != 0)
            {
                textBox2.Enabled = false;
                textBox2.Text = "";
            }
            if (textBox1.Text.Length == 0)
            {
                textBox2.Enabled = false;
                textBox2.Text = "";
            }
            if (textBox1.Text.Length == 2)
            {
                textBox2.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                textBox3.Enabled = true;

                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox2.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text.Substring(i, 1), @" ")))
                    {
                        textBox2.Text = textBox2.Text.Remove(i, 1);
                    }
                }
                textBox2.SelectionStart = textBox2.Text.Length;
            }
            if (textBox2.Text.Length != 2 || textBox2.Text.Length != 0)
            {
                textBox3.Enabled = false;
                textBox3.Text = "";
            }
            if (textBox2.Text.Length == 0)
            {
                textBox3.Enabled = false;
                textBox3.Text = "";
            }
            if (textBox2.Text.Length == 2)
            {
                textBox3.Enabled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                textBox8.Enabled = true;

                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox3.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text.Substring(i, 1), @" ")))
                    {
                        textBox3.Text = textBox3.Text.Remove(i, 1);
                    }
                }
                textBox3.SelectionStart = textBox3.Text.Length;
            }
            if (textBox3.Text.Length != 2 || textBox3.Text.Length != 0)
            {
                textBox8.Enabled = false;
                textBox8.Text = "";
            }
            if (textBox3.Text.Length == 0)
            {
                textBox8.Enabled = false;
                textBox8.Text = "";
            }
            if (textBox3.Text.Length == 2)
            {
                textBox8.Enabled = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length > 0)
            {
                textBox9.Enabled = true;
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox8.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox8.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox8.Text.Substring(i, 1), @" ")))
                    {
                        textBox8.Text = textBox8.Text.Remove(i, 1);
                    }
                }
                textBox8.SelectionStart = textBox8.Text.Length;
            }
            if (textBox8.Text.Length != 2 || textBox8.Text.Length != 0)
            {
                textBox9.Enabled = false;
                textBox9.Text = "";
            }
            if (textBox8.Text.Length == 0)
            {
                textBox9.Enabled = false;
                textBox9.Text = "";
            }
            if (textBox8.Text.Length == 2)
            {
                textBox9.Enabled = true;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox9.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox9.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox9.Text.Substring(i, 1), @" ")))
                    {
                        textBox9.Text = textBox9.Text.Remove(i, 1);
                    }
                }
                textBox9.SelectionStart = textBox9.Text.Length;
            }
            if (textBox9.Text.Length != 2 || textBox9.Text.Length != 0)
            {
                textBox10.Enabled = false;
                textBox10.Text = "";
            }
            if (textBox9.Text.Length == 0)
            {
                textBox10.Enabled = false;
                textBox10.Text = "";
            }
            if (textBox9.Text.Length == 2)
            {
                textBox10.Enabled = true;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox10.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox10.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox10.Text.Substring(i, 1), @" ")))
                    {
                        textBox10.Text = textBox10.Text.Remove(i, 1);
                    }
                }
                textBox10.SelectionStart = textBox10.Text.Length;
            }
            if (textBox10.Text.Length != 2 || textBox10.Text.Length != 0)
            {
                textBox11.Enabled = false;
                textBox11.Text = "";
            }
            if (textBox10.Text.Length == 0)
            {
                textBox11.Enabled = false;
                textBox11.Text = "";
            }
            if (textBox10.Text.Length == 2)
            {
                textBox11.Enabled = true;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox11.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox11.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox11.Text.Substring(i, 1), @" ")))
                    {
                        textBox11.Text = textBox11.Text.Remove(i, 1);
                    }
                }
                textBox11.SelectionStart = textBox11.Text.Length;
            }
            if (textBox11.Text.Length != 2 || textBox11.Text.Length != 0)
            {
                textBox12.Enabled = false;
                textBox12.Text = "";
            }
            if (textBox11.Text.Length == 0)
            {
                textBox12.Enabled = false;
                textBox12.Text = "";
            }
            if (textBox11.Text.Length == 2)
            {
                textBox12.Enabled = true;
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text.Length > 0)
            {
                for (int i = textBox12.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox12.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox12.Text.Substring(i, 1), @" ")))
                    {
                        textBox12.Text = textBox12.Text.Remove(i, 1);
                    }
                }
                textBox12.SelectionStart = textBox12.Text.Length;
            }
            if (textBox12.Text.Length != 2 || textBox12.Text.Length != 0)
            {
                textBox13.Enabled = false;
                textBox13.Text = "";
            }
            if (textBox12.Text.Length == 0)
            {
                textBox13.Enabled = false;
                textBox13.Text = "";
            }
            if (textBox12.Text.Length == 2)
            {
                textBox13.Enabled = true;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text.Length > 0)
            {
                for (int i = textBox13.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox13.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox13.Text.Substring(i, 1), @" ")))
                    {
                        textBox13.Text = textBox13.Text.Remove(i, 1);
                    }
                }
                textBox13.SelectionStart = textBox13.Text.Length;
            }
            if (textBox13.Text.Length != 2 || textBox13.Text.Length != 0)
            {
                textBox14.Enabled = false;
                textBox14.Text = "";
            }
            if (textBox13.Text.Length == 0)
            {
                textBox14.Enabled = false;
                textBox14.Text = "";
            }
            if (textBox13.Text.Length == 2)
            {
                textBox14.Enabled = true;
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (textBox14.Text.Length > 0)
            {
                for (int i = textBox14.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox14.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox14.Text.Substring(i, 1), @" ")))
                    {
                        textBox14.Text = textBox14.Text.Remove(i, 1);
                    }
                }
                textBox14.SelectionStart = textBox14.Text.Length;
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                textBox5.Enabled = true;
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox4.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text.Substring(i, 1), @" ")))
                    {
                        textBox4.Text = textBox4.Text.Remove(i, 1);
                    }
                }
                textBox4.SelectionStart = textBox4.Text.Length;
            }
            if (textBox4.Text.Length != 2 || textBox4.Text.Length != 0)
            {
                textBox5.Enabled = false;
                textBox5.Text = "";
            }
            if (textBox4.Text.Length == 0)
            {
                textBox5.Enabled = false;
                textBox5.Text = "";
            }
            if (textBox4.Text.Length == 2)
            {
                textBox5.Enabled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
                textBox6.Enabled = true;
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox5.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text.Substring(i, 1), @" ")))
                    {
                        textBox5.Text = textBox5.Text.Remove(i, 1);
                    }
                }
                textBox5.SelectionStart = textBox5.Text.Length;
            }
            if (textBox5.Text.Length != 2 || textBox5.Text.Length != 0)
            {
                textBox6.Enabled = false;
                textBox6.Text = "";
            }
            if (textBox5.Text.Length == 0)
            {
                textBox6.Enabled = false;
                textBox6.Text = "";
            }
            if (textBox5.Text.Length == 2)
            {
                textBox6.Enabled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox6.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text.Substring(i, 1), @" ")))
                    {
                        textBox6.Text = textBox6.Text.Remove(i, 1);
                    }
                }
                textBox6.SelectionStart = textBox6.Text.Length;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox7.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text.Substring(i, 1), @" ")))
                    {
                        textBox7.Text = textBox7.Text.Remove(i, 1);
                    }
                }
                textBox7.SelectionStart = textBox7.Text.Length;
            }
        }

        private void cusFJTbx1_TextChanged(object sender, EventArgs e)
        {
            if (cusFJTbx1.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = cusFJTbx1.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(cusFJTbx1.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(cusFJTbx1.Text.Substring(i, 1), @" ")))
                    {
                        cusFJTbx1.Text = cusFJTbx1.Text.Remove(i, 1);
                    }

                }
                cusFJTbx1.SelectionStart = cusFJTbx1.Text.Length;

                string txt = cusFJTbx1.Text;
                string ans = "";//缓存输入给赋值框
                string[] num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                List<string> li = new List<string>();
                List<string> li2 = new List<string>();
                li.AddRange(num);

                for (int i = 0; i < cusFJTbx1.Text.Length; i++)
                {
                    li2.Add(cusFJTbx1.Text.Substring(i, 1));//将输入框的值分成每个数添加进序列中
                    li.Remove(li2[i]);//将要显示的框中删除所有在序列中的数
                }

                for (int i = 0; i < li.Count(); i++)
                {
                    ans += li[i];
                }
                cusFJTbx1Auto.Text = ans;
            }
            if (cusFJTbx1.Text.Length == 0)
            {
                cusFJTbx1Auto.Text = "";
            }

        }

        private void cusFJTbx2_TextChanged(object sender, EventArgs e)
        {
            if (cusFJTbx2.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = cusFJTbx2.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(cusFJTbx2.Text.Substring(i, 1), @"^[0-9]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(cusFJTbx2.Text.Substring(i, 1), @" ")))
                    {
                        cusFJTbx2.Text = cusFJTbx2.Text.Remove(i, 1);
                    }
                }
                cusFJTbx2.SelectionStart = cusFJTbx2.Text.Length;

                string txt = cusFJTbx1.Text;
                string ans = "";//缓存输入给赋值框
                string[] num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                List<string> li = new List<string>();
                List<string> li2 = new List<string>();
                li.AddRange(num);

                for (int i = 0; i < cusFJTbx2.Text.Length; i++)
                {
                    li2.Add(cusFJTbx2.Text.Substring(i, 1));//将输入框的值分成每个数添加进序列中
                    li.Remove(li2[i]);//将要显示的框中删除所有在序列中的数
                }

                for (int i = 0; i < li.Count(); i++)
                {
                    ans += li[i];
                }
                cusFJTbx2Auto.Text = ans;
            }
            if (cusFJTbx2.Text.Length == 0)
            {
                cusFJTbx2Auto.Text = "";
            }
        }
        #endregion

        #region Groupbox重绘

        private void groupBox18_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(lmGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(lmGpb.Text, lmGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(lmGpb.Text, lmGpb.Font).Width + 8, 7, lmGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, lmGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, lmGpb.Height - 2, lmGpb.Width - 2, lmGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, lmGpb.Width - 2, 7, lmGpb.Width - 2, lmGpb.Height - 2);//右边那条竖线
        }

        private void groupBox19_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox19.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox19.Text, groupBox19.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox19.Text, groupBox19.Font).Width + 8, 7, groupBox19.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox19.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox19.Height - 2, groupBox19.Width - 2, groupBox19.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox19.Width - 2, 7, groupBox19.Width - 2, groupBox19.Height - 2);//右边那条竖线
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox2.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox2.Text, groupBox2.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox2.Text, groupBox2.Font).Width + 8, 7, groupBox2.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox2.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox2.Height - 2, groupBox2.Width - 2, groupBox2.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox2.Width - 2, 7, groupBox2.Width - 2, groupBox2.Height - 2);//右边那条竖线 
        }

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

        private void groupBox9_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox9.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox9.Text, groupBox9.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox9.Text, groupBox9.Font).Width + 8, 7, groupBox9.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox9.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox9.Height - 2, groupBox9.Width - 2, groupBox9.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox9.Width - 2, 7, groupBox9.Width - 2, groupBox9.Height - 2);//右边那条竖线
        }

        private void groupBox7_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox7.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox7.Text, groupBox7.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox7.Text, groupBox7.Font).Width + 8, 7, groupBox7.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox7.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox7.Height - 2, groupBox7.Width - 2, groupBox7.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox7.Width - 2, 7, groupBox7.Width - 2, groupBox7.Height - 2);//右边那条竖线
        }

        private void groupBox10_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox10.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox10.Text, groupBox10.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox10.Text, groupBox10.Font).Width + 8, 7, groupBox10.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox10.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox10.Height - 2, groupBox10.Width - 2, groupBox10.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox10.Width - 2, 7, groupBox10.Width - 2, groupBox10.Height - 2);//右边那条竖线 
        }

        private void groupBox11_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox11.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox11.Text, groupBox11.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox11.Text, groupBox11.Font).Width + 8, 7, groupBox11.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox11.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox11.Height - 2, groupBox11.Width - 2, groupBox11.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox11.Width - 2, 7, groupBox11.Width - 2, groupBox11.Height - 2);//右边那条竖线
        }

        private void groupBox8_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox8.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox8.Text, groupBox8.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox8.Text, groupBox8.Font).Width + 8, 7, groupBox8.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox8.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox8.Height - 2, groupBox8.Width - 2, groupBox8.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox8.Width - 2, 7, groupBox8.Width - 2, groupBox8.Height - 2);//右边那条竖线
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox3.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox3.Text, groupBox3.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox3.Text, groupBox3.Font).Width + 8, 7, groupBox3.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox3.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox3.Height - 2, groupBox3.Width - 2, groupBox3.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox3.Width - 2, 7, groupBox3.Width - 2, groupBox3.Height - 2);//右边那条竖线
        }

        private void groupBox16_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox16.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox16.Text, groupBox16.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox16.Text, groupBox16.Font).Width + 8, 7, groupBox16.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox16.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox16.Height - 2, groupBox16.Width - 2, groupBox16.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox16.Width - 2, 7, groupBox16.Width - 2, groupBox16.Height - 2);//右边那条竖线 
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox4.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox4.Text, groupBox4.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox4.Text, groupBox4.Font).Width + 8, 7, groupBox4.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox4.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox4.Height - 2, groupBox4.Width - 2, groupBox4.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox4.Width - 2, 7, groupBox4.Width - 2, groupBox4.Height - 2);//右边那条竖线
        }

        private void groupBox6_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox6.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox6.Text, groupBox6.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox6.Text, groupBox6.Font).Width + 8, 7, groupBox6.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox6.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox6.Height - 2, groupBox6.Width - 2, groupBox6.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox6.Width - 2, 7, groupBox6.Width - 2, groupBox6.Height - 2);//右边那条竖线
        }

        private void groupBox5_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox5.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox5.Text, groupBox5.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox5.Text, groupBox5.Font).Width + 8, 7, groupBox5.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox5.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox5.Height - 2, groupBox5.Width - 2, groupBox5.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox5.Width - 2, 7, groupBox5.Width - 2, groupBox5.Height - 2);//右边那条竖线
        }

        private void groupBox17_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox17.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox17.Text, groupBox17.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox17.Text, groupBox17.Font).Width + 8, 7, groupBox17.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox17.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox17.Height - 2, groupBox17.Width - 2, groupBox17.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox17.Width - 2, 7, groupBox17.Width - 2, groupBox17.Height - 2);//右边那条竖线
        }

        #endregion

        //清空页面上的Checkbox
        public void clearCheckbox()
        {

            foreach (Control ctl in this.Controls)
            {
                if (ctl is GroupBox)
                {
                    foreach (Control ctls in ctl.Controls)
                    {
                        if (ctls is CheckBox)
                        {
                            (ctls as CheckBox).Checked = false;
                        }
                        if (ctls is TextBox)
                        {
                            (ctls as TextBox).Text = "";
                        }
                        if (ctls is GroupBox)
                        {
                            foreach (Control ctlls in ctls.Controls)
                            {
                                if (ctlls is CheckBox)
                                {
                                    (ctlls as CheckBox).Checked = false;
                                }
                                if (ctlls is TextBox)
                                {
                                    (ctlls as TextBox).Text = "";
                                }
                            }
                        }
                    }
                }
            }
        }

        #region 平面胆组中标签实现清空功能

        #region 一号组标签实现清空功能
        private void oneZuChu_MouseEnter(object sender, EventArgs e)
        {
            this.oneZuChu.Text = "清";
        }

        private void oneZuChu_MouseLeave(object sender, EventArgs e)
        {
            this.oneZuChu.Text = "出:";
        }

        private void oneZuChu_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.groupBox2.Controls)
            {                
                if (ctl is CheckBox&&(ctl as CheckBox).Checked)
                {
                    (ctl as CheckBox).Checked = false;
                }
            }
        }
        #endregion

        #region 二号组标签实现清空功能
        private void twoZuChu_MouseEnter(object sender, EventArgs e)
        {
            this.twoZuChu.Text = "清";
        }

        private void twoZuChu_MouseLeave(object sender, EventArgs e)
        {
            this.twoZuChu.Text = "出:";
        }

        private void twoZuChu_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.groupBox9.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked)
                {
                    (ctl as CheckBox).Checked = false;
                }
            }
        }
        #endregion

        #region 三号组标签实现清空功能
        private void threeZuChu_MouseEnter(object sender, EventArgs e)
        {
            this.threeZuChu.Text = "清";
        }

        private void threeZuChu_MouseLeave(object sender, EventArgs e)
        {
            this.threeZuChu.Text = "出:";
        }

        private void threeZuChu_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.groupBox10.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked)
                {
                    (ctl as CheckBox).Checked = false;
                }
            }
        }
        #endregion

        #region 四号组标签实现清空功能
        private void fourZuChu_MouseEnter(object sender, EventArgs e)
        {
            this.fourZuChu.Text = "清";
        }

        private void fourZuChu_MouseLeave(object sender, EventArgs e)
        {
            this.fourZuChu.Text = "出:";
        }

        private void fourZuChu_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.groupBox11.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked)
                {
                    (ctl as CheckBox).Checked = false;
                }
            }
        }
        #endregion

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

        #endregion

        //百位杀号：杀单留双
        private void shaDanLiuShuang1_CheckedChanged(object sender, EventArgs e)
        {
            int[] nums = { 1, 3, 5, 7, 9 };
            hookNums(shaDanLiuShuang1, nums, this.groupBox4);
        }

        //百位杀号：杀大留小
        private void shaDaLiuXiao1_CheckedChanged(object sender, EventArgs e)
        {
            int[] nums = { 5, 6, 7, 8, 9 };
            hookNums(shaDaLiuXiao1,nums, this.groupBox4);
        }

        //个位杀号：杀单留双
        private void shaDanLiuShuang2_CheckedChanged(object sender, EventArgs e)
        {
            int[] nums = { 1, 3, 5, 7, 9 };
            hookNums(shaDanLiuShuang2,nums, this.groupBox6);
        }

        //个位杀号：杀大留小
        private void shaDaLiuXiao2_CheckedChanged(object sender, EventArgs e)
        {
            int[] nums = { 5, 6, 7, 8, 9 };
            hookNums(shaDaLiuXiao2,nums, this.groupBox6);
        }

        //十位杀号：杀单留双
        private void shaDanLiuShuang3_CheckedChanged(object sender, EventArgs e)
        {
            int[] nums = { 1, 3, 5, 7, 9 };
            hookNums(shaDanLiuShuang3,nums, this.groupBox5);
        }

        //十位杀号：杀大留小
        private void shaDaLiuXiao3_CheckedChanged(object sender, EventArgs e)
        {
            int[] nums = { 5, 6, 7, 8, 9 };
            hookNums(shaDaLiuXiao3,nums, this.groupBox5);
        }

        /// <summary>
        /// 百位个位十位杀号条件勾选（杀单留双，杀大留小）
        /// </summary>
        private void hookNums(CheckBox me,int[] nums,Control c)
        {
            if (me.Checked == true)
            {
                foreach (Control ctls in c.Controls)
                {
                    if (ctls.Name.Contains("sha"))
                    {
                        continue;
                    }

                    int num = Convert.ToInt16(ctls.Text);
                    if (nums.Contains(num))
                    {
                        (ctls as CheckBox).Checked = true;
                    }
                }
                return;
            }

            foreach (Control ctls in c.Controls)
            {
                if (ctls.Name.Contains("sha"))
                {
                    continue;
                }

                int num = Convert.ToInt16(ctls.Text);
                if (nums.Contains(num))
                {
                    (ctls as CheckBox).Checked = false;
                }
            }
        }
    }
}