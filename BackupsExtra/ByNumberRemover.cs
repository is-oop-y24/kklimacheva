using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class ByNumberRemover : IPointRemover
    {
        private readonly int _limitNum;

        public ByNumberRemover(int num)
        {
            if (num < 0)
            {
                throw new PointRemoverException("Number of points can't be negative");
            }

            _limitNum = num;
        }

        public void Update(BackupJob job)
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

        public void RemovePoints(BackupJob job, RestorePoint point)
        {
            job.RemovePoint(point);
        }
    }
}