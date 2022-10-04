using System;

namespace ATIL.FeeCalculator.Exceptions
{
    [Serializable]
    public class IllegalTiltakstypeException : Exception
    {
        public IllegalTiltakstypeException()
        {
        }

        public IllegalTiltakstypeException(string message) : base(message)
        {
        }

        public IllegalTiltakstypeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}