using dateRange.Logging.Interfaces;
using NLog;

namespace dateRange.Logging
{
    public class CustomLogger : ICustomILogger
    {
        private Logger Logger { get; set; }

        public CustomLogger()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }

        public void Debug(string message)
        {
            Logger.Debug(message);
        }

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void Fatal(string message)
        {
            Logger.Fatal(message);
        }
    }
}
