using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace textOnpaint
{
    public partial class CusButton : Button
    {
        private enum MouseActionType
        {
            BUTTON_UP,
            BUTTON_FOCUS,
            BUTTON_DOWN,
            BUTTON_DISABLED,
            MOUSE_OVER
        }

        private MouseActionType mouseAction;
        private ImageAttributes imgAttr = new ImageAttributes();
        private bool currentSelect = false;

        public bool CurrentSelect
        {
            get { return currentSelect; }
            set { currentSelect = value; }
        }

        public CusButton()
        {
            InitializeComponent();

            mouseAction = MouseActionType.BUTTON_UP;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint, true);

            //The following defaults are better suited to draw the text outline
            //this.Font = new Font("宋体", 20);
            this.Size = new Size(90, 41);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;//抗锯齿处理 

            Image img = textOnpaint.Properties.Resources.button;

            int imgW = 90;
            int imgH = 41;


            //绘制背景
            if (this.currentSelect)
            {
                g.DrawImage(img, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, (imgH * 2), imgW, imgH), GraphicsUnit.Pixel);
                drawText(g);
                return;
            }


            switch (mouseAction)
            {
                case MouseActionType.BUTTON_UP:
                    if (this.Enabled == false)
                    {
                        break;
                    }
                    g.DrawImage(img, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, 0, imgW, imgH), GraphicsUnit.Pixel);
                    break;
                case MouseActionType.MOUSE_OVER:
                    if (this.Enabled == false)
                    {
                        break;
                    }
                    g.DrawImage(img, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, 0, imgW, imgH), GraphicsUnit.Pixel);
                    break;
                case MouseActionType.BUTTON_DOWN:
                    if (this.Enabled == false)
                    {
                        break;
                    }
                    g.DrawImage(img, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, imgH, imgW, imgH), GraphicsUnit.Pixel);
                    break;
                case MouseActionType.BUTTON_DISABLED:
                    //g.DrawImage(img, new Rectangle(0, 0, this.Width, this.Height), new Rectangle((this.Width + 2) * 2, 0, this.Width, this.Height), GraphicsUnit.Pixel);
                    break;
            }
            drawText(g);
        }

        private void drawText(Graphics g)
        {
            ///
            /// 绘制按钮的文本
            /// 
            GraphicsPath path4 = new GraphicsPath();


            Rectangle rcText = new Rectangle(0, 0, this.Width, this.Height);

            StringFormat strformat = new StringFormat();
            strformat.Alignment = StringAlignment.Center;
            strformat.LineAlignment = StringAlignment.Center;

            Font f = new Font("微软雅黑", 9);

            if (CurrentSelect)
            {
                g.DrawString(this.Text, f, Brushes.White, rcText, strformat);
                return;
            }

            g.DrawString(this.Text, f, Brushes.DimGray, rcText, strformat);


        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseAction = MouseActionType.BUTTON_DOWN;
                this.Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.mouseAction = MouseActionType.MOUSE_OVER;
            this.Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            this.mouseAction = MouseActionType.MOUSE_OVER;
            this.Invalidate();
            base.OnMouseHover(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.mouseAction = MouseActionType.MOUSE_OVER;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.mouseAction = MouseActionType.MOUSE_OVER;
            this.Invalidate();
            base.OnMouseLeave(e);
        }
        
    }
}
