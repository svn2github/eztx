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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        #region 主数据组

        private string[] f3Data;

        public void getF3Data(string[] args)
        {
            f3Data = args;//从main中得到f1的数据并将其赋值给本页面
        }

        private string[] heZhi()//合值
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = f3Data;

            List<int> nums = new List<int>();
            foreach (Control ctls in this.heZhiGpb.Controls)
            {
                bool isNum = isNumber(ctls.Text);
                if ((ctls as CheckBox).Checked == true && isNum == true)
                {
                    nums.Add(Convert.ToInt16(ctls.Text));
                }
            }

            if (nums.Count > 0)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        int allNumSum = Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1));
                        if (
                            allNumSum.ToString().Substring(allNumSum.ToString().Length - 1, 1) == nums[j].ToString()
                        )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            else
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] kuaJu()//跨距
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = heZhi();

            List<int> nums = new List<int>();
            foreach (Control ctls in this.kuaJuGpb.Controls)
            {
                bool isNum = isNumber(ctls.Text);
                if ((ctls as CheckBox).Checked == true && isNum == true)
                {
                    nums.Add(Convert.ToInt16(ctls.Text));
                }
            }

            if (nums.Count > 0)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        int a = Convert.ToInt32(allNum[i].Substring(0, 1));
                        int b = Convert.ToInt32(allNum[i].Substring(1, 1));
                        int c = Convert.ToInt32(allNum[i].Substring(2, 1));
                        int max = 0;
                        int min = 0;

                        if (a > b)
                        {
                            if (a > c)
                            {
                                max = a;
                            }
                            else
                            {
                                max = c;
                            }
                        }
                        else
                        {
                            if (b > c)
                            {
                                max = b;
                            }
                            else
                            {
                                max = c;
                            }
                        }

                        if (a < b)
                        {
                            if (a < c)
                            {
                                min = a;
                            }
                            else
                            {
                                min = c;
                            }
                        }
                        else
                        {
                            if (b < c)
                            {
                                min = b;
                            }
                            else
                            {
                                min = c;
                            }
                        }

                        if (
                            max - min == nums[j]
                        )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            else
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] shaHeZhi()//杀合值
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = kuaJu();

            List<int> nums = new List<int>();
            foreach (Control ctls in this.shaHeZhiGpb.Controls)
            {
                bool isNum = isNumber(ctls.Text);
                if ((ctls as CheckBox).Checked == false && isNum == true)
                {
                    nums.Add(Convert.ToInt16(ctls.Text));
                }
            }

            if (nums.Count > 0)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        int allNumSum = Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1));
                        if (
                            allNumSum.ToString().Substring(allNumSum.ToString().Length - 1, 1) != nums[j].ToString()
                        )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            else
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] chaHe()//差合
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = shaHeZhi();

            List<int> nums = new List<int>();
            foreach (Control ctls in this.chaHeGpb.Controls)
            {
                bool isNum = isNumber(ctls.Text);
                if ((ctls as CheckBox).Checked == true && isNum == true)
                {
                    nums.Add(Convert.ToInt16(ctls.Text));
                }
            }

            if (nums.Count > 0)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                        int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                        int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                        int aa = Math.Abs(a - b);
                        int bb = Math.Abs(a - c);
                        int cc = Math.Abs(b - c);

                        int f = Convert.ToInt16((aa + bb + cc).ToString().Substring((aa + bb + cc).ToString().Length - 1, 1));

                        if (
                            f == nums[j]
                        )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            else
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] touDx()//龙头大小
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = chaHe();

            List<string> nums = new List<string>();
            foreach (Control ctls in this.touDxGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums.Add(ctls.Text);
                }
            }

            int[] bigNums = new int[] { 5, 6, 7, 8, 9 };
            int[] smallNums = new int[] { 0, 1, 2, 3, 4 };

            if (nums.Count > 0)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                        int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                        int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                        if (nums[0].Equals("大"))
                        {
                            if (bigNums.Contains(a))
                            {
                                result.Add(allNum[i]);
                            }
                        }

                        if (nums[0].Equals("小"))
                        {
                            if (smallNums.Contains(a))
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] touDs()//龙头单双
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = chaHe();

            List<string> nums = new List<string>();
            foreach (Control ctls in this.touDsGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums.Add(ctls.Text);
                }
            }

            int[] danNums = new int[] { 1, 3, 5, 7, 9 };
            int[] shuangNums = new int[] { 0, 2, 4, 6, 8 };

            if (nums.Count > 0)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                        int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                        int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                        if (nums[0].Equals("单"))
                        {
                            if (danNums.Contains(a))
                            {
                                result.Add(allNum[i]);
                            }
                        }

                        if (nums[0].Equals("双"))
                        {
                            if (shuangNums.Contains(a))
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] touZh()//龙头质合
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = chaHe();

            List<string> nums = new List<string>();
            foreach (Control ctls in this.touZhGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums.Add(ctls.Text);
                }
            }

            int[] zhiNums = new int[] { 1, 2, 3, 5, 7 };
            int[] HeNums = new int[] { 0, 4, 6, 8, 9 };

            if (nums.Count > 0)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                        int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                        int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                        if (nums[0].Equals("质"))
                        {
                            if (zhiNums.Contains(a))
                            {
                                result.Add(allNum[i]);
                            }
                        }

                        if (nums[0].Equals("和"))
                        {
                            if (HeNums.Contains(a))
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] weiDx()//凤尾大小
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = chaHe();

            List<string> nums = new List<string>();
            foreach (Control ctls in this.weiDxGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums.Add(ctls.Text);
                }
            }

            int[] bigNums = new int[] { 5, 6, 7, 8, 9 };
            int[] smallNums = new int[] { 0, 1, 2, 3, 4 };

            if (nums.Count > 0)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                        int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                        int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                        if (nums[0].Equals("大"))
                        {
                            if (bigNums.Contains(c))
                            {
                                result.Add(allNum[i]);
                            }
                        }

                        if (nums[0].Equals("小"))
                        {
                            if (smallNums.Contains(c))
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] weiDs()//凤尾单双
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = chaHe();

            List<string> nums = new List<string>();
            foreach (Control ctls in this.weiDsGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums.Add(ctls.Text);
                }
            }

            int[] danNums = new int[] { 1, 3, 5, 7, 9 };
            int[] shuangNums = new int[] { 0, 2, 4, 6, 8 };

            if (nums.Count > 0)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                        int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                        int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                        if (nums[0].Equals("单"))
                        {
                            if (danNums.Contains(c))
                            {
                                result.Add(allNum[i]);
                            }
                        }

                        if (nums[0].Equals("双"))
                        {
                            if (shuangNums.Contains(c))
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] weiZh()//凤尾质合
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = chaHe();

            List<string> nums = new List<string>();
            foreach (Control ctls in this.weiZhGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums.Add(ctls.Text);
                }
            }

            int[] zhiNums = new int[] { 1, 2, 3, 5, 7 };
            int[] HeNums = new int[] { 0, 4, 6, 8, 9 };

            if (nums.Count > 0)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < nums.Count(); j++)
                    {
                        int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                        int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                        int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                        if (nums[0].Equals("质"))
                        {
                            if (zhiNums.Contains(c))
                            {
                                result.Add(allNum[i]);
                            }
                        }

                        if (nums[0].Equals("和"))
                        {
                            if (HeNums.Contains(c))
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                result.AddRange(allNum);
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] longTouFengWei() //判断龙头凤尾
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();

            int nums = 0;

            List<string> mm = new List<string>();
            foreach (Control ctls in this.ltfwMustGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    mm.Add(ctls.Text);
                }
            }

            if (mm.Contains("包含"))
            {
                foreach (Control ctls in this.touDxGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(touDx());
                    }
                }
                foreach (Control ctls in this.touDsGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(touDs());
                    }
                }
                foreach (Control ctls in this.touZhGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(touZh());
                    }
                }
                foreach (Control ctls in this.weiDxGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(weiDx());
                    }
                }
                foreach (Control ctls in this.weiDsGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(weiDs());
                    }
                }
                foreach (Control ctls in this.weiZhGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(weiZh());
                    }
                }
            }

            if (mm.Contains("杀去"))
            {
                foreach (Control ctls in this.touDxGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(touDx());
                    }
                }
                foreach (Control ctls in this.touDsGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(touDs());
                    }
                }
                foreach (Control ctls in this.touZhGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(touZh());
                    }
                }
                foreach (Control ctls in this.weiDxGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(weiDx());
                    }
                }
                foreach (Control ctls in this.weiDsGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(weiDs());
                    }
                }
                foreach (Control ctls in this.weiZhGpb.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums++;
                        result.AddRange(weiZh());
                    }
                }

                List<string> temp = new List<string>();
                temp.AddRange(chaHe());
                for (int i = 0; i < result.Count(); i++)
                {
                    temp.Remove(result[i]);
                }
                result.Clear();
                result.AddRange(temp);

            }

            if (nums == 0)
            {
                result.AddRange(chaHe());
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        public string[] numberPro() //号码属性
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = longTouFengWei();
            string[] zhiNums = new string[] { "1", "2", "3", "5", "7" };
            string[] danNums = new string[] { "1", "3", "5", "7", "9" };
            string[] xiaoNums = new string[] { "0", "1", "2", "3", "4" };

            int cbkCount = 0;
            foreach (Control ctls in this.numberProGpb.Controls)
            {
                if (ctls is CheckBox)
                    if ((ctls as CheckBox).Checked == true)
                    {
                        cbkCount++;
                        if (ctls.Name.Equals("zs0"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (!zhiNums.Contains(a) && !zhiNums.Contains(b) && !zhiNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("ds0"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (!danNums.Contains(a) && !danNums.Contains(b) && !danNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("xs0"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (!xiaoNums.Contains(a) && !xiaoNums.Contains(b) && !xiaoNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }

                        if (ctls.Name.Equals("zs1"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (zhiNums.Contains(a) && !zhiNums.Contains(b) && !zhiNums.Contains(c))
                                    ||
                                    (!zhiNums.Contains(a) && zhiNums.Contains(b) && !zhiNums.Contains(c))
                                    ||
                                    (!zhiNums.Contains(a) && !zhiNums.Contains(b) && zhiNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("ds1"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (danNums.Contains(a) && !danNums.Contains(b) && !danNums.Contains(c))
                                    ||
                                    (!danNums.Contains(a) && danNums.Contains(b) && !danNums.Contains(c))
                                    ||
                                    (!danNums.Contains(a) && !danNums.Contains(b) && danNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("xs1"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (xiaoNums.Contains(a) && !xiaoNums.Contains(b) && !xiaoNums.Contains(c))
                                    ||
                                    (!xiaoNums.Contains(a) && xiaoNums.Contains(b) && !xiaoNums.Contains(c))
                                    ||
                                    (!xiaoNums.Contains(a) && !xiaoNums.Contains(b) && xiaoNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }

                        if (ctls.Name.Equals("zs2"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (zhiNums.Contains(a) && zhiNums.Contains(b) && !zhiNums.Contains(c))
                                    ||
                                    (!zhiNums.Contains(a) && zhiNums.Contains(b) && zhiNums.Contains(c))
                                    ||
                                    (zhiNums.Contains(a) && !zhiNums.Contains(b) && zhiNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("ds2"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (danNums.Contains(a) && danNums.Contains(b) && !danNums.Contains(c))
                                    ||
                                    (!danNums.Contains(a) && danNums.Contains(b) && danNums.Contains(c))
                                    ||
                                    (danNums.Contains(a) && !danNums.Contains(b) && danNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("xs2"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (xiaoNums.Contains(a) && xiaoNums.Contains(b) && !xiaoNums.Contains(c))
                                    ||
                                    (!xiaoNums.Contains(a) && xiaoNums.Contains(b) && xiaoNums.Contains(c))
                                    ||
                                    (xiaoNums.Contains(a) && !xiaoNums.Contains(b) && xiaoNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }

                        if (ctls.Name.Equals("zs3"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (zhiNums.Contains(a) && zhiNums.Contains(b) && zhiNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("ds3"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (danNums.Contains(a) && danNums.Contains(b) && danNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("xs3"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (xiaoNums.Contains(a) && xiaoNums.Contains(b) && xiaoNums.Contains(c))
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
            result1.Sort();
            return result1.ToArray();
        }

        private string[] phJia() //平衡加
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = numberPro();

            if (jiaCkb.Checked == true)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                    int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                    int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                    int leftvv = (10 - a + b);
                    int rightvv = (10 - b + c);
                    if (leftvv > rightvv)
                    {
                        result.Add(allNum[i]);
                    }
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            result1.Sort();
            return result1.ToArray();
        }

        private string[] phJian() //平衡减
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = numberPro();

            if (jianCkb.Checked == true)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                    int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                    int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                    int leftvv = (10 - a + b);
                    int rightvv = (10 - b + c);
                    if (leftvv < rightvv)
                    {
                        result.Add(allNum[i]);
                    }
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            result1.Sort();
            return result1.ToArray();
        }

        private string[] phDeng() //平衡等
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = numberPro();

            if (dengCkb.Checked == true)
            {
                for (int i = 0; i < allNum.Count(); i++)
                {
                    int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                    int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                    int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                    int leftvv = (10 - a + b);
                    int rightvv = (10 - b + c);
                    if (leftvv == rightvv)
                    {
                        result.Add(allNum[i]);
                    }
                }
            }

            List<string> result1 = result.Distinct().ToList();//去除重复项
            result1.Sort();
            return result1.ToArray();
        }

        public string[] pingHengZhiShu()//平衡指数
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = numberPro();

            int overMy = 0;
            List<int> nums = new List<int>();
            foreach (Control ctls in this.pHZSGpb.Controls)
            {
                bool isNum = isNumber(ctls.Text);
                if (ctls is CheckBox)
                {
                    if ((ctls as CheckBox).Checked == true && isNum == true)
                    {
                        nums.Add(Convert.ToInt16(ctls.Text));
                    }
                }
            }

            if (nums.Count == 1)
            {
                if (nums.Contains(1))
                {
                    if (jiaCkb.Checked == true)
                    {
                        overMy++;
                        result.AddRange(phJia());
                    }

                    if (jianCkb.Checked == true)
                    {
                        overMy++;
                        result.AddRange(phJian());
                    }

                    if (dengCkb.Checked == true)
                    {
                        overMy++;
                        result.AddRange(phDeng());
                    }
                }

                if (nums.Contains(0))
                {
                    if (jiaCkb.Checked == true)
                    {
                        overMy++;
                        result.AddRange(phJia());
                    }

                    if (jianCkb.Checked == true)
                    {
                        overMy++;
                        result.AddRange(phJian());
                    }

                    if (dengCkb.Checked == true)
                    {
                        overMy++;
                        result.AddRange(phDeng());
                    }

                    List<string> temp = new List<string>();
                    temp.AddRange(chaHe());
                    for (int i = 0; i < result.Count(); i++)
                    {
                        temp.Remove(result[i]);
                    }
                    result.Clear();
                    result.AddRange(temp);
                }

            }

            if (nums.Count == 2)
            {
                result.AddRange(allNum);
            }

            if (overMy == 0)
                result.AddRange(allNum);

            List<string> result1 = result.Distinct().ToList();//去除重复项
            result1.Sort();
            return result1.ToArray();
        }

        //判断字符串是否是数字
        private bool isNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 出号个数

        public Boolean chuHaoGeShu()
        {
            int nums = 0;
            bool rtn = true;

            foreach (Control ctls in this.touDxGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums++;
                }
            }
            foreach (Control ctls in this.touDsGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums++;
                }
            }
            foreach (Control ctls in this.touZhGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums++;
                }
            }
            foreach (Control ctls in this.weiDxGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums++;
                }
            }
            foreach (Control ctls in this.weiDsGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums++;
                }
            }
            foreach (Control ctls in this.weiZhGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    nums++;
                }
            }

            List<string> mm = new List<string>();
            foreach (Control ctls in this.ltfwMustGpb.Controls)
            {
                if ((ctls as CheckBox).Checked == true)
                {
                    mm.Add(ctls.Text);
                }
            }

            if ((nums > 0 && mm.Count > 0) || (nums == 0 && mm.Count >= 0))
            {
                rtn = true;
            }
            else
            {
                MessageBox.Show("请勾选\"龙头凤尾条件设置\"区域中的条件才能生效您所设置的龙头凤尾", "温馨提示");
                rtn = false;
            }

            if (jiaCkb.Checked == true || jianCkb.Checked == true || dengCkb.Checked == true)
            {
                List<int> numss = new List<int>();
                foreach (Control ctls in this.pHZSGpb.Controls)
                {
                    bool isNum = isNumber(ctls.Text);
                    if (ctls is CheckBox)
                    {
                        if ((ctls as CheckBox).Checked == true && isNum == true)
                        {
                            numss.Add(Convert.ToInt16(ctls.Text));
                        }
                    }
                }
                if (numss.Count == 0)
                {
                    MessageBox.Show("勾选\"平衡指数\"的同时需要勾选后面的出现条件才可生效！", "温馨提示");
                    rtn= false;
                }
            }

            return rtn;
        }

        #endregion

        #region Groupbox重绘,全选按钮,清空页面复选框,checkbox改变

        //清空页面checkbox复选框
        public void clearCheckBox()
        {
            foreach (Control ctls in this.Controls)
            {
                if (ctls is GroupBox)
                {
                    foreach (Control ctl in ctls.Controls)
                    {
                        if (ctl is CheckBox)
                        {
                            (ctl as CheckBox).Checked = false;
                        }
                    }
                }
            }
        }

        //合值Gpb
        private void heZhiGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(heZhiGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(heZhiGpb.Text, heZhiGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(heZhiGpb.Text, heZhiGpb.Font).Width + 8, 7, heZhiGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, heZhiGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, heZhiGpb.Height - 2, heZhiGpb.Width - 2, heZhiGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, heZhiGpb.Width - 2, 7, heZhiGpb.Width - 2, heZhiGpb.Height - 2);//右边那条竖线
        }

        //跨距Gpb
        private void kuaJuGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(kuaJuGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(kuaJuGpb.Text, kuaJuGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(kuaJuGpb.Text, kuaJuGpb.Font).Width + 8, 7, kuaJuGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, kuaJuGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, kuaJuGpb.Height - 2, kuaJuGpb.Width - 2, kuaJuGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, kuaJuGpb.Width - 2, 7, kuaJuGpb.Width - 2, kuaJuGpb.Height - 2);//右边那条竖线
        }

        //杀合值Gpb
        private void shaHeZhiGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(shaHeZhiGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(shaHeZhiGpb.Text, shaHeZhiGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(shaHeZhiGpb.Text, shaHeZhiGpb.Font).Width + 8, 7, shaHeZhiGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, shaHeZhiGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, shaHeZhiGpb.Height - 2, shaHeZhiGpb.Width - 2, shaHeZhiGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, shaHeZhiGpb.Width - 2, 7, shaHeZhiGpb.Width - 2, shaHeZhiGpb.Height - 2);//右边那条竖线
        }

        //差合Gpb
        private void chaHeGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(chaHeGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(chaHeGpb.Text, chaHeGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(chaHeGpb.Text, chaHeGpb.Font).Width + 8, 7, chaHeGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, chaHeGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, chaHeGpb.Height - 2, chaHeGpb.Width - 2, chaHeGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, chaHeGpb.Width - 2, 7, chaHeGpb.Width - 2, chaHeGpb.Height - 2);//右边那条竖线
        }

        //龙头大小Gpb
        private void touDxGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(touDxGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(touDxGpb.Text, touDxGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(touDxGpb.Text, touDxGpb.Font).Width + 8, 7, touDxGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, touDxGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, touDxGpb.Height - 2, touDxGpb.Width - 2, touDxGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, touDxGpb.Width - 2, 7, touDxGpb.Width - 2, touDxGpb.Height - 2);//右边那条竖线
        }

        //龙头单双Gpb
        private void touDsGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(touDsGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(touDsGpb.Text, touDsGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(touDsGpb.Text, touDsGpb.Font).Width + 8, 7, touDsGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, touDsGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, touDsGpb.Height - 2, touDsGpb.Width - 2, touDsGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, touDsGpb.Width - 2, 7, touDsGpb.Width - 2, touDsGpb.Height - 2);//右边那条竖线
        }

        //龙头质合Gpb
        private void touZhGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(touZhGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(touZhGpb.Text, touZhGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(touZhGpb.Text, touZhGpb.Font).Width + 8, 7, touZhGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, touZhGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, touZhGpb.Height - 2, touZhGpb.Width - 2, touZhGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, touZhGpb.Width - 2, 7, touZhGpb.Width - 2, touZhGpb.Height - 2);//右边那条竖线
        }

        //凤尾大小Gpb
        private void weiDxGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(weiDxGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(weiDxGpb.Text, weiDxGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(weiDxGpb.Text, weiDxGpb.Font).Width + 8, 7, weiDxGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, weiDxGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, weiDxGpb.Height - 2, weiDxGpb.Width - 2, weiDxGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, weiDxGpb.Width - 2, 7, weiDxGpb.Width - 2, weiDxGpb.Height - 2);//右边那条竖线
        }

        //凤尾单双Gpb
        private void weiDsGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(weiDsGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(weiDsGpb.Text, weiDsGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(weiDsGpb.Text, weiDsGpb.Font).Width + 8, 7, weiDsGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, weiDsGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, weiDsGpb.Height - 2, weiDsGpb.Width - 2, weiDsGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, weiDsGpb.Width - 2, 7, weiDsGpb.Width - 2, weiDsGpb.Height - 2);//右边那条竖线
        }

        //凤尾质合Gpb
        private void weiZhGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(weiZhGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(weiZhGpb.Text, weiZhGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(weiZhGpb.Text, weiZhGpb.Font).Width + 8, 7, weiZhGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, weiZhGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, weiZhGpb.Height - 2, weiZhGpb.Width - 2, weiZhGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, weiZhGpb.Width - 2, 7, weiZhGpb.Width - 2, weiZhGpb.Height - 2);//右边那条竖线
        }

        //龙头凤尾出号条件Gpb
        private void ltfwMustGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(ltfwMustGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(ltfwMustGpb.Text, ltfwMustGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(ltfwMustGpb.Text, ltfwMustGpb.Font).Width + 8, 7, ltfwMustGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, ltfwMustGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, ltfwMustGpb.Height - 2, ltfwMustGpb.Width - 2, ltfwMustGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, ltfwMustGpb.Width - 2, 7, ltfwMustGpb.Width - 2, ltfwMustGpb.Height - 2);//右边那条竖线
        }

        //号码属性
        private void numberProGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(numberProGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(numberProGpb.Text, numberProGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(numberProGpb.Text, numberProGpb.Font).Width + 8, 7, numberProGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, numberProGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, numberProGpb.Height - 2, numberProGpb.Width - 2, numberProGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, numberProGpb.Width - 2, 7, numberProGpb.Width - 2, numberProGpb.Height - 2);//右边那条竖线
        }

        //平衡指数Gpb
        private void pHZSGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(pHZSGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(pHZSGpb.Text, pHZSGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(pHZSGpb.Text, pHZSGpb.Font).Width + 8, 7, pHZSGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, pHZSGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, pHZSGpb.Height - 2, pHZSGpb.Width - 2, pHZSGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, pHZSGpb.Width - 2, 7, pHZSGpb.Width - 2, pHZSGpb.Height - 2);//右边那条竖线
        }

        //合值全选
        private void locBaiShiChaChAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.heZhiGpb.Controls)
            {
                if (ctl is CheckBox && locBaiShiChaChAll.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //跨距全选
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.kuaJuGpb.Controls)
            {
                if (ctl is CheckBox && checkBox1.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //杀合值全选
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.shaHeZhiGpb.Controls)
            {
                if (ctl is CheckBox && checkBox12.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //差合全选
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.chaHeGpb.Controls)
            {
                if (ctl is CheckBox && checkBox23.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //0
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true)
            {
                checkBox98.Enabled = false;

                checkBox98.Checked = false;
            }
            else
            {
                checkBox98.Enabled = true;
            }
        }

        //1
        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked == true)
            {
                checkBox97.Enabled = false;

                checkBox97.Checked = false;
            }
            else
            {
                checkBox97.Enabled = true;
            }
        }

        //2
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                checkBox96.Enabled = false;

                checkBox96.Checked = false;
            }
            else
            {
                checkBox96.Enabled = true;
            }
        }

        //3
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                checkBox95.Enabled = false;

                checkBox95.Checked = false;
            }
            else
            {
                checkBox95.Enabled = true;
            }
        }

        //4
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                checkBox94.Enabled = false;

                checkBox94.Checked = false;
            }
            else
            {
                checkBox94.Enabled = true;
            }
        }

        //5
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                checkBox89.Enabled = false;

                checkBox89.Checked = false;
            }
            else
            {
                checkBox89.Enabled = true;
            }
        }

        //6
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                checkBox91.Enabled = false;

                checkBox91.Checked = false;
            }
            else
            {
                checkBox91.Enabled = true;
            }
        }

        //7
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true)
            {
                checkBox92.Enabled = false;

                checkBox92.Checked = false;
            }
            else
            {
                checkBox92.Enabled = true;
            }
        }

        //8
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true)
            {
                checkBox93.Enabled = false;

                checkBox93.Checked = false;
            }
            else
            {
                checkBox93.Enabled = true;
            }
        }

        //9
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                checkBox90.Enabled = false;

                checkBox90.Checked = false;
            }
            else
            {
                checkBox90.Enabled = true;
            }
        }

        //龙头大Ckb
        private void touBigCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (touBigCkb.Checked == true)
            {
                touSmallCkb.Enabled = false;
                touSmallCkb.Checked = false;
            }
            else
            {
                touSmallCkb.Enabled = true;
            }
        }

        //龙头小Ckb
        private void touSmallCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (touSmallCkb.Checked == true)
            {
                touBigCkb.Enabled = false;
                touBigCkb.Checked = false;
            }
            else
            {
                touBigCkb.Enabled = true;
            }
        }

        //龙头单Ckb
        private void touDanCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (touDanCkb.Checked == true)
            {
                touShuangCkb.Enabled = false;
                touShuangCkb.Checked = false;
            }
            else
            {
                touShuangCkb.Enabled = true;
            }
        }

        //龙头双Ckb
        private void touShuangCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (touShuangCkb.Checked == true)
            {
                touDanCkb.Enabled = false;
                touDanCkb.Checked = false;
            }
            else
            {
                touDanCkb.Enabled = true;
            }
        }

        //龙头质Ckb
        private void touZhiCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (touZhiCkb.Checked == true)
            {
                touHeCkb.Enabled = false;
                touHeCkb.Checked = false;
            }
            else
            {
                touHeCkb.Enabled = true;
            }
        }

        //龙头和Ckb
        private void touHeCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (touHeCkb.Checked == true)
            {
                touZhiCkb.Enabled = false;
                touZhiCkb.Checked = false;
            }
            else
            {
                touZhiCkb.Enabled = true;
            }
        }

        //凤尾大Ckb
        private void weiBigCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (weiBigCkb.Checked == true)
            {
                weiSmallCkb.Enabled = false;
                weiSmallCkb.Checked = false;
            }
            else
            {
                weiSmallCkb.Enabled = true;
            }
        }

        //凤尾小Ckb
        private void weiSmallCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (weiSmallCkb.Checked == true)
            {
                weiBigCkb.Enabled = false;
                weiBigCkb.Checked = false;
            }
            else
            {
                weiBigCkb.Enabled = true;
            }
        }

        //凤尾单Ckb
        private void weiDanCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (weiDanCkb.Checked == true)
            {
                weiShuangCkb.Enabled = false;
                weiShuangCkb.Checked = false;
            }
            else
            {
                weiShuangCkb.Enabled = true;
            }
        }

        //凤尾双Ckb
        private void weiShuangCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (weiShuangCkb.Checked == true)
            {
                weiDanCkb.Enabled = false;
                weiDanCkb.Checked = false;
            }
            else
            {
                weiDanCkb.Enabled = true;
            }
        }

        //凤尾质Ckb
        private void weiZhiCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (weiZhiCkb.Checked == true)
            {
                weiHeCkb.Enabled = false;
                weiHeCkb.Checked = false;
            }
            else
            {
                weiHeCkb.Enabled = true;
            }
        }

        //凤尾和Ckb
        private void weiHeCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (weiHeCkb.Checked == true)
            {
                weiZhiCkb.Enabled = false;
                weiZhiCkb.Checked = false;
            }
            else
            {
                weiZhiCkb.Enabled = true;
            }
        }

        //龙头凤尾包含
        private void baoHanCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (baoHanCkb.Checked == true)
            {
                shaQuCkb.Enabled = false;
                shaQuCkb.Checked = false;
            }
            else
            {
                shaQuCkb.Enabled = true;
            }
        }

        //龙头凤尾杀去
        private void shaQuCkb_CheckedChanged(object sender, EventArgs e)
        {
            if (shaQuCkb.Checked == true)
            {
                baoHanCkb.Enabled = false;
                baoHanCkb.Checked = false;
            }
            else
            {
                baoHanCkb.Enabled = true;
            }
        }

        #endregion


    }
}
