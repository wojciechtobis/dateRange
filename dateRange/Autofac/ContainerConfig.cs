using Autofac;
using dateRange.Logging;
using dateRange.Logging.Interfaces;

namespace dateRange.Autofac
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CustomLogger>().As<ICustomILogger>();

            return builder.Build();
        }
    }
}
