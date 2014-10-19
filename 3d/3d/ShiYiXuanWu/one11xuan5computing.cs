using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _3d
{
    class one11xuan5computing
    {
        public static List<string> mainData = new List<string>();
        public static List<string> data1 = new List<string>();
        public static List<string> data2 = new List<string>();
        public static List<string> data3 = new List<string>();
        public static List<string> data4 = new List<string>();
        public static List<string> data5 = new List<string>();
        public static List<string> data6 = new List<string>();
        public static List<string> data7 = new List<string>();
        public static List<string> data8 = new List<string>();
        public static List<string> data9 = new List<string>();
        public static List<string> data10 = new List<string>();
        public static List<string> data11 = new List<string>();
        private string fg = one11xuan5.normalFenGe;

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

        /// <summary>
        /// 第一号码组
        /// </summary>
        /// <param name="oneNums"></param>
        /// <param name="oneZus"></param>
        /// <returns></returns>
        public List<string> oneZuComputing(string[] oneNums, string[] oneZus, List<string> md)
        {
            Array.Sort(oneNums);
            Array.Sort(oneZus);
            List<string> res = new List<string>();

            if (oneZus.Contains("0"))
            {
                res.AddRange(md);
                for (int i = 0; i < oneNums.Length; i++)
                {
                    for (int j = 0; j < oneZus.Length; j++)
                    {
                        for (int k = 0; k < md.Count(); k++)
                        {
                            if (SubstringCount(md[k].Trim(), oneNums[i]) != 0)
                            {
                                res.Remove(md[k]);
                            }
                        }
                    }
                }
            }

            List<string> tempLi = new List<string>();
            if (oneZus.Contains("1"))
            {
                for (int i = 0; i < oneNums.Length; i++)
                {
                    List<string> a = new List<string>();
                    a.AddRange(getOneNumData(new string[] { oneNums[i] }, new string[] { "1" }, md));

                    if (res.Count == 0)
                    {
                        res.AddRange(a);
                        tempLi.AddRange(a);
                    }
                    else
                    {
                        tempLi=tempLi.Intersect(a).ToList<string>();
                        res=res.Except(a).Concat(a.Except(res)).ToList<string>();
                        for (int j = 0;j<tempLi.Count;j++ )
                        {
                            res.Remove(tempLi[j]);
                        }
                        //res=res.Intersect(a).ToList<string>();
                    }
                }
            }

            /*if (oneZus.Contains(oneNums.Length+"")&&oneZus.Length==1)
            {
                for (int i = 0; i < oneNums.Length; i++)
                {
                    List<string> a = new List<string>();
                    a.AddRange(getOneNumData(new string[] { oneNums[i] }, new string[] { "1" }, md));

                    if (res.Count == 0)
                    {
                        res.AddRange(a);
                    }
                    else
                    {
                        res=res.Intersect(a).ToList<string>();
                    }
                }
            }*/

            res.Sort();
            return res;
        }

        public List<string> getOneNumData(string[] oneNums, string[] oneZus, List<string> md)
        {
            List<string> res = new List<string>();
            
            for (int i = 0; i < oneNums.Length; i++)
            {
                for (int j = 0; j < oneZus.Length; j++)
                {
                    for (int k = 0; k < md.Count(); k++)
                    {
                        if (SubstringCount(md[k].Trim(), oneNums[i]) == Convert.ToInt16(oneZus[j]))
                        {
                            res.Add(md[k]);
                        }
                    }
                }
            }

            return res;
        }
    }
}

