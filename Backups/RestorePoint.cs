using System;
using System.Collections.Generic;

namespace Backups
{
    public class RestorePoint
    {
        private DateTime _creationTime;
        private List<string> _files;

        public RestorePoint(List<string> files)
        {
            _creationTime = DateTime.Now;
            _files = files;
        }

        public IReadOnlyList<string> Files()
        {
            return _files;
        }

        public DateTime CreationTime()
        {
            return _creationTime;
        }
    }
}