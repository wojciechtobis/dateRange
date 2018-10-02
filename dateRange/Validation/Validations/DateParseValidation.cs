using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dateRange.Validation.Validations
{
    public class DateParseValidation : ValidationBase<string>
    {

        public DateParseValidation(string context) : base(context)
        {
        }

        public override bool Requirement
        {
            get
            {
                DateTime date;
                return DateTime.TryParse(Context, out date);
            }
        }

        protected override string ValidationMessage
        {
            get
            {
                return string.Format("Cannot parse date: {0}", Context);
            }
        }
    }
}
