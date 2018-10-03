using System;

namespace dateRange.Interfaces
{
    public interface IDateRangeParser
    {
        string CalculateRange(DateTime startDate, DateTime endDate);
    }
}
