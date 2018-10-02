namespace dateRange.Validation.Validations
{
    public class ArgsCounterValidation : ValidationBase<string[]>
    {
        public ArgsCounterValidation(string[] context) : base(context)
        {
        }

        public override bool Requirement => throw new System.NotImplementedException();

        protected override string ValidationMessage => throw new System.NotImplementedException();
    }
}
