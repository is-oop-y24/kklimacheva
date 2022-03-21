using System.Collections.Generic;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupsTests
    {
        private RuntimeRepository _newRepo;
        
        [SetUp]
        public void Setup()
        {
            _newRepo = new RuntimeRepository("repoPath");
        }

        [Test]
        public void Test_1()
        {
            var obj1 = new JobObject("C:\\Users\\kklimacheva\\FilesToAdd\\a.txt");
            var obj2 = new JobObject("C:\\Users\\kklimacheva\\FilesToAdd\\b.txt");
            List<JobObject> objects = new List<JobObject>();
            objects.Add(obj1);
            objects.Add(obj2);
            IStorageAlgorithm type = new SplitStorage(_newRepo);
            var newJob = new BackupJob("job1", objects);
            var manager = new BackupManager(newJob, type, _newRepo);
            manager.StartBackup();
            manager.RemoveObject(obj1);
            manager.StartBackup();
            Assert.AreEqual(2, newJob.Points().Count);
            Assert.AreEqual(3, _newRepo.Storages().Count);
        }
    }
}