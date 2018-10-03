using Autofac;
using dateRange.Interfaces;
using dateRange.Logging;
using dateRange.Logging.Interfaces;
using dateRange.Utils;
using dateRange.Utils.Interfaces;

namespace dateRange.Autofac
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DateParserUtil>().As<IDateParserUtil>();
            builder.RegisterType<CustomLogger>().As<ICustomILogger>();
            builder.RegisterType<CultureUtil>().As<ICultureUtil>();
            builder.RegisterType<PatternsUtil>().As<IPatternsUtil>();
            builder.RegisterType<DateRangeParser>().As<IDateRangeParser>();

            return builder.Build();
        }
    }
}
