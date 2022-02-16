using System;
using System.Collections.Generic;
using Backups;

namespace BackupsExtra
{
    public class DataTransformer
    {
        public DataTransformer(BackupJobExtra job)
        {
            JobName = job.BackupJob().Name;
            JobFiles = job.BackupJob().Objects() as List<string>;
            foreach (RestorePoint point in job.BackupJob().Points())
            {
                Points.Add(point.CreationTime(), point.FilesList() as List<string>);
            }
        }

        public DataTransformer() { }

        public string JobName { get; set; }
        public List<string> JobFiles { get; set; }
        public Dictionary<DateTime, List<string>> Points { get; set; } = new Dictionary<DateTime, List<string>>();
    }
}