using Autofac;
using dateRange.Autofac;
using dateRange.Logging.Interfaces;
using System;

namespace dateRange
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                ICustomILogger logger = scope.Resolve<ICustomILogger>();

                logger.Debug(string.Format("Start processing with args: {0}", string.Join(", ", args)));

                try
                {

                }
                catch(Exception e)
                {
                    logger.Fatal(string.Format("Unknown exception: {0}", e.ToString()));
                }
            }

            Console.ReadKey();
        }
    }
}
