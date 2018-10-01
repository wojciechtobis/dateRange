using dateRange.Autofac;
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

            }
                Console.ReadKey();
        }
    }
}
