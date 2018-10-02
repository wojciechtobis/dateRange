using Microsoft.VisualStudio.TestTools.UnitTesting;
using dateRange.Utils;
using System;
using dateRange.Utils.Interfaces;
using dateRangeTests;
using Autofac;

namespace dateRange.Utils.Tests
{
    [TestClass()]
    public class DateParserUtilTests : BaseTests
    {
        [TestMethod()]
        public void ParseDateTestForValidInput()
        {
            IDateParserUtil dateParser = container.Resolve<IDateParserUtil>();
            string dateString = "01.01.2016";

            DateTime result = dateParser.ParseDate(dateString).Value;
            DateTime expected = DateTime.Parse(dateString);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ParseDateTestForInvalidInput()
        {
            IDateParserUtil dateParser = container.Resolve<IDateParserUtil>();
            string dateString = "01.01.2016r";

            DateTime? result = dateParser.ParseDate(dateString);
            DateTime? expected = null;

            Assert.AreEqual(expected, result);
        }
    }
}