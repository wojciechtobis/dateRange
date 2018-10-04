using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using dateRangeTests;
using Moq;
using dateRange.Utils.Interfaces;
using Autofac;
using dateRange.DTOs;

namespace dateRange.Utils.Tests
{
    [TestClass()]
    public class PatternsUtilTests : BaseTests
    {
        private ShortDateTimeInfo[] patternsAndSeparators = new ShortDateTimeInfo[]
        {
            new ShortDateTimeInfo("dd.MM.yyyy", ".", "dd", "dd.MM.yyyy", "dd.MM", "dd.MM.yyyy", "dd.MM.yyyy", "dd.MM.yyyy"),
            new ShortDateTimeInfo("dd.yyyy.MM", ".", "dd", "dd.yyyy.MM", "dd.yyyy.MM", "dd.yyyy.MM", "dd.yyyy.MM", "dd.yyyy.MM"),
            new ShortDateTimeInfo("MM.dd.yyyy", ".", "MM.dd", "MM.dd.yyyy", "MM.dd", "MM.dd.yyyy", "MM.dd.yyyy", "MM.dd.yyyy"),
            new ShortDateTimeInfo("MM.yyyy.dd", ".", "MM.yyyy.dd", "dd", "MM.yyyy.dd", "MM.yyyy.dd", "MM.yyyy.dd", "MM.yyyy.dd"),
            new ShortDateTimeInfo("yyyy.dd.MM", ".", "yyyy.dd.MM", "dd.MM", "yyyy.dd.MM", "dd.MM", "yyyy.dd.MM", "yyyy.dd.MM"),
            new ShortDateTimeInfo("yyyy.MM.dd", ".", "yyyy.MM.dd", "dd", "yyyy.MM.dd", "MM.dd", "yyyy.MM.dd", "yyyy.MM.dd"),
        };

        [TestMethod()]
        public void CheckStartPatternForDifferentDays()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern);
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator);

                DateTime today = DateTime.Now.Date;
                DateTime tomorrow = DateTime.Now.Date.AddDays(1).Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, tomorrow);

                string expected = pas.DayDiff.StartPattern;
                string result = resultPatterns.StartPattern;

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void CheckEndPatternForDifferentDays()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern);
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator);

                DateTime today = DateTime.Now.Date;
                DateTime tomorrow = DateTime.Now.Date.AddDays(1).Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, tomorrow);

                string expected = pas.DayDiff.EndPattern;
                string result = resultPatterns.EndPattern;

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void CheckStartPatternForDifferentMonths()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern);
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator);

                DateTime today = DateTime.Now.Date;
                DateTime tomorrow = DateTime.Now.Date.AddMonths(1).Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, tomorrow);

                string expected = pas.MonthDiff.StartPattern;
                string result = resultPatterns.StartPattern;

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void CheckEndPatternForDifferentMonths()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern);
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator);

                DateTime today = DateTime.Now.Date;
                DateTime tomorrow = DateTime.Now.Date.AddMonths(1).Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, tomorrow);

                string expected = pas.MonthDiff.EndPattern;
                string result = resultPatterns.EndPattern;

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void CheckStartPatternForDifferentYears()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern);
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator);

                DateTime today = DateTime.Now.Date;
                DateTime tomorrow = DateTime.Now.Date.AddYears(1).Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, tomorrow);

                string expected = pas.YearDiff.StartPattern;
                string result = resultPatterns.StartPattern;

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void CheckEndPatternForDifferentYears()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern);
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator);

                DateTime today = DateTime.Now.Date;
                DateTime tomorrow = DateTime.Now.Date.AddYears(1).Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, tomorrow);

                string expected = pas.YearDiff.EndPattern;
                string result = resultPatterns.EndPattern;

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void CheckStartPatternForSameDates()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern);
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator);

                DateTime today = DateTime.Now.Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, today);

                string expected = pas.ShortDatePattern;
                string result = resultPatterns.StartPattern;

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void CheckEndPatternForSameDates()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern);
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator);

                DateTime today = DateTime.Now.Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, today);

                string expected = pas.ShortDatePattern;
                string result = resultPatterns.EndPattern;

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void CheckPatternsForDifferentSeparatorAndDays()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();
            char newSeparator = '/';

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern.Replace('.', newSeparator));
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator.Replace('.', newSeparator));

                DateTime today = DateTime.Now.Date;
                DateTime tomorrow = DateTime.Now.Date.AddDays(1).Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, tomorrow);

                string expectedStart = pas.DayDiff.StartPattern.Replace('.', newSeparator);
                string resultStart = resultPatterns.StartPattern;
                string expectedEnd = pas.DayDiff.EndPattern.Replace('.', newSeparator);
                string resultEnd = resultPatterns.EndPattern;

                Assert.AreEqual(expectedStart, resultStart);
                Assert.AreEqual(expectedEnd, resultEnd);
            }
        }

        [TestMethod()]
        public void CheckPatternsForDifferentSeparatorAndMonths()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();
            char newSeparator = '/';

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern.Replace('.', newSeparator));
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator.Replace('.', newSeparator));

                DateTime today = DateTime.Now.Date;
                DateTime tomorrow = DateTime.Now.Date.AddMonths(1).Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, tomorrow);

                string expectedStart = pas.MonthDiff.StartPattern.Replace('.', newSeparator);
                string resultStart = resultPatterns.StartPattern;
                string expectedEnd = pas.MonthDiff.EndPattern.Replace('.', newSeparator);
                string resultEnd = resultPatterns.EndPattern;

                Assert.AreEqual(expectedStart, resultStart);
                Assert.AreEqual(expectedEnd, resultEnd);
            }
        }

        [TestMethod()]
        public void CheckPatternsForDifferentSeparatorAndYears()
        {
            Mock<ICultureUtil> cultureUtilMock = new Mock<ICultureUtil>();
            char newSeparator = '/';

            foreach (ShortDateTimeInfo pas in patternsAndSeparators)
            {
                cultureUtilMock.Setup(m => m.ShortDatePattern).Returns(pas.ShortDatePattern.Replace('.', newSeparator));
                cultureUtilMock.Setup(m => m.DateSeparator).Returns(pas.DateSeparator.Replace('.', newSeparator));

                DateTime today = DateTime.Now.Date;
                DateTime tomorrow = DateTime.Now.Date.AddYears(1).Date;

                IPatternsUtil patternsUtil = container.Resolve<IPatternsUtil>(new TypedParameter(typeof(ICultureUtil), cultureUtilMock.Object));
                PatternsDTO resultPatterns = patternsUtil.GetPatterns(today, tomorrow);

                string expectedStart = pas.YearDiff.StartPattern.Replace('.', newSeparator);
                string resultStart = resultPatterns.StartPattern;
                string expectedEnd = pas.YearDiff.EndPattern.Replace('.', newSeparator);
                string resultEnd = resultPatterns.EndPattern;

                Assert.AreEqual(expectedStart, resultStart);
                Assert.AreEqual(expectedEnd, resultEnd);
            }
        }
    }

    class ShortDateTimeInfo
    {
        public string ShortDatePattern { get; set; }
        public string DateSeparator { get; set; }
        public StartEndPatterns DayDiff { get; set; }
        public StartEndPatterns MonthDiff { get; set; }
        public StartEndPatterns YearDiff { get; set; }

        public ShortDateTimeInfo(
            string shortDatePattern,
            string dateSeparator,
            string dayStartPattern,
            string dayEndPattern,
            string monthStartPattern,
            string monthEndPattern,
            string yearStartPattern,
            string yearEndPattern)
        {
            ShortDatePattern = shortDatePattern;
            DateSeparator = dateSeparator;
            DayDiff = new StartEndPatterns(dayStartPattern, dayEndPattern);
            MonthDiff = new StartEndPatterns(monthStartPattern, monthEndPattern);
            YearDiff = new StartEndPatterns(yearStartPattern, yearEndPattern);
        }
    }

    class StartEndPatterns
    {
        public string StartPattern { get; set; }
        public string EndPattern { get; set; }

        public StartEndPatterns(string startPattern, string endPattern)
        {
            StartPattern = startPattern;
            EndPattern = endPattern;
        }
    }
}