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
        //loginType为登录方式，等于1时是通过用户名密码登录，等于2为通过机器码登录
        public static string user_name, user_realname,user_province, user_vali, allowlogin,main_msg,splitRegex,loginType;
        public static string sqlUserTable = "user_wucaijun";//表名，通用表名
        public static string soft_url = "http://eztx.cn/soft_wucaijun";
    }
}
