using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace textOnpaint
{
    /// <summary>  
    /// ColoredCheckBox 的摘要说明。  
    /// </summary>  
    public partial class  CusColorCheck : CheckBox
    {
        //添加自定义颜色属性  
        private Color checkColor;
        public Color checkBGColor;

        public CusColorCheck()
        {
            this.checkColor = this.ForeColor;
            this.Paint += new PaintEventHandler(this.PaintHandler);
        }
        [Description("checkColor由于显示在CheckBox选中时的颜色")]
        public Color CheckColor
        {
            get
            {
                return checkColor;
            }
            set
            {
                checkColor = value;
                this.Invalidate();
            }
        }

        public Color checkBgColor
        {
            get
            {
                return checkBGColor;
            }
            set
            {
                checkBGColor = value;
            }
        }

        private void PaintHandler(object sender, PaintEventArgs pe)
        {

            Point pt = new Point();

            if (this.CheckAlign == ContentAlignment.BottomCenter)
            {
                pt.X = (this.Width / 2) - 4;
                pt.Y = this.Height - 11;
            }
            if (this.CheckAlign == ContentAlignment.BottomLeft)
            {
                pt.X = 3;
                pt.Y = this.Height - 11;
            }
            if (this.CheckAlign == ContentAlignment.BottomRight)
            {
                pt.X = this.Width - 11;
                pt.Y = this.Height - 11;
            }
            if (this.CheckAlign == ContentAlignment.MiddleCenter)
            {
                pt.X = (this.Width / 2) - 4;
                pt.Y = (this.Height / 2) - 4;
            }
            if (this.CheckAlign == ContentAlignment.MiddleLeft)
            {
                pt.X = 3;
                pt.Y = (this.Height / 2) - 4;
            }
            if (this.CheckAlign == ContentAlignment.MiddleRight)
            {
                pt.X = this.Width - 11;
                pt.Y = (this.Height / 2) - 4;
            }
            if (this.CheckAlign == ContentAlignment.TopCenter)
            {
                pt.X = (this.Width / 2) - 4;
                pt.Y = 3;
            }
            if (this.CheckAlign == ContentAlignment.TopLeft)
            {
                pt.X = 3;
                pt.Y = 3;
            }
            if (this.CheckAlign == ContentAlignment.TopRight)
            {
                pt.X = this.Width - 11;
                pt.Y = 3;
            }

            DrawBackColor(pe.Graphics, this.checkBGColor, pt);
            if (this.Checked) DrawCheck(pe.Graphics, this.checkColor, pt);
        }

        public void DrawCheck(Graphics g, Color c, Point pt)
        {
            Pen pen = new Pen(this.checkColor);
            g.DrawLine(pen, pt.X, pt.Y + 2, pt.X + 2, pt.Y + 4);
            g.DrawLine(pen, pt.X, pt.Y + 3, pt.X + 2, pt.Y + 5);
            g.DrawLine(pen, pt.X, pt.Y + 4, pt.X + 2, pt.Y + 6);
            g.DrawLine(pen, pt.X + 3, pt.Y + 3, pt.X + 6, pt.Y);
            g.DrawLine(pen, pt.X + 3, pt.Y + 4, pt.X + 6, pt.Y + 1);
            g.DrawLine(pen, pt.X + 3, pt.Y + 5, pt.X + 6, pt.Y + 2);
        }
        public void DrawBackColor(Graphics g, Color b, Point pt)
        {
            SolidBrush br = new SolidBrush(this.checkBgColor);
            g.FillRectangle(br, pt.X, pt.Y, 7, 7);
        }
    }
}

