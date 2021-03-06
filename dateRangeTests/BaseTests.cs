﻿using Autofac;
using dateRange;
using dateRange.Interfaces;
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
            builder.RegisterType<CultureUtil>().As<ICultureUtil>();
            builder.RegisterType<PatternsUtil>().As<IPatternsUtil>();
            builder.RegisterType<DateRangeParser>().As<IDateRangeParser>();

            container = builder.Build();
        }
    }
}
