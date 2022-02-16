using System.Collections.Generic;
using System.IO;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            const string repositoryPath = "C:\\Users\\kklimacheva\\Desktop\\TestFolder";
            var repo = new Repository(repositoryPath);
            Directory.CreateDirectory(repositoryPath);
            var paths = new List<string>()
            {
                "C:\\Users\\kklimacheva\\Desktop\\Source\\Test_1.txt",
                "C:\\Users\\kklimacheva\\Desktop\\Source\\Test_2.txt",
            };
            IStorageAlgorithmType algo = new SplitStorageAlgorithm(new FileSystemSaver());
            var newJob = new BackupJob("Job", algo, paths);
            newJob.StartJob(repo);
        }
    }
}
