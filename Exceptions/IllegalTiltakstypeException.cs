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

        //protected IllegalTiltakstypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}