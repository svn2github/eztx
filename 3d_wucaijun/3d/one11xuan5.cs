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
        public one11xuan5()
        {
            InitializeComponent();
        }

        private OutputForm f2 = null;

        string[] oSum()
        {
            List<string> o11 = new List<string>();//1~11那11个数

            for (int i = 1; i <= 11; i++)
            {
                o11.Add(i.ToString("d2"));
            }
            
            return o11.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f2 == null || f2.IsDisposed)//判断窗口是否打开
            {
                f2 = new OutputForm();

            }
            f2.Text = "Hello";
            string a = "";
            for (int i = 0; i < oSum().Count(); i++)
                a += (oSum()[i].Substring(0, 2) + " ");
            f2.textBox1.Text = a;
            //try { f2.Text = "共计  " + (ans.Length / 4).ToString() + "   注"; f2.textBox1.Text = ans.Substring(0, ans.Length - 1); }
            //catch { f2.Text = "出错"; f2.textBox1.Text = "运算出错，请您检查您设置的条件！"; }
            f2.Show();
        }

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

        private void one11xuan5_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = getIP.GetWebIP();
            this.textBox2.Text = getIP.GetWebCity();
        }
    }
}
