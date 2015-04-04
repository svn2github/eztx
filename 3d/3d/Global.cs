using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3d
{
    public class Global
    {
        //将登录者的信息存入内存当中，以便随时调用
        //user_name为用户名
        //user_realname为用户真实姓名
        //user_vali为用户权限
        //allowlogin为是否允许登录
        //splitRegex为每组数字之间的分隔符
        //main_msg为main页面上方滚动条文字
        //loginType为登录方式，等于1是通过用户名密码登录，等于2为通过机器码登录
        public static string user_name, user_realname, user_province, user_vali, allowlogin, main_msg, splitRegex, loginType;

        /// <summary>
        /// 判断是否是正常关闭，如果是异地登录，那么就不是正常关闭，就不用写入数据库下线的信息
        /// 默认为正常true
        /// </summary>
        public static bool isNormalStatus = true;

        public static string soft_server_url = "http://eztx.eztx.cn/other_soft";
        public static string version = string.Empty;//当前软件版本
        public static string sqlAddress = string.Empty;//数据库地址
        public static string sqlPort = string.Empty;//数据库端口
        public static string sqlUsername = string.Empty;//数据库用户名
        public static string sqlPwd = string.Empty;//数据库密码
        public static string sqlDB = string.Empty;//数据库所用库
        public static string sqlCharset = string.Empty;//数据库所用库
        public static string sqlUserTable = string.Empty;//表名，通用表名
    }
}
