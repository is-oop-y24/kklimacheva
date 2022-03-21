using System;
using Backups;

namespace BackupsExtra
{
    public class RemoveByDate : IPointRemover
    {
        private DateTime _limitDate;
        public RemoveByDate(DateTime limitDate)
        {
            _limitDate = limitDate;
        }

        public void Remove(BackupJob job)
        {
            foreach (var point in job.Points())
            {
                if (point.CreationTime() > _limitDate)
                {
                    job.DeleteRestorePoint(point);
                }
            }
        }
    }
}