using System;

namespace SimpleCalculator
{
    public class CalculateEngine
    {
        public double calculate(string argOperation, double argFirstNumber, double argSecondNumber)
        {
            double result;
            switch (argOperation.ToLower()?.Trim())
            {
                case "+":
                case "add":
                    result = argFirstNumber + argSecondNumber;
                    break;
                case "-":
                case "subtract":
                    result = argFirstNumber - argSecondNumber;
                    break;
                case "*":
                case "multiply":
                    result = argFirstNumber * argSecondNumber;
                    break;
                case "/":
                case "divide":
                    result = argFirstNumber / argSecondNumber;
                    break;
                    
                default:
                    throw new InvalidOperationException("Specified operation is not recognized.");
            }
            return result;
        }
    }
}