using dateRange.Logging.Interfaces;
using dateRange.Utils.Interfaces;
using dateRange.Validation.Interfaces;
using dateRange.Validation.Validations;
using System;

namespace dateRange.Utils
{
    public class DateParserUtil : IDateParserUtil
    {
        public DateParserUtil()
        {            
        }

        /// <summary>
        /// Method which parse string to DateTime with validation
        /// </summary>
        /// <param name="dateString">
        /// String with date for parsing
        /// </param>
        /// <returns>
        /// If input can be parsed method returns DateTime, otherwise returns null
        /// </returns>
        public DateTime? ParseDate(string dateString)
        {
            throw new NotImplementedException();
        }
    }
}
