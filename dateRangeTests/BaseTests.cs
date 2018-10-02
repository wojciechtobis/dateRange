using Autofac;
using dateRange.Logging;
using dateRange.Logging.Interfaces;
using dateRange.Utils;
using dateRange.Utils.Interfaces;

namespace dateRangeTests
{
    public class BaseTests
    {
        protected IContainer container;

        public BaseTests()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DateParserUtil>().As<IDateParserUtil>();
            builder.RegisterType<CustomLogger>().As<ICustomILogger>();

            container = builder.Build();
        }
    }
}
