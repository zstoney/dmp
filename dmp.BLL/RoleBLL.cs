using dmp.IBLL;
using dmp.IDAL;
using dmp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.BLL
{
    public class RoleBLL: IRoleBLL
    {

        public IRoleDAL RoleDAL { get; set; }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Role model)
        {
            return RoleDAL.Add(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Role model)
        {
            return RoleDAL.Update(model);
        }

        /// <summary>
        /// 主键查询
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Role GetUserByID(int id)
        {
            return RoleDAL.GetUserByID(id);
        }

        public List<Role> GetRoleList()
        {
            return RoleDAL.GetRoleList();
        }

    }
}
