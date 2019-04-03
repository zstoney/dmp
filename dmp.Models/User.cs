using SqlSugar;
using System;

namespace dmp.Model
{
    public class User
    {
        //IsPrimaryKey:设置主键,IsIdentity:自增列
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "")]
        public int UserId { get; set; }

        [SugarColumn(Length = 50)]
        public string UserName { get; set; }

        [SugarColumn(Length = 50)]
        public string PassWord { get; set; }

        [SugarColumn(Length = 10, IsNullable = true)]
        public string RealName { get; set; }

        [SugarColumn(Length = 11, IsNullable = true)]
        public string Mobile { get; set; }

        [SugarColumn(ColumnDescription = "用户状态：0-正常;1-注销", IsNullable = true)]
        public int? Status { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? Role { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? LoginTime { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime CreateTime { get; set; }
    }
}
