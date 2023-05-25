using Backups;

namespace BackupsExtra
{
    public interface IPointRemover
    {
        void Update(BackupJob job);
        void RemovePoints(BackupJob job, RestorePoint point);
    }
}