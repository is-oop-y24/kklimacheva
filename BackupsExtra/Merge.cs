using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class Merge : IPointRemover
    {
        public void Remove(BackupJob job)
        {
            foreach (var file in job.Points().Last().Files())
            {
                if (job.Points().ElementAt(job.Points().Count - 1).Files().Contains(file))
                {
                    job.DeleteRestorePoint(job.Points().ElementAt(job.Points().Count - 1));
                }
            }
        }
    }
}