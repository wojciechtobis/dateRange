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

        public override bool Requirement
        {
            get
            {
                return Context[0] <= Context[1];
            }
        }

        protected override string ValidationMessage
        {
            get
            {
                return string.Format("First date - {0} greater than second date - {1}", Context[0].ToShortDateString(), Context[1].ToShortDateString());
            }
        }
    }
}
