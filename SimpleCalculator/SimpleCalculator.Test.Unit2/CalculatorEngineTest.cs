using System;
using Xunit;

namespace SimpleCalculator.Test.Unit
{
    public class CalculatorEngineTest
    {
        private readonly CalculateEngine _calculateEngine = new CalculateEngine();
        
        [Fact]
        public void AddTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            int number1 = 8;
            int number2 = 2;
            
            double result = _calculateEngine.calculate("add", number1, number2);
            Assert.Equal(10, result);
            
            result = _calculateEngine.calculate("subtract", number1, number2);
            Assert.Equal(6, result);
            
            result = _calculateEngine.calculate("multiply", number1, number2);
            Assert.Equal(16, result);
            
            result = _calculateEngine.calculate("divide", number1, number2);
            Assert.Equal(4, result);
        }
        
        [Fact]
        public void AddTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            int number1 = 8;
            int number2 = 2;
            
            double result = _calculateEngine.calculate("+", number1, number2);
            Assert.Equal(10, result);
            
            result = _calculateEngine.calculate("-", number1, number2);
            Assert.Equal(6, result);
            
            result = _calculateEngine.calculate("*", number1, number2);
            Assert.Equal(16, result);
            
            result = _calculateEngine.calculate("/", number1, number2);
            Assert.Equal(4, result);
        }
        
        [Fact]
        public void AddTwoNumbersAndReturnsValidResultForNonSymbolOperationIgnoreCase()
        {
            int number1 = 8;
            int number2 = 2;
            double result = _calculateEngine.calculate("multIply", number1, number2);
            Assert.Equal(16, result);
        }
        
        [Fact]
        public void AddTwoNumbersAndReturnsValidResultForNonSymbolOperationIgnoreTrailingWhiteSpace()
        {
            int number1 = 100;
            int number2 = 1;
            double result = _calculateEngine.calculate("   subtract    ", number1, number2);
            Assert.Equal(99, result);
        }
        
        [Fact]
        public void AddTwoNumbersAndReturnsValidResultForSymbolOperationIgnoreTrailingWhiteSpace()
        {
            int number1 = 1;
            int number2 = 101;
            double result = _calculateEngine.calculate("   -    ", number1, number2);
            Assert.Equal(-100, result);
        }
    }
}