using Backups;

namespace BackupsExtra
{
    public class BackupsExtraManager
    {
        private BackupManager _backupManager;
        private ILogger _logger;
        private Recover _recover;
        private IPointRemover _remover;

        public BackupsExtraManager(BackupJob job, IRepository rep, IStorageAlgorithm algo)
        {
            _backupManager = new BackupManager(job, algo, rep);
            Log("Manager created.");
        }

        public BackupManager BackupManagerInstance()
        {
            return _backupManager;
        }

        public void StartBackup()
        {
            _backupManager.StartBackup();
            _remover?.Remove(_backupManager.JobInstance());
            Log("Backup started.");
        }

        public void AddRemover(IPointRemover remover)
        {
            _remover = remover;
            Log("Remover added.");
        }

        public void DeleteRemover()
        {
            if (!_remover.Equals(null))
            {
                _remover = null!;
            }

            Log("Remover deleted.");
        }

        public void AddRecover(Recover recover)
        {
            _recover = recover;
            Log("Recover added.");
        }

        public void StartRecover(string sourcePath, string destinationPath, RestorePoint point)
        {
            _recover.RestoreFiles(sourcePath, destinationPath, point);
            Log("Staring restoration.");
        }

        public void AddLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void RemoveLogger()
        {
            Log("Deleting logger...");
            if (!_logger.Equals(null))
            {
                _logger = null!;
            }
        }

        private void Log(string message)
        {
            if (_logger != null)
            {
                _logger.Log(message);
            }
        }
    }
}