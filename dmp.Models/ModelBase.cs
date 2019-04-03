using SqlSugar;
using System;

namespace dmp.Model
{
    public class ModelBase //: ModelContext
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "自增主键")]
        public int Id { get; set; }
   
        [SugarColumn(ColumnDescription ="创建时间", IsNullable = false)]
        public DateTime? CreateTime { get; set; }
    }
}
