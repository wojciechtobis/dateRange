using Autofac;
using dateRange.DTOs;
using dateRange.Interfaces;
using dateRange.Utils.Interfaces;
using dateRange.Validation;
using dateRangeTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Globalization;

namespace dateRange.Tests
{
    [TestClass()]
    public class DateRangeParserTests : BaseTests
    {
        [TestMethod()]
        public void ThrowExceptionWrongDatesOrder()
        {
            DateTime startDate = DateTime.Parse("02.01.2016", new CultureInfo("pl-PL"));
            DateTime endDate = DateTime.Parse("01.01.2016", new CultureInfo("pl-PL"));

            IDateRangeParser dateRangeParser = container.Resolve<IDateRangeParser>();

            Assert.ThrowsException<ValidationException>(() => dateRangeParser.CalculateRange(startDate, endDate));
        }

        [TestMethod()]
        public void CheckRangeForSameDates()
        {
            DateTime startDate = DateTime.Parse("01.01.2016", new CultureInfo("pl-PL")).Date;
            DateTime endDate = DateTime.Parse("01.01.2016", new CultureInfo("pl-PL")).Date;

            IDateRangeParser dateRangeParser = container.Resolve<IDateRangeParser>();

            string expected = "01.01.2016";
            string result = dateRangeParser.CalculateRange(startDate, endDate);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckRangeForDifferentDays()
        {
            Mock<IPatternsUtil> patternsUtilMock = new Mock<IPatternsUtil>();

            DateTime startDate = DateTime.Parse("01.01.2016", new CultureInfo("pl-PL")).Date;
            DateTime endDate = DateTime.Parse("02.01.2016", new CultureInfo("pl-PL")).Date;

            // table with all possible patterns and ranges
            DatePatternAndRange[] patternsAndRanges = new DatePatternAndRange[]
            {
                new DatePatternAndRange("dd", "dd.MM.yyyy", "01 - 02.01.2016"),
                new DatePatternAndRange("dd", "dd.yyyy.MM", "01 - 02.2016.01"),
                new DatePatternAndRange("MM.dd", "MM.dd.yyyy", "01.01 - 01.02.2016"),
                new DatePatternAndRange("MM.yyyy.dd", "dd", "01.2016.01 - 02"),
                new DatePatternAndRange("yyyy.dd.MM", "dd.MM", "2016.01.01 - 02.01"),
                new DatePatternAndRange("yyyy.MM.dd", "dd", "2016.01.01 - 02"),
            };

            foreach (DatePatternAndRange par in patternsAndRanges)
            {
                patternsUtilMock.Setup(m => m.GetPatterns(startDate, endDate)).Returns(par.Patterns);

                IDateRangeParser dateRangeParser = container.Resolve<IDateRangeParser>(new TypedParameter(typeof(IPatternsUtil), patternsUtilMock.Object));

                string expected = par.Range;
                string result = dateRangeParser.CalculateRange(startDate, endDate);

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void CheckRangeForDifferentMonths()
        {
            Mock<IPatternsUtil> patternsUtilMock = new Mock<IPatternsUtil>();

            DateTime startDate = DateTime.Parse("01.01.2016", new CultureInfo("pl-PL")).Date;
            DateTime endDate = DateTime.Parse("01.02.2016", new CultureInfo("pl-PL")).Date;

            // table with all possible patterns and ranges
            DatePatternAndRange[] patternsAndRanges = new DatePatternAndRange[]
            {
                new DatePatternAndRange("dd.MM", "dd.MM.yyyy", "01.01 - 01.02.2016"),
                new DatePatternAndRange("dd.yyyy.MM", "dd.yyyy.MM", "01.2016.01 - 01.2016.02"),
                new DatePatternAndRange("MM.dd", "MM.dd.yyyy", "01.01 - 02.01.2016"),
                new DatePatternAndRange("MM.yyyy.dd", "MM.yyyy.dd", "01.2016.01 - 02.2016.01"),
                new DatePatternAndRange("yyyy.dd.MM", "dd.MM", "2016.01.01 - 01.02"),
                new DatePatternAndRange("yyyy.MM.dd", "MM.dd", "2016.01.01 - 02.01"),
            };

            foreach (DatePatternAndRange par in patternsAndRanges)
            {
                patternsUtilMock.Setup(m => m.GetPatterns(startDate, endDate)).Returns(par.Patterns);

                IDateRangeParser dateRangeParser = container.Resolve<IDateRangeParser>(new TypedParameter(typeof(IPatternsUtil), patternsUtilMock.Object));

                string expected = par.Range;
                string result = dateRangeParser.CalculateRange(startDate, endDate);

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void CheckRangeForDifferentYears()
        {
            Mock<IPatternsUtil> patternsUtilMock = new Mock<IPatternsUtil>();

            DateTime startDate = DateTime.Parse("01.01.2016", new CultureInfo("pl-PL")).Date;
            DateTime endDate = DateTime.Parse("01.01.2017", new CultureInfo("pl-PL")).Date;

            // table with all possible patterns and ranges
            DatePatternAndRange[] patternsAndRanges = new DatePatternAndRange[]
            {
                new DatePatternAndRange("dd.MM.yyyy", "dd.MM.yyyy", "01.01.2016 - 01.01.2017"),
                new DatePatternAndRange("dd.yyyy.MM", "dd.yyyy.MM", "01.2016.01 - 01.2017.01"),
                new DatePatternAndRange("MM.dd.yyyy", "MM.dd.yyyy", "01.01.2016 - 01.01.2017"),
                new DatePatternAndRange("MM.yyyy.dd", "MM.yyyy.dd", "01.2016.01 - 01.2017.01"),
                new DatePatternAndRange("yyyy.dd.MM", "yyyy.dd.MM", "2016.01.01 - 2017.01.01"),
                new DatePatternAndRange("yyyy.MM.dd", "yyyy.MM.dd", "2016.01.01 - 2017.01.01"),
            };

            foreach (DatePatternAndRange par in patternsAndRanges)
            {
                patternsUtilMock.Setup(m => m.GetPatterns(startDate, endDate)).Returns(par.Patterns);

                IDateRangeParser dateRangeParser = container.Resolve<IDateRangeParser>(new TypedParameter(typeof(IPatternsUtil), patternsUtilMock.Object));

                string expected = par.Range;
                string result = dateRangeParser.CalculateRange(startDate, endDate);

                Assert.AreEqual(expected, result);
            }
        }
    }

    class DatePatternAndRange
    {
        public PatternsDTO Patterns { get; set; }
        public string Range { get; set; }

        public DatePatternAndRange(string startPattern, string endPattern, string range)
        {
            Patterns = new PatternsDTO(startPattern, endPattern);
            Range = range;
        }
    }
}