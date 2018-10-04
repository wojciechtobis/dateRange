using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using dateRange.Utils.Interfaces;
using dateRangeTests;
using Autofac;
using dateRange.Validation;

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

            DateTime result = dateParser.ParseDate(dateString);
            DateTime expected = DateTime.Parse(dateString);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ParseDateTestForInvalidInput()
        {
            IDateParserUtil dateParser = container.Resolve<IDateParserUtil>();
            string dateString = "01.01.2016r";
            
            Assert.ThrowsException<ValidationException>(() => dateParser.ParseDate(dateString));
        }
    }
}