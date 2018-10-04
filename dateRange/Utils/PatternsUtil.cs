using System;
using dateRange.DTOs;
using dateRange.Utils.Interfaces;

namespace dateRange.Utils
{
    public class PatternsUtil : IPatternsUtil
    {
        private string StartPattern { get; set; }
        private string EndPattern { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private string ShortDatePattern { get; set; }
        private string DateSeparator { get; set; }

        private ICultureUtil _cultureUtil;

        public PatternsUtil(ICultureUtil cultureUtil)
        {
            _cultureUtil = cultureUtil;
        }

        /// <summary>
        /// Set StartPattern and EndPattern for input dates
        /// </summary>
        /// <param name="startDate">
        /// Range's start date
        /// </param>
        /// <param name="endDate">
        /// Range's end date
        /// </param>
        /// <returns>
        /// PatternsDTO which contains patterns for start and end dates in range
        /// </returns>
        public PatternsDTO GetPatterns(DateTime startDate, DateTime endDate)
        {
            StartPattern = _cultureUtil.ShortDatePattern;
            EndPattern = _cultureUtil.ShortDatePattern;

            if (startDate.Equals(endDate))
            {
                return new PatternsDTO(StartPattern, EndPattern);
            }

            ShortDatePattern = _cultureUtil.ShortDatePattern;
            DateSeparator = _cultureUtil.DateSeparator;
            StartDate = startDate;
            EndDate = endDate;

            if (StartDate.Year < EndDate.Year)
            {
                return new PatternsDTO(StartPattern, EndPattern);
            }

            if (StartDate.Month < EndDate.Month)
            {
                return GetPatternsForDifferentMonths();                
            }

            return GetPatternsForDifferentDays();
        }

        /// <summary>
        /// Set patterns when months are different
        /// </summary>
        private PatternsDTO GetPatternsForDifferentMonths()
        {
            string newPattern = RemovePartFromDatePattern(ShortDatePattern, "y");

            if (ShortDatePattern[0].Equals('y'))
            {
                EndPattern = newPattern;
            }

            if (ShortDatePattern[ShortDatePattern.Length - 1].Equals('y'))
            {
                StartPattern = newPattern;
            }

            return new PatternsDTO(StartPattern, EndPattern);
        }

        /// <summary>
        /// Set patterns when days are different
        /// </summary>
        private PatternsDTO GetPatternsForDifferentDays()
        {
            string newPattern = RemovePartFromDatePattern(ShortDatePattern, "y");

            if (ShortDatePattern[0].Equals('y'))
            {
                EndPattern = newPattern;
            }

            if (ShortDatePattern[ShortDatePattern.Length - 1].Equals('y'))
            {
                StartPattern = newPattern;
            }

            newPattern = RemovePartFromDatePattern(newPattern, "M");

            if (ShortDatePattern[0].Equals('d'))
            {
                StartPattern = newPattern;
            }

            if (ShortDatePattern[ShortDatePattern.Length - 1].Equals('d'))
            {
                EndPattern = newPattern;
            }

            return new PatternsDTO(StartPattern, EndPattern);
        }

        /// <summary>
        /// Remove specified part from date pattern provided as input
        /// </summary>
        /// <param name="datePattern">
        /// Initial date pattern
        /// </param>
        /// <param name="part">
        /// Part to delete. 'd' - day, 'M' - month, 'y' - year
        /// </param>
        /// <returns>
        /// Pattern without deleted part
        /// </returns>
        private string RemovePartFromDatePattern(string datePattern, string part)
        {
            string result = datePattern.Replace(part, "");
            result = result.Replace(string.Concat(DateSeparator, DateSeparator), DateSeparator);

            if (result.Substring(0, DateSeparator.Length).Equals(DateSeparator))
            {
                result = result.Remove(0, DateSeparator.Length);
            }

            if (result.Substring(result.Length - DateSeparator.Length, DateSeparator.Length).ToString().Equals(DateSeparator))
            {
                int index = result.Length - DateSeparator.Length;
                result = result.Remove(index, DateSeparator.Length);
            }

            return result;
        }
    }
}
