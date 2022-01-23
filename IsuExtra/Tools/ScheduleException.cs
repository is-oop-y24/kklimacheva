using System;

namespace IsuExtra.Tools
{
    public class ScheduleException : IsuExtraException
    {
        public ScheduleException()
        {
        }

        public ScheduleException(string message)
            : base(message)
        {
        }

        public ScheduleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}