
using dmp.Common;
using dmp.IBLL;
using dmp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace dmp.Auth.Controllers
{
    public class AuthController : Controller
    {
        public IUserBLL UserBll { get; set; }
        public ActionResult Index()
        {
            ViewBag.Referrer = Request.QueryString["referrerurl"];
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userName, string password, string referrerurl)
        {
            ViewBag.Referrer = referrerurl;

            var result = UserBll.UserLoginAuth(userName, password);
            if (result.type == 1)
            {
                //跳转referrerurl
                Response.Redirect(!string.IsNullOrEmpty(referrerurl) ? referrerurl.Decrypt() : "/",true);//todo 默认跳转页面
            }
            return View(result);
        }
    }
}