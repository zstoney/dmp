
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using ServiceStack.ServiceHost;
using ServiceStack.Text;

namespace dmp.Common
{
    /// <summary>
    /// 异常处理工具类
    /// 1、处理ServiceStack Service中抛出的异常
    /// 2、记录ASP.NET程序全局未处理异常
    /// </summary>
    public static class ExceptionUtils
    {
        ///// <summary>
        ///// 处理ServiceStack Service中抛出的异常
        ///// </summary>
        ///// <param name="httpRequest">当前执行的http请求</param>
        ///// <param name="request">RequestDTO</param>
        ///// <param name="ex">抛出的异常</param>
        ///// <returns></returns>
        //public static object HandleServiceException(IHttpRequest httpRequest, object request, Exception ex)
        //{
        //    if (EndpointHost.Config != null && EndpointHost.Config.ReturnsInnerException
        //        && ex.InnerException != null && !(ex is IHttpError))
        //    {
        //        ex = ex.InnerException;
        //    }
        //    LogServiceException(httpRequest, request, ex);
        //    var responseStatus = ex.ToResponseStatus();
        //    var errorResponse = DtoUtils.CreateErrorResponse(request, ex, responseStatus);
        //    return errorResponse;
        //}

        /// <summary>
        /// 记录ASP.NET程序全局未处理异常
        /// </summary>
        /// <param name="request">当前执行的http请求</param>
        /// <param name="ex">抛出的异常</param>
        public static void LogHttpApplicationError(HttpRequest request, Exception ex)
        {
            StringBuilder msg = new StringBuilder()
            .Append(Environment.NewLine)
            .Append("ServerIP:    ").Append(GetServerIP()).Append(Environment.NewLine)
            .Append("RemoteIP:    ").Append(GetRemoteIP(request)).Append(Environment.NewLine)
            .Append("UserAgent:   ").Append(request.UserAgent).Append(Environment.NewLine)
            .Append("AbsoluteUri: ").Append(request.Url.AbsoluteUri).Append(Environment.NewLine)
            .Append("UrlReferrer:   ").Append(request.UrlReferrer).Append(Environment.NewLine)
            .Append("Exception:   ").Append(ex.ToString()).Append(Environment.NewLine)

            .Append("-------------------------------------------------------------------------------").Append(Environment.NewLine);
            Log.Error(msg);
        }

        /// <summary>
        /// 记录ServiceStack Service中抛出的异常
        /// </summary>
        /// <param name="httpRequest">当前执行的http请求</param>
        /// <param name="request">RequestDTO</param>
        /// <param name="ex">抛出的异常</param>
        private static void LogServiceException(IHttpRequest httpRequest, object request, Exception ex)
        {
            StringBuilder msg = new StringBuilder()
            .Append(Environment.NewLine)
            .Append("ServerIP:    ").Append(GetServerIP()).Append(Environment.NewLine)
            .Append("RemoteIP:    ").Append(httpRequest.RemoteIp).Append(Environment.NewLine)
            .Append("UserAgent:   ").Append(httpRequest.UserAgent).Append(Environment.NewLine)
            .Append("AbsoluteUri: ").Append(httpRequest.AbsoluteUri).Append(Environment.NewLine)
            .Append("Request:     ").Append(SerializeRequest(request)).Append(Environment.NewLine)
             .Append("UrlReferrer:   ").Append(httpRequest.RawUrl).Append(Environment.NewLine)
            .Append("Exception:   ").Append(ex.ToString()).Append(Environment.NewLine)
            .Append("-------------------------------------------------------------------------------").Append(Environment.NewLine);
            Log.Error(msg);
        }

        /// <summary>
        /// 获取服务器IP列表，以；分割
        /// </summary>
        private static string GetServerIP()
        {
            string machineIP = String.Empty;
            IPAddress[] ipList = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in ipList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    machineIP += ip.ToString() + "; ";
            }
            if (machineIP.EndsWith("; "))
            {
                machineIP = machineIP.Substring(0, machineIP.Length - 2);
            }
            return machineIP;
        }

        /// <summary>
        /// 序列化RequestDTO
        /// </summary>
        /// <param name="request">RequestDTO</param>
        /// <returns>序列化后的字符串</returns>
        private static string SerializeRequest(object request)
        {
            try
            {
                return TypeSerializer.SerializeToString(request);
            }
            catch
            {
                return "Serialize request failure.";
            }
        }

        /// <summary>
        /// 获取发起当前请求机器的IP地址
        /// </summary>
        /// <param name="request">当前执行http请求</param>
        /// <returns>当前发起请求机器的IP地址</returns>
        private static string GetRemoteIP(HttpRequest request)
        {
            var ip = request.Headers["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrWhiteSpace(ip) || ip.ToLower().IndexOf("unknown") >= 0)
            {
                ip = request.Headers["X-Real-IP"];
            }
            if (string.IsNullOrWhiteSpace(ip))
            {
                ip = request.UserHostAddress;
            }
            return ip;
        }
    }
}