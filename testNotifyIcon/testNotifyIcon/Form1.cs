using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testNotifyIcon
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class Form1 : Form
    {
        //private Empty em = new Empty();
        public Form1()
        {
            InitializeComponent();
        }

        private void showForm()
        {
            NetTools nt = new NetTools();
            this.webBrowser1.Url = new Uri("http://timesheet.attic-architect.com/login.php?a=v_status&b=" + nt.HostMAC);
            this.webBrowser1.ObjectForScripting = this;
            this.Show();
            this.WindowState = FormWindowState.Maximized;
            this.Activate();
            //showOnMonitor(0);
        }

        private void showOnMonitor(int o)
        {
            Screen[] sc;
            sc = Screen.AllScreens;

            int _showOnMonitor = o;
            
            if (_showOnMonitor >= sc.Length)
            {
                _showOnMonitor = 0;
            }
            
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[_showOnMonitor].Bounds.Left, sc[_showOnMonitor].Bounds.Top);
        }

        public void unlockForm()
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }
        public void closeForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                //this.MaximizedBounds = Screen.FromControl(this).WorkingArea;
                showForm();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注意判断关闭事件Reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
                notifyIcon1.Visible = true;
                this.Hide();

                //em.Close();
                return;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)    //最小化到系统托盘
            {
                notifyIcon1.Visible = true;    //显示托盘图标
                this.Hide();    //隐藏窗口
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NetTools nt = new NetTools();
            showForm();
            /*if (!nt.getUserStatus())
            {
                showForm();
            }
            if (Screen.AllScreens.Length > 1)
            {
                //em.Show();
            }*/
        }
    }
}
