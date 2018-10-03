using System;
using dateRange.Interfaces;
using dateRange.Logging.Interfaces;
using dateRange.Utils.Interfaces;
using dateRange.Validation.Interfaces;
using dateRange.Validation.Validations;

namespace dateRange
{
    public class DateRangeParser : IDateRangeParser
    {

        private IValidationBase Validator { get; set; }

        private const string _rangeSeparator = " - ";

        private ICustomILogger _customILogger;
        private IPatternsUtil _patternsUtil;

        public DateRangeParser(ICustomILogger customILogger, IPatternsUtil patternsUtil)
        {
            _customILogger = customILogger;
            _patternsUtil = patternsUtil;
        }

        /// <summary>
        /// Calculate range for input dates
        /// </summary>
        /// <param name="startDate">
        /// Start range date
        /// </param>
        /// <param name="endDate">
        /// End range date
        /// </param>
        /// <returns>
        /// Calculated range
        /// </returns>
        public string CalculateRange(DateTime startDate, DateTime endDate)
        {
            Validator = new DatesOrderValidation(new DateTime[] { startDate, endDate });

            if (!Validator.IsValid)
            {
                _customILogger.Error(Validator.Message);
                return null;
            }

            if (startDate.Equals(endDate))
            {
                return GetRangeForSameDates(startDate);
            }

            _patternsUtil.SetPatterns(startDate, endDate);

            return GetRangeWithSeparator(startDate, endDate, _patternsUtil.StartPattern, _patternsUtil.EndPattern);
        }

        /// <summary>
        /// Returns range when dates are the same
        /// </summary>
        /// <param name="dateTime">
        /// Start/end date
        /// </param>
        /// <returns>
        /// Range for the same dates
        /// </returns>
        private string GetRangeForSameDates(DateTime dateTime)
        {
            return dateTime.ToShortDateString();
        }

        /// <summary>
        /// Returns calculated range
        /// </summary>
        /// <param name="startDate">
        /// Range's start date
        /// </param>
        /// <param name="endDate">
        /// Range's end date
        /// </param>
        /// <param name="startPattern">
        /// Pattern for start date
        /// </param>
        /// <param name="endPattern">
        /// Pattern for end date
        /// </param>
        /// <returns>
        /// Calculated range
        /// </returns>
        private string GetRangeWithSeparator(DateTime startDate, DateTime endDate, string startPattern, string endPattern)
        {
            return string.Concat(startDate.ToString(startPattern), _rangeSeparator, endDate.ToString(endPattern));
        }
    }
}
