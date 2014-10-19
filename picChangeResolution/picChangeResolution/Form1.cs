using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace picChangeResolution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelBili.Text = "比例";
            ClearTextBox(this);
            mesLabel.Text = "";
            
        }

        private void afterLength_TextChanged(object sender, EventArgs e)
        {
            if (afterLength.Focused == true)
            {
                if (afterLength.Text.Length > 0)
                {
                    try
                    {
                        // 將 TextBox1.Text 的中文字刪除
                        for (int i = afterLength.Text.Length - 1; i >= 0; i--)
                        {
                            // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                            if (System.Text.RegularExpressions.Regex.IsMatch(afterLength.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$"))
                            {
                                afterLength.Text = afterLength.Text.Remove(i, 1);
                            }
                            if (System.Text.RegularExpressions.Regex.IsMatch(afterLength.Text.Substring(i, 1), @"^[A-Za-z]+$"))
                            {
                                afterLength.Text = afterLength.Text.Remove(i, 1);
                            }
                        }
                        afterLength.SelectionStart = afterLength.Text.Length;
                    }
                    catch { }
                }
                if (beforeLength.Text != "" && beforeWidth.Text != "" && labelBili.Text != "比例")
                {
                    string lbtext = labelBili.Text;
                    string[] sArray = lbtext.Split(':');
                    double a = Convert.ToDouble(sArray[0]);
                    double b = Convert.ToDouble(sArray[1]);
                    if (afterLength.Text != "")
                    {
                        double aftLength = Convert.ToDouble(afterLength.Text);
                        double aftWidth = (aftLength / a) * b;
                        if (aftWidth < 0)
                        {
                            aftWidth = Math.Round(aftWidth + 5 / Math.Pow(10, 3), 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            aftWidth = Math.Round(Convert.ToDouble(aftWidth), 2, MidpointRounding.AwayFromZero);
                        }
                        double aftWid = Math.Round(Convert.ToDouble(aftWidth), 0, MidpointRounding.AwayFromZero);
                        afterWidth.Text = Convert.ToString(aftWid);
                    }
                    else
                    {
                        afterWidth.Text = "";
                    }
                }
            }
        }

        private void afterWidth_TextChanged(object sender, EventArgs e)
        {
            
            if (afterWidth.Focused==true)
            {
                if (afterWidth.Text.Length > 0)
                {
                    try
                    {
                        // 將 TextBox1.Text 的中文字刪除
                        for (int i = afterWidth.Text.Length - 1; i >= 0; i--)
                        {
                            // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                            if (System.Text.RegularExpressions.Regex.IsMatch(afterWidth.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$"))
                            {
                                afterWidth.Text = afterWidth.Text.Remove(i, 1);
                            }
                            if (System.Text.RegularExpressions.Regex.IsMatch(afterWidth.Text.Substring(i, 1), @"^[A-Za-z]+$"))
                            {
                                afterWidth.Text = afterWidth.Text.Remove(i, 1);
                            }
                        }
                        afterWidth.SelectionStart = afterWidth.Text.Length;
                    }
                    catch { }
                }
                if (beforeLength.Text != "" && beforeWidth.Text != "" && labelBili.Text != "比例")
                {
                    string lbtext = labelBili.Text;
                    string[] sArray = lbtext.Split(':');
                    double a = Convert.ToDouble(sArray[0]);
                    double b = Convert.ToDouble(sArray[1]);
                    if (afterWidth.Text != "")
                    {
                        double aftWidth = Convert.ToDouble(afterWidth.Text);
                        double aftLength = (aftWidth / b) * a;
                        if (aftLength < 0)
                        {
                            aftLength = Math.Round(aftLength + 5 / Math.Pow(10, 3), 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            aftLength = Math.Round(Convert.ToDouble(aftLength), 2, MidpointRounding.AwayFromZero);
                        }
                        double aftLen = Math.Round(Convert.ToDouble(aftLength), 0, MidpointRounding.AwayFromZero);
                        afterLength.Text = Convert.ToString(aftLen);
                    }
                    else
                    {
                        afterLength.Text = "";
                    }
                }
            }
            else { }
        }

        private void beforeLength_TextChanged(object sender, EventArgs e)
        {

            if (beforeLength.Text.Length > 0)
            {
                try
                {
                    // 將 TextBox1.Text 的中文字刪除
                    for (int i = beforeLength.Text.Length - 1; i >= 0; i--)
                    {
                        // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                        if (System.Text.RegularExpressions.Regex.IsMatch(beforeLength.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$"))
                        {
                            beforeLength.Text = beforeLength.Text.Remove(i, 1);
                        }
                        if (System.Text.RegularExpressions.Regex.IsMatch(beforeLength.Text.Substring(i, 1), @"^[A-Za-z]+$"))
                        {
                            beforeLength.Text = beforeLength.Text.Remove(i, 1);
                        }
                    }
                    beforeLength.SelectionStart = beforeLength.Text.Length;
                }
                catch { }
            }

        }

        private void beforeWidth_TextChanged(object sender, EventArgs e)
        {
            if (beforeWidth.Text.Length > 0)
            {
                try
                {
                    // 將 TextBox1.Text 的中文字刪除
                    for (int i = beforeWidth.Text.Length - 1; i >= 0; i--)
                    {
                        // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                        if (System.Text.RegularExpressions.Regex.IsMatch(beforeWidth.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$"))
                        {
                            beforeWidth.Text = beforeWidth.Text.Remove(i, 1);
                        }
                        if (System.Text.RegularExpressions.Regex.IsMatch(beforeWidth.Text.Substring(i, 1), @"^[A-Za-z]+$"))
                        {
                            beforeWidth.Text = beforeWidth.Text.Remove(i, 1);
                        }
                    }
                    beforeWidth.SelectionStart = beforeWidth.Text.Length;
                }
                catch { }
            }

            if (beforeLength.Text != "")
            {
                if (beforeWidth.Text != "")
                {
                    
                    
                    string befLength = beforeLength.Text;
                    string befWidth = beforeWidth.Text;
                    double befL = Convert.ToDouble(befLength);
                    double befW = Convert.ToDouble(befWidth);
                    double befO = 0;
                    if (befL < befW)
                    {
                        String c = beforeWidth.Text;
                        beforeWidth.Text = beforeLength.Text;
                        beforeLength.Text = c;

                        befO = befW;
                        befW = befL;
                        befL = befO;
                    }
                    //以下为求最大公约数
                    double max = 0; //max为最大公约数
                    for (double i = 1; i <= (befL < befW ? befL : befW); i++)
                    {
                        if (befL % i == 0 && befW % i == 0)
                            max = i;
                        double a = befL / max;
                        double b = befW / max;
                        double bilires = Math.Round(Convert.ToDouble(a), 0, MidpointRounding.AwayFromZero); ;
                        double bilires2 = Math.Round(Convert.ToDouble(b), 0, MidpointRounding.AwayFromZero); ;
                        labelBili.Text = bilires + ":" + bilires2;

                    }
                    //以下为求最小公倍数
                    //int min = 0;//min为最小公倍数
                    /*for (int i = (a > b ? a : b); i <= a * b; i++)
                    {
                        if (i % a == 0 && i % b == 0)
                        {
                            min = i;
                            break; //找到第一个符合条件的i的值便跳转出循环，即为最小公倍数
                        }
                    }*/
                    if (afterLength.Text != "")
                    {
                        string lbtext = labelBili.Text;
                        string[] sArray = lbtext.Split(':');
                        double a = Convert.ToDouble(sArray[0]);
                        double b = Convert.ToDouble(sArray[1]);
                        double aftLength = Convert.ToDouble(afterLength.Text);
                        double aftWidth = (aftLength / a) * b;
                        if (aftWidth < 0)
                        {
                            aftWidth = Math.Round(aftWidth + 5 / Math.Pow(10, 3), 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            aftWidth = Math.Round(Convert.ToDouble(aftWidth), 2, MidpointRounding.AwayFromZero);
                        }
                        double aftWid = Math.Round(Convert.ToDouble(aftWidth), 0, MidpointRounding.AwayFromZero);
                        afterWidth.Text = Convert.ToString(aftWid);
                    }
                    //else if (afterWidth.Text != "")
                    //{
                    //    string lbtext = labelBili.Text;
                    //    string[] sArray = lbtext.Split(':');
                    //    double a = Convert.ToDouble(sArray[0]);
                    //    double b = Convert.ToDouble(sArray[1]);
                    //    double aftWidth = Convert.ToDouble(afterWidth.Text);
                    //    double aftLength = (aftWidth / b) * a;
                    //    if (aftLength < 0)
                    //    {
                    //        aftLength = Math.Round(aftLength + 5 / Math.Pow(10, 3), 2, MidpointRounding.AwayFromZero);
                    //    }
                    //    else
                    //    {
                    //        aftLength = Math.Round(Convert.ToDouble(aftLength), 2, MidpointRounding.AwayFromZero);
                    //    }
                    //    double aftLen = Math.Round(Convert.ToDouble(aftLength), 0, MidpointRounding.AwayFromZero);
                    //    afterLength.Text = Convert.ToString(aftLen);
                    //}
                    else
                    {
                        mesLabel.Text = "接下来您可以输入你要转换的分辨率了";
                    }

                }
                else
                {
                    mesLabel.Text = "请输入转换前的“宽”";
                    //MessageBox.Show("请输入转换前的“宽”", "温馨提示");
                    beforeWidth.Focus();
                }
            }
            else
            {
                mesLabel.Text = "请输入转换前的“高”";
                //MessageBox.Show("请输入转换前的“高”", "温馨提示");
                beforeLength.Focus();
            }
            //afterWidth.Text=Convert.ToString(Math.Round((double)1920 / (double)1080));
            
        }

        //清空页面上所有textbox控件
        private void ClearTextBox(Control sender) 
        {
            foreach (Control item in sender.Controls)
            { 
                if(item is TextBox)
                {
                    item.Text = string.Empty;
                    continue;
                }
                if (item.Controls.Count > 0)
                    ClearTextBox(item);
            }
        }

    }
}
