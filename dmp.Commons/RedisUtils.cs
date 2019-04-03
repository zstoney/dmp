using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace dmp.Common
{
    public class RedisUtils : IDisposable
    {
        private bool _disposed = false;

        private static string _redisPath = ConfigurationManager.AppSettings["RedisHosts"];
        public static PooledRedisClientManager prc_Manager;
        private static RedisClient redis_client;
        //private static IRedisClient _redis;

        private static object _locker = new object();
        static RedisUtils()
        {
            InitClient();
        }

        static void InitClient()
        {
            CreateManager();
            //通过单例模式创建redis客户端对象
            if (redis_client == null)
            {
                lock (_locker)
                {
                    if (redis_client == null)
                    {
                        redis_client = prc_Manager.GetClient() as RedisClient;

                    }
                }
            }
        }

        public static IRedisClient GetClient()
        {

            //获取客户端缓存操作对象
            lock (_locker)
            {
                return redis_client;
            }
            //return prc_Manager.GetClient();
        }

        /// <summary>
        /// 创建Redis连接池管理对象
        /// </summary>
        /// <param name="readWriteUrl"></param>
        /// <param name="readOnlyUrl"></param>
        /// <returns></returns>
        public static void CreateManager()
        {
            prc_Manager = new PooledRedisClientManager(
                // 支持读写分离，均衡负载
                new string[] { _redisPath },
                new string[] { _redisPath },
                new RedisClientManagerConfig()
                {
                    MaxWritePoolSize = 100,
                    MaxReadPoolSize = 100,
                    AutoStart = true,
                })
            {
                PoolTimeout = 10,
                ConnectTimeout = 500,
                IdleTimeOutSecs = 30
            };
            //return manager;
        }

        /// <summary>
        /// 这里只实现存储String，Get时进行类型转换即可，可满足使用
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirseIn"></param>
        public static void Set(string key, object value, TimeSpan expirseIn)
        {
            if (value != null)
            {
                redis_client.Set(key, value, expirseIn);
            }
            //Redis.AddItemToList(); //可以存储List
            //Redis.AddItemToSet();//set
            //Redis.AddItemToSortedSet();//sortSet
            //Redis.SetEntryInHash();//hash
        }

        /// <summary>
        /// 指定类型Set<T>，Get时也需指定类型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirseIn"></param>
        public static bool Set<T>(string key, T value, TimeSpan expirseIn)
        {
            return redis_client.Set<T>(key, value, expirseIn);
        }

        public static void Set(string key, object value, DateTime expirseIn)
        {
            if (value != null)
            {
                redis_client.Set(key, value, expirseIn);
            }
        }

        public static T Get<T>(string key)
        {
            return redis_client.Get<T>(key);
        }

        public static bool Remove(string key)
        {
            return redis_client.Remove(key);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    redis_client.Dispose();
                    redis_client = null;
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            if (redis_client != null)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

        }

        ~RedisUtils()
        {
            Dispose(false);
        }
        /// <summary>
        /// 保存数据DB文件到硬盘
        /// </summary>
        public void Save()
        {
            redis_client.Save();
        }
        /// <summary>
        /// 异步保存数据DB文件到硬盘
        /// </summary>
        public void SaveAsync()
        {
            redis_client.SaveAsync();
        }
    }
}
