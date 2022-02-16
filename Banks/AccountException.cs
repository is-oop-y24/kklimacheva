using System;

namespace Banks
{
    public class AccountException : BanksException
    {
        public AccountException()
        {
        }

        public AccountException(string message)
            : base(message)
        {
        }

        public AccountException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}