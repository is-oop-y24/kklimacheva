namespace Backups
{
    public interface IStorageType
    {
        string AddFolderToZip(string zipPath, string fileToZip, string name);
        string InitStorage(string outputPath, string name);
    }
}