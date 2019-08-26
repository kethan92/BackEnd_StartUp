using System;
using System.Runtime.Serialization;

namespace StartUp.Data.Exceptions
{
    [Serializable]
    public class DataNotFoundException : ApplicationException
    {
        protected DataNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            //default constructor
        }
        public DataNotFoundException(string message) : base(message)
        {
            //constructor with message
        }
    }
}
