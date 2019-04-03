using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dmp.Common
{
    public static class CookieUtils
    {
        public static void AddCookie(string key, string value, int expires)
        {
            var cookie = new HttpCookie(key);
            cookie.Value = value;
            cookie.Domain = AppSettingUtils.Domain;
            cookie.Path = AppSettingUtils.Path;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static string GetCookie(string key)
        {
            var httpCookie = HttpContext.Current.Request.Cookies[key];

            if (httpCookie != null)
            {
                return httpCookie.Value;
            }
            return "";
        }

        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Encrypt(this string s)
        {
            return DESEncrypt.Encrypt(s);
        }
        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Decrypt(this string s)
        {
            return DESEncrypt.Decrypt(s);
        }
    }
}