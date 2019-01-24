using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculateEngine _calculateEngine = new CalculateEngine();
        private readonly int _number1 = 8;
        private readonly int _number2 = 2;
        
        [TestMethod]
        public void AddTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {            
            double result = _calculateEngine.calculate("add", _number1, _number2);
            Assert.AreEqual(10, result);
        }
        
        [TestMethod]
        public void SubtractTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            double result = _calculateEngine.calculate("subtract", _number1, _number2);
            Assert.AreEqual(6, result);
        }
        
        [TestMethod]
        public void MultipleTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            double result = _calculateEngine.calculate("multiply", _number1, _number2);
            Assert.AreEqual(16, result);
        }
        
        [TestMethod]
        public void DivideTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            double result = _calculateEngine.calculate("divide", _number1, _number2);
            Assert.AreEqual(4, result);
        }
        
        [TestMethod]
        public void AddTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            double result = _calculateEngine.calculate("+", _number1, _number2);
            Assert.AreEqual(10, result);
        }
        
        [TestMethod]
        public void SubtractTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            double result = _calculateEngine.calculate("-", _number1, _number2);
            Assert.AreEqual(6, result);
        }
        
        [TestMethod]
        public void MultipleTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            double result = _calculateEngine.calculate("*", _number1, _number2);
            Assert.AreEqual(16, result);
        }
        
        [TestMethod]
        public void DivideTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            double result = _calculateEngine.calculate("/", _number1, _number2);
            Assert.AreEqual(4, result);
        }
        
        [TestMethod]
        public void AddTwoNumbersAndReturnsValidResultForNonSymbolOperationIgnoreCase()
        {
            double result = _calculateEngine.calculate("multIply", _number1, _number2);
            Assert.AreEqual(16, result);
        }
        
        [TestMethod]
        public void SubtractTwoNumbersAndReturnsValidResultForNonSymbolOperationIgnoreTrailingWhiteSpace()
        {
            double result = _calculateEngine.calculate("   subtract    ", _number2, _number1);
            Assert.AreEqual(-6, result);
        }
        
        [TestMethod]
        public void SubtractTwoNumbersAndReturnsValidResultForSymbolOperationIgnoreTrailingWhiteSpace()
        {
            double result = _calculateEngine.calculate("   -    ", _number2, _number1);
            Assert.AreEqual(-6, result);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FailsToCalculateInvalidOperation()
        {
            double result = _calculateEngine.calculate("Random", _number1, _number2);
            Assert.AreEqual(-100, result);
        }
        
    }
}