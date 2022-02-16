using System;
using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class HybridRemover : IPointRemover
    {
        private readonly int _limitNum;
        private readonly DateTime _limitDate;

        public HybridRemover(int num = 0, DateTime date = default)
        {
            if (num < 0)
            {
                throw new PointRemoverException("Number of points can't be negative");
            }

            _limitNum = num;
            _limitDate = date;
        }

        public void Update(BackupJob job)
        {
            if (_limitNum == 0 && _limitDate.Equals(default))
            {
            }

            if (_limitNum == 0 && !_limitDate.Equals(default))
            {
                foreach (RestorePoint point in job.Points())
                {
                    if (point.CreationTime() >= _limitDate) continue;
                    if (job.Points().Count == 1)
                    {
                        throw new PointRemoverException("Can't delete all points.");
                    }

                    RemovePoints(job, point);
                }
            }

            if (_limitNum != 0 && _limitDate.Equals(default))
            {
                while (job.Points().Count > _limitNum)
                {
                    if (job.Points().Count == 1)
                    {
                        throw new PointRemoverException("Can't delete all points.");
                    }

                    RemovePoints(job, job.Points().First());
                }
            }

            if (_limitNum == 0 || _limitDate.Equals(default)) return;
            {
                while (job.Points().Count > _limitNum)
                {
                    RemovePoints(job, job.Points().First());
                }

                foreach (RestorePoint point in job.Points())
                {
                    if (point.CreationTime() < _limitDate)
                    {
                        RemovePoints(job, point);
                    }
                }
            }
        }

        public void RemovePoints(BackupJob job, RestorePoint point)
        {
            job.RemovePoint(point);
        }
    }
}