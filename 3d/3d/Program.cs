using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _3d.Function;
using _3d.Others;
using System.Threading;

namespace _3d
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());

            loadMySQLCfg();

            Global.user_name = "";
            Login l = new Login();
            if (l.ShowDialog() == DialogResult.OK)//如果等于ok，就证明通过验证，则打开main窗口
            {
                string _user = Global.user_name;
                main ma = new main();
                Application.Run(ma);

                if (ma.IsDisposed)
                {
                    //程序关闭时写数据库
                    if (_user.Length > 0)
                    {
                        quitWriteSql();
                    }
                }
            }
        }

        // 读取数据库配置
        static void loadMySQLCfg()
        {
            LinkMySql.getSQLcfg(Global.soft_server_url + "\\MySQLConfig.xml");
        }

        //关闭程序时写注册表离线
        static void quitWriteSql()
        {
            if (Global.isNormalStatus == false)
                return;

            int res = LinkMySql.MySqlExcute("update " + Global.sqlUserTable + " set `online`='0' where user_name='" + Global.user_name + "'");
            if (res == 0)
            {
                MessageBox.Show("程序关闭时遇到问题，如果无法再次登录软件，请联系售后", "温馨提示", MessageBoxButtons.OKCancel);
            }
            else {
                Environment.Exit(0);
            }

            //try
            //{
                //WebConnect wc = new WebConnect();
               // string result = wc.sendStringMessage("http://eztx.cn/eztx/eztx_offline.php?username=" + Global.user_name + "");
               // Application.Exit();
            //}
            //catch
            //{
            //    MessageBox.Show("程序关闭时遇到问题，如果无法再次登录软件，请联系售后", "温馨提示");
            //}
        }
    }
}
