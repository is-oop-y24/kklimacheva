using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class RemoveByAmount : IPointRemover
    {
        public RemoveByAmount(int n)
        {
            LimitAmount = n;
        }

        public int LimitAmount { get; }

        public void Remove(BackupJob job)
        {
            var size = job.Points().Count;
            if (size <= LimitAmount) return;
            for (var i = 0; i < LimitAmount - size; ++i)
            {
                job.DeleteRestorePoint(job.Points().ElementAt(i));
            }
        }
    }
}