using System;
using System.Collections.Generic;

namespace Backups
{
    public class BackupJob
    {
        private IStorageAlgorithmType _algorithmType;
        private List<string> _filesToBackup;
        private List<RestorePoint> _points = new ();

        public BackupJob(string name, IStorageAlgorithmType algorithmType, List<string> files)
        {
            Name = name;
            _algorithmType = algorithmType;
            _filesToBackup = files;
        }

        public string Name { get; }

        public void AddObject(string objectPath)
        {
            _filesToBackup.Add(objectPath);
        }

        public IReadOnlyList<string> Objects()
        {
            return _filesToBackup;
        }

        public IReadOnlyList<RestorePoint> Points()
        {
            return _points;
        }

        public void RemoveObject(string objectPath)
        {
            if (_filesToBackup.Contains(objectPath))
            {
                _filesToBackup.Remove(objectPath);
            }
        }

        public void StartJob(Repository repository)
        {
            _points.Add(_algorithmType.Backup(repository, _filesToBackup, DateTime.Now.Millisecond.ToString()));
        }

        public void RemovePoint(RestorePoint point)
        {
            _points.Remove(point);
        }

        private RestorePoint AddRestorePoint(List<string> files)
        {
            return new RestorePoint(files);
        }
    }
}