using Backups;

namespace BackupsExtra
{
    public class VirtualRestorer : IRestorer
    {
        public void RestoreToOriginLocation(BackupJobExtra job, RestorePoint point)
        {
        }

        public void RestoreToNewLocation(string path, RestorePoint point)
        {
        }
    }
}