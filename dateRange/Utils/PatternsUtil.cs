using System;
using dateRange.Utils.Interfaces;

namespace dateRange.Utils
{
    public class PatternsUtil : IPatternsUtil
    {
        /// <summary>
        /// Pattern for start date in date range
        /// </summary>
        public string StartPattern { get; private set; }

        /// <summary>
        /// Pattern for end date in date range
        /// </summary>
        public string EndPattern { get; private set; }

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
        public void SetPatterns(DateTime startDate, DateTime endDate)
        {
            StartPattern = _cultureUtil.ShortDatePattern;
            EndPattern = _cultureUtil.ShortDatePattern;

            if (startDate.Equals(endDate))
            {
                return;
            }

            ShortDatePattern = _cultureUtil.ShortDatePattern;
            DateSeparator = _cultureUtil.DateSeparator;
            StartDate = startDate;
            EndDate = endDate;

            if (StartDate.Year < EndDate.Year)
            {
                return;
            }

            if (StartDate.Month < EndDate.Month)
            {
                SetPatternsForDifferentMonths();
                return;
            }

            SetPatternsForDifferentDays();
            return;
        }

        /// <summary>
        /// Set patterns when months are different
        /// </summary>
        private void SetPatternsForDifferentMonths()
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
        }

        /// <summary>
        /// Set patterns when days are different
        /// </summary>
        private void SetPatternsForDifferentDays()
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
