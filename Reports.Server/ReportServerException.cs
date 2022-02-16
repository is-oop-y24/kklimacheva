using System;

namespace Reports.Server
{
    public class ReportServerException : Exception
    {
        public ReportServerException()
        {
        }

        public ReportServerException(string message)
            : base(message)
        {
        }

        public ReportServerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
