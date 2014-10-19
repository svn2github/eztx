using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using Public.Manager.File.Class;
using System.Media;


namespace mmClock
{
    public partial class frmMain
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            fisrtInit();
            Init();
        }

        /// <summary>
        /// ���س�ʼ��
        /// </summary>
        public void Init()
        {
            Deserialize();

            LoadData();

            UpdateRegistry();

            SoundSetting();
        }
        /// <summary>
        /// �ڳ�ʼ��֮ǰִ��
        /// </summary>
        public void fisrtInit()
        {
            RunPath = Application.ExecutablePath;
            RunPath = RunPath.Substring(0, RunPath.LastIndexOf("\\"));
            SERPATH = RunPath + "\\" + SERPATH;
            INIPATH = RunPath + "\\" + INIPATH;
            fIni = new FileIni(INIPATH);
            fSer = new FileSer();
            fTxt = new FileTxt();
            frmSet = null;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void LoadData()
        {
            string temp1 = fIni.IniReadValue(INIKEYNAME, INIMusciFilePath);//����·��
            string temp2 = fIni.IniReadValue(INIKEYNAME, INIAutomatismLogin).ToLower();//�Ƿ񿪻�����
            string temp3 = fIni.IniReadValue(INIKEYNAME, INIAutomatismStartClock).ToLower();//�Ƿ��Զ���������
            string temp4 = fIni.IniReadValue(INIKEYNAME, INIIsShowMini).ToLower();//�Ƿ���С��
            string temp5 = fIni.IniReadValue(INIKEYNAME, INIMsgBoxShowAgain).ToLower();//��Ϣ���Ƿ��´���ʾ
            string temp6 = fIni.IniReadValue(INIKEYNAME, INIMsgBoxShowTime);//��Ϣ����ʾʱ��
            string temp7 = fIni.IniReadValue(INIKEYNAME, INIMsgBoxTitle);//��Ϣ�����
            string temp8 = fIni.IniReadValue(INIKEYNAME, INIMsgBoxContent);//��Ϣ����ʾ����
            string temp9 = fIni.IniReadValue(INIKEYNAME, INIAutomatismShowLogin);//�Ƿ��ٴ���ʾ����������

            if (!string.IsNullOrEmpty(temp1))
                MusicFilePath = temp1;
            if (!string.IsNullOrEmpty(temp2))
                AutomatismLogin = Convert.ToBoolean(temp2);
            if (!string.IsNullOrEmpty(temp3))
                AutomatismStartClock = Convert.ToBoolean(temp3);
            if (!string.IsNullOrEmpty(temp4))
                IsShowMini = Convert.ToBoolean(temp4);
            if (!string.IsNullOrEmpty(temp5))
                MsgBoxShowAgain = Convert.ToBoolean(temp5);
            if (!string.IsNullOrEmpty(temp6))
                MsgBoxShowTime = Convert.ToInt32(temp6);
            if (!string.IsNullOrEmpty(temp7))
                MsgBoxTitle = temp7;
            if (!string.IsNullOrEmpty(temp8))
                MsgBoxContent = temp8;
            if (!string.IsNullOrEmpty(temp9))
                AutomatismShowLogin = Convert.ToBoolean(temp9);
        }

        /// <summary>
        /// �����л� �����б� ���ص�������ͼ��
        /// </summary>
        public void Deserialize()
        {
            ClockList cl = new ClockList();
            try
            {
                cl = (ClockList)fSer.FileDeserialize(SERPATH);
            }
            catch (Exception)
            {
                fSer.FileSerialize(SERPATH, cl);
            }
            list = cl.List;
            for (int i = 0; i < list.Count; i++)
            {
                Clock c = list[i];
                c.STime = STR17;
                if (c.State == ON)
                    AutomatismStartClock = true;
                list[i] = c;
            }
            BindList();
            btnPlaySound.Tag = PLAY;
        }

        /// <summary>
        /// �޸�ע���
        /// </summary>
        public void UpdateRegistry()
        {
            RegistryKey HKLM = Registry.LocalMachine;
            RegistryKey Run = HKLM.CreateSubKey(RegeditKeyPath);
            if (AutomatismShowLogin)
            {
                Run.DeleteValue(RegeditKeyName, false);
                if (MessageBox.Show(STR12, STR13, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    RunWhenStart(true, RegeditKeyName, RunPath);
                    AutomatismLogin = true;
                }
                else
                {
                    RunWhenStart(false, RegeditKeyName, RunPath);
                    AutomatismLogin = false;
                }
            }
            else
            {
                string isExists = "true";
                isExists = Run.GetValue(RegeditKeyName, "false").ToString();
                if (isExists == "false")
                {
                    if (AutomatismLogin)
                        RunWhenStart(true, RegeditKeyName, RunPath);
                }
                else
                    if (!AutomatismLogin)
                        RunWhenStart(false, RegeditKeyName, RunPath);
            }
        }

        /// <summary>
        /// ������������
        /// </summary>
        public string SoundSetting()
        {
            if (string.IsNullOrEmpty(MusicFilePath) || (!File.Exists(MusicFilePath)))
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "*.wav|*.wav";
                op.Multiselect = false;
                op.Title = "��ѡ�����������ļ�";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    MusicFilePath = op.FileName;
                    fIni.IniWriteValue(INIKEYNAME, INIMusciFilePath, MusicFilePath);
                }
            }
            try
            {
                soundPlay = new SoundPlayer(MusicFilePath);
                txtSounPath.Text = MusicFilePath;
            }
            catch { }
            return MusicFilePath;
        }

        /// <summary>
        /// ������
        /// </summary>
        public void BindList()
        {
            dgvList.DataSource = new List<Clock>();
            dgvList.DataSource = list;
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void PlaySound()
        {
            btnPlaySound.PerformClick();
        }

        /// <summary>
        /// ��������(ÿ��)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hh2"></param>
        /// <param name="mm2"></param>
        private void StartClock(DateTime dt, int hh2, int mm2)
        {
            int h1 = dt.Hour;
            int m1 = dt.Minute;
            int h2 = hh2;
            int m2 = mm2;
            int allSec = 0;//������

            for (int i = 0; i < list.Count; i++)
            {
                Clock temp = list[i];
                string temp1 = temp.Time;
                h2 = Convert.ToInt32(temp1.Substring(0, temp1.IndexOf(":")));

                m2 = Convert.ToInt32(temp1.Substring(temp1.IndexOf(":") + 1));

                allSec = (h2 - h1) * 60 * 60 + (m2 - m1) * 60 + (0 - dt.Second);//������

                if (allSec < 0)// ��ʵ��24Сʱ���ڵĶ�ʱ����
                    allSec = (h2 + 24 - h1) * 60 * 60 + (m2 - m1) * 60 + (0 - dt.Second);

                if (temp.State == OFF)
                    temp.STime = STR18;
                else
                    temp.STime = GetTimeStr(allSec);

                list[i] = temp;

                if (allSec == 0 && temp.State == ON)
                {
                    btnPlaySound.Tag = PLAY;
                    PlaySound();
                    btnPlaySound.Tag = STOP;
                    ShowMessage();
                }
            }
            dgvList.DataSource = new List<Clock>();
            dgvList.DataSource = list;
        }

        /// <summary>
        /// ��������( ����)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="h2">��ʱ ʱ</param>
        /// <param name="m2"></param>
        private void StartClock(DateTime dt)
        {
            int h1 = dt.Hour;
            int m1 = dt.Minute;
            int h2 = Convert.ToInt32(txtHour.Text);
            int m2 = Convert.ToInt32(txtMin.Text);
            int allSec = (h2 - h1) * 60 * 60 + (m2 - m1) * 60 + (0 - dt.Second);//������

            if (allSec < 0)// ��ʵ��24Сʱ���ڵĶ�ʱ����
                allSec = (h2 + 24 - h1) * 60 * 60 + (m2 - m1) * 60 + (0 - dt.Second);

            lblInfo1.Text = STR3 + STR2 + SPACE + GetTimeStr(allSec);

            lblInfo2.Text = STR4 + STR2 + SPACE + allSec + SPACE + SECOND;

            if (allSec == 0)
            {
                PlaySound();
                isOk = false;
                ShowMessage();
            }
        }

        /// <summary>
        /// �õ�����ʱʱ��
        /// </summary>
        /// <param name="allSec"></param>
        /// <returns></returns>
        private string GetTimeStr(int allSec)
        {
            string temp = ((allSec / 60 / 60) < 1 ? (allSec / 60) < 1 ?
                 (allSec / 60 / 60) + HOUR + (allSec / 60) + MINUTE + allSec + SECOND :
                 (allSec / 60 / 60) + HOUR + (allSec / 60) + MINUTE + (allSec - (allSec / 60) * 60) + SECOND :
                 (allSec / 60 / 60) + HOUR + (allSec / 60 - (allSec / 60 / 60) * 60) + MINUTE + (allSec - (allSec / 60) * 60) + SECOND);
            return temp;
        }

        /// <summary>
        /// ��ʾ��ʾ��Ϣ
        /// </summary>
        private void ShowMessage()
        {
            frmMessage mf = new frmMessage();
            bool isExists = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == mf.Name)
                {
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
                mf.Show();
            else
                mf.Activate();
        }

        /// <summary>
        /// �õ�ϵͳʱ��
        /// </summary>
        /// <param name="dt"></param>
        private void TimerMeth(DateTime dt)
        {
            if (lblTime.Text == ZERO)
            {
                lblDate.Text = GetDate(dt);
                this.Text = "ľľ����Beta3.0  ��������" +
              (dt.DayOfWeek == DayOfWeek.Sunday ? "��" :
              dt.DayOfWeek == DayOfWeek.Monday ? "һ" :
              dt.DayOfWeek == DayOfWeek.Tuesday ? "��" :
              dt.DayOfWeek == DayOfWeek.Wednesday ? "��" :
             dt.DayOfWeek == DayOfWeek.Saturday ? "��" :
             dt.DayOfWeek == DayOfWeek.Friday ? "��" :
             dt.DayOfWeek == DayOfWeek.Saturday ? "��" : "δ֪");
            }
            lblTime.Text = GetTime(dt);
        }

        /// <summary>
        /// �õ�ʱ��
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetTime(DateTime dt)
        {
            string hh = string.Format(STR5, dt.Hour);
            string mm = string.Format(STR5, dt.Minute);
            string ss = string.Format(STR5, dt.Second);
            return hh + STR2 + mm + STR2 + ss;
        }

        /// <summary>
        /// �õ�����
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetDate(DateTime dt)
        {
            string year = string.Format(STR6, dt.Year);
            string month = string.Format(STR5, dt.Month);
            string day = string.Format(STR5, dt.Day);
            return year + YEAR + month + MONTH + day + DAY;
        }

        /// <summary>
        /// ֹͣ
        /// </summary>
        private void PlayStop()
        {
            txtHour.Enabled = true;
            txtMin.Enabled = true;
            btnStart.Enabled = true;
            isOk = false;
            lblInfo2.Text = STATE;
            lblInfo1.Text = STATE;
            btnAdd.Enabled = true;
            txtHour.Focus();
            if (dgvList.Rows.Count > 0)
            {
                btnClear.Enabled = true;
                for (int i = 0; i < list.Count; i++)
                {
                    Clock c = list[i];
                    c.STime = STR17;
                    list[i] = c;
                }
                BindList();
            }

        }

        /// <summary>
        /// ��Ӷ�ʱʱ�䵽�б�
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="min"></param>
        private void SetClockStart(int hour, int min)
        {
            Clock c = new Clock();
            int temp1 = hour;
            int temp2 = min;
            c.Time = temp1 + STR2 + temp2;
            c.STime = STR17;
            c.State = ON;

            bool isBool = false;
            for (int i = 0; i < list.Count; i++)
            {
                Clock c2 = list[i];
                string temp = c2.Time;
                int ccc1 = Convert.ToInt32(temp.Substring(0, temp.IndexOf(":")));

                int ccc2 = Convert.ToInt32(temp.Substring(temp.IndexOf(":") + 1));

                if (temp1 == ccc1 && temp2 == ccc2)
                {
                    isBool = true;
                    ttInfo.Show(TTXT1, btnAdd);
                    return;
                }
                else
                    ttInfo.Show(TTXT2, btnAdd);
            }
            if (!isBool)
                list.Add(c);
            BindList();
        }

        /// <summary>
        /// ��ʱ����
        /// </summary>
        /// <param name="temp1">����Сʱ</param>
        /// <param name="temp2">���ڷ���</param>
        /// <param name="temp3">����������</param>
        /// <param name="temp4">����Сʱ��</param>
        private void switchAll(int temp1, int temp2, int temp3, int temp4)
        {
            if (temp4 == 0)
            {
                if ((temp2 + temp3) > 59)
                    SetClockStart(temp1 + 1, temp2 + temp3 - 59);
                else
                    SetClockStart(temp1, temp2 + temp3);
            }
            else
                SetClockStart(temp1 + temp4, temp2);
        }
    }
}
