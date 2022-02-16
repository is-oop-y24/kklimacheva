using System.Collections.Generic;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupsTests
    {
        private Repository _newRepo;
        [SetUp]
        public void Setup()
        {
            _newRepo = new Repository("repoPath");
        }

        [Test]
        public void InitialTest()
        {
            var paths = new List<string>()
            {
                "enterYourPath1",
                "enterYourPath2",
            };
            IStorageAlgorithmType newAlgo = new SplitStorageAlgorithm(new VirtualStorageSaver());
            var job = new BackupJob("job", newAlgo, paths);
            job.StartJob(_newRepo);
            job.RemoveObject(paths[1]);
            job.StartJob(_newRepo);
            if (job.Points().Count != 2 || _newRepo.Storages().Count != 3)
            {
                Assert.Fail();
            }
        }
    }
}