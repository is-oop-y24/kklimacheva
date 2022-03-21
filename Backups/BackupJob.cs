using System;
using System.Collections.Generic;
using System.Linq;

namespace Backups
{
    public class BackupJob
    {
        private List<RestorePoint> _points = new ();
        private List<JobObject> _jobObjects;

        public BackupJob(string name, List<JobObject> jobObjects)
        {
            Name = name;
            _jobObjects = jobObjects;
        }

        public string Name { get; }

        public void AddRestorePoint(RestorePoint newPoint)
        {
            _points.Add(newPoint);
        }

        public IReadOnlyList<RestorePoint> Points()
        {
            return _points;
        }

        public IReadOnlyList<JobObject> JobObjects()
        {
            return _jobObjects;
        }

        public void DeleteRestorePoint(DateTime creationTime)
        {
            foreach (var point in _points.Where(point => point.CreationTime().Equals(creationTime)))
            {
                _points.Remove(point);
            }
        }

        public void DeleteRestorePoint(RestorePoint point)
        {
            if (_points.Contains(point))
            {
                _points.Remove(point);
            }
        }

        public void AddJobObject(JobObject jobObject)
        {
            _jobObjects.Add(jobObject);
        }

        public void RemoveJobObject(JobObject jobObject)
        {
            if (_jobObjects.Contains(jobObject))
            {
                _jobObjects.Remove(jobObject);
            }
        }
    }
}