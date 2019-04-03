using dmp.Common;
using dmp.IBLL;
using dmp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dmp.Web.Controllers
{
    /// <summary>
    /// 命名规范
    /// 类名：首字母大写
    /// 类的属性和方法：首字母大写
    /// 方法变量：首字母小写
    /// </summary>
    public class SystemManageController : Controller
    {
        public IUserBLL UserBll { get; set; }
        public IRoleBLL RoleBLL { get; set; }


        #region 用户管理

        public ActionResult UserList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUserList(InputUser input)
        {
            var page = UserBll.GetUserList(input);
            return Json(page, JsonRequestBehavior.AllowGet);
        }

      

        [HttpPost]
        public JsonResult AddOrUpdateUser(User user)
        {
            var bl = false;
            if (user.UserId > 0)
            {
                var model = UserBll.GetUserByID(user.UserId);
                model.UserName = user.UserName;
                model.RealName = user.RealName;
                model.Mobile = user.Mobile;
                if (!string.IsNullOrEmpty(user.PassWord))
                {
                    model.RealName = DESEncrypt.GetMD5String(user.PassWord);
                }
                bl = UserBll.Update(model);
            }
            else
            {
                //新建
                user.PassWord = DESEncrypt.GetMD5String(user.PassWord);
                user.CreateTime = DateTime.Now;
                user.Status = 0;
                bl = UserBll.Add(user) > 0;
            }

            if (bl)
            {
                return Json(JsonHandler.CreateMessage(1, "操作成功"));
            }
            else
            {
                return Json(JsonHandler.CreateMessage(-1, "操作失败"));
            }
        }

        [HttpPost]
        public JsonResult GetUserByID(int userId)
        {
            var model = UserBll.GetUserByID(userId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 权限管理

        public ActionResult RoleList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetRoleList()
        {
            var list = RoleBLL.GetRoleList();
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddOrUpdateRole(Role role)
        {
            var bl = false;
            if (role.Id > 0)
            {
                var model = RoleBLL.GetUserByID(role.Id);
                model.RoleName = role.RoleName;
                model.RoleString = role.RoleString;
                bl = RoleBLL.Update(model);
            }
            else
            {
                role.Status = 0;
                role.CreateTime = DateTime.Now; 
                bl = RoleBLL.Add(role) > 0;
            }

            if (bl)
            {
                return Json(JsonHandler.CreateMessage(1, "操作成功"));
            }
            else
            {
                return Json(JsonHandler.CreateMessage(-1, "操作失败"));
            }
        }

        [HttpPost]
        public JsonResult GetRoleByID(int Id)
        {
            var date = RoleBLL.GetUserByID(Id);
            return Json(date,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetUserAll()
        {
            var list = UserBll.GetRoleUser();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}