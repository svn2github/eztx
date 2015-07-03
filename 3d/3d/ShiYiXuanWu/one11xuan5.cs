using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace _3d
{
    public partial class one11xuan5 : Form
    {
        private static string fenGeFu = " ";//当前分隔符
        private static string fenGeFuOld = " ";//上一个分隔符
        private static int countOneHaoZuCbxOld = 0;
        private static int countTwoHaoZuCbxOld = 0;
        private static int countThreeHaoZuCbxOld = 0;
        private static int countFourHaoZuCbxOld = 0;
        private string allDataStr = Properties.Resources._11xuan5;
        private List<string> allDataList = new List<string>();

        public one11xuan5()
        {
            InitializeComponent();
            getMainData();
            this.fenGeCombx.SelectedIndex = 0;

            this.timer1.Interval = 1;
            this.timer1.Enabled = true;
            this.timer2.Interval = 1;
            this.timer1.Enabled = true;

            Tools.SetGroupBoxPaintAll(this.Controls);
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
            li.Sort();
            li = li.Distinct().ToList();//去除重复项
            for (int i = 0; i < li.Count; i++)
            {
                res += (li[i] + "\r\n");
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
            string[] allDataStrs = allDataStr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
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
            string oneNum = "";//所选数字
            string oneZu = "";//所出个数
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
                return erHaoZu(allDataList);
            }

            List<string> resData = new List<string>();
            List<string> oneNums = new List<string>();
            oneNum = oneNum.Substring(0, oneNum.Length - 1);
            oneZu = oneZu.Substring(0, oneZu.Length - 1);
            oneNums.AddRange(oneNum.Split(','));
            oneNums.Sort();

            if (oneZu.IndexOf("0") > -1)
            {
                resData.AddRange(calcHaoMaZuFor0(allDataList, oneNums));
            }

            if (oneZu.IndexOf("1") > -1)
            {
                resData.AddRange(calcHaoMaZuFor1(allDataList, oneNums, 1));
            }
            
            if (oneZu.IndexOf("2") > -1)
            {
                resData.AddRange(calcHaoMaZuFor2(allDataList, oneNums, 2));
            }
            
            if (oneZu.IndexOf("3") > -1)
            {
                resData.AddRange(calcHaoMaZuFor3(allDataList, oneNums, 3));
            }
            
            if (oneZu.IndexOf("4") > -1)
            {
                resData.AddRange(calcHaoMaZuFor4(allDataList, oneNums, 4));
            }
            
            if (oneZu.IndexOf("5") > -1)
            {
                resData.AddRange(calcHaoMaZuFor5(allDataList, oneNums, 5));
            }

            return erHaoZu(resData);
        }

        /// <summary>
        /// 二号组运算
        /// </summary>
        /// <returns></returns>
        private List<string> erHaoZu(List<string> allData)
        {
            string oneNum = "";//所选数字
            string oneZu = "";//所出个数
            foreach (Control ctl in twoZuGpb.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked == true)
                {
                    if (ctl.Name.Contains("twoNum"))
                    {
                        oneNum += ctl.Text + ",";
                    }
                    if (ctl.Name.Contains("twoZu"))
                    {
                        oneZu += ctl.Text + ",";
                    }
                }
            }

            //如果没勾选号码或者所出个数则返回全数据
            if (oneNum.Length == 0 || oneZu.Length == 0)
            {
                return sanHaoZu(allData);
            }

            List<string> resData = new List<string>();
            List<string> oneNums = new List<string>();
            oneNum = oneNum.Substring(0, oneNum.Length - 1);
            oneZu = oneZu.Substring(0, oneZu.Length - 1);
            oneNums.AddRange(oneNum.Split(','));
            oneNums.Sort();

            if (oneZu.IndexOf("0") > -1)
            {
                resData.AddRange(calcHaoMaZuFor0(allData, oneNums));
            }

            if (oneZu.IndexOf("1") > -1)
            {
                resData.AddRange(calcHaoMaZuFor1(allData, oneNums, 1));
            }

            if (oneZu.IndexOf("2") > -1)
            {
                resData.AddRange(calcHaoMaZuFor2(allData, oneNums, 2));
            }

            if (oneZu.IndexOf("3") > -1)
            {
                resData.AddRange(calcHaoMaZuFor3(allData, oneNums, 3));
            }

            if (oneZu.IndexOf("4") > -1)
            {
                resData.AddRange(calcHaoMaZuFor4(allData, oneNums, 4));
            }

            if (oneZu.IndexOf("5") > -1)
            {
                resData.AddRange(calcHaoMaZuFor5(allData, oneNums, 5));
            }

            return sanHaoZu(resData);
        }

        /// <summary>
        /// 三号组运算
        /// </summary>
        /// <returns></returns>
        private List<string> sanHaoZu(List<string> allData)
        {
            string oneNum = "";//所选数字
            string oneZu = "";//所出个数
            foreach (Control ctl in threeZuGpb.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked == true)
                {
                    if (ctl.Name.Contains("threeNum"))
                    {
                        oneNum += ctl.Text + ",";
                    }
                    if (ctl.Name.Contains("threeZu"))
                    {
                        oneZu += ctl.Text + ",";
                    }
                }
            }

            //如果没勾选号码或者所出个数则返回全数据
            if (oneNum.Length == 0 || oneZu.Length == 0)
            {
                return siHaoZu(allData);
            }

            List<string> resData = new List<string>();
            List<string> oneNums = new List<string>();
            oneNum = oneNum.Substring(0, oneNum.Length - 1);
            oneZu = oneZu.Substring(0, oneZu.Length - 1);
            oneNums.AddRange(oneNum.Split(','));
            oneNums.Sort();

            if (oneZu.IndexOf("0") > -1)
            {
                resData.AddRange(calcHaoMaZuFor0(allData, oneNums));
            }

            if (oneZu.IndexOf("1") > -1)
            {
                resData.AddRange(calcHaoMaZuFor1(allData, oneNums, 1));
            }

            if (oneZu.IndexOf("2") > -1)
            {
                resData.AddRange(calcHaoMaZuFor2(allData, oneNums, 2));
            }

            if (oneZu.IndexOf("3") > -1)
            {
                resData.AddRange(calcHaoMaZuFor3(allData, oneNums, 3));
            }

            if (oneZu.IndexOf("4") > -1)
            {
                resData.AddRange(calcHaoMaZuFor4(allData, oneNums, 4));
            }

            if (oneZu.IndexOf("5") > -1)
            {
                resData.AddRange(calcHaoMaZuFor5(allData, oneNums, 5));
            }

            return siHaoZu(resData);
        }

        /// <summary>
        /// 四号组运算
        /// </summary>
        /// <returns></returns>
        private List<string> siHaoZu(List<string> allData)
        {
            string oneNum = "";//所选数字
            string oneZu = "";//所出个数
            foreach (Control ctl in fourZuGpb.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked == true)
                {
                    if (ctl.Name.Contains("fourNum"))
                    {
                        oneNum += ctl.Text + ",";
                    }
                    if (ctl.Name.Contains("fourZu"))
                    {
                        oneZu += ctl.Text + ",";
                    }
                }
            }

            //如果没勾选号码或者所出个数则返回全数据
            if (oneNum.Length == 0 || oneZu.Length == 0)
            {
                return allData;
            }

            List<string> resData = new List<string>();
            List<string> oneNums = new List<string>();
            oneNum = oneNum.Substring(0, oneNum.Length - 1);
            oneZu = oneZu.Substring(0, oneZu.Length - 1);
            oneNums.AddRange(oneNum.Split(','));
            oneNums.Sort();

            if (oneZu.IndexOf("0") > -1)
            {
                resData.AddRange(calcHaoMaZuFor0(allData, oneNums));
            }

            if (oneZu.IndexOf("1") > -1)
            {
                resData.AddRange(calcHaoMaZuFor1(allData, oneNums, 1));
            }

            if (oneZu.IndexOf("2") > -1)
            {
                resData.AddRange(calcHaoMaZuFor2(allData, oneNums, 2));
            }

            if (oneZu.IndexOf("3") > -1)
            {
                resData.AddRange(calcHaoMaZuFor3(allData, oneNums, 3));
            }

            if (oneZu.IndexOf("4") > -1)
            {
                resData.AddRange(calcHaoMaZuFor4(allData, oneNums, 4));
            }

            if (oneZu.IndexOf("5") > -1)
            {
                resData.AddRange(calcHaoMaZuFor5(allData, oneNums, 5));
            }

            return resData;
        }

        /// <summary>
        /// 用于计算号码组的出0个
        /// </summary>
        /// <returns></returns>
        private List<string> calcHaoMaZuFor0(List<string> allData, List<string> srcNums)
        {
            List<string> resLi = new List<string>();
            int srcNumsCount = srcNums.Count;

            foreach (string oneLineData in allData)
            {
                bool noneThisNum = true;
                for (int i = 0; i < srcNumsCount; i++)
                {
                    string currStr = srcNums[i];
                    //如果含有要出的数，且没有要出的数之外所勾选的数
                    if (oneLineData.IndexOf(currStr) > -1)
                    {
                        noneThisNum = false;
                    }
                }
                if (noneThisNum)
                {
                    resLi.Add(oneLineData);//将分割前的正确数据插入结果集
                }
            }
            resLi.Sort();
            return resLi;
        }


        /// <summary>
        /// 用于计算号码组的出1个
        /// </summary>
        /// <returns></returns>
        private List<string> calcHaoMaZuFor1(List<string> allData, List<string> srcNums, int choiceCount)
        {
            List<string> resLi = new List<string>();
            int srcNumsCount = srcNums.Count;
            int srcNumsCountLessOne = srcNumsCount - 1;

            for (int i = 0; i < srcNumsCount; i++)
            {
                string currStr = srcNums[i];
                foreach (string oneLineData in allData)
                {
                    //如果含有要出的数，且没有要出的数之外所勾选的数
                    if (oneLineData.IndexOf(currStr) > -1)
                    {
                        List<string> tempSrcNums = new List<string>();
                        tempSrcNums.AddRange(srcNums);//用于将其他多余数字筛除
                        tempSrcNums.Remove(currStr);
                        if (noNeedNumClear(tempSrcNums, oneLineData))
                        {
                            resLi.Add(oneLineData);//将分割前的正确数据插入结果集
                        }
                    }
                }
            }
            resLi.Sort();
            return resLi;
        }

        /// <summary>
        /// 用于计算号码组的出2个
        /// </summary>
        /// <returns></returns>
        private List<string> calcHaoMaZuFor2(List<string> allData, List<string> srcNums,int choiceCount)
        {
            List<string> resLi = new List<string>();
            int srcNumsCount = srcNums.Count;
            int srcNumsCountLessOne = srcNumsCount - 1;

            for (int i = 0; i < srcNumsCount; i++)
            {
                string currStr = srcNums[i];
                int temp_i = i;
                
                //组成每一个“出2位数”
                while (temp_i < srcNumsCountLessOne)
                {
                    temp_i++;
                    string nextStr = srcNums[temp_i];

                    foreach (string oneLineData in allData)
                    {
                        //如果含有要出的数，且没有要出的数之外所勾选的数
                        if (oneLineData.IndexOf(currStr) > -1 && 
                            oneLineData.IndexOf(nextStr) > -1)
                        {
                            List<string> tempSrcNums = new List<string>();
                            tempSrcNums.AddRange(srcNums);//用于将其他多余数字筛除
                            tempSrcNums.Remove(currStr);
                            tempSrcNums.Remove(nextStr);
                            if (noNeedNumClear(tempSrcNums, oneLineData))
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
        private List<string> calcHaoMaZuFor3(List<string> allData, List<string> srcNums, int choiceCount)
        {
            List<string> resLi = new List<string>();
            int srcNumsCount = srcNums.Count;
            int srcNumsCountLessOne = srcNumsCount - 1;

            for (int i = 0; i < srcNumsCount; i++)
            {
                string currStr = srcNums[i];
                int temp_i = i;

                //组成每一个“出3位数”
                while (temp_i < srcNumsCountLessOne)
                {
                    temp_i++;
                    string nextStr = srcNums[temp_i];
                    int temp_i2 = temp_i;

                    while (temp_i2 < srcNumsCountLessOne)
                    {
                        temp_i2++;
                        string next2Str = srcNums[temp_i2];

                        foreach (string oneLineData in allData)
                        {
                            //如果含有要出的数，且没有要出的数之外所勾选的数
                            if (oneLineData.IndexOf(currStr) > -1 &&
                                oneLineData.IndexOf(nextStr) > -1 &&
                                oneLineData.IndexOf(next2Str) > -1)
                            {
                                List<string> tempSrcNums = new List<string>();
                                tempSrcNums.AddRange(srcNums);//用于将其他多余数字筛除
                                tempSrcNums.Remove(currStr);
                                tempSrcNums.Remove(nextStr);
                                tempSrcNums.Remove(next2Str);
                                if (noNeedNumClear(tempSrcNums, oneLineData))
                                {
                                    resLi.Add(oneLineData);//将分割前的正确数据插入结果集
                                }
                            }
                        }
                    }
                }
            }
            resLi.Sort();
            return resLi;
        }

        /// <summary>
        /// 用于计算号码组的出4个
        /// </summary>
        /// <returns></returns>
        private List<string> calcHaoMaZuFor4(List<string> allData, List<string> srcNums, int choiceCount)
        {
            List<string> resLi = new List<string>();
            int srcNumsCount = srcNums.Count;
            int srcNumsCountLessOne = srcNumsCount - 1;

            for (int i = 0; i < srcNumsCount; i++)
            {
                string currStr = srcNums[i];
                int temp_i = i;

                //组成每一个“出3位数”
                while (temp_i < srcNumsCountLessOne)
                {
                    temp_i++;
                    string nextStr = srcNums[temp_i];
                    int temp_i2 = temp_i;

                    while (temp_i2 < srcNumsCountLessOne)
                    {
                        temp_i2++;
                        string next2Str = srcNums[temp_i2];
                        int temp_i3 = temp_i2;

                        while (temp_i3 < srcNumsCountLessOne)
                        {
                            temp_i3++;
                            string next3Str = srcNums[temp_i3];

                            foreach (string oneLineData in allData)
                            {
                                //如果含有要出的数，且没有要出的数之外所勾选的数
                                if (oneLineData.IndexOf(currStr) > -1 &&
                                    oneLineData.IndexOf(nextStr) > -1 &&
                                    oneLineData.IndexOf(next2Str) > -1 &&
                                    oneLineData.IndexOf(next3Str) > -1)
                                {
                                    List<string> tempSrcNums = new List<string>();
                                    tempSrcNums.AddRange(srcNums);//用于将其他多余数字筛除
                                    tempSrcNums.Remove(currStr);
                                    tempSrcNums.Remove(nextStr);
                                    tempSrcNums.Remove(next2Str);
                                    tempSrcNums.Remove(next3Str);
                                    if (noNeedNumClear(tempSrcNums, oneLineData))
                                    {
                                        resLi.Add(oneLineData);//将分割前的正确数据插入结果集
                                    }
                                }
                            }
                        }
                    }
                }
            }
            resLi.Sort();
            return resLi;
        }

        /// <summary>
        /// 用于计算号码组的出5个
        /// </summary>
        /// <returns></returns>
        private List<string> calcHaoMaZuFor5(List<string> allData, List<string> srcNums, int choiceCount)
        {
            List<string> resLi = new List<string>();
            int srcNumsCount = srcNums.Count;
            int srcNumsCountLessOne = srcNumsCount - 1;

            for (int i = 0; i < srcNumsCount; i++)
            {
                string currStr = srcNums[i];
                int temp_i = i;

                //组成每一个“出3位数”
                while (temp_i < srcNumsCountLessOne)
                {
                    temp_i++;
                    string nextStr = srcNums[temp_i];
                    int temp_i2 = temp_i;

                    while (temp_i2 < srcNumsCountLessOne)
                    {
                        temp_i2++;
                        string next2Str = srcNums[temp_i2];
                        int temp_i3 = temp_i2;

                        while (temp_i3 < srcNumsCountLessOne)
                        {
                            temp_i3++;
                            string next3Str = srcNums[temp_i3];
                            int temp_i4 = temp_i3;

                            while (temp_i4 < srcNumsCountLessOne)
                            {
                                temp_i4++;
                                string next4Str = srcNums[temp_i4];

                                foreach (string oneLineData in allData)
                                {
                                    //如果含有要出的数，且没有要出的数之外所勾选的数
                                    if (oneLineData.IndexOf(currStr) > -1 &&
                                        oneLineData.IndexOf(nextStr) > -1 &&
                                        oneLineData.IndexOf(next2Str) > -1 &&
                                        oneLineData.IndexOf(next3Str) > -1 &&
                                        oneLineData.IndexOf(next4Str) > -1)
                                    {
                                        List<string> tempSrcNums = new List<string>();
                                        tempSrcNums.AddRange(srcNums);//用于将其他多余数字筛除
                                        tempSrcNums.Remove(currStr);
                                        tempSrcNums.Remove(nextStr);
                                        tempSrcNums.Remove(next2Str);
                                        tempSrcNums.Remove(next3Str);
                                        tempSrcNums.Remove(next4Str);
                                        if (noNeedNumClear(tempSrcNums, oneLineData))
                                        {
                                            resLi.Add(oneLineData);//将分割前的正确数据插入结果集
                                        }
                                    }
                                }
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
                int tempLastTwoNum = Convert.ToInt16(newOneLineData.Substring(newOneLineData.Length - 2));
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

        //号码组区域Combobox监控器1
        private void timer1_Tick(object sender, EventArgs e)
        {
            visibleZuCbx1(this.oneZuGpb, "oneNum", "oneZu");
            visibleZuCbx2(this.twoZuGpb, "twoNum", "twoZu");
            visibleZuCbx3(this.threeZuGpb, "threeNum", "threeZu");
            visibleZuCbx4(this.fourZuGpb, "fourNum", "fourZu");
        }

        private void visibleZuCbx1(Control Gpb, string oneNumName, string oneZuName)
        {
            int countOneNum = 0;

            if (countOneHaoZuCbxOld == 0)
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

            if (countOneNum == countOneHaoZuCbxOld)
            {
                return;
            }
            countOneHaoZuCbxOld = countOneNum;
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

        private void visibleZuCbx2(Control Gpb, string oneNumName, string oneZuName)
        {
            int countOneNum = 0;

            if (countTwoHaoZuCbxOld == 0)
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

            if (countOneNum == countTwoHaoZuCbxOld)
            {
                return;
            }
            countTwoHaoZuCbxOld = countOneNum;
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

        private void visibleZuCbx3(Control Gpb, string oneNumName, string oneZuName)
        {
            int countOneNum = 0;

            if (countThreeHaoZuCbxOld == 0)
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

            if (countOneNum == countThreeHaoZuCbxOld)
            {
                return;
            }
            countThreeHaoZuCbxOld = countOneNum;
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

        private void visibleZuCbx4(Control Gpb, string oneNumName, string oneZuName)
        {
            int countOneNum = 0;

            if (countFourHaoZuCbxOld == 0)
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

            if (countOneNum == countFourHaoZuCbxOld)
            {
                return;
            }
            countFourHaoZuCbxOld = countOneNum;
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

        private void oneZuClearBtn_Click(object sender, EventArgs e)
        {
            clearSingleCheckbox(this.oneZuGpb);
        }

        private void twoZuClearBtn_Click(object sender, EventArgs e)
        {
            clearSingleCheckbox(this.twoZuGpb);
        }

        private void threeZuClearBtn_Click(object sender, EventArgs e)
        {
            clearSingleCheckbox(this.threeZuGpb);
        }

        private void fourZuClearBtn_Click(object sender, EventArgs e)
        {
            clearSingleCheckbox(this.fourZuGpb);
        }

        /// <summary>
        /// 清空单个框体里面的单选框勾选
        /// </summary>
        /// <param name="ctrls"></param>
        private void clearSingleCheckbox(Control ctrls)
        {
            foreach (Control cbx in ctrls.Controls)
            {
                if(cbx is CheckBox){
                    (cbx as CheckBox).Checked = false;
                }
            }
        }
    }
}
