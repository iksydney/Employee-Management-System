using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public interface ILoggerManager
    {
        void LogInfo(string Message);
        void LogWarning(string Message);
        void LogError(string Message);
        void LogDebug(string Message);
    }
}
