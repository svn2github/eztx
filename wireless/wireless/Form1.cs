using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //排除中文
            if (textBox1.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox1.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$"))
                    {
                        textBox1.Text = textBox1.Text.Remove(i, 1);
                    }
                }
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //排除中文
            if (textBox2.Text.Length > 0)
            {
                // 將 TextBox2.Text 的中文字刪除
                for (int i = textBox2.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$"))
                    {
                        textBox2.Text = textBox2.Text.Remove(i, 1);
                    }
                }
                textBox2.SelectionStart = textBox2.Text.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String wireName = textBox1.Text;
            String wirePass = textBox2.Text;
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            // 这里是关键点,不用Shell启动/重定向输入/重定向输出/显示窗口
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;//设置是否有输入
            p.StartInfo.RedirectStandardOutput = true;//设置是否有输出
            //p.StartInfo.RedirectStandardError = true;
            //p.StartInfo.CreateNoWindow = false;//是否显示窗口
            //p.StartInfo.Arguments = "";//设置运行参数
            ProcessStartInfo ac = new ProcessStartInfo("cmd.exe");
            ac.WindowStyle = ProcessWindowStyle.Normal;
            //p.StartInfo.WorkingDirectory = "c:\\";//设置默认的工作路径
            p.Start();
            p.StandardInput.WriteLine(wireName);
            p.StandardInput.WriteLine("exit");
            p.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://1337.eu5.org");
        }
    }
}
