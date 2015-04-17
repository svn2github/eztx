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

        private void Form4_Load(object sender, EventArgs e)
        {
            Tools.SetGroupBoxPaintAll(this.Controls);
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

            if (killKuaDu.Checked == false)
            {
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
            else
            {
                List<int> nums = new List<int>();
                result.AddRange(allNum);

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
                                result.Remove(allNum[i]);
                            }
                        }
                    }
                }

                List<string> result1 = result.Distinct().ToList();//去除重复项
                return result1.ToArray();
            
            }
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

        private string[] quanTaiCal() //全态计算
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = numberPro();
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

                        if (ctls.Name.Equals("zhi"))
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
                        else if (ctls.Name.Equals("dan"))
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
                        else if (ctls.Name.Equals("xiao"))
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
                        else if (ctls.Name.Equals("he"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (heNums.Contains(a) && heNums.Contains(b) && heNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("shuang"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (shuangNums.Contains(a) && shuangNums.Contains(b) && shuangNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("da"))
                        {
                            for (int i = 0; i < allNum.Count(); i++)
                            {
                                string a = allNum[i].Substring(0, 1);
                                string b = allNum[i].Substring(1, 1);
                                string c = allNum[i].Substring(2, 1);
                                if (
                                    (daNums.Contains(a) && daNums.Contains(b) && daNums.Contains(c))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                        else if (ctls.Name.Equals("zuSan"))
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
            result1.Sort();
            return result1.ToArray();
        }

        private string[] zuiDaLinMaJuLiCal()//最大邻码跨距
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = quanTaiCal();
            int countChecked = 0;//计算勾选过数字没
            foreach (Control ctls in this.zuiDaLinMaKuaJu.Controls)
            {
                if (ctls is CheckBox == false || (ctls as CheckBox).Checked == false)
                {
                    continue;
                }
                countChecked++;

                int _kuaJu = Convert.ToInt16(ctls.Name.Split('_')[1]);//拿到勾选的最大邻码跨距
                for (int i = 0; i < allNum.Length; i++)
                {
                    int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                    int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                    int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                    int leftCenter = 9 - a + b;//得到百位与十位在立体走势图中的空格数
                    int centerRight = 9 - b + c;//得到十位与个位在立体走势图中的空格数
                    if (leftCenter > centerRight && leftCenter == _kuaJu)//如果左边大于右边
                    {
                        result.Add(allNum[i]);
                    }

                    if (centerRight > leftCenter && centerRight == _kuaJu)//如果右边大于左边
                    {
                        result.Add(allNum[i]);
                    }

                    if (leftCenter == centerRight && centerRight == _kuaJu)//如果两个跨距相等
                    {
                        result.Add(allNum[i]);
                    }

                }
            }
            if (countChecked == 0)
            {
                result.AddRange(allNum);
            }
            return result.ToArray();
        }

        private string[] bianLinHeCal()//边临和
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = zuiDaLinMaJuLiCal();
            int countChecked = 0;//计算勾选过数字没
            foreach (Control ctls in this.bianLinHe.Controls)
            {
                if (ctls is CheckBox == false || (ctls as CheckBox).Checked == false)
                {
                    continue;
                }
                countChecked++;

                int _blh = Convert.ToInt32(ctls.Name.Split('_')[1]);//拿到勾选的边临和

                for (int i = 0; i < allNum.Length; i++)
                {
                    int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                    int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                    int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                    //反边球运算 开始
                    int left = a;//得到百位之前空格数
                    int right = 9 - c;//得到个位之后空格数
                    int _fbq=left + right;
                    //反边球运算 结束

                    int leftCenter = 9 - a + b;//得到百位与十位在立体走势图中的空格数
                    int centerRight = 9 - b + c;//得到十位与个位在立体走势图中的空格数
                    if (leftCenter > centerRight && leftCenter + _fbq == _blh)//如果左边大于右边
                    {
                        result.Add(allNum[i]);
                    }

                    if (centerRight > leftCenter && centerRight + _fbq == _blh)//如果右边大于左边
                    {
                        result.Add(allNum[i]);
                    }

                    if (leftCenter == centerRight && centerRight + _fbq == _blh)//如果两个跨距相等
                    {
                        result.Add(allNum[i]);
                    }

                }
            }
            if (countChecked == 0)
            {
                result.AddRange(allNum);
            }

            return result.ToArray();
        }

        private string[] fanBianQiuCal()//反边球
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = bianLinHeCal();
            int countChecked = 0;//计算勾选过数字没
            foreach (Control ctls in this.fanBianQiu.Controls)
            {
                if (ctls is CheckBox == false || (ctls as CheckBox).Checked == false)
                {
                    continue;
                }
                countChecked++;

                int _fbq = Convert.ToInt16(ctls.Name.Split('_')[1]);//拿到勾选的反边球

                for (int i = 0; i < allNum.Length; i++)
                {
                    int a = Convert.ToInt16(allNum[i].Substring(0, 1));
                    int b = Convert.ToInt16(allNum[i].Substring(1, 1));
                    int c = Convert.ToInt16(allNum[i].Substring(2, 1));

                    int left = a;//得到百位之前空格数
                    int right = 9 - c;//得到个位之后空格数
                    if (left + right == _fbq)
                    {
                        result.Add(allNum[i]);
                    }

                }

            }
            if (countChecked == 0)
            {
                result.AddRange(allNum);
            }

            return result.ToArray();
        }

        private string[] phJia() //平衡加
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = fanBianQiuCal();
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
            string[] allNum = fanBianQiuCal();

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
            string[] allNum = fanBianQiuCal();

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
            string[] allNum = fanBianQiuCal();

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
                    rtn = false;
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

        /// <summary>
        /// 页面上GroupBox和CheckBox设置
        /// </summary>
        /// <param name="gpb"></param>
        /// <param name="ckb"></param>
        private void GroupBoxAndCheckBox(GroupBox gpb,CheckBox ckb) 
        {
            foreach (Control ctl in gpb.Controls)
            {
                if (ctl is CheckBox && ckb.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //合值全选
        private void locBaiShiChaChAll_CheckedChanged(object sender, EventArgs e)
        {
            GroupBoxAndCheckBox(heZhiGpb, locBaiShiChaChAll);
        }

        //跨距全选
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GroupBoxAndCheckBox(kuaJuGpb, checkBox1);
        }

        //杀合值全选
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            GroupBoxAndCheckBox(shaHeZhiGpb, checkBox12);
        }

        //差合全选
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            GroupBoxAndCheckBox(chaHeGpb, checkBox23);
        }

        /// <summary>
        /// 设置所有的CheckBox选中与否
        /// </summary>
        /// <param name="chk1"></param>
        /// <param name="chk2"></param>
        private void SetAllCheckBoxChanged(CheckBox chk1, CheckBox chk2)
        {
            if (chk1.Checked == true)
            {
                chk2.Enabled = false;
                chk2.Checked = false;
            }
            else
            {
                chk2.Enabled = true;
            }
        }

        //0
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(checkBox22, checkBox98);
        }

        //1
        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(checkBox21, checkBox97);
        }

        //2
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(checkBox20, checkBox96);
        }

        //3
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(checkBox19, checkBox95);
        }

        //4
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(checkBox18, checkBox94);
        }

        //5
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(checkBox13, checkBox89);
        }

        //6
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(checkBox15, checkBox91);
        }

        //7
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(checkBox16, checkBox92);
        }

        //8
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(checkBox17, checkBox93);
        }

        //9
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(checkBox14, checkBox90);
        }

        //龙头大Ckb
        private void touBigCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(touBigCkb, touSmallCkb);
        }

        //龙头小Ckb
        private void touSmallCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(touSmallCkb, touBigCkb);
        }

        //龙头单Ckb
        private void touDanCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(touDanCkb, touShuangCkb);
        }

        //龙头双Ckb
        private void touShuangCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(touShuangCkb, touDanCkb);
        }

        //龙头质Ckb
        private void touZhiCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(touZhiCkb, touHeCkb);
        }

        //龙头和Ckb
        private void touHeCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(touHeCkb, touZhiCkb);
        }

        //凤尾大Ckb
        private void weiBigCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(weiBigCkb, weiSmallCkb);
        }

        //凤尾小Ckb
        private void weiSmallCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(weiSmallCkb, weiBigCkb);
        }

        //凤尾单Ckb
        private void weiDanCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(weiDanCkb, weiShuangCkb);
        }

        //凤尾双Ckb
        private void weiShuangCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(weiShuangCkb, weiDanCkb);
        }

        //凤尾质Ckb
        private void weiZhiCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(weiZhiCkb, weiHeCkb);
        }

        //凤尾和Ckb
        private void weiHeCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(weiHeCkb, weiZhiCkb);
        }

        //龙头凤尾包含
        private void baoHanCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(baoHanCkb, shaQuCkb);
        }

        //龙头凤尾杀去
        private void shaQuCkb_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckBoxChanged(shaQuCkb, baoHanCkb);
        }

        #endregion


    }
}
