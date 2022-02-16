using System.Collections.Generic;
using Backups;

namespace BackupsExtra
{
    public class BackupJobExtra
    {
        private readonly bool _isTimeCodePrefixNeeded;
        private readonly BackupJob _job;
        private readonly Repository _repository;
        private readonly List<ILogger> _observers = new List<ILogger>();
        private IPointRemover _pointRemover;

        public BackupJobExtra(
            string name,
            Repository repo,
            IStorageAlgorithmType algorithmType,
            List<string> files,
            bool creationTimeNeeded = false)
        {
            _job = new BackupJob(name, algorithmType, files);
            _repository = repo;
            _isTimeCodePrefixNeeded = creationTimeNeeded;
        }

        public void StartJob()
        {
            _job.StartJob(_repository);
            NotifyRemover();
            NewStorageNotification();
            NewRestorePointNotification();
        }

        public void AddFile(string filePath)
        {
            _job.AddObject(filePath);
            NewFileAddedNotification();
        }

        public void RemoveFile(string filePath)
        {
            _job.RemoveObject(filePath);
            FileDeletedNotification();
        }

        public void AttachLogger(ILogger logger)
        {
            _observers.Add(logger);
        }

        public void DetachLogger(ILogger logger)
        {
            _observers.Remove(logger);
        }

        public void AttachPointRemover(IPointRemover remover)
        {
            _pointRemover = remover;
        }

        public void DetachPointRemover()
        {
            _pointRemover = null;
        }

        public BackupJob BackupJob()
        {
            return _job;
        }

        private void NewRestorePointNotification()
        {
            foreach (ILogger observer in _observers)
            {
                const string message = "New point created.";
                observer.Log(message, _isTimeCodePrefixNeeded);
            }
        }

        private void NewStorageNotification()
        {
            foreach (ILogger observer in _observers)
            {
                const string message = "Storage created.";
                observer.Log(message, _isTimeCodePrefixNeeded);
            }
        }

        private void NewFileAddedNotification()
        {
            foreach (ILogger observer in _observers)
            {
                const string message = "File added.";
                observer.Log(message, _isTimeCodePrefixNeeded);
            }
        }

        private void FileDeletedNotification()
        {
            foreach (ILogger observer in _observers)
            {
                const string message = "File deleted.";
                observer.Log(message, _isTimeCodePrefixNeeded);
            }
        }

        private void NotifyRemover()
        {
            _pointRemover?.Update(_job);
        }
    }
}