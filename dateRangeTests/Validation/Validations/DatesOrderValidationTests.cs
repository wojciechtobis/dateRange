using Microsoft.VisualStudio.TestTools.UnitTesting;
using dateRange.Validation.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dateRange.Validation.Validations.Tests
{
    [TestClass()]
    public class DatesOrderValidationTests
    {
        private DateTime[] _validInput = new DateTime[] { DateTime.Now.Date, DateTime.Now.AddDays(1).Date };
        private DateTime[] _invalidInput = new DateTime[] { DateTime.Now.AddDays(1).Date, DateTime.Now.Date };

        [TestMethod()]
        public void CheckIfValidForValidInput()
        {
            DatesOrderValidation validation = new DatesOrderValidation(_validInput);
            bool result = validation.IsValid;

            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void CheckIfValidForInvalidInput()
        {
            DatesOrderValidation validation = new DatesOrderValidation(_invalidInput);
            bool result = validation.IsValid;

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void CheckMessageForInvalidInput()
        {
            DatesOrderValidation validation = new DatesOrderValidation(_invalidInput);

            string result = validation.Message;
            string expected = string.Format("DatesOrderValidation: First date - {0} greater than second date - {1}\n", _invalidInput[0].ToShortDateString(), _invalidInput[1].ToShortDateString());

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckValidateForValidInput()
        {
            DatesOrderValidation validation = new DatesOrderValidation(_validInput);

            try
            {
                validation.Validate();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CheckValidateForInvalidInput()
        {
            DatesOrderValidation validation = new DatesOrderValidation(_invalidInput);

            Assert.ThrowsException<ValidationException>(() => validation.Validate());
        }
    }
}