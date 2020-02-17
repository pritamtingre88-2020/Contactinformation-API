using System;

namespace CalculationSummary.Common
{
    public class InvalidContactException : Exception
    {
        public InvalidContactException(string message) : base(message)
        {

        }
    }
}
