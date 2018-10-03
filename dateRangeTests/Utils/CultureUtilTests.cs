using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Threading;
using dateRange.Utils.Interfaces;
using dateRangeTests;
using Autofac;

namespace dateRange.Utils.Tests
{
    [TestClass()]
    public class CultureUtilTests : BaseTests
    {
        [TestMethod()]
        public void CheckDateSeparatorForCurrentCulture()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

            ICultureUtil cultureUtil = container.Resolve<ICultureUtil>();

            string expected = currentCulture.DateTimeFormat.DateSeparator;
            string result = cultureUtil.DateSeparator;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckShortDatePatternForCurrentCulture()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

            ICultureUtil cultureUtil = container.Resolve<ICultureUtil>();

            string expected = currentCulture.DateTimeFormat.ShortDatePattern;
            string result = cultureUtil.ShortDatePattern;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckDateSeparatorForUSCulture()
        {
            CultureInfo newCultureInfo = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = newCultureInfo;

            ICultureUtil cultureUtil = container.Resolve<ICultureUtil>();

            string expected = newCultureInfo.DateTimeFormat.DateSeparator;
            string result = cultureUtil.DateSeparator;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckShortDatePatternForUSCulture()
        {
            CultureInfo newCultureInfo = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = newCultureInfo;

            ICultureUtil cultureUtil = container.Resolve<ICultureUtil>();

            string expected = newCultureInfo.DateTimeFormat.ShortDatePattern;
            string result = cultureUtil.ShortDatePattern;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckDateSeparatorForJPCulture()
        {
            CultureInfo newCultureInfo = new CultureInfo("ja-JP");
            Thread.CurrentThread.CurrentCulture = newCultureInfo;

            ICultureUtil cultureUtil = container.Resolve<ICultureUtil>();

            string expected = newCultureInfo.DateTimeFormat.DateSeparator;
            string result = cultureUtil.DateSeparator;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckShortDatePatternForJPCulture()
        {
            CultureInfo newCultureInfo = new CultureInfo("ja-JP");
            Thread.CurrentThread.CurrentCulture = newCultureInfo;

            ICultureUtil cultureUtil = container.Resolve<ICultureUtil>();

            string expected = newCultureInfo.DateTimeFormat.ShortDatePattern;
            string result = cultureUtil.ShortDatePattern;

            Assert.AreEqual(expected, result);
        }
    }
}