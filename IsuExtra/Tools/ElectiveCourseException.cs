using System;

namespace IsuExtra.Tools
{
    public class ElectiveCourseException : IsuExtraException
    {
        public ElectiveCourseException()
        {
        }

        public ElectiveCourseException(string message)
            : base(message)
        {
        }

        public ElectiveCourseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}