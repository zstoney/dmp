using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dmp.Web.Filter
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var pass = new PassportService();
            pass.Run();
        }
    }
}