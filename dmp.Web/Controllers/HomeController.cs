using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dmp.Common;
using dmp.IBLL;
using dmp.Web.Filter;
using dmp.Web.Models.SystemManage;
using Microsoft.CSharp;

namespace dmp.Web.Controllers
{
    [Authentication]
    public class HomeController : Controller
    {
        public IUserBLL UserBLL { get; set; }

        // GET: Home
        public ActionResult Index()
        {
            var list = UserBLL.GetMenuList();
            var menus = list.Where(a => a.ParentId == 0).Select(a => new Menu { MenuName = a.MenuName,IocnFont = a.IocnFont, ActionId  = a.ActionId}).ToList();
            foreach (var item in menus)
            {
                var models = list.Where(a => a.ParentId == item.ActionId).Select(a => new MenuChildren { MenuName =a.MenuName,MenuUrl = a.MenuUrl }).ToList();
                item.MenuChildrens = models;
            }
            return View(menus);
        }

        public ActionResult Panel()
        {
            ViewBag.Count = Request.QueryString["V"];
            return View();
        } 

    }
}