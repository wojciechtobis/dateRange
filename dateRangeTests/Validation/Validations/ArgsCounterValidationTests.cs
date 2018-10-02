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
    public class ArgsCounterValidationTests
    {
        private string[] _validInput = new string[] { "01.01.2016", "02.01.2016" };
        private string[] _invalidInput = new string[] { "01.01.2016", "02.01.2016", "02.03.2016" };

        [TestMethod()]
        public void CheckIfValidForValidInput()
        {

            ArgsCounterValidation validation = new ArgsCounterValidation(_validInput);
            bool result = validation.IsValid;

            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void CheckIfValidForInvalidInput()
        {
            ArgsCounterValidation validation = new ArgsCounterValidation(_invalidInput);
            bool result = validation.IsValid;

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void CheckMessageForInvalidInput()
        {
            ArgsCounterValidation validation = new ArgsCounterValidation(_invalidInput);

            string result = validation.Message;
            string expected = string.Format("ArgsCounterValidation: Received {0} parameters, should be 2\n", _invalidInput.Length);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckValidateForValidInput()
        {
            ArgsCounterValidation validation = new ArgsCounterValidation(_validInput);

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
            ArgsCounterValidation validation = new ArgsCounterValidation(_invalidInput);

            Assert.ThrowsException<ValidationException>(() => validation.Validate());
        }
    }
}