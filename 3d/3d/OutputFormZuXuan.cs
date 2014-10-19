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
    public partial class OutputFormZuXuan : Form
    {
        public OutputFormZuXuan()
        {
            InitializeComponent();
        }

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
    }
}
