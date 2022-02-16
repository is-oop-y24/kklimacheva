using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class PointMerger : IPointRemover
    {
        private readonly int _limitNum;
        private readonly DateTime _limitDate;

        public PointMerger(int limitNum = 0, DateTime limitDate = default)
        {
            if (limitNum < 0)
            {
                throw new PointRemoverException("Number of points can't be negative");
            }

            _limitNum = limitNum;
            _limitDate = limitDate;
        }

        public void Update(BackupJob job)
        {
            RestorePoint lastPoint = job.Points().Last();
            var lastPointFiles = new List<string>();
            lastPointFiles.AddRange(lastPoint.FilesList().Select(GetOriginalFileName));
            while (job.Points().Count > _limitNum)
            {
                foreach (string filePath in job.Points().First().FilesList())
                {
                    if (!lastPointFiles.Contains(GetOriginalFileName(filePath)))
                    {
                        job.Points().Last().AddFile(filePath);
                    }
                }

                RemovePoints(job, job.Points().First());
            }

            for (int i = 0; i < job.Points().Count - 1; ++i)
            {
                RestorePoint point = job.Points().ElementAt(i);
                if (point.CreationTime() >= _limitDate) continue;
                foreach (string filePath in point.FilesList())
                {
                    if (!lastPointFiles.Contains(GetOriginalFileName(filePath)))
                    {
                        job.Points().Last().AddFile(filePath);
                    }
                }

                job.RemovePoint(point);
            }
        }

        public void RemovePoints(BackupJob job, RestorePoint point)
        {
            job.RemovePoint(point);
        }

        private string GetOriginalFileName(string path)
        {
            string filename = Path.GetFileNameWithoutExtension(path);
            int index = filename.LastIndexOf("_", StringComparison.Ordinal);
            return filename[..index];
        }
    }
}