using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.Common
{
    public class DBContext<T> where T : class, new()
    {

        public static SqlSugarClient Db
        { 
            get => new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigurationManager.AppSettings["SqlServerHosts"],

                DbType = DbType.SqlServer,//数据库类型

                IsAutoCloseConnection = true,//默认false,自动释放链接，设置为true无需要使用using或者colse操作

                InitKeyType = InitKeyType.Attribute, //从特性读取主键和自增列信息

                IsShardSameThread = true, //设为true时，相同线程是同一个sqlConnection(用于跨方法事务)。

                //ConfigureExternalServices = new ConfigureExternalServices() //二级缓存（单位秒）
                //{
                //    DataInfoCacheService = new RedisCache(ConfigurationManager.AppSettings["RedisHosts"]) //redis地址
                //}

                //从连接，HitRate值越大，执行次数越高
                //SlaveConnectionConfigs = new List<SlaveConnectionConfig>()
                //{
                //    new SlaveConnectionConfig (){ HitRate = 10 , ConnectionString = ""},
                //    new SlaveConnectionConfig (){ HitRate = 20 , ConnectionString = ""}
                //} 

            });
        }

        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }

        #region 跨方法事务（Sqlsugar提供了同一个线程共享一个SqlsugarClient）

        public void BeginTran()
        {
            Db.Ado.BeginTran();
        }

        public void CommitTran()
        {
            Db.Ado.CommitTran();
        }

        public void RollbackTran()
        {
            Db.Ado.RollbackTran();
        }

        #endregion

    }
}
