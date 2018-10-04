using dateRange.DTOs;
using System;

namespace dateRange.Utils.Interfaces
{
    public interface IPatternsUtil
    {
        PatternsDTO GetPatterns(DateTime startDate, DateTime endDate);
    }
}
