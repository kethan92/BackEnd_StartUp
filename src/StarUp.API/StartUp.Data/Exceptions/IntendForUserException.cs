using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Data.Exceptions
{
    [Serializable]
    public class IntendForUserException : ApplicationException
    {
        protected IntendForUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            //default constructor
        }
        public IntendForUserException(string message) : base(message)
        {
            //constructor with message
        }
    }
}
