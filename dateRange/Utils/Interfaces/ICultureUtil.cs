using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dateRange.Utils.Interfaces
{
    public interface ICultureUtil
    {
        string DateSeparator { get; }
        string ShortDatePattern { get; }
    }
}
