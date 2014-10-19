using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Public.Manager.File.Class;

namespace mmClock
{
    public partial class frmMessage : Form
    {
        FileIni fIni;
        frmMain fm;
        public frmMessage()
        {
            InitializeComponent();
            fm = new frmMain();
            fIni = fm.fIni; 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int x;
        int y;
        int pHeight = Screen.PrimaryScreen.WorkingArea.Height;
        int pWidth = Screen.PrimaryScreen.WorkingArea.Width;

        bool isUp = true;
        private void MessageForm_Load(object sender, EventArgs e)
        {
            Visible = false;

            if (frmMain.MsgBoxShowAgain)
                Visible = true;
            else Close();
            x = Screen.PrimaryScreen.WorkingArea.Width-this.Width;
            y = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(x, y);
            tmrTime.Interval = frmMain.MsgBoxShowTime * 1000;
            lblTitle.Text = frmMain.MsgBoxTitle;
            lblCount.Text = frmMain.MsgBoxContent;
            tmrStart.Start();
        }

        private void tmrStart_Tick(object sender, EventArgs e)
        {
            if (isUp)
            {
                Top--;
                if (Top <= pHeight - Height)
                {
                    tmrStart.Stop();
                    isUp = false;
                    tmrTime.Start();
                    Activate();
                }
            }
            else if (!isUp)
            {
                Top++;
                if (this.Top >= pHeight)
                {
                    tmrStart.Stop();
                    Close();
                }
            }
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            Activate();
            tmrTime.Stop();
            tmrStart.Start();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            tmrStart.Stop();
            tmrTime.Stop();
            tmrStart.Stop();
            tmrTime.Stop();
            this.Location = new Point(x, y);
            frmSetting set = new frmSetting();
            set.ShowDialog();
            Close();
        }

        int mx;
        int my;
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mx = e.X;
                my = e.Y;
            }
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(Location.X + (e.X - mx), Location.Y + (e.Y - my));
            }
        }
    }
}