using dmp.Common;
using dmp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace dmp.Web.Filter
{
    public class PassportService
    {
        /// <summary>
        /// 验证用户授权token
        /// </summary>
        /// <returns></returns>
        public static string TokenReplace()
        {
            string strHost = HttpContext.Current.Request.Url.Host;
            string strPort = HttpContext.Current.Request.Url.Port.ToString();

            string url = String.Format("http://{0}:{1}{2}", strHost, strPort, HttpContext.Current.Request.RawUrl);
            url = Regex.Replace(url, @"(\?|&)Token=.*", "", RegexOptions.IgnoreCase);

            return AppSettingUtils.AuthUrl + "?referrerurl=" + url.Encrypt();
        }

        public void Run()
        {
            var token = Common.CookieUtils.GetCookie("token");
            User user = RedisUtils.Get<User>(token);

            if (user == null || user.UserId <= 0)
            {
                //令牌错误,重新登录
                Common.CookieUtils.AddCookie("token", token, -1);//立即过期
                HttpContext.Current.Response.Redirect(TokenReplace());
            }
            else
            {
                Common.CookieUtils.AddCookie("token", token, 30);
            }
        }
    }
}