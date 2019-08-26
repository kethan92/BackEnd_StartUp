using System;
using System.Runtime.Serialization;

namespace StartUp.Data.Exceptions
{
    [Serializable]
    public class InvalidModelStateException : ApplicationException
    {
        protected InvalidModelStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            //default constructor
        }
        public InvalidModelStateException(string message) : base(message)
        {
            //constructor with message
        }
    }
}
