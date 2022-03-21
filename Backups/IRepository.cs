namespace Backups
{
    public interface IRepository
    {
        public string RepositoryPath { get; }
        public string InitStorage();
        public string MakeZip(string storagePath, string fileToZip);
    }
}