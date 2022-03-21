using System.Collections.Generic;
using Backups;
using NUnit.Framework;

namespace BackupsExtra.Tests
{
    public class BackupsExtraTests
    {
        
        private RuntimeRepository _newRepo;
        
        [SetUp]
        public void Setup()
        {
            _newRepo = new RuntimeRepository("repoPath");
        }
        
        [Test]
        public void PointsSuccessfullyDeleted()
        {
            var obj1 = new JobObject("C:\\Users\\kklimacheva\\FilesToAdd\\a.txt");
            var obj2 = new JobObject("C:\\Users\\kklimacheva\\FilesToAdd\\b.txt");
            var objects = new List<JobObject>();
            objects.Add(obj1);
            objects.Add(obj2);
            IStorageAlgorithm type = new SplitStorage(_newRepo);
            var newJob = new BackupJob("job1", objects);
            var manager = new BackupsExtraManager(newJob, _newRepo, type);
            for (int i = 0; i < 6; ++i)
            {
                manager.StartBackup();
            }

            var points = manager.BackupManagerInstance().JobInstance().Points().Count;
            var remover = new RemoveByAmount(3);
            manager.AddRemover(remover);
            manager.StartBackup();
            var pointsNow = manager.BackupManagerInstance().JobInstance().Points().Count;
            Assert.AreNotEqual(points, pointsNow);
        }
    }
}