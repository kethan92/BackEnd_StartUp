using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Data.Exceptions
{
    [Serializable]
    public class UnAuthorizedException : ApplicationException
    {
        protected UnAuthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            //default constructor
        }
        public UnAuthorizedException(string message) : base(message)
        {
            //constructor with message
        }
    }
}
