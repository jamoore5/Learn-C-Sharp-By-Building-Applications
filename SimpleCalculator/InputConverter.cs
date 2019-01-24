using System;
using System.Runtime.Remoting.Messaging;

namespace SimpleCalculator
{
    public class InputConverter
    {
        public double ConvertInputToNumeric(string argTextInput)
        {
            bool isConvertedSuccessfully = double.TryParse(argTextInput, out double convertedNumber);
            if (!isConvertedSuccessfully) 
                throw new ArgumentException("Expected a numeric value.");
            return convertedNumber;
        }
    }
}