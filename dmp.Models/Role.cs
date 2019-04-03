using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.Model
{
    public class Role : ModelBase
    {
        [SugarColumn(ColumnDescription = "角色名称", Length = 20)]
        public string RoleName { get; set; }

        [SugarColumn(ColumnDescription = "状态：0=正常，1=失效")]
        public int Status { get; set; }

        [SugarColumn(ColumnDescription = "权限字符",Length = 50)]
        public string RoleString { get; set; }

    }
}
