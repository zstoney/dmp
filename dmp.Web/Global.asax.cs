using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using dmp.Common;

namespace dmp.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Autofac注册组件
            AutofacConfig.Register();

            //注册日志
            Log.Init();
        }

        protected virtual void Application_Error(object sender, EventArgs e)
        {
            ExceptionUtils.LogHttpApplicationError(Context.Request, Server.GetLastError());
        }
    }
}