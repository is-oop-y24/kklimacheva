using System;
using Backups;

namespace BackupsExtra
{
    public class ByDateRemover : IPointRemover
    {
        private readonly DateTime _limitDateTime;

        public ByDateRemover(DateTime date)
        {
            _limitDateTime = date;
        }

        public void Update(BackupJob job)
        {
            foreach (RestorePoint point in job.Points())
            {
                if (point.CreationTime() >= _limitDateTime) continue;
                if (job.Points().Count == 1)
                {
                    throw new PointRemoverException("Can't delete all points.");
                }

                RemovePoints(job, point);
            }
        }

        public void RemovePoints(BackupJob job, RestorePoint point)
        {
            job.RemovePoint(point);
        }
    }
}