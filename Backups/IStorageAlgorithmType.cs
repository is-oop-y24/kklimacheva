using System.Collections.Generic;

namespace Backups
{
    public interface IStorageAlgorithmType
    {
        RestorePoint Backup(Repository repository, List<string> files, string name);
    }
}