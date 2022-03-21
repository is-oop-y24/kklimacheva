using System;

namespace Banks.Exceptions
{
    public class WrongIdException : Exception
    {
        public WrongIdException(string message)
            : base(message)
        {
        }
    }
}