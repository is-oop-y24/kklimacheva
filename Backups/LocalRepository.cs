using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups
{
    public class LocalRepository : IRepository
    {
        public LocalRepository(string repositoryPath)
        {
            RepositoryPath = repositoryPath;
        }

        public string RepositoryPath { get; }

        public List<string> Save(string outputPath, List<string> files)
        {
            var restorePointFiles = new List<string>();
            string resultFile = outputPath + "\\" + Guid.NewGuid() + ".zip";
            using ZipArchive archive = ZipFile.Open(resultFile, ZipArchiveMode.Create);
            foreach (string fileToZip in files)
            {
                string name = Guid.NewGuid() + Path.GetExtension(fileToZip);
                archive.CreateEntryFromFile(fileToZip, name);
                restorePointFiles.Add(resultFile + "\\" + name);
            }

            return restorePointFiles;
        }

        public string InitStorage()
        {
            string storagePath = RepositoryPath + "\\" + Guid.NewGuid() + ".zip";
            using ZipArchive archive = ZipFile.Open(storagePath, ZipArchiveMode.Create);
            return storagePath;
        }

        public string MakeZip(string storagePath, string fileToZip)
        {
            string name = Guid.NewGuid() + Path.GetExtension(fileToZip);
            using ZipArchive archive = ZipFile.Open(storagePath, ZipArchiveMode.Update);
            archive.CreateEntryFromFile(fileToZip, name);
            return storagePath + "\\" + name;
        }
    }
}