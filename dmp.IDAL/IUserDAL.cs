using dmp.Common;
using dmp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.IDAL
{
    public interface IUserDAL
    {
        int Add(User user);

        User GetUser(string userName, string passWord);

        PagesModel GetUserList(InputUser input);

        object GetRoleUser();

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Update(User user);

        /// <summary>
        /// 主键查询
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUserByID(int userId);

        /// <summary>
        /// 获取有效菜单
        /// </summary>
        /// <returns></returns>
        List<Menu> GetMenuList();

    }
}
