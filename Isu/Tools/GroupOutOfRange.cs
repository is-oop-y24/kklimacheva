using System;

namespace Isu.Tools
{
    public class GroupOutOfRange : IsuException
    {
        public GroupOutOfRange()
        {
        }

        public GroupOutOfRange(string message)
            : base(message)
        {
        }

        public GroupOutOfRange(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}