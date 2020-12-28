using System;
using System.Runtime.Serialization;

namespace EasyConsoleNG.Menus
{
    [Serializable]
    public class EndMenuException : Exception
    {
        public EndMenuException()
        {
        }

        public EndMenuException(string message) : base(message)
        {
        }

        public EndMenuException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EndMenuException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
