using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ProgressBarTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false; 
        }

        private void Send()
        {
            int i = 0;
            while (i <= 100)
            {
                //显示进度 信息
                this.ShowPro(i);
                //循环发生文件
                //模拟的 
                i++; //模拟发送多少
                Thread.Sleep(100);
            }
            Thread.CurrentThread.Abort();
        }

        private void ShowPro(int value)
        {
                this.progressBar1.Value = value;
                this.label1.Text = value + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Send));
            thread.Start();
        }

    }
}
