using System.IO;
using Backups;

namespace BackupsExtra
{
    public class Recover
    {
        public Recover(string path)
        {
            RecoverPath = path;
        }

        public string RecoverPath { get; }

        public void RestoreFiles(string sourcePath, string destinationPath, RestorePoint point)
        {
            foreach (string filename in point.Files())
            {
                string sourceFile = sourcePath + filename;
                File.Move(sourceFile, destinationPath);
                File.Delete(sourceFile);
            }
        }
    }
}