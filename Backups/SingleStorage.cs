using System.Linq;

namespace Backups
{
    public class SingleStorage : IStorageAlgorithm
    {
        private IRepository _repository;

        public SingleStorage(IRepository repository)
        {
            _repository = repository;
        }

        public void Backup(BackupJob job, IRepository rep)
        {
            string storage = rep.InitStorage();
            var filesInPoint = job.JobObjects().
                Select(jobObject => rep.MakeZip(storage, jobObject.Path)).ToList();
            job.AddRestorePoint(new RestorePoint(filesInPoint));
        }
    }
}