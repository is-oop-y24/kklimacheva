using System;

namespace Banks
{
    public class ClientException : BanksException
    {
        public ClientException()
        {
        }

        public ClientException(string message)
            : base(message)
        {
        }

        public ClientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}