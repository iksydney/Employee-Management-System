using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager()
        {

        }
        public void LogDebug(string Message) => logger.Debug(Message);

        public void LogError(string Message) => logger.Error(Message);

        public void LogInfo(string Message) => logger.Info(Message);

        public void LogWarning(string Message) => logger.Warn(Message);
    }
}
