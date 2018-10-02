using System;

namespace dateRange.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string message, params object[] args)
            : base(String.Format(message, args))
        {
        }
    }
}
