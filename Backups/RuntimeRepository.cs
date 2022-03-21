using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backups
{
    public class RuntimeRepository : IRepository
    {
        private List<Storage> _storages = new List<Storage>();

        public RuntimeRepository(string repositoryPath)
        {
            RepositoryPath = repositoryPath;
        }

        public string RepositoryPath { get; }

        public IReadOnlyList<Storage> Storages()
        {
            return _storages;
        }

        public string InitStorage()
        {
            string storageName = Guid.NewGuid() + ".zip";
            Storage newStorage = new Storage(Guid.NewGuid() + ".zip");
            string storagePath = RepositoryPath + "\\" + storageName;
            _storages.Add(newStorage);
            return storagePath;
        }

        public string MakeZip(string storagePath, string fileToZip)
        {
            var newPath = Guid.NewGuid() + Path.GetExtension(fileToZip);
            foreach (var storage in _storages.Where(storage => storage.Path.Equals(storagePath)))
            {
                storage.AddFile(fileToZip);
            }

            return newPath;
        }

        public void RemoveStorage(string path)
        {
            foreach (var storage in _storages.Where(storage => storage.Path.Equals(path)))
            {
                _storages.Remove(storage);
            }
        }
    }
}