using System.Collections.Generic;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            const string repositoryPath = "C:\\Users\\kklimacheva\\Repository";
            LocalRepository rep = new LocalRepository(repositoryPath);
            var obj1 = new JobObject("C:\\Users\\kklimacheva\\FilesToAdd\\a.txt");
            var obj2 = new JobObject("C:\\Users\\kklimacheva\\FilesToAdd\\b.txt");
            List<JobObject> objects = new List<JobObject>();
            objects.Add(obj1);
            objects.Add(obj2);
            IStorageAlgorithm type = new SplitStorage(rep);
            var newJob = new BackupJob("job1", objects);
            var manager = new BackupManager(newJob, type, rep);
            manager.StartBackup();
        }
    }
}