using dateRange.Utils.Interfaces;

namespace dateRange.Utils
{
    public class CultureUtil : ICultureUtil
    {
        /// <summary>
        /// Date separtor specific for user's culture
        /// </summary>
        public string DateSeparator { get; }

        /// <summary>
        /// Short date pattern specific for user's culture
        /// </summary>
        public string ShortDatePattern { get; }

    }
}
