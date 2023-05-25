using System;

namespace Banks.Exceptions
{
    public class UnsuccessfulWithdrawalException : Exception
    {
        public UnsuccessfulWithdrawalException(string message)
            : base(message)
        {
        }
    }
}