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
    public partial class Page4Form : Form
    {
        public Page4Form()
        {
            InitializeComponent();

        }

        private zst z = null;
        private OutputFormForEast otForm = null;
        private OutputForm otFormNormal = null;
        Form1 f1 = new Form1();

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

            Tools.SetGroupBoxPaintAll(this.Controls);
        }

        #region 按钮点击、标签

        //两位数生成按钮click事件
        private void liangWeiShuGenerateBtn_Click(object sender, EventArgs e)
        {
            if (otForm == null || otForm.IsDisposed)//判断窗口是否打开
            {
                otForm = new OutputFormForEast();
            }
            liangWeiShuGenerate();
        }

        /// <summary>
        /// 插入号码组按钮click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 清空mdb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearMDB_Click(object sender, EventArgs e)
        {
            clearTableMDB();
        }
        private void clearTableMDB()
        {
            bool addOK = LinkMyMDB.clearData("numberGroup");
            if (addOK == false)
            {
                MessageBox.Show("清空失败");
                return;
            }
            this.issueTxt.Text = "";
            this.numGroupTxt.Text = "";
        }

        //两码差中“生成”按钮点击事件
        private void liangMaChaGenerateBtn_Click(object sender, EventArgs e)
        {

            if (otForm == null || otForm.IsDisposed)//判断窗口是否打开
            {
                otForm = new OutputFormForEast();
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

            result = pingMianShaMa(result);
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


            try
            {
                ans = ans.Substring(0, ans.Length - 1);
                otForm.Text = "共计  " + li.Count + "   注 - 恩泽天下";
                otForm.textBox1.Text = ans;
            }
            catch
            {
                otForm.Text = "出错";
                otForm.textBox1.Text = "运算出错，请您检查您设置的条件！";
            }
            otForm.Show();
        }

        /// <summary>
        /// 号码形态生成
        /// </summary>
        /// <param name="li"></param>
        private void generateDataCalHaoMaXingTai(List<string> li)
        {
            string ans = "";
            for (int i = 0; i < li.Count(); i++)
            {
                ans += li[i];
            }


            try
            {
                ans = ans.Substring(0, ans.Length - 1);
                otFormNormal.Text = "共计  " + li.Count + "   注 - 恩泽天下";
                otFormNormal.textBox1.Text = ans;
            }
            catch
            {
                otFormNormal.Text = "出错";
                otFormNormal.textBox1.Text = "运算出错，请您检查您设置的条件！";
            }
            otFormNormal.Show();
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

            result = pingMianShaMa(result);
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

        #region 主数据组

        /// <summary>
        /// 平面杀码
        /// </summary>
        /// <param name="lastResult"></param>
        /// <returns></returns>
        private List<string> pingMianShaMa(List<string> lastResult)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string shaNum = "";

            foreach (Control ctl in this.pingMianShaHaoGpb.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        shaNum += (ctl as CheckBox).Text;
                }
            }
            List<string> tempRes = lastResult;
            if (shaNum.Equals(""))
            {
                result.AddRange(tempRes);
            }
            if (shaNum != "")
            {
                for (int i = 0; i < tempRes.Count(); i++)
                {
                    if (tempRes[i].IndexOfAny(shaNum.ToCharArray(0, shaNum.Length)) < 0)
                    {
                        result.Add(tempRes[i]);
                    }
                }
            }

            return pingMianBiChu1(result);
        }

        /// <summary>
        /// 平面胆码组一
        /// </summary>
        /// <returns></returns>
        private List<string> pingMianBiChu1(List<string> lastResult)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            List<string> pingMianBiChu = new List<string>();
            List<string> pingMianBiChuGeShu = new List<string>();
            foreach (Control ctl in this.groupNum_1.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
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

            result.AddRange(pingMianDanMaOutput(lastResult, pingMianBiChu, pingMianBiChuGeShu));
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return pingMianBiChu2(result1);
        }

        /// <summary>
        /// 平面胆码组二
        /// </summary>
        /// <param name="lastResult"></param>
        /// <returns></returns>
        private List<string> pingMianBiChu2(List<string> lastResult)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            List<string> pingMianBiChu = new List<string>();
            List<string> pingMianBiChuGeShu = new List<string>();
            foreach (Control ctl in this.groupNum_2.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
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
            result.AddRange(pingMianDanMaOutput(lastResult, pingMianBiChu, pingMianBiChuGeShu));
            List<string> result1 = result.Distinct().ToList();//去除重复项
            return quanTaiCal(result1);
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
                            if (Tools.SubstringCount(allNum[k], pingMianBiChu[i]) == Convert.ToInt16(pingMianBiChuGeShu[j]))
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

       
        /// <summary>
        /// 全态计算
        /// </summary>
        /// <param name="lastResult"></param>
        /// <returns></returns>
        private List<string> quanTaiCal(List<string> lastResult)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = lastResult.ToArray();
            string[] zhiNums = new string[] { "1", "2", "3", "5", "7" };
            string[] danNums = new string[] { "1", "3", "5", "7", "9" };
            string[] xiaoNums = new string[] { "0", "1", "2", "3", "4" };
            string[] heNums = new string[] { "0", "4", "6", "8", "9" };
            string[] shuangNums = new string[] { "0", "2", "4", "6", "8" };
            string[] daNums = new string[] { "5", "6", "7", "8", "9" };

            int cbkCount = 0;
            foreach (Control ctls in this.quantaiGpb.Controls)
            {
                if (ctls is CheckBox)
                    if ((ctls as CheckBox).Checked == true)
                    {
                        cbkCount++;
                        if (ctls.Name.Equals("zuSan"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                                int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                                int c = Convert.ToInt16(allNum[i].Substring(2, 1));
                                if (
                                    a == b || a == c || b == c
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("zuLiu"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                                int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                                int c = Convert.ToInt16(allNum[i].Substring(2, 1));
                                if (
                                    a != b && a != c && b != c
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                    }
            }

            if (cbkCount == 0)
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1;
        }

        /// <summary>
        /// 号码排列形态
        /// </summary>
        /// <param name="lastResult"></param>
        /// <returns></returns>
        private List<string> calHaoMaXingTai()
        {
            List<string> result = new List<string>();
            List<string> condition = new List<string>();//存储勾选的CheckboxName
            List<string> lastResult = new List<string>(f1.ttt());

            string[] da = { "5", "6", "7", "8", "9" };
            string[] xiao = { "0", "1", "2", "3", "4" };
            foreach (Control ctrl in this.haoMaPaiLie.Controls)
            {
                if (ctrl is CheckBox && (ctrl as CheckBox).Checked == true)
                {
                    condition.Add(ctrl.Name.Substring(0, 3));
                }
            }
            if (condition.Count == 0)
            {
                result.AddRange(lastResult);
            }
            else
            {
                for (int i = 0; i < condition.Count; i++)
                {
                    string whatChoice = condition[i];

                    for (int j = 0; j < lastResult.Count; j++)
                    {
                        string nums = lastResult[j];
                        string x = nums.Substring(0, 1);
                        string y = nums.Substring(1, 1);
                        string z = nums.Substring(2, 1);

                        if (whatChoice.Equals("ddd"))
                        {
                            if (da.Contains(x) && da.Contains(y) && da.Contains(z))
                            {
                                result.Add(nums);
                            }
                        }

                        if (whatChoice.Equals("ddx"))
                        {
                            if (da.Contains(x) && da.Contains(y) && xiao.Contains(z))
                            {
                                result.Add(nums);
                            }
                        }

                        if (whatChoice.Equals("dxd"))
                        {
                            if (da.Contains(x) && xiao.Contains(y) && da.Contains(z))
                            {
                                result.Add(nums);
                            }
                        }

                        if (whatChoice.Equals("xdd"))
                        {
                            if (xiao.Contains(x) && da.Contains(y) && da.Contains(z))
                            {
                                result.Add(nums);
                            }
                        }

                        if (whatChoice.Equals("xxx"))
                        {
                            if (xiao.Contains(x) && xiao.Contains(y) && xiao.Contains(z))
                            {
                                result.Add(nums);
                            }
                        }

                        if (whatChoice.Equals("xxd"))
                        {
                            if (xiao.Contains(x) && xiao.Contains(y) && da.Contains(z))
                            {
                                result.Add(nums);
                            }
                        }

                        if (whatChoice.Equals("xdx"))
                        {
                            if (xiao.Contains(x) && da.Contains(y) && xiao.Contains(z))
                            {
                                result.Add(nums);
                            }
                        }

                        if (whatChoice.Equals("dxx"))
                        {
                            if (da.Contains(x) && xiao.Contains(y) && xiao.Contains(z))
                            {
                                result.Add(nums);
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        //清空页面checkbox复选框
        public void clearCheckBox(Control.ControlCollection cc)
        {
            foreach (Control ctls in cc)
            {
                if (ctls is CheckBox)
                {
                    (ctls as CheckBox).Checked = false;
                    continue;
                }
                if (ctls is RadioButton)
                {
                    (ctls as RadioButton).Checked = false;
                    continue;
                }
                clearCheckBox(ctls.Controls);
            }
        }

        private void liangMaChaSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control ckb in this.liangMaChaGpb.Controls)
            {
                if (ckb is CheckBox)
                    (ckb as CheckBox).Checked = true;
            }
        }

        private void haoMaPaiLieClear_Click(object sender, EventArgs e)
        {
            foreach (Control ctls in this.haoMaPaiLie.Controls)
            {
                if (ctls is CheckBox)
                {
                    (ctls as CheckBox).Checked = false;
                }
            }
        }

        private void haoMaPaiLieSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control ckb in this.haoMaPaiLie.Controls)
            {
                if (ckb is CheckBox)
                    (ckb as CheckBox).Checked = true;
            }
        }

        private void calHaoMaXT_Click(object sender, EventArgs e)
        {
            if (otFormNormal == null || otFormNormal.IsDisposed)//判断窗口是否打开
            {
                otFormNormal = new OutputForm();
            }

            List<string> result = new List<string>(calHaoMaXingTai());
            result.Sort();
            generateDataCalHaoMaXingTai(result);
        }

        private void clearShaHaoBtn_Click(object sender, EventArgs e)
        {
            foreach (Control ctls in this.pingMianShaHaoGpb.Controls) {
                if (ctls is CheckBox)
                    (ctls as CheckBox).Checked = false;
            }
        }

        private void clear1HaoMaZubtn_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.groupNum_1.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked)
                {
                    (ctl as CheckBox).Checked = false;
                }
            }
        }

        private void clear2HaoMaZubtn_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.groupNum_2.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked)
                {
                    (ctl as CheckBox).Checked = false;
                }
            }
        }
    }
}