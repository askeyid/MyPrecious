using System;
using System.Runtime.Serialization;

namespace MyPrecious.AT.Framework.CustomExceptions
{
    [Serializable]
    public class FatalTestingException : TestingException
    {
        public override string Message => $"Fatal Testing Exception: {base.Message}";


        public FatalTestingException()
        {
        }

        public FatalTestingException(string message) : base(message)
        {
        }

        public FatalTestingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FatalTestingException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}
