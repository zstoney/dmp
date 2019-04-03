using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace dmp.Common
{
    public class AppSettingUtils
    {
        public static readonly string AuthUrl = WebConfigurationManager.AppSettings["AuthUrl"];//认证地址

        public static readonly string Domain = WebConfigurationManager.AppSettings["Domain"] ?? "";//cookie domain
        public static readonly string Path = WebConfigurationManager.AppSettings["Path"] ?? "/";//cookie path
    }
}
