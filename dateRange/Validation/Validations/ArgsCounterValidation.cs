namespace dateRange.Validation.Validations
{
    public class ArgsCounterValidation : ValidationBase<string[]>
    {
        public ArgsCounterValidation(string[] context) : base(context)
        {
        }

        public override bool Requirement
        {
            get
            {
                return Context.Length == 2;
            }
        }

        protected override string ValidationMessage
        {
            get
            {
                return string.Format("Received {0} parameters, should be 2", Context.Length);
            }
        }
    }
}
