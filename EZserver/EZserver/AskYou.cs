using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EZserver
{
    public partial class AskYou : Form
    {
        public AskYou()
        {
            InitializeComponent();
        }

        private void finishThisForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void unfinishThisForm()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            finishThisForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            unfinishThisForm();
        }
    }
}
