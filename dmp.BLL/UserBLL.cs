using dmp.IBLL;
using dmp.IDAL;
using dmp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dmp.Common;

namespace dmp.BLL
{
    public class UserBLL : IUserBLL
    {
        public IUserDAL UserDal { get; set; }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(User user)
        {
            return UserDal.Add(user);
        }

        /// <summary>
        /// 根据用户名、密码获取用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string userName, string password)
        {
            return UserDal.GetUser(userName, DESEncrypt.GetMD5String(password));
        }

        /// <summary>
        /// 主键查询
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserByID(int userId)
        {
            return UserDal.GetUserByID(userId);
        }

        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JsonMessage UserLoginAuth(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return JsonHandler.CreateMessage(-1, "请输入用户名");
            }
            if (string.IsNullOrEmpty(password))
            {
                return JsonHandler.CreateMessage(-1, "请输入密码");
            }

            User user = GetUser(userName, password);
            if (user == null || user.UserId <= 0) return JsonHandler.CreateMessage(0, "用户名或密码错误");

            var userInfo = new
            {
                UserId = user.UserId,
                UserName = user.UserName,
                PassWord = user.PassWord,
                Mobile = user.Mobile,
                Role = user.Role
            };

            //生成token
            var token = Guid.NewGuid().ToString();
            //写入token
            CookieUtils.AddCookie("token", token, 30);
            //写入凭证
            RedisUtils.Set(token, userInfo, new TimeSpan(0, 30, 0));

            return JsonHandler.CreateMessage(1, "登录成功");
        }

        /// <summary>
        /// 用户集合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagesModel GetUserList(InputUser input)
        {
            return UserDal.GetUserList(input);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(User user)
        {
            return UserDal.Update(user);
        }

        /// <summary>
        /// 获取有效菜单
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetMenuList()
        {
            return UserDal.GetMenuList();
        }

        public object GetRoleUser()
        {
            return UserDal.GetRoleUser();
        }
    }
}
