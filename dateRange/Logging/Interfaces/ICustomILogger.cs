namespace dateRange.Logging.Interfaces
{
    public interface ICustomILogger
    {
        void Info(string message);
        void Debug(string message);
        void Error(string message);
        void Fatal(string message);
    }
}
