using System;
using System.Collections.Generic;
using System.Text;
using Public.Manager.File.Class;
using System.Media;
using System.Windows.Forms;

namespace mmClock
{
    public partial class frmMain
    {

        #region ���г���

        #region �������õ�������
        /// <summary>
        ///"����";
        /// </summary>
        public const string ON = "����";
        /// <summary>
        /// "�ر�";
        /// </summary>
        public const string OFF = "�ر�";
        /// <summary>
        /// ע�� : ����������
        /// </summary>
        public const string CLOCKON = "���� : ����������";
        /// <summary>
        ///ע�� : ����δ���� ��
        /// </summary>
        public const string CLOCKOFF = "ע�� : ����δ���� ��";
        /// <summary>
        /// "�� �� �� ��"
        /// </summary>
        public const string PLAY = "�� �� �� ��";
        /// <summary>
        /// "ͣ ֹ �� ��"
        /// </summary>
        public const string STOP = "ͣ ֹ �� ��";
        /// <summary>
        /// "����"
        /// </summary>
        public const string STATE = "����";
        /// <summary>
        /// "ʱ���ʽ����"
        /// </summary>
        public const string ERROR = "ʱ���ʽ����";
        /// <summary>
        /// "ʱ"
        /// </summary>
        public const string HOUR = "ʱ";
        /// <summary>
        /// "��"
        /// </summary>
        public const string MINUTE = "��";
        /// <summary>
        /// "��"
        /// </summary>
        public const string SECOND = "��";
        /// <summary>
        /// "��"
        /// </summary>
        public const string YEAR = "��";
        /// <summary>
        /// "��"
        /// </summary>
        public const string MONTH = "��";
        /// <summary>
        /// "��"
        /// </summary>
        public const string DAY = "��";
        /// <summary>
        /// " "
        /// </summary>
        public const string SPACE = " ";
        /// <summary>
        /// "00:00:00"
        /// </summary>
        public const string ZERO = "00:00:00";
        /// <summary>
        /// "--"
        /// </summary>
        public const string STR1 = "--";
        /// <summary>
        /// ":"
        /// </summary>
        public const string STR2 = ":";
        /// <summary>
        /// "��ʣ"
        /// </summary>
        public const string STR3 = "��ʣ";
        /// <summary>
        /// "�ܼ�"
        /// </summary>
        public const string STR4 = "�ܼ�";
        /// <summary>
        /// "{0:00}"
        /// </summary>
        public const string STR5 = "{0:00}";
        /// <summary>
        /// "{0:0000}"
        /// </summary>
        public const string STR6 = "{0:0000}";
        /// <summary>
        /// "0"
        /// </summary>
        public const string STR7 = "0";
        /// <summary>
        /// "�Ѿ�ѡ�е�"
        /// </summary>
        public const string STR8 = "�Ѿ�ѡ�е�";
        /// <summary>
        /// "��"
        /// </summary>
        public const string STR9 = "��";
        /// <summary>
        /// �޸�ע���ʧ�ܣ���������δʵ��
        /// </summary>
        public const string STR10 = "�޸�ע���ʧ�ܣ���������δʵ��";
        /// <summary>
        /// �޸�ע���ʧ�ܣ�����������δʵ��
        /// </summary>
        public const string STR11 = "�޸�ע���ʧ�ܣ�����������δʵ��";
        /// <summary>
        /// "Ϊ�����ķ��㣬�´ο����Ƿ��Զ�����?";
        /// </summary>
        public const string STR12 = "Ϊ�����ķ��㣬�´ο����Ƿ��Զ�����?";
        /// <summary>
        /// "��ʾ"
        /// </summary>
        public const string STR13 = "��ʾ";
        /// <summary>
        /// ","
        /// </summary>
        public const string STR14 = ",";
        /// <summary>
        /// "ȷ��ɾ����"
        /// </summary>
        public const string STR15 = "ȷ��ɾ����";
        /// <summary>
        /// "ȷ�������"
        /// </summary>
        public const string STR16 = "ȷ��ɾ���б������е����Ӽƻ���";
        /// <summary>
        /// "����δ����"
        /// </summary>
        public const string STR17 = "����δ����";
        /// <summary>
        /// "����δ����"
        /// </summary>
        public const string STR18 = "����δ����";
        /// <summary>
        /// "ȷ����������������";
        /// </summary>
        public const string STR19="ȷ����������������";
        /// <summary>
        /// "ȷ���˳�������";
        /// </summary>
        public const string STR20 = "ȷ���˳�������";

        /// <summary>
        /// "���ʱ���ظ�"
        /// </summary>
        public const string TTXT1 = "���ʱ���ظ�";
        /// <summary>
        /// ""
        /// </summary>
        public const string TTXT2 = "";

        #endregion

        #region �����ļ����

        /// <summary>
        /// �����ļ��Ľڵ��� "mmClockSetting"
        /// </summary>
        public const string INIKEYNAME = "mmClockSetting";
        /// <summary>
        /// �����ļ�·�� "MusciFilePath"
        /// </summary>
        public const string INIMusciFilePath = "MusciFilePath";
        /// <summary>
        /// �Ƿ񿪻��Զ����� "AutomatismLogin"
        /// </summary>
        public const string INIAutomatismLogin = "AutomatismLogin";
        /// <summary>
        /// �Ƿ���ʾ�������� "AutomatismShowLogin"
        /// </summary>
        public const string INIAutomatismShowLogin = "AutomatismShowLogin";
        /// <summary>
        /// �Ƿ��Զ��������� "AutomatismStartClock";
        /// </summary>
        public const string INIAutomatismStartClock = "AutomatismStartClock";
        /// <summary>
        /// �������Ƿ���С�� "IsShowMini";
        /// </summary>
        public const string INIIsShowMini = "IsShowMini";
        /// <summary>
        /// �´��Ƿ��ٴ���ʾ "MsgBoxShowAgain"
        /// </summary>
        public const string INIMsgBoxShowAgain = "MsgBoxShowAgain";
        /// <summary>
        /// ��Ϣ����ʾʱ�� "MsgBoxShowTime";
        /// </summary>
        public const string INIMsgBoxShowTime = "MsgBoxShowTime";
        /// <summary>
        /// ��Ϣ����� "MsgBoxTitle";
        /// </summary>
        public const string INIMsgBoxTitle = "MsgBoxTitle";
        /// <summary>
        /// ��Ϣ����ʾ���� "MsgBoxContent";
        /// </summary>
        public const string INIMsgBoxContent = "MsgBoxContent";

        #endregion

        #region ע������

        /// <summary>
        /// ע����� ����
        /// </summary>
        public const string RegeditKeyName = "mmClock";
        /// <summary>
        /// ע����� ·��
        /// </summary>
        public const string RegeditKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\";

        #endregion

        #endregion

        #region �����ֶ�

        public FileIni fIni;
        public FileSer fSer;
        public FileTxt fTxt;

        /// <summary>
        /// �����б��ļ�·�� @"Config\Clock.list";
        /// </summary>
        public string SERPATH =  @"Config\Clock.list";
        /// <summary>
        /// �����ļ�·�� @"Config\Config.ini";
        /// </summary>
        public string INIPATH = @"Config\Config.ini";

        /// <summary>
        /// ��������
        /// </summary>
        public SoundPlayer soundPlay;
        /// <summary>
        /// frmSetting (���ô���)
        /// </summary>
        public frmSetting frmSet;

        /// <summary>
        /// ��ʶ
        /// </summary>
        bool isOk = false;
        /// <summary>
        /// ��ͼ�е�����
        /// </summary>
        List<Clock> list = new List<Clock>();
        /// <summary>
        /// ѡ����ͼ����� ����
        /// </summary>
        int dgvIndex = 0;
        /// <summary>
        /// ��������·��
        /// </summary>
        public string RunPath = Application.ExecutablePath;
        /// <summary>
        /// �����ļ�·��
        /// </summary>
        public static string MusicFilePath = @"D:\Multimedia\Music\����\���ɻ��� ���ƺ����ٻ�����������.wav";
        /// <summary>
        /// ע����� ֵ
        /// </summary>
        public static bool RegeditKeyValue = true;
        /// <summary>
        /// �Ƿ���ʾ��������
        /// </summary>
        public static bool AutomatismLogin = true;
        /// <summary>
        /// �Ƿ���ʾ��������
        /// </summary>
        public static bool AutomatismShowLogin = true;
        /// <summary>
        /// �Ƿ��Զ���������
        /// </summary>
        public static bool AutomatismStartClock = false;
        /// <summary>
        /// �Ƿ���С��
        /// </summary>
        public static bool IsShowMini = true;
        /// <summary>
        /// �Ƿ��´���ʾ��Ϣ��ʾ��
        /// </summary>
        public static bool MsgBoxShowAgain = true;
        /// <summary>
        /// ��Ϣ����ʾʱ��
        /// </summary>
        public static int MsgBoxShowTime = 5;
        /// <summary>
        /// ��Ϣ�����
        /// </summary>
        public static string MsgBoxTitle = "��ʾ��Ϣ";
        /// <summary>
        /// ��Ϣ���ı�����
        /// </summary>
        public static string MsgBoxContent = "����ʱ�䵽";

        #endregion

    }
}
