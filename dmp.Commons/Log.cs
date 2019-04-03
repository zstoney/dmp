using System;
using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;

namespace dmp.Common
{
    /// <summary>
    /// 全局日志类
    /// 1、使用NLog记录日志
    /// 2、简化日志记录层级，只包括DEBUG，INFO，ERROR三个层级
    /// 3、简化日志操作
    /// </summary>
    public static class Log
    {
        private static ILog _log;

        public static void Init()
        {
            LogManager.LogFactory = new NLogFactory();
            _log = LogManager.GetLogger("globallog");
        }

        public static ILog GetLogger(string typeName)
        {
            return LogManager.GetLogger(typeName);
        }

        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }

        public static bool IsDebugEnabled
        {
            get { return _log.IsDebugEnabled; }
        }

        public static void Debug(object message)
        {
            _log.Debug(message);
        }

        public static void DebugFormat(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }

        public static void Error(object message)
        {
            _log.Error(message);
        }

        public static void Error(object message, Exception exception)
        {
            _log.Error(message, exception);
        }

        public static void ErrorFormat(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }

        public static void Info(object message)
        {
            _log.Info(message);
        }

        public static void InfoFormat(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }
    }
}