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
    public class DateParseValidationTests
    {
        private string _validInput = "01.01.2016";
        private string _invalidInput = "01.01.2016r";

        [TestMethod()]
        public void CheckIfValidForValidInput()
        {
            DateParseValidation validation = new DateParseValidation(_validInput);
            bool result = validation.IsValid;

            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void CheckIfValidForInvalidInput()
        {
            DateParseValidation validation = new DateParseValidation(_invalidInput);
            bool result = validation.IsValid;

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void CheckMessageForInvalidInput()
        {
            DateParseValidation validation = new DateParseValidation(_invalidInput);

            string result = validation.Message;
            string expected = string.Format("DateParseValidation: Cannot parse date: {0}\n", _invalidInput);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckValidateForValidInput()
        {
            DateParseValidation validation = new DateParseValidation(_validInput);

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
            DateParseValidation validation = new DateParseValidation(_invalidInput);

            Assert.ThrowsException<ValidationException>(() => validation.Validate());
        }
    }
}