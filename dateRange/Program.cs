using Autofac;
using dateRange.Autofac;
using dateRange.Interfaces;
using dateRange.Logging.Interfaces;
using dateRange.Utils.Interfaces;
using dateRange.Validation.Validations;
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
                    ArgsCounterValidation argsCounterValidator = new ArgsCounterValidation(args);

                    if (argsCounterValidator.IsValid)
                    {
                        IDateParserUtil dateParserUtil = scope.Resolve<IDateParserUtil>();

                        DateTime? startDate = dateParserUtil.ParseDate(args[0]);
                        DateTime? endDate = dateParserUtil.ParseDate(args[1]);

                        if (startDate != null && endDate != null)
                        {
                            IDateRangeParser dateRangeParser = scope.Resolve<IDateRangeParser>();
                            string range = dateRangeParser.CalculateRange(startDate.Value, endDate.Value);
                            if (range != null)
                            {
                                logger.Info(range);
                            }
                        }
                    }
                    else
                    {
                        logger.Error(argsCounterValidator.Message);
                    }
                }
                catch(Exception e)
                {
                    logger.Fatal(string.Format("Unknown exception: {0}", e.ToString()));
                }
            }
        }
    }
}
