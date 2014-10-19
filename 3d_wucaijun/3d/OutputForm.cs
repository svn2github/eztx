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

        private OutputFormZuXuan otForm = null;

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

        //组选转直选
        private void zuXuanZhuanZhiXuan()
        {
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

                    List<string> _arrangeResult=Tools.GetArrangeResult(_answer);
                   
                    for (int j = 0; j < _arrangeResult.Count; j++)
                    {
                        li.Add(_arrangeResult[j]+Global.splitRegex);
                    }
                }
                li = li.Distinct().ToList();
                li.Sort();
                generateData(li);
            }
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
            ans = ans.Substring(0, ans.Length - 1);

            try { otForm.Text = "共计  " + li.Count + "   注 - 恩泽天下"; otForm.textBox1.Text = ans; }
            catch { otForm.Text = "出错"; otForm.textBox1.Text = "运算出错，请您检查您设置的条件！"; }
            otForm.Show();
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
            if (otForm == null || otForm.IsDisposed)//判断窗口是否打开
            {
                otForm = new OutputFormZuXuan();

            }

            zuXuanZhuanZhiXuan();
        }
    }
}
