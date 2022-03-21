namespace Backups
{
    public interface IStorageAlgorithm
    {
        void Backup(BackupJob job, IRepository rep);
    }
}