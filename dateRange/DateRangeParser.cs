using System;
using dateRange.Interfaces;

namespace dateRange
{
    public class DateRangeParser : IDateRangeParser
    {
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
            throw new NotImplementedException();
        }
    }
}
