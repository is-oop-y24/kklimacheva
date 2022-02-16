using System.Collections.Generic;

namespace Backups
{
    public class Repository
    {
        private Dictionary<string, List<string>> _repository = new Dictionary<string, List<string>>();

        public Repository(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public void AddStorage(string storage, List<string> files)
        {
            _repository.Add(storage, files);
        }

        public IReadOnlyDictionary<string, List<string>> Storages()
        {
            return _repository;
        }
    }
}