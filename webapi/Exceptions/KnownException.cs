using System;
using System.Runtime.Serialization;

namespace webapi.Exceptions
{
    public class KnownException : Exception
    {
        public KnownException():base()
        {
        }

        public KnownException(string message) : base(message)
        {
        }

        public KnownException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected KnownException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}