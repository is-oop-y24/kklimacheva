using System.Collections.Generic;

namespace Backups
{
    public class Storage
    {
        private List<string> _files = new List<string>();

        public Storage(string path)
        {
            Path = path;
        }

        public Storage(string path, List<string> files)
        {
            Path = path;
            _files = files;
        }

        public string Path { get; }

        public void AddFile(string fileName)
        {
            _files.Add(fileName);
        }

        public void RemoveFile(string fileName)
        {
            if (_files.Contains(fileName))
            {
                _files.Remove(fileName);
            }
        }
    }
}