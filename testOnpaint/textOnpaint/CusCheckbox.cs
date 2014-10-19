using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace textOnpaint
{
    public partial class CusCheckbox : CheckBox
    {
        public CusCheckbox()
        {
            InitializeComponent();
            this.Size = new Size(16,16);

            this.BackColor = Color.Transparent;
        }

        private string value = "";

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;//抗锯齿处理 

            Image img = textOnpaint.Properties.Resources.checkbox;
            if (this.Checked)
            {
                g.DrawImage(img, new Rectangle(0, 0, 16, 16), new Rectangle(1, (16 + 1) + 1, 16, 16), GraphicsUnit.Pixel);
            }
            if (!this.Checked)
            {
                g.DrawImage(img, new Rectangle(0, 0, 16, 16), new Rectangle(1, 1, 16, 16), GraphicsUnit.Pixel);
            }

        }
    }
}
