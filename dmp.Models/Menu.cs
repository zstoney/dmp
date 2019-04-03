using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.Model
{
    public class Menu : ModelBase
    {
        [SugarColumn(ColumnDescription = "菜单排序")]
        public int ActionId { get; set; }

        [SugarColumn(Length = 50,ColumnDescription = "URL名称")]
        public string MenuName { get; set; }

        [SugarColumn(Length = 100,ColumnDescription = "URL地址")]
        public string MenuUrl { get; set; }


        [SugarColumn(ColumnDescription = "有效姿态：0=有效，1=失效")]
        public int Status { get; set; }

        public int ParentId { get; set; }

        [SugarColumn(ColumnDescription = "图标",IsNullable = true,Length = 20)]
        public string IocnFont { get; set; }

    }
}
