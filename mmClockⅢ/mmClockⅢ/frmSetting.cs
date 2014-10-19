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
    public partial class frmSetting : Form
    {
        FileIni fIni;
        frmMain frmMain;
        public frmSetting()
        {
            InitializeComponent();
            frmMain = new frmMain();
            fIni = new FileIni(frmMain.INIPATH);
        }

        private void SettIngForm_Load(object sender, EventArgs e)
        {
            cbIsShowLogin.Checked = frmMain.AutomatismShowLogin;
            cbIsLogin.Checked = frmMain.AutomatismLogin;
            cbShow.Checked = frmMain.MsgBoxShowAgain;
            cbIsStart.Checked = frmMain.AutomatismStartClock;
            cbIsMin.Checked = frmMain.IsShowMini;

            nudTime.Value = frmMain.MsgBoxShowTime;
            txtTitle.Text = frmMain.MsgBoxTitle;
            txtContent.Text = frmMain.MsgBoxContent;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnSubmit.PerformClick();
            btnClose.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
            fIni.IniWriteValue(frmMain.INIKEYNAME, frmMain.INIAutomatismShowLogin, cbIsShowLogin.Checked.ToString().ToLower());
            fIni.IniWriteValue(frmMain.INIKEYNAME, frmMain.INIAutomatismLogin, cbIsLogin.Checked.ToString().ToLower());
            fIni.IniWriteValue(frmMain.INIKEYNAME, frmMain.INIMsgBoxShowAgain, cbShow.Checked.ToString().ToLower());
            fIni.IniWriteValue(frmMain.INIKEYNAME, frmMain.INIAutomatismStartClock, cbIsStart.Checked.ToString().ToLower());
            fIni.IniWriteValue(frmMain.INIKEYNAME, frmMain.INIIsShowMini, cbIsMin.Checked.ToString().ToLower());

            fIni.IniWriteValue(frmMain.INIKEYNAME, frmMain.INIMsgBoxShowTime, nudTime.Value.ToString());
            fIni.IniWriteValue(frmMain.INIKEYNAME, frmMain.INIMsgBoxTitle, txtTitle.Text.Trim());
            fIni.IniWriteValue(frmMain.INIKEYNAME, frmMain.INIMsgBoxContent, txtContent.Text.Trim());

            frmMain.UpdateRegistry();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (txtTitle.Text.Length <= 0)
            {
                btnOk.Enabled = false;
                btnSubmit.Enabled = false;
            }
            else
            {
                btnOk.Enabled = true;
                btnSubmit.Enabled = true;
            }

            lblInfo1.Text = "可以输入" + (12 - txtTitle.Text.Length) + "个字";
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            if (txtContent.Text.Length <= 0)
            {
                btnOk.Enabled = false;
                btnSubmit.Enabled = false;
            }
            else
            {
                btnOk.Enabled = true;
                btnSubmit.Enabled = true;
            }
            lblInfo2.Text = "可以输入" + (30 - txtContent.Text.Length) + "个字";
        }

        private void cbIsShowLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsShowLogin.Checked)
                cbIsLogin.Enabled = true;
            else
                cbIsLogin.Enabled = false;

        }

        private void SaveData()
        {
            frmMain.AutomatismShowLogin = cbIsShowLogin.Checked;
            frmMain.AutomatismLogin = cbIsLogin.Checked;
            frmMain.MsgBoxShowAgain = cbShow.Checked;
            frmMain.AutomatismStartClock = cbIsStart.Checked;
            frmMain.IsShowMini = cbIsMin.Checked;

            frmMain.MsgBoxShowTime = Convert.ToInt32(nudTime.Value);
            frmMain.MsgBoxTitle = txtTitle.Text.Trim();
            frmMain.MsgBoxContent = txtContent.Text.Trim();
        }
    }
}