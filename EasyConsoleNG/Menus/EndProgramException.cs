using System;
using System.Runtime.Serialization;

namespace EasyConsoleNG.Menus
{
    [Serializable]
    public class EndProgramException : Exception
    {
        public EndProgramException()
        {
        }

        public EndProgramException(string message) : base(message)
        {
        }

        public EndProgramException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EndProgramException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
