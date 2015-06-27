using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3d
{
    public partial class one11xuan5 : Form
    {
        private static string fenGeFu = " ";//当前分隔符
        private static string fenGeFuOld = " ";//上一个分隔符
        private static int countCbxOld = 0;
        private string allDataStr = Properties.Resources._11xuan5;
        private List<string> allDataList = new List<string>();

        public one11xuan5()
        {
            InitializeComponent();
            getMainData();
            this.fenGeCombx.SelectedIndex = 0;
            this.timer1.Interval = 1;
            this.timer1.Enabled = true;
        }

        /// <summary>
        /// main界面“计算”按钮调用方法，用于发送11选5数据
        /// </summary>
        /// <returns></returns>
        public string sendData()
        {
            string res = "";
            List<string> li = new List<string>();
            li.AddRange(yiHaoZu());
            li = li.Distinct().ToList();//去除重复项
            for (int i = 0; i < li.Count; i++)
            {
                res += (li[i] + "\n");
            }
            if (res.Length != 0)
            {
                res = res.Substring(0, res.Length - 1);
            }
            return res;
        }

        /// <summary>
        /// 生成主数据
        /// </summary>
        private void getMainData()
        {
            //分隔符替换
            allDataStr = allDataStr.Replace(fenGeFuOld, fenGeFu);
            fenGeFuOld = fenGeFu;//将当前设置的分隔符赋值给老的，以便于下次替换

            //将462注主数据导入List中
            allDataList.Clear();
            string[] allDataStrs = allDataStr.Split('\n');
            foreach (string oneStr in allDataStrs){
                allDataList.Add(oneStr);
            }
        }

        /// <summary>
        /// 一号组运算
        /// </summary>
        /// <returns></returns>
        private List<string> yiHaoZu()
        {
            string oneNum = "";
            string oneZu = "";
            string tempData = allDataStr.Replace(fenGeFu,"");
            foreach (Control ctl in oneZuGpb.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked == true)
                {
                    if (ctl.Name.Contains("oneNum"))
                    {
                        oneNum += ctl.Text + ",";
                    }
                    if (ctl.Name.Contains("oneZu"))
                    {
                        oneZu += ctl.Text + ",";
                    }
                }
            }

            //如果没勾选号码或者所出个数则返回全数据
            if (oneNum.Length == 0 || oneZu.Length == 0)
            {
                return allDataList;
            }

            List<string> resData = new List<string>();
            List<string> oneNums = new List<string>();
            oneNum = oneNum.Substring(0, oneNum.Length - 1);
            oneZu = oneZu.Substring(0, oneZu.Length - 1);
            oneNums.AddRange(oneNum.Split(','));
            oneNums.Sort();

            if (oneZu.IndexOf("1") > -1)
            {

            }
            else if (oneZu.IndexOf("2") > -1)
            {
                resData.AddRange(calcHaoMaZuFor2(allDataList, oneNums));
            }
            else if (oneZu.IndexOf("3") > -1)
            {
                resData.AddRange(calcHaoMaZuFor3(allDataList, oneNums));
            }
            else if (oneZu.IndexOf("4") > -1)
            {

            }
            else if (oneZu.IndexOf("5") > -1)
            {

            }

            return resData;
        }

        /// <summary>
        /// 用于计算号码组的出2个
        /// </summary>
        /// <returns></returns>
        private List<string> calcHaoMaZuFor2(List<string> allData, List<string> srcNums)
        {
            List<string> resLi = new List<string>();
            for(int i = 0 ; i<srcNums.Count ; i++){
                string currStr = srcNums[i];
                int temp_i = i;
                
                //组成每一个“出2位数”
                while (temp_i < srcNums.Count - 1)
                {
                    temp_i++;
                    string nextStr = srcNums[temp_i];
                    string mixNum = currStr + nextStr;//生成勾选出几个的数

                    foreach (string oneLineData in allData)
                    {
                        string newOneLineData = oneLineData.Replace(fenGeFu,"");//将每行数据的分隔符去掉，达到一个完整字符串

                        //如果含有要出的数，且没有要出的数之外所勾选的数
                        if (newOneLineData.IndexOf(mixNum) > -1)
                        {
                            List<string> tempSrcNums = new List<string>();
                            tempSrcNums.AddRange(srcNums);//用于将其他多余数字筛除
                            tempSrcNums.Remove(currStr);
                            tempSrcNums.Remove(nextStr);
                            if (noNeedNumClear(tempSrcNums, newOneLineData))
                            {
                                resLi.Add(oneLineData);//将分割前的正确数据插入结果集
                            }
                        }
                    }
                }
            }
            resLi.Sort();
            return resLi;
        }

        /// <summary>
        /// 用于计算号码组的出3个
        /// </summary>
        /// <returns></returns>
        private List<string> calcHaoMaZuFor3(List<string> allData, List<string> srcNums)
        {
            List<string> resLi = new List<string>();
            for (int i = 0; i < srcNums.Count; i++)
            {
                string currStr = srcNums[i];
                int temp_i = i;

                //组成每一个“出3位数”
                while (temp_i < srcNums.Count - 2)
                {
                    temp_i++;
                    string nextStr = srcNums[temp_i];
                    string next2Str = srcNums[temp_i + 1];
                    string mixNum = currStr + nextStr + next2Str;//生成勾选出几个的数

                    foreach (string oneLineData in allData)
                    {
                        string newOneLineData = oneLineData.Replace(fenGeFu, "");//将每行数据的分隔符去掉，达到一个完整字符串

                        //如果含有要出的数，且没有要出的数之外所勾选的数
                        if (newOneLineData.IndexOf(mixNum) > -1)
                        {
                            List<string> tempSrcNums = new List<string>();
                            tempSrcNums.AddRange(srcNums);//用于将其他多余数字筛除
                            tempSrcNums.Remove(currStr);
                            tempSrcNums.Remove(nextStr);
                            tempSrcNums.Remove(next2Str);
                            if (noNeedNumClear(tempSrcNums, newOneLineData))
                            {
                                resLi.Add(oneLineData);//将分割前的正确数据插入结果集
                            }
                        }
                    }
                }
            }
            resLi.Sort();
            return resLi;
        }

        /// <summary>
        /// 如果当前的数不在这行中，但是又勾选了，那么摘出去
        /// </summary>
        /// <returns></returns>
        private bool noNeedNumClear(List<string> tempSrcNums,string newOneLineData)
        {
            List<string> newTemp = new List<string>();
            newTemp.AddRange(tempSrcNums);
            foreach (string tempSrcNum in tempSrcNums)
            {
                int tempSrcNumInt = Convert.ToInt16(tempSrcNum);
                int tempLastTwoNum = Convert.ToInt16(newOneLineData.Substring(newOneLineData.Length - 3));
                if (tempSrcNumInt <= tempLastTwoNum)
                {
                    if (newOneLineData.IndexOf(tempSrcNum) > -1)
                    {
                        return false;
                    }
                    else {
                        newTemp.Remove(tempSrcNum);
                        return noNeedNumClear(newTemp, newOneLineData);
                    }

                }
            }
            return true;
        }

        /// <summary>
        /// 分隔符Combobox改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fenGeCombx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string txt = this.fenGeCombx.Text;
            if(txt.Equals("空格")){
                fenGeFu = " ";
            }
            else if (txt.Equals("中文逗号，"))
            {
                fenGeFu = "，";
            }
            else if (txt.Equals("英文逗号,"))
            {
                fenGeFu = ",";
            }
            else if (txt.Equals("中文分号；"))
            {
                fenGeFu = "；";
            }
            else if (txt.Equals("英文分号;"))
            {
                fenGeFu = ";";
            }
            getMainData();
        }

        #region 页面Groupbox重绘

        private void oneZuGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(oneZuGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(oneZuGpb.Text, oneZuGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(oneZuGpb.Text, oneZuGpb.Font).Width + 8, 7, oneZuGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, oneZuGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, oneZuGpb.Height - 2, oneZuGpb.Width - 2, oneZuGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, oneZuGpb.Width - 2, 7, oneZuGpb.Width - 2, oneZuGpb.Height - 2);//右边那条竖线
        }

        #endregion

        //监控胆码组的复选框
        private void timer1_Tick(object sender, EventArgs e)
        {
            visibleZuCbx(this.oneZuGpb, "oneNum", "oneZu");
        }

        private void visibleZuCbx(Control Gpb, string oneNumName, string oneZuName)
        {
            int countOneNum = 0;

            if (countCbxOld == 0)
            {
                foreach (Control ctl in Gpb.Controls)
                {
                    if (ctl is CheckBox && ctl.Name.Contains(oneZuName))
                    {
                        ctl.Enabled = false;
                    }
                }
            }

            //判断有勾了几个数
            foreach (Control ctl in Gpb.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked && ctl.Name.Contains(oneNumName))
                {
                    countOneNum++;
                }
            }

            //把所有Enable=false的勾去掉
            foreach (Control ctl in Gpb.Controls)
            {
                if (ctl is CheckBox && ctl.Name.Contains(oneZuName) && ctl.Enabled == false)
                {
                    (ctl as CheckBox).Checked = false;
                }
            }

            if (countOneNum == countCbxOld)
            {
                return;
            }
            countCbxOld = countOneNum;
            foreach (Control ctl in Gpb.Controls)
            {
                if (ctl is CheckBox && ctl.Name.Contains(oneZuName))
                {
                    ctl.Enabled = false;
                    for (int i = 0; i <= countOneNum; i++)
                    {
                        if (ctl.Name.Contains(i.ToString()))
                        {
                            ctl.Enabled = true;
                        }
                    }
                }

            }
        }
    }
}
