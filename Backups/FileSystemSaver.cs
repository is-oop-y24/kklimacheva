using System.IO;
using System.IO.Compression;

namespace Backups
{
    public class FileSystemSaver : IStorageType
    {
        public string AddFolderToZip(string zipPath, string fileToZip, string name)
        {
            string name1 = Path.GetFileNameWithoutExtension(fileToZip) + "_" + name + Path.GetExtension(fileToZip);
            using ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update);
            archive.CreateEntryFromFile(fileToZip, name1);
            string newFilePath = zipPath + "\\" + name1;
            return newFilePath;
        }

        public string InitStorage(string repositoryPath, string name)
        {
            string outputFile = repositoryPath + "\\" + name + ".zip";
            using ZipArchive archive = ZipFile.Open(outputFile, ZipArchiveMode.Create);
            return outputFile;
        }
    }
}