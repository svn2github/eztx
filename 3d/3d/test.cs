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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            List<int> a = new List<int> { 1, 2, 3, 4 };
            List<int> b = new List<int> { 2, 3, 4, 5 };
            List<int> c = new List<int> { 3, 4, 5, 6 };
            List<int> res = a.Intersect(b).ToList<int>();//a.Except(b).Concat(b.Except(a)).ToList<int>();
            res = res.Intersect(c).ToList<int>();//a.Except(c).Concat(c.Except(a)).ToList<int>();
            a.Except(b).Concat(a.Except(b)).OrderBy(i => i).ToList().ForEach(i => Console.Write(i.ToString()));
            string abc = "";
            for (int i = 0;i<res.Count ;i++ )
            {
                abc += res[i];
            }

            this.textBox1.Text = abc;
        }
    }
}
