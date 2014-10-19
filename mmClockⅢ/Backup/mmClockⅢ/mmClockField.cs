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

        #region 公有常量

        #region 程序中用到的文字
        /// <summary>
        ///"启用";
        /// </summary>
        public const string ON = "启用";
        /// <summary>
        /// "关闭";
        /// </summary>
        public const string OFF = "关闭";
        /// <summary>
        /// 注意 : 闹钟已启动
        /// </summary>
        public const string CLOCKON = "就绪 : 闹钟已启动";
        /// <summary>
        ///注意 : 闹钟未启动 ！
        /// </summary>
        public const string CLOCKOFF = "注意 : 闹钟未启动 ！";
        /// <summary>
        /// "播 放 音 乐"
        /// </summary>
        public const string PLAY = "播 放 音 乐";
        /// <summary>
        /// "停 止 音 乐"
        /// </summary>
        public const string STOP = "停 止 音 乐";
        /// <summary>
        /// "就绪"
        /// </summary>
        public const string STATE = "就绪";
        /// <summary>
        /// "时间格式有误"
        /// </summary>
        public const string ERROR = "时间格式有误";
        /// <summary>
        /// "时"
        /// </summary>
        public const string HOUR = "时";
        /// <summary>
        /// "分"
        /// </summary>
        public const string MINUTE = "分";
        /// <summary>
        /// "秒"
        /// </summary>
        public const string SECOND = "秒";
        /// <summary>
        /// "年"
        /// </summary>
        public const string YEAR = "年";
        /// <summary>
        /// "月"
        /// </summary>
        public const string MONTH = "月";
        /// <summary>
        /// "日"
        /// </summary>
        public const string DAY = "日";
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
        /// "还剩"
        /// </summary>
        public const string STR3 = "还剩";
        /// <summary>
        /// "总计"
        /// </summary>
        public const string STR4 = "总计";
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
        /// "已经选中第"
        /// </summary>
        public const string STR8 = "已经选中第";
        /// <summary>
        /// "个"
        /// </summary>
        public const string STR9 = "个";
        /// <summary>
        /// 修改注册表失败，开机启动未实现
        /// </summary>
        public const string STR10 = "修改注册表失败，开机启动未实现";
        /// <summary>
        /// 修改注册表失败，开机不启动未实现
        /// </summary>
        public const string STR11 = "修改注册表失败，开机不启动未实现";
        /// <summary>
        /// "为了您的方便，下次开机是否自动启动?";
        /// </summary>
        public const string STR12 = "为了您的方便，下次开机是否自动启动?";
        /// <summary>
        /// "提示"
        /// </summary>
        public const string STR13 = "提示";
        /// <summary>
        /// ","
        /// </summary>
        public const string STR14 = ",";
        /// <summary>
        /// "确定删除吗？"
        /// </summary>
        public const string STR15 = "确定删除吗？";
        /// <summary>
        /// "确定清空吗？"
        /// </summary>
        public const string STR16 = "确定删除列表中所有的闹钟计划吗？";
        /// <summary>
        /// "闹钟未启动"
        /// </summary>
        public const string STR17 = "闹钟未启动";
        /// <summary>
        /// "闹钟未激活"
        /// </summary>
        public const string STR18 = "闹钟未激活";
        /// <summary>
        /// "确定重新启动程序吗？";
        /// </summary>
        public const string STR19="确定重新启动程序吗？";
        /// <summary>
        /// "确定退出程序吗？";
        /// </summary>
        public const string STR20 = "确定退出程序吗？";

        /// <summary>
        /// "添加时间重复"
        /// </summary>
        public const string TTXT1 = "添加时间重复";
        /// <summary>
        /// ""
        /// </summary>
        public const string TTXT2 = "";

        #endregion

        #region 配置文件相关

        /// <summary>
        /// 配置文件的节点名 "mmClockSetting"
        /// </summary>
        public const string INIKEYNAME = "mmClockSetting";
        /// <summary>
        /// 音乐文件路径 "MusciFilePath"
        /// </summary>
        public const string INIMusciFilePath = "MusciFilePath";
        /// <summary>
        /// 是否开机自动启动 "AutomatismLogin"
        /// </summary>
        public const string INIAutomatismLogin = "AutomatismLogin";
        /// <summary>
        /// 是否提示开机启动 "AutomatismShowLogin"
        /// </summary>
        public const string INIAutomatismShowLogin = "AutomatismShowLogin";
        /// <summary>
        /// 是否自动启动闹钟 "AutomatismStartClock";
        /// </summary>
        public const string INIAutomatismStartClock = "AutomatismStartClock";
        /// <summary>
        /// 启动后是否最小化 "IsShowMini";
        /// </summary>
        public const string INIIsShowMini = "IsShowMini";
        /// <summary>
        /// 下次是否再次显示 "MsgBoxShowAgain"
        /// </summary>
        public const string INIMsgBoxShowAgain = "MsgBoxShowAgain";
        /// <summary>
        /// 消息框显示时间 "MsgBoxShowTime";
        /// </summary>
        public const string INIMsgBoxShowTime = "MsgBoxShowTime";
        /// <summary>
        /// 消息框标题 "MsgBoxTitle";
        /// </summary>
        public const string INIMsgBoxTitle = "MsgBoxTitle";
        /// <summary>
        /// 消息框显示内容 "MsgBoxContent";
        /// </summary>
        public const string INIMsgBoxContent = "MsgBoxContent";

        #endregion

        #region 注册表相关

        /// <summary>
        /// 注册表中 名称
        /// </summary>
        public const string RegeditKeyName = "mmClock";
        /// <summary>
        /// 注册表中 路径
        /// </summary>
        public const string RegeditKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\";

        #endregion

        #endregion

        #region 共有字段

        public FileIni fIni;
        public FileSer fSer;
        public FileTxt fTxt;

        /// <summary>
        /// 闹钟列表文件路径 @"Config\Clock.list";
        /// </summary>
        public string SERPATH =  @"Config\Clock.list";
        /// <summary>
        /// 配置文件路径 @"Config\Config.ini";
        /// </summary>
        public string INIPATH = @"Config\Config.ini";

        /// <summary>
        /// 播放音乐
        /// </summary>
        public SoundPlayer soundPlay;
        /// <summary>
        /// frmSetting (设置窗口)
        /// </summary>
        public frmSetting frmSet;

        /// <summary>
        /// 标识
        /// </summary>
        bool isOk = false;
        /// <summary>
        /// 视图中的数据
        /// </summary>
        List<Clock> list = new List<Clock>();
        /// <summary>
        /// 选择视图中项的 索引
        /// </summary>
        int dgvIndex = 0;
        /// <summary>
        /// 程序运行路径
        /// </summary>
        public string RunPath = Application.ExecutablePath;
        /// <summary>
        /// 音乐文件路径
        /// </summary>
        public static string MusicFilePath = @"D:\Multimedia\Music\试音\蝶飞花舞 大唐豪侠百花宫主题音乐.wav";
        /// <summary>
        /// 注册表中 值
        /// </summary>
        public static bool RegeditKeyValue = true;
        /// <summary>
        /// 是否提示开机启动
        /// </summary>
        public static bool AutomatismLogin = true;
        /// <summary>
        /// 是否提示开机启动
        /// </summary>
        public static bool AutomatismShowLogin = true;
        /// <summary>
        /// 是否自动启动闹钟
        /// </summary>
        public static bool AutomatismStartClock = false;
        /// <summary>
        /// 是否最小化
        /// </summary>
        public static bool IsShowMini = true;
        /// <summary>
        /// 是否下次显示消息提示框
        /// </summary>
        public static bool MsgBoxShowAgain = true;
        /// <summary>
        /// 消息框显示时间
        /// </summary>
        public static int MsgBoxShowTime = 5;
        /// <summary>
        /// 消息框标题
        /// </summary>
        public static string MsgBoxTitle = "提示消息";
        /// <summary>
        /// 消息框文本内容
        /// </summary>
        public static string MsgBoxContent = "闹钟时间到";

        #endregion

    }
}
