using System;

namespace SimpleCalculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                InputConverter inputConverter = new InputConverter();
                CalculateEngine calculateEngine = new CalculateEngine();

                double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                string operation = Console.ReadLine();

                double result = calculateEngine.calculate(operation, firstNumber, secondNumber);
                Console.WriteLine("The result is: {0}", result);
            }
            catch (Exception ex)
            {
                // In real world we would want to log this message
                Console.WriteLine(ex.Message);
            }

        }
    }
}