using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Net;

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

        /// <summary>
        /// 计算字符串中子串出现的次数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="substring">子串</param>
        /// <returns>出现的次数</returns>
        public static int SubstringCount(string str, string substring)
        {
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }

            return 0;
        }


        /// <summary>
        /// Groupbox重绘
        /// </summary>
        public static void SetGroupBoxPaintAll(Control.ControlCollection cc)
        {

            foreach (Control ctr in cc)
            {
                if (ctr is GroupBox)
                {
                    ctr.Paint += new System.Windows.Forms.PaintEventHandler(GroupBoxPaint);
                }
                Tools.SetGroupBoxPaintAll(ctr.Controls);
            }
        }

        //↑
        public static void GroupBoxPaint(object sender, PaintEventArgs e)
        {
            GroupBox gpb = (GroupBox)sender;
            e.Graphics.Clear(gpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(gpb.Text, gpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(gpb.Text, gpb.Font).Width + 8, 7, gpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, gpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, gpb.Height - 2, gpb.Width - 2, gpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, gpb.Width - 2, 7, gpb.Width - 2, gpb.Height - 2);//右边那条竖线
        }

        /// <summary>
        /// 读文件(路径)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string readFile(string filePath)
        {
            string fileInfo = "";
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath, new UTF8Encoding(false), false);//new UTF8Encoding(false),
                fileInfo = sr.ReadToEnd();
            }
            return fileInfo;
        }

        /// <summary>
        /// 写文件(路径、内容)
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileInfo"></param>
        public static void writeFile(string filePath, string fileInfo)
        {
            StreamWriter sw = new StreamWriter(filePath, false, new UTF8Encoding(false));//, new UTF8Encoding(false)
            {
                sw.WriteLine(fileInfo);
                sw.Close();
            }
        }

        /// <summary>
        /// 获取在线XML文档
        /// </summary>
        /// <param name="url">传入在线XML地址，如：www.baidu.com/abc.xml</param>
        /// <returns></returns>
        public string getOnlineXML(string url)
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据
            string pageHtml = Encoding.Default.GetString(pageData);
            return pageHtml;
        }
    }
}
