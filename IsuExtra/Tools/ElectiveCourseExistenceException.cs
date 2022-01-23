using System;

namespace IsuExtra.Tools
{
    public class ElectiveCourseExistenceException : IsuExtraException
    {
        public ElectiveCourseExistenceException()
        {
        }

        public ElectiveCourseExistenceException(string message)
            : base(message)
        {
        }

        public ElectiveCourseExistenceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}