using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace testFonts
{
    public partial class TabControlEz : System.Windows.Forms.TabControl
    {
        public TabControlEz()
        {
            InitializeComponent();
            base.SetStyle(
             ControlStyles.UserPaint |                      // 控件将自行绘制，而不是通过操作系统来绘制  
             ControlStyles.OptimizedDoubleBuffer |          // 该控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁  
             ControlStyles.AllPaintingInWmPaint |           // 控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁  
             ControlStyles.ResizeRedraw |                   // 在调整控件大小时重绘控件  
             ControlStyles.SupportsTransparentBackColor,    // 控件接受 alpha 组件小于 255 的 BackColor 以模拟透明  
             true);                                         // 设置以上值为 true  
            base.UpdateStyles();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.PaintTransparentBackground(e.Graphics, this.ClientRectangle);//画透明背景
            this.PaintAllTheTabs(e);//画每个标签
            this.PaintTheTabPageBorder(e);//画TabPage边框
            this.PaintTheSelectedTab(e);//话选中的Tab标签
        }

        protected void PaintTransparentBackground(Graphics g, Rectangle clipRect)
        {
            if ((this.Parent != null))
            {
                clipRect.Offset(this.Location);
                PaintEventArgs e = new PaintEventArgs(g, clipRect);
                GraphicsState state = g.Save();
                g.SmoothingMode = SmoothingMode.HighSpeed;
                try
                {
                    g.TranslateTransform((float)-this.Location.X, (float)-this.Location.Y);
                    this.InvokePaintBackground(this.Parent, e);
                    this.InvokePaint(this.Parent, e);
                }

                finally
                {
                    g.Restore(state);
                    clipRect.Offset(-this.Location.X, -this.Location.Y);
                }
            }
            else
            {
                System.Drawing.Drawing2D.LinearGradientBrush backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(this.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                g.FillRectangle(backBrush, this.Bounds);
                backBrush.Dispose();
            }
        }

        private void PaintAllTheTabs(System.Windows.Forms.PaintEventArgs e)
        {
            if (this.TabCount > 0)
            {
                for (int index = 0; index < this.TabCount; index++)
                {
                    this.PaintTab(e, index);
                }
            }
        }
        private void PaintTab(System.Windows.Forms.PaintEventArgs e, int index)
        {
            GraphicsPath path = new GraphicsPath();//this.GetPath(index);
            this.PaintTabBackground(e.Graphics, index, path);
            this.PaintTabBorder(e.Graphics, index, path);
            this.PaintTabText(e.Graphics, index);
            this.PaintTabImage(e.Graphics, index);
        }

        private void PaintTabBackground(System.Drawing.Graphics graph, int index, System.Drawing.Drawing2D.GraphicsPath path)
        {
            Rectangle rect = this.GetTabRect(index);
            System.Drawing.Brush buttonBrush =
                new System.Drawing.Drawing2D.LinearGradientBrush(
                    rect,
                    SystemColors.ControlLightLight,
                    SystemColors.ControlLight,
                    LinearGradientMode.Vertical);

            if (index == this.SelectedIndex)
            {
                buttonBrush = new System.Drawing.SolidBrush(SystemColors.ControlLightLight);
            }

            graph.FillPath(buttonBrush, path);
            buttonBrush.Dispose();
        }

        private void PaintTabBorder(System.Drawing.Graphics graph, int index, System.Drawing.Drawing2D.GraphicsPath path)
        {
            Pen borderPen = new Pen(SystemColors.ControlDark);

            if (index == this.SelectedIndex)
            {
                borderPen = new Pen(ThemedColors.ToolBorder);
            }
            graph.DrawPath(borderPen, path);
            borderPen.Dispose();
        }

        private void PaintTabImage(System.Drawing.Graphics graph, int index)
        {
            Image tabImage = null;
            if (this.TabPages[index].ImageIndex > -1 && this.ImageList != null)
            {
                tabImage = this.ImageList.Images[this.TabPages[index].ImageIndex];
            }
            else if (this.TabPages[index].ImageKey.Trim().Length > 0 && this.ImageList != null)
            {
                tabImage = this.ImageList.Images[this.TabPages[index].ImageKey];
            }
            if (tabImage != null)
            {
                Rectangle rect = this.GetTabRect(index);
                graph.DrawImage(tabImage, rect.Right - rect.Height - 4, 4, rect.Height - 2, rect.Height - 2);
            }
        }

        private void PaintTabText(System.Drawing.Graphics graph, int index)
        {
            Rectangle rect = this.GetTabRect(index);
            Rectangle rect2 = new Rectangle(rect.Left + 8, rect.Top + 1, rect.Width - 6, rect.Height);
            if (index == 0) rect2 = new Rectangle(rect.Left + rect.Height, rect.Top + 1, rect.Width - rect.Height, rect.Height);

            string tabtext = this.TabPages[index].Text;

            System.Drawing.StringFormat format = new System.Drawing.StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;

            Brush forebrush = null;

            if (this.TabPages[index].Enabled == false)
            {
                forebrush = SystemBrushes.ControlDark;
            }
            else
            {
                forebrush = SystemBrushes.ControlText;
            }

            Font tabFont = this.Font;
            if (index == this.SelectedIndex)
            {
                tabFont = new Font(this.Font, FontStyle.Bold);
                if (index == 0)
                {
                    rect2 = new Rectangle(rect.Left + rect.Height, rect.Top + 1, rect.Width - rect.Height + 5, rect.Height);
                }
            }

            graph.DrawString(tabtext, tabFont, forebrush, rect2, format);

        }

        private System.Drawing.Drawing2D.GraphicsPath GetPath(int index)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.Reset();

            Rectangle rect = this.GetTabRect(index);

            if (index == 0)
            {
                path.AddLine(rect.Left + 1, rect.Bottom + 1, rect.Left + rect.Height, rect.Top + 2);
                path.AddLine(rect.Left + rect.Height + 4, rect.Top, rect.Right - 3, rect.Top);
                path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
            }
            else
            {
                if (index == this.SelectedIndex)
                {
                    path.AddLine(rect.Left + 1, rect.Top + 5, rect.Left + 4, rect.Top + 2);
                    path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                    path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left + 1, rect.Bottom + 1);
                }
                else
                {
                    path.AddLine(rect.Left, rect.Top + 6, rect.Left + 4, rect.Top + 2);
                    path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                    path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left, rect.Bottom + 1);
                }

            }

            

            return path;
        }

        private void PaintTheTabPageBorder(System.Windows.Forms.PaintEventArgs e)
        {
            if (this.TabCount > 0)
            {
                Rectangle borderRect = this.TabPages[0].Bounds;
                borderRect.Inflate(1, 1);
                ControlPaint.DrawBorder(e.Graphics, borderRect, ThemedColors.ToolBorder, ButtonBorderStyle.Solid);
            }
        }

        private void PaintTheSelectedTab(System.Windows.Forms.PaintEventArgs e)
        {
            Rectangle selrect;
            int selrectRight = 0;

            switch (this.SelectedIndex)
            {
                case -1:
                    break;
                case 0:
                    selrect = this.GetTabRect(this.SelectedIndex);
                    selrectRight = selrect.Right;
                    e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left + 2, selrect.Bottom + 1, selrectRight - 2, selrect.Bottom + 1);
                    break;
                default:
                    selrect = this.GetTabRect(this.SelectedIndex);
                    selrectRight = selrect.Right;
                    e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left + 6 - selrect.Height, selrect.Bottom + 1, selrectRight - 2, selrect.Bottom + 1);
                    break;
            }
        }
    }
}
