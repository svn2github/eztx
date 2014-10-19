using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
//Download by http://www.codefans.net
namespace TabControlExDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            linkLabel1.Click += delegate(object sender, EventArgs e)
            {
                Process.Start("www.csharpwin.com");
            };
        }
    }
}