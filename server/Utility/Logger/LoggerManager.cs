using NLog;
using ILogger = NLog.ILogger;

namespace server.Utility.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger;

        public LoggerManager()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        public void LogDebug(string message) => logger.Debug(message);

        public void LogError(string message) => logger.Error(message);

        public void LogInformation(string message) => logger.Info(message);

        public void LogWarning(string message) => logger.Warn(message);
    }
}
