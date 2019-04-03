using dmp.IDAL;
using dmp.Model;
using dmp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace dmp.DAL
{
    public class UserDAL : DBContext<User>,IUserDAL
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(User user)
        {
            return Db.Insertable(user).ExecuteReturnIdentity();
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(User user)
        {
            return Db.Updateable(user).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 主键查询
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserByID(int userId)
        {
            return Db.Queryable<User>().InSingle(userId);
        }

        /// <summary>
        /// 根据用户名、密码获取用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public User GetUser(string userName, string passWord)
        { 
            return Db.Queryable<User>().Where(it => it.UserName == userName && it.PassWord == passWord && it.Status == 0).First();
        }
          
        public PagesModel GetUserList(InputUser input)
        {
            int totalCounts = 0;
            var query = Db.Queryable<User>();
            if (!string.IsNullOrEmpty(input.UserName))
            {
                query = query.Where(a => a.UserName.Contains(input.UserName));
            }
            if (input.Status > 0)
            {
                query = query.Where(a => a.Status == input.Status);
            }
            var list = query.OrderBy(it => it.CreateTime,OrderByType.Desc).ToPageList(input.PageIndex, input.PageSize, ref totalCounts);
            var page = new Common.PagesModel {
                total = totalCounts,
                rows = list,
            }; 
            return page;
        }

        public object GetRoleUser()
        {
            var list = Db.Queryable<User,RoleUser>((u,ru) => 
                new object[] {
                    JoinType.Left,u.UserId == ru.UserId
                })
                .Where((u) => u.Status == 0)
                .OrderBy((u) => u.CreateTime, OrderByType.Desc)
                .Select((u,ru) => new { UserName = u.UserName, Mobile = u.Mobile, UserId = u.UserId,Id = ru.UserId })
                .ToList();
            return list;
        }

        /// <summary>
        /// 获取有效菜单
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetMenuList()
        {
            return Db.Queryable<Menu>().Where(a => a.Status == 0).ToList();
        }

        public List<Role> GetRoleList()
        {
            return Db.Queryable<Role>().Where(a => a.Status == 0).ToList();
        }
        
        


    }
}
