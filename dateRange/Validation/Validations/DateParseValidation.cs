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

        public override bool Requirement => throw new NotImplementedException();

        protected override string ValidationMessage => throw new NotImplementedException();
    }
}
