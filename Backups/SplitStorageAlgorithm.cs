using System.Collections.Generic;
using System.IO;

namespace Backups
{
    public class SplitStorageAlgorithm : IStorageAlgorithmType
    {
        private IStorageType _storageType;

        public SplitStorageAlgorithm(IStorageType type)
        {
            _storageType = type;
        }

        public RestorePoint Backup(Repository repository, List<string> files, string name)
        {
            var newPaths = new List<string>();
            int fileCounter = 1;
            foreach (string file in files)
            {
                string newName = name + "_" + fileCounter++;
                string storage = _storageType.InitStorage(repository.Path, newName);
                string name1 = _storageType.AddFolderToZip(storage, file, name);
                newPaths.Add(name1);
                var tmpList = new List<string> { name1 };
                repository.AddStorage(Path.GetFileName(storage), tmpList);
            }

            return new RestorePoint(newPaths);
        }
    }
}