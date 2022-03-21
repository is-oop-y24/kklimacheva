using System.Linq;

namespace Backups
{
    public class SplitStorage : IStorageAlgorithm
    {
        private IRepository _repository;

        public SplitStorage(IRepository repository)
        {
            _repository = repository;
        }

        public void Backup(BackupJob job, IRepository rep)
        {
            var filesInPoint = (from jobObject in job.JobObjects() let storage = rep.InitStorage() select rep.MakeZip(storage, jobObject.Path)).ToList();
            job.AddRestorePoint(new RestorePoint(filesInPoint));
        }
    }
}