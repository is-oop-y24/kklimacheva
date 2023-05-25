using System;

namespace BackupsExtra
{
    public class PointRemoverException : BackupsExtraException
    {
        public PointRemoverException()
        {
        }

        public PointRemoverException(string message)
            : base(message)
        {
        }

        public PointRemoverException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}