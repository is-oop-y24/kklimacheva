using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backups
{
    public class SingleStorageAlgorithm : IStorageAlgorithmType
    {
        private IStorageType _storageType;

        public SingleStorageAlgorithm(IStorageType type)
        {
            _storageType = type;
        }

        public RestorePoint Backup(Repository repository, List<string> files, string name)
        {
            string storage = _storageType.InitStorage(repository.Path, name);
            var newPaths = files.Select(file => _storageType.AddFolderToZip(storage, file, name)).ToList();

            repository.AddStorage(Path.GetFileName(storage), newPaths);
            return new RestorePoint(newPaths);
        }
    }
}