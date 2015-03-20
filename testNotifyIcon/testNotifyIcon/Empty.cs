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
    public partial class Empty : Form
    {
        public Empty()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            showOnMonitor(1);
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

    }
}
