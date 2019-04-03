using dmp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.Common
{
    public class DBTable:DBContext<User>
    { 
        /// <summary>
        /// code first 创建表
        /// </summary>
        public static void AddTable()
        {
            Db.CodeFirst.InitTables(typeof(User));
            Db.CodeFirst.InitTables(typeof(Menu));
            Db.CodeFirst.InitTables(typeof(Role));
            Db.CodeFirst.InitTables(typeof(RoleUser));
            Db.CodeFirst.InitTables(typeof(RoleMenu));
        }
    }
}
