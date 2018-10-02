using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dateRange.Validation.Validations
{
    public class DatesOrderValidation : ValidationBase<DateTime[]>
    {
        public DatesOrderValidation(DateTime[] context) : base(context)
        {
        }

        public override bool Requirement => throw new NotImplementedException();

        protected override string ValidationMessage => throw new NotImplementedException();
    }
}
