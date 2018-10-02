namespace dateRange.Validation.Interfaces
{
    public interface IValidationBase
    {
        bool IsValid { get; }
        void Validate();
        string Message { get; }
    }
}
