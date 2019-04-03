using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dmp.Web.Models.SystemManage
{
    public class Menu
    {
        public int ActionId { get; set; }
        public string MenuName { get; set; }
        public string IocnFont { get; set; } 
        public List<MenuChildren> MenuChildrens { get; set; }
    }

    public class MenuChildren
    {
        public string MenuUrl { get; set; }
        public string MenuName { get; set; }

    }
}