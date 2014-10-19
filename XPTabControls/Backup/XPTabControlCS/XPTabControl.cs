/* Copyright(c) 2008-2010 Vladimir Svyatsky
 * E-mail: v.unreal@gmail.com
 * This code is provided "as is" without any warranty. You can modify it and use it in any applications
 * as long as you do not sell it as a component or a part of component library.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace VSControls
{
    /// <summary>
    /// This class supports rendering of TabControl correctly when using bottom alignment with visual
    /// styles enabled. When ones are disabled the default method of rendering is used.
    /// </summary>
    public partial class XPTabControl : TabControl
    {
        public XPTabControl()
        {
            InitializeComponent();
            fUpDown = new NativeUpDown(this);
        }

        #region Some overridden properties

        [Browsable(true), DefaultValue(TabAlignment.Bottom)]
        new public TabAlignment Alignment
        {
            get { return base.Alignment; }
            set { if (value <= TabAlignment.Bottom) base.Alignment = value; }
        }

        [Browsable(true), DefaultValue(true)]
        new public bool HotTrack
        {
            get { return base.HotTrack; }
            set { base.HotTrack = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        new public TabAppearance Appearance
        {
            get { return base.Appearance; }
            set { if (value == TabAppearance.Normal) base.Appearance = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        new public TabDrawMode DrawMode
        {
            get { return base.DrawMode; }
            set { if (value == TabDrawMode.Normal) base.DrawMode = value; }
        }

        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { if (value == RightToLeft.No) base.RightToLeft = value; }
        }

        public override bool RightToLeftLayout
        {
            get { return base.RightToLeftLayout; }
            set { if (!value) base.RightToLeftLayout = value; }
        }
        
        #endregion

        //This field tells us whether custom drawing is turned on.
        private bool fCustomDraw;

        /// <summary>
        /// Turns custom drawing on/off and sets native font for the control (it's required for tabs to
        /// adjust their size correctly). If one doesn't install native font manually then Windows will
        /// install ugly system font for the control.
        /// </summary>
        private void InitializeDrawMode()
        {
            this.fCustomDraw = Application.RenderWithVisualStyles && TabRenderer.IsSupported;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, this.fCustomDraw);
            this.UpdateStyles();
            if (this.fCustomDraw) //custom drawing will be used
            {
                if (this.fSysFont == IntPtr.Zero) this.fSysFont = this.Font.ToHfont();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.fSysFont, (IntPtr)1);
            }
            else //default drawing will be used
            {
                /* Note that in the SendMessage call below we do not delete HFONT passed to control. If we do
                 * so we can see ugly system font. I think in this case the control deletes this font by itself
                 * when disposing or finalizing.*/
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.Font.ToHfont(), (IntPtr)1);
                //but we need to delete the font(if any) created when being in custom drawing mode
                if (this.fSysFont != IntPtr.Zero)
                {
                    NativeMethods.DeleteObject(this.fSysFont);
                    this.fSysFont = IntPtr.Zero;
                }
            }
        }

        /* Handle to the font used for custom drawing. We do not use this native font directly but tab control
         * adjusts size of tabs and tab scroller being based on the size of that font.*/
        private IntPtr fSysFont = IntPtr.Zero;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            //after the control has been created we should turn custom drawing on/off etc.
            InitializeDrawMode();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (this.fCustomDraw)
            {
                /* The control is being custom drawn and managed font size is changed. We should inform system
                 * about such great event for it to adjust tabs' sizes. And certainly we have to create a new
                 * native font from managed one.*/
                if (this.fSysFont != IntPtr.Zero) NativeMethods.DeleteObject(this.fSysFont);
                this.fSysFont = this.Font.ToHfont();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.fSysFont, (IntPtr)1);
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            /* If visual theme is changed we have to reinitialize drawing mode to prevent exception being
             * thrown by TabRenderer when switching from visual styles to "Windows Classic" and vise versa.*/
            if (m.Msg == NativeMethods.WM_THEMECHANGED) InitializeDrawMode();
            else if (m.Msg == NativeMethods.WM_PARENTNOTIFY && (m.WParam.ToInt32() & 0xffff) == NativeMethods.WM_CREATE)
            {
                /* Tab scroller has created(too many tabs to display and tab control is not multiline), so
                 * let's attach our hook to it.*/
                StringBuilder className = new StringBuilder(16);
                if (NativeMethods.RealGetWindowClass(m.LParam, className, 16) > 0 &&
                    className.ToString() == "msctls_updown32")
                {
                    fUpDown.ReleaseHandle();
                    fUpDown.AssignHandle(m.LParam);
                }
            }
            base.WndProc(ref m);
        }

        //required to correct pane height on Win Vista(and possible Win 7)
        private static int sAdjHeight = Environment.OSVersion.Version.Major >= 6 ? 1 : 0;
        
        /// <summary>
        /// Draws our tab control.
        /// </summary>
        /// <param name="g">The <see cref="System.Drawing.Graphics"/> object used to draw tab control.</param>
        /// <param name="clipRect">The <see cref="System.Drawing.Rectangle"/> that specifies clipping rectangle
        /// of the control.</param>
        private void DrawCustomTabControl(Graphics g, Rectangle clipRect)
        {
            /* In this method we draw only those parts of the control which intersects with the
             * clipping rectangle. It's some kind of optimization.*/
            if (!this.Visible) return;

            //selected tab index and rectangle
            int iSel = this.SelectedIndex;
            Rectangle selRect = iSel != -1 ? this.GetTabRect(iSel) : Rectangle.Empty;

            Rectangle rcPage = this.ClientRectangle;
            //correcting page rectangle
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    {
                        int trunc = selRect.Height * this.RowCount + 2;
                        rcPage.Y += trunc; rcPage.Height -= trunc;
                    } break;
                case TabAlignment.Bottom: rcPage.Height -= (selRect.Height + XPTabControl.sAdjHeight) * this.RowCount; break;
            }

            //draw page itself
            if (rcPage.IntersectsWith(clipRect)) TabRenderer.DrawTabPage(g, rcPage);

            int tabCount = this.TabCount;
            if (tabCount == 0) return;

            //drawing unselected tabs
            this.lastHotIndex = HitTest();//hot tab
            VisualStyleRenderer tabRend = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
            for (int iTab = 0; iTab < tabCount; iTab++)
                if (iTab != iSel)
                {
                    Rectangle tabRect = this.GetTabRect(iTab);
                    if (tabRect.Right >= 3 && tabRect.IntersectsWith(clipRect))
                    {
                        TabItemState state = iTab == this.lastHotIndex ? TabItemState.Hot : TabItemState.Normal;
                        tabRend.SetParameters(tabRend.Class, tabRend.Part, (int)state);
                        DrawTabItem(g, iTab, tabRect, tabRend);
                    }
                }

            /* Drawing selected tab. We'll also increase selected tab's rectangle. It should be a little
             * bigger than other tabs.*/
            selRect.Inflate(2, 2);
            if (iSel != -1 && selRect.IntersectsWith(clipRect))
            {
                tabRend.SetParameters(tabRend.Class, tabRend.Part, (int)TabItemState.Selected);
                DrawTabItem(g, iSel, selRect, tabRend);
            }
        }

        /// <summary>
        /// Draws certain tab.
        /// </summary>
        /// <param name="g">The <see cref="System.Drawing.Graphics"/> object used to draw tab control.</param>
        /// <param name="index">Index of the tab being drawn.</param>
        /// <param name="tabRect">The <see cref="System.Drawing.Rectangle"/> object specifying tab bounds.</param>
        /// <param name="rend">The <see cref="System.Windows.Forms.VisualStyles.VisualStyleRenderer"/> object for rendering the tab.</param>
        private void DrawTabItem(Graphics g, int index, Rectangle tabRect, VisualStyleRenderer rend)
        {
            //if scroller is visible and the tab is fully placed under it we don't need to draw such tab
            if (fUpDown.X <= 0 || tabRect.X < fUpDown.X)
            {
                bool tabSelected = rend.State == (int)TabItemState.Selected;
                /* We will draw our tab on the bitmap and then will transfer image on the control
                 * graphic context.*/
                GDIMemoryContext memGDI = new GDIMemoryContext(g, tabRect.Width, tabRect.Height);
                Rectangle drawRect = new Rectangle(0, 0, tabRect.Width, tabRect.Height);
                using (Graphics bitmapContext = memGDI.CreateGraphics())
                {
                    rend.DrawBackground(bitmapContext, drawRect);
                    if (tabSelected && tabRect.X == 0)
                    {
                        int corrY = memGDI.Height - 1;
                        memGDI.SetPixel(0, corrY, memGDI.GetPixel(0, corrY - 1));
                    }
                    /* Important moment. If tab alignment is bottom we should flip image to display tab
                     * correctly.*/
                    if (this.Alignment == TabAlignment.Bottom) memGDI.FlipVertical();

                    Rectangle focusRect = Rectangle.Inflate(drawRect, -3, -3);//focus rect
                    TabPage pg = this.TabPages[index];//tab page whose tab we're drawing
                    //trying to get tab image if any
                    Image pagePict = this.GetImageByIndexOrKey(pg.ImageIndex, pg.ImageKey);
                    if (pagePict != null)
                    {
                        //If tab image is present we should draw it.
                        Point imgLoc = tabSelected ? new Point(8, 2) : new Point(6, 2);
                        if (this.Alignment == TabAlignment.Bottom) imgLoc.Y = drawRect.Bottom - 2 - pagePict.Height;
                        bitmapContext.DrawImageUnscaled(pagePict, imgLoc);
                        //Correcting rectangle for drawing text.
                        drawRect.X += imgLoc.X + pagePict.Width; drawRect.Width -= imgLoc.X + pagePict.Width;
                    }
                    //drawing tab text
                    TextRenderer.DrawText(bitmapContext, pg.Text, this.Font, drawRect, rend.GetColor(ColorProperty.TextColor),
                        TextFormatFlags.SingleLine | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    //and finally drawing focus rect(if needed)
                    if (this.Focused && tabSelected)
                        ControlPaint.DrawFocusRectangle(bitmapContext, focusRect);
                }
                //If the tab has part under scroller we shouldn't draw that part.
                int shift = tabSelected ? 2 : 0;
                if (fUpDown.X > 0 && fUpDown.X >= tabRect.X - shift && fUpDown.X < tabRect.Right + shift)
                    tabRect.Width -= tabRect.Right - fUpDown.X + shift;
                memGDI.DrawContextClipped(g, tabRect);
            }
        }

        /// <summary>
        /// This function attempts to get tab image by index first or if not set then by key.
        /// </summary>
        /// <param name="index">Index of tab image in tab control image list.</param>
        /// <param name="key">Key of tab image in tab control image list.</param>
        /// <returns><see cref="System.Drawing.Image"/> that represents image of the tab or null if not assigned.</returns>
        private Image GetImageByIndexOrKey(int index, string key)
        {
            if (this.ImageList == null) return null;
            else if (index > -1) return this.ImageList.Images[index];
            else if (key.Length > 0) return this.ImageList.Images[key];
            else return null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //drawing our control
            DrawCustomTabControl(e.Graphics, e.ClipRectangle);
        }

        /// <summary>
        /// Gets hot tab index.
        /// </summary>
        /// <returns>Index of the tab over that the mouse is hovering or -1 if the mouse isn't over any tab.</returns>
        private unsafe int HitTest()
        {
            NativeMethods.TCHITTESTINFO hti = new NativeMethods.TCHITTESTINFO();
            Point mousePos = this.PointToClient(TabControl.MousePosition);
            hti.pt.x = mousePos.X; hti.pt.y = mousePos.Y;
            return (int)NativeMethods.SendMessage(this.Handle, NativeMethods.TCM_HITTEST, IntPtr.Zero, (IntPtr)(&hti));
        }

        /* We have to remember the index of last hot tab for our native updown hook to overdraw that tab as
         * normal when mouse is moving over it.*/
        private int lastHotIndex = -1;

        //handle to our hook
        private NativeUpDown fUpDown;

        /// <summary>
        /// This class represents low level hook to updown control used to scroll tabs. We need it to know the
        /// position of scroller and to draw hot tab as normal when the mouse moves from that tab to scroller.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private class NativeUpDown : NativeWindow
        {
            public NativeUpDown(XPTabControl ctrl) { fparent = ctrl; }

            private int x;

            private XPTabControl fparent;

            /// <summary>
            /// Reports about current position of tab scroller.
            /// </summary>
            public int X { get { return x; } }

            protected override void WndProc(ref Message m)
            {
                //if native updown is destroyed we need release our hook
                if (m.Msg == NativeMethods.WM_DESTROY || m.Msg == NativeMethods.WM_NCDESTROY)
                    this.ReleaseHandle();
                else if (m.Msg == NativeMethods.WM_WINDOWPOSCHANGING)
                {
                    //When scroller position is changed we should remember that new position.
                    unsafe
                    {
                        NativeMethods.WINDOWPOS* wp = (NativeMethods.WINDOWPOS*)m.LParam.ToPointer();
                        this.x = wp->x;
                    }
                }
                else if (m.Msg == NativeMethods.WM_MOUSEMOVE && fparent.lastHotIndex > 0 &&
                    fparent.lastHotIndex != fparent.SelectedIndex)
                {
                    //owerdrawing former hot tab as normal
                    using (Graphics context = Graphics.FromHwnd(fparent.Handle))
                    {
                        VisualStyleRenderer rend = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
                        fparent.DrawTabItem(context, fparent.lastHotIndex, fparent.GetTabRect(fparent.lastHotIndex), rend);
                        if (fparent.lastHotIndex - fparent.SelectedIndex == 1)
                        {
                            Rectangle selRect = fparent.GetTabRect(fparent.SelectedIndex);
                            selRect.Inflate(2, 2);
                            rend.SetParameters(rend.Class, rend.Part, (int)TabItemState.Selected);
                            fparent.DrawTabItem(context, fparent.SelectedIndex, selRect, rend);
                        }
                    }
                }
                else if (m.Msg == NativeMethods.WM_LBUTTONDOWN)
                {
                    Rectangle invalidRect = fparent.GetTabRect(fparent.SelectedIndex);
                    invalidRect.X = 0; invalidRect.Width = 2;
                    invalidRect.Inflate(0, 2);
                    fparent.Invalidate(invalidRect);
                }
                base.WndProc(ref m);
            }
        }
    }
}