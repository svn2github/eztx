using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using Public.Manager.File.Class;
using Microsoft.Win32;
using System.IO;


namespace mmClock
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 时间控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrTime_Tick(object sender, EventArgs e)
        {
            if (btnStart.Enabled)
            {
                if (dgvList.Rows.Count > 0)
                    btnClear.Enabled = true;
                lblInfo4.ForeColor = Color.Red;
                lblInfo4.Text = CLOCKOFF;
            }
            else
            {
                btnClear.Enabled = false;
                lblInfo4.ForeColor = Color.White;
                lblInfo4.Text = CLOCKON;
            }
            if (dgvList.Rows.Count <= 0)
                lblInfo3.Text = STATE;
            DateTime dt = DateTime.Now;
            TimerMeth(dt);
            if (isOk)
                if (dgvList.RowCount > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Clock c = list[i];
                        string temp = c.Time;
                        int ccc1 = Convert.ToInt32(temp.Substring(0, temp.IndexOf(STR2)));
                        int ccc2 = Convert.ToInt32(temp.Substring(temp.IndexOf(STR2) + 1));
                        StartClock(dt, ccc1, ccc2);
                    }
                }
                else
                    StartClock(dt);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            txtHour.Text = string.Format(STR5, dt.Hour);
            txtMin.Text = string.Format(STR5, dt.Minute+1);
            TimerMeth(dt);
            tmrTime.Start();
            if (AutomatismStartClock && list.Count > 0)
                btnStart.PerformClick();
            if (IsShowMini)
                this.WindowState = FormWindowState.Minimized;
        }

        private void txtMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
                e.Handled = true;
        }

        private void txtHour_TextChanged(object sender, EventArgs e)
        {
            if (txtHour.Text.Length == 2)
                txtMin.Focus();
            else
                txtHour.Focus();
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            if (txtMin.Text.Length == 2)
                btnAdd.Focus();
            else
                txtMin.Focus();
        }

        private void txtHour_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHour.Text.Trim()))
            {
                int hour = Convert.ToInt32(txtHour.Text);
                if (hour >= 24 || hour < 0)
                {
                    txtHour.Text = STR7;
                    lblInfo1.Text = ERROR;
                    return;
                }
                lblInfo1.Text = STATE;
            }
            else
                txtHour.Focus();
        }

        private void txtMin_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMin.Text.Trim()))
            {
                int min = Convert.ToInt32(txtMin.Text);
                if (min >= 60 || min < 0)
                {
                    txtMin.Text = STR7;
                    lblInfo1.Text = ERROR;
                    return;
                }
                lblInfo1.Text = STATE;
            }
            else
                txtMin.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string temp = SoundSetting();
            if (string.IsNullOrEmpty(temp) || (!File.Exists(temp)))
                return;
            txtHour.Enabled = false;
            txtMin.Enabled = false;
            btnStart.Enabled = false;
            isOk = true;
            btnAdd.Enabled = false;
            if (dgvList.RowCount > 0)
                btnClear.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            PlayStop();
            btnPlaySound.Tag = STOP;
            btnPlaySound.PerformClick();
        }

        /// <summary>
        /// 添加到视图中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHour.Text.Trim()))
                return;
            if (string.IsNullOrEmpty(txtMin.Text.Trim()))
                return;
            SetClockStart(Convert.ToInt32(txtHour.Text.Trim()), Convert.ToInt32(txtMin.Text.Trim()));
        }

        private void 删除闹铃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count <= 0)
                return;
            if (dgvList.SelectedRows.Count <= 0)
                return;
            if (MessageBox.Show(STR8 + (dgvIndex + 1) + STR9 + STR14 + STR15, STR13, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                list.RemoveAt(dgvIndex);
                BindList();
                btnStop.PerformClick();
            }
        }

        private void 修改闹钟状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count <= 0)
                return;
            Clock c1 = list[dgvIndex];
            string state = c1.State;
            c1.State = state == ON ? OFF : ON;
            if (state == OFF)
                if (btnStart.Enabled)
                    c1.STime = STR17;
                else
                    c1.STime = STR18;
            list[dgvIndex] = c1;
            BindList();
        }

        /// <summary>
        /// 选择视图项时  得到视图索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count >= 1)
            {
                dgvIndex = dgvList.SelectedRows[0].Index;
                lblInfo3.Text = STR8 + SPACE + (dgvIndex + 1) + SPACE + STR9;
            }
        }

        /// <summary>
        /// 清空闹钟列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(STR16, STR13, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                list = new List<Clock>();
                BindList();
            }
        }

        /// <summary>
        /// 修改注册表 是否开机启动
        /// </summary>
        /// <param name="Started">是否开机启动 True:开机启动  False:开机不启动</param>
        /// <param name="name">注册表中的名字</param>
        /// <param name="path">启动文件的路径</param>
        /// <!--俏俏提供-->
        private void RunWhenStart(bool Started, string name, string path)
        {
            RegistryKey HKLM = Registry.LocalMachine;
            RegistryKey Run = HKLM.CreateSubKey(RegeditKeyPath);
            if (Started)
            {
                try
                {
                    Run.SetValue(name, path);
                    HKLM.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(STR10);
                }
            }
            else
            {
                try
                {
                    if (Run.GetValue(name) != null)
                    {
                        Run.DeleteValue(name);
                        HKLM.Close();
                    }
                    else
                        return;
                }
                catch (Exception)
                {
                    MessageBox.Show(STR11);
                }
            }
        }

        /// <summary>
        /// 关闭窗口时  序列化闹钟列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClockList cl = new ClockList();
            cl.List = list;
            fSer.FileSerialize(SERPATH, cl);
        }

        private void 设置音乐路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temp = MusicFilePath;
            MusicFilePath = "";
            string temp2= SoundSetting();
            if (string.IsNullOrEmpty(temp2) || (!File.Exists(temp2)))
                MusicFilePath = temp;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShow_Click(object sender, EventArgs e)
        {
            cmsSetting.Show(pnlSet, btnShow.Location.X, btnShow.Location.Y);
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MusicFilePath) || (!File.Exists(MusicFilePath)))
                SoundSetting();
            else
            {
                if (btnPlaySound.Tag.ToString() == PLAY)
                {
                    soundPlay.Play();
                    btnPlaySound.BackgroundImage = imgSmall.Images[1];
                    btnPlaySound.Tag = STOP;
                }
                else
                {
                    soundPlay.Stop();
                    btnPlaySound.BackgroundImage = imgSmall.Images[0];
                    btnPlaySound.Tag = PLAY;
                }
            }
        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSet == null || frmSet.IsDisposed)
            {
                frmSet = new frmSetting();
                frmSet.Show();
            }
            else
                frmSet.Activate();
        }

        private void 重新启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(STR19,STR13, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK) Application.Restart();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(STR20, STR13, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK) Application.Exit();
        }

        private void 快速定时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            DateTime dt=DateTime.Now;
            int index = Convert.ToInt32(item.Tag);
            int temp1=dt.Hour;
            int temp2=dt.Minute;
            switch (index)
            { 
                case 1:
                    switchAll(temp1, temp2, 1, 0);
                    break;
                case 2:
                    switchAll(temp1, temp2, 5, 0);
                    break;
                case 3:
                    switchAll(temp1, temp2, 10, 0);
                    break;
                case 4:
                    switchAll(temp1, temp2, 30, 0);
                    break;
                case 5:
                    switchAll(temp1, temp2, 0, 1);
                    break;
                default :
                    break;
            }
        }

        private void 自定义定时toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}