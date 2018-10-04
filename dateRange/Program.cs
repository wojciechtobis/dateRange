using Autofac;
using dateRange.Autofac;
using dateRange.Interfaces;
using dateRange.Logging.Interfaces;
using dateRange.Utils.Interfaces;
using dateRange.Validation;
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
                    argsCounterValidator.Validate();

                    IDateParserUtil dateParserUtil = scope.Resolve<IDateParserUtil>();

                    DateTime startDate = dateParserUtil.ParseDate(args[0]);
                    DateTime endDate = dateParserUtil.ParseDate(args[1]);

                    IDateRangeParser dateRangeParser = scope.Resolve<IDateRangeParser>();
                    string range = dateRangeParser.CalculateRange(startDate, endDate);
                    logger.Info(range);
                    
                }
                catch(ValidationException ve)
                {
                    logger.Error(ve.Message);
                }
                catch(Exception e)
                {
                    logger.Fatal(string.Format("Unknown exception: {0}", e.ToString()));
                }
            }
        }
    }
}
