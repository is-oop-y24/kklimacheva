using System;
using System.Collections.Generic;

namespace Backups
{
    public class RestorePoint
    {
        private DateTime _creationTime;
        private List<string> _filesList;

        public RestorePoint(List<string> copiesList)
        {
            _creationTime = DateTime.Now;
            _filesList = copiesList;
        }

        public RestorePoint(DateTime creationTime, List<string> files)
        {
            _creationTime = creationTime;
            _filesList = files;
        }

        public DateTime CreationTime()
        {
            return _creationTime;
        }

        public IReadOnlyList<string> FilesList()
        {
            return _filesList;
        }

        public void AddFile(string filePath)
        {
            _filesList.Add(filePath);
        }
    }
}