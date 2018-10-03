using dateRange.Logging.Interfaces;
using dateRange.Utils.Interfaces;
using System.Globalization;
using System.Threading;

namespace dateRange.Utils
{
    public class CultureUtil : ICultureUtil
    {
        /// <summary>
        /// Date separtor specific for user's culture
        /// </summary>
        public string DateSeparator { get; private set; }

        /// <summary>
        /// Short date pattern specific for user's culture
        /// </summary>
        public string ShortDatePattern { get; private set; }

        private ICustomILogger _customILogger;

        public CultureUtil(ICustomILogger customILogger)
        {
            _customILogger = customILogger;

            DateTimeFormatInfo currentDateTimeFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            DateSeparator = currentDateTimeFormat.DateSeparator;
            ShortDatePattern = currentDateTimeFormat.ShortDatePattern;

            _customILogger.Debug(string.Format("ShortDatePattern: {0}, DateSeparator: {1}", ShortDatePattern, DateSeparator));
        }
    }
}
