using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
//Download by http://www.codefans.net
namespace MyProcessBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.myProcessBar1.Task = this.Task;
            this.myProcessBar1.Run();
        }

        public void Task(ref float percentage)
        {
            int i = 0;
            while (i < int.MaxValue )
            {
                i++;
                percentage = i / (float)int.MaxValue;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.myProcessBar1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.myProcessBar1.Resume();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.myProcessBar1.Abort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.myProcessBar1.Run();
        }
    }
}
