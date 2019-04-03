using dmp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dmp.Common;

namespace dmp.IBLL
{
    public interface IUserBLL
    {
        int Add(User user);

        bool Update(User user);

        User GetUser(string userName, string passWord);
        JsonMessage UserLoginAuth(string userName, string password);
        PagesModel GetUserList(InputUser input);

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

        object GetRoleUser();
    }
}
