using Backups;

namespace BackupsExtra
{
    public interface IPointRemover
    {
        public void Remove(BackupJob job);
    }
}