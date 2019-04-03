using SqlSugar;
using System;

namespace dmp.Model
{
    public class DBBase : ModelContext
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "自增主键")]
        public int ID { get; set; }

        [SugarColumn(ColumnDescription ="创建时间", IsNullable = true)]
        public DateTime? CreateTime { get; set; }

        [SugarColumn(ColumnDescription ="最后一次修改时间", IsNullable = true)]
        public DateTime? LastTime { get; set; }



    }
}
