using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dateRange.Utils.Interfaces
{
    public interface IPatternsUtil
    {
        string StartPattern { get; }
        string EndPattern { get; }
        void SetPatterns(DateTime startDate, DateTime endDate);
    }
}
