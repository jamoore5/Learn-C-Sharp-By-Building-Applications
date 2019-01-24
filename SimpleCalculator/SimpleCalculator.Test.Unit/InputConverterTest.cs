using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class InputConverterTest
    {
        private readonly InputConverter _inputConverter = new InputConverter();
        
        [TestMethod]
        public void ConvertsValidStringInputIntoDouble()
        {
            string inputNumber = "5";
            double result = _inputConverter.ConvertInputToNumeric(inputNumber);
            Assert.AreEqual(5, result);
        }
        
        [TestMethod]
        public void ConvertsValidStringInputIntoDoubleIgnoreWhiteSpace()
        {
            string inputNumber = "   5    ";
            double result = _inputConverter.ConvertInputToNumeric(inputNumber);
            Assert.AreEqual(5, result);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailsToConvertInvalidStringIntoDouble()
        {
            string inputNumber = "*";
            _inputConverter.ConvertInputToNumeric(inputNumber);
        }

    }
}