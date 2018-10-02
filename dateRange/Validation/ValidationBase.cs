using dateRange.Validation.Interfaces;
using System;

namespace dateRange.Validation
{
    /// <summary>
    /// Base class for all validations. Inspired by 'A SOLID validation class by Alex Siepman (http://www.siepman.nl/blog/post/2014/01/05/SOLID-validation-class-with-easy-logical-implication.aspx)
    /// </summary>
    /// <typeparam name="T">
    /// Validation's context type
    /// </typeparam>
    public abstract class ValidationBase<T> : IValidationBase where T : class
    {
        protected T Context { get; private set; }

        private bool UnableToExecute { get; set; }
        private string UnableReason { get; set; }

        protected ValidationBase(T context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            UnableToExecute = false;
        }

        /// <summary>
        /// Validation function, throws ValidationException when Validation is not valid
        /// </summary>
        public void Validate()
        {
            if (!IsValid)
            {
                throw new ValidationException(Message);
            }
        }

        /// <summary>
        /// Requirement for validation to be valid
        /// </summary>
        public abstract bool Requirement { get; }

        public bool IsValid
        {
            get
            {
                try
                {
                    return Implication(Requirement);
                }
                catch (Exception e)
                {
                    UnableToExecute = true;
                    UnableReason = e.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// Message returned when validation is not valid
        /// </summary>
        protected abstract string ValidationMessage { get; }

        private static bool Implication(bool requirement)
        {
            return requirement;
        }

        /// <summary>
        /// Message returned when exception is thrown during checking implication 
        /// </summary>
        private string UnableToExecuteMessage
        {
            get
            {
                return string.Format("Unable to execute validation. Reason: {0}", UnableReason);
            }
        }

        public string Message
        {
            get
            {
                return string.Format("{0}: {1}\n", this.GetType().Name, UnableToExecute ? UnableToExecuteMessage : ValidationMessage);
            }
        }
    }
}
