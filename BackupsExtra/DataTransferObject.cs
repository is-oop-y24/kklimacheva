using System;
using System.Collections.Generic;
using Backups;

namespace BackupsExtra
{
    public class DataTransferObject
    {
        public DataTransferObject(BackupJob job)
        {
            JobName = job.Name;
            foreach (var obj in job.JobObjects())
            {
                JobObjects?.Add(obj.Path);
            }

            foreach (RestorePoint point in job.Points())
            {
                Points.Add(point.CreationTime(), point.Files() as List<string> ?? throw new InvalidOperationException());
            }
        }

        public List<string> JobObjects { get; set; } = null!;
        public string JobName { get; set; }
        public Dictionary<DateTime, List<string>> Points { get; set; } = new Dictionary<DateTime, List<string>>();
    }
}