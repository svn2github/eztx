using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace _3d
{
    public partial class OutputForm : Form
    {
        public OutputForm()
        {
            InitializeComponent();
        }

        private OutputFormZuXuan f2 = null;

        private void Form2_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.textBox1.Select(0,0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
            this.textBox1.Copy();
            MessageBox.Show("复制成功！","提示",MessageBoxButtons.OK);
        }

        //直选转组选
        private void zhiXuanZhuanZuXuan() {
            string answer=this.textBox1.Text;
            List<string> li = new List<string>();

            //根据form1的分隔符下拉框来分割
            string txt = Global.splitRegex;

            //MessageBox.Show("[" + f1.comboBox1.Text + "],[" + txt + "]");
            string[] answersLine = Regex.Split(answer, txt, RegexOptions.IgnoreCase);

            if(answersLine.Length>0){
                for (int i = 0; i < answersLine.Length; i++)
                {
                    string _answer = answersLine[i];
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
                    li.Add(_answer + txt);
                }
                li = li.Distinct().ToList();
            }

            string ans = "";
            string[] allNum = li.ToArray();
            /* int countNums = 1;
             int whereEnter = 22;
             if(txt.Equals("，")||txt.Equals("；")){
                 whereEnter = 16;
             }
             for (int i = 0; i < allNum.Count(); i++)
             {
                 string _allNum = allNum[i];
                 if (countNums == whereEnter)
                 {
                     _allNum += Environment.NewLine;//"\r\n"+
                     countNums = 0;
                 }
                 ans += _allNum;
                 countNums++;
             }
             ans = ans.Trim();
             if(!IsNumber(ans.Substring(ans.Length-1,1))){
                 ans=ans.Substring(0, ans.Length - 1);
             }*/
            for (int i = 0; i < allNum.Count(); i++)
            {
                ans += allNum[i];
            }

            try { f2.Text = "共计  " + (ans.Length / 4).ToString() + "   注,当前运算结果为 时时彩 - 3D - 排列三 - 快乐3 - 时时乐"; f2.textBox1.Text = ans.Substring(0, ans.Length - 1); }
            catch { f2.Text = "出错"; f2.textBox1.Text = "运算出错，请您检查您设置的条件！"; }
            f2.Show();
        }

        //判断字符串是否可以为数字
        public bool IsNumber(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
            !objTwoDotPattern.IsMatch(strNumber) &&
            !objTwoMinusPattern.IsMatch(strNumber) &&
            objNumberPattern.IsMatch(strNumber);
        }

        private void zhiZhuanZu_Click(object sender, EventArgs e)
        {
            if (f2 == null || f2.IsDisposed)//判断窗口是否打开
            {
                f2 = new OutputFormZuXuan();

            }
            
            zhiXuanZhuanZuXuan();
        }
    }
}
