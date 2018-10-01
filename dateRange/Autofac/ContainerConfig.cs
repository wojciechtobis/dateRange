using Autofac;

namespace dateRange.Autofac
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            
            return builder.Build();
        }
    }
}
