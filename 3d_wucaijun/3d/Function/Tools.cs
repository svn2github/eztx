using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3d
{
    class Tools
    {
        /// <summary>
        /// 将传进来的3位数字从小到大排列出来
        /// </summary>
        /// <param name="_answer"></param>
        /// <returns></returns>
        public static string sort3D(string _answer) {
            int a = Int32.Parse(_answer.Substring(0, 1));
            int b = Int32.Parse(_answer.Substring(1, 1));
            int c = Int32.Parse(_answer.Substring(2, 1));
            int temp = 0;
            if (a > b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            if (b > c)
            {
                temp = c;
                c = b;
                if (temp > a)
                {
                    b = temp;
                }
                else
                {
                    b = a;
                    a = temp;
                }
            }
            _answer = a + "" + b + "" + c + "";

            return _answer;
        }

        /// <summary>
        /// 生成三种组合
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> GetArrangeResult(string str)
        {
            str = str.Trim();
            if (string.IsNullOrEmpty(str))
            {
                return new List<string>();
            }
            else if (str.Length == 1)
            {
                return new List<string> { str };
            }
            else if (str.Length == 2)
            {
                char[] ca = str.ToArray();
                return new List<string>() { ca[0].ToString() + ca[1].ToString(), ca[1].ToString() + ca[0].ToString() };
            }
            else
            {
                char[] array = str.ToCharArray();
                List<string> temp = GetArrangeString(array[0].ToString(), array[1]);
                for (int i = 2; i < array.Length; i++)
                {
                    int count = temp.Count;
                    for (int j = 0; j < count; j++)
                    {
                        temp.AddRange(GetArrangeString(temp[j], array[i]));
                        temp.Remove(temp[j]);
                        j--;
                        count--;
                    }
                }
                return temp;
            }
        }

        private static List<string> GetArrangeString(string parent, char child)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i <= parent.Length; i++)
            {
                temp.Add(parent.Insert(i, child.ToString()));
            }
            return temp;
        }
    }
}
