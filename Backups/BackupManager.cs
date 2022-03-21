using System.Collections.Generic;

namespace Backups
{
    public class BackupManager
    {
        private BackupJob _job;
        private IRepository _repository;
        private IStorageAlgorithm _algo;

        public BackupManager(BackupJob job, IStorageAlgorithm algo, IRepository repo)
        {
            _job = job;
            _algo = algo;
            _repository = repo;
        }

        public BackupJob JobInstance()
        {
            return _job;
        }

        public void RemoveObject(JobObject obj)
        {
            _job.RemoveJobObject(obj);
        }

        public void AddJobObject(JobObject jobObject)
        {
            _job.AddJobObject(jobObject);
        }

        public IReadOnlyList<JobObject> JobObjects()
        {
            return _job.JobObjects();
        }

        public void StartBackup()
        {
            _algo.Backup(_job, _repository);
        }
    }
}