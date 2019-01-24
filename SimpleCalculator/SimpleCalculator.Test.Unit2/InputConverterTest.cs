using System;
using Xunit;

namespace SimpleCalculator.Test.Unit
{
    public class InputConverterTest
    {
        private readonly InputConverter _inputConverter = new InputConverter();
        
        [Fact]
        public void ConvertsValidStringInputIntoDouble()
        {
            string inputNumber = "5";
            double result = _inputConverter.ConvertInputToNumeric(inputNumber);
            Assert.Equal(5, result);
        }
        
        [Fact]
        public void ConvertsValidStringInputIntoDoubleIgnoreWhiteSpace()
        {
            string inputNumber = "   5    ";
            double result = _inputConverter.ConvertInputToNumeric(inputNumber);
            Assert.Equal(5, result);
        }
        
        [Fact]
        [ExpectedException(typeof(ArgumentException))]
        public void FailsToConvertInvalidStringIntoDouble()
        {
            string inputNumber = "*";
            double result = _inputConverter.ConvertInputToNumeric(inputNumber);
            Assert.Equal(5, result);
        }
    }
}