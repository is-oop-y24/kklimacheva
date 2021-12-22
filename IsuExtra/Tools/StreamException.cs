using System;

namespace IsuExtra.Tools
{
    public class StreamException : IsuExtraException
    {
        public StreamException()
        {
        }

        public StreamException(string message)
            : base(message)
        {
        }

        public StreamException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}