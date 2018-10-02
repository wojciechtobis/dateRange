using Autofac;
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

            container = builder.Build();
        }
    }
}
