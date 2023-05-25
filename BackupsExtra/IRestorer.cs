using Backups;

namespace BackupsExtra
{
    public interface IRestorer
    {
        void RestoreToOriginLocation(BackupJobExtra job, RestorePoint point);
        void RestoreToNewLocation(string path, RestorePoint point);
    }
}