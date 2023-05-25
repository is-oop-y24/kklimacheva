using System;
using System.IO;
using Backups;

namespace BackupsExtra
{
    public class FileRestorer : IRestorer
    {
        public void RestoreToOriginLocation(BackupJobExtra job, RestorePoint point)
        {
            foreach (string pointFile in point.FilesList())
            {
                foreach (string jobFile in job.BackupJob().Objects())
                {
                    if (!Path.GetFileName(jobFile).Equals(GetOriginalFileName(pointFile))) continue;
                    File.Delete(jobFile);
                    File.Move(pointFile, Path.GetDirectoryName(jobFile));
                }
            }
        }

        public void RestoreToNewLocation(string path, RestorePoint point)
        {
            foreach (string filePath in point.FilesList())
            {
                File.Move(filePath, path, true);
            }
        }

        private static string GetOriginalFileName(string path)
        {
            string filename = Path.GetFileNameWithoutExtension(path);
            int index = filename.LastIndexOf("_", StringComparison.Ordinal);
            return filename[..index];
        }
    }
}