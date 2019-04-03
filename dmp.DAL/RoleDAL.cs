using dmp.Common;
using dmp.IDAL;
using dmp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.DAL
{
    public class RoleDAL : DBContext<Role>,IRoleDAL
    {

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Role model)
        {
            return Db.Insertable(model).ExecuteReturnIdentity();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Role model)
        {
            return Db.Updateable(model).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 主键查询
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Role GetUserByID(int id)
        {
            return Db.Queryable<Role>().InSingle(id);
        }

        public List<Role> GetRoleList()
        {
            return Db.Queryable<Role>().Where(a => a.Status == 0).OrderBy(a=>a.CreateTime,SqlSugar.OrderByType.Desc).ToList();
        }


    }
}
