using System;
using System.IO;

namespace BackupsExtra
{
    public class FileLogger : ILogger
    {
        public FileLogger(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public void Log(string message, bool timeNeeded)
        {
            using var writer = new StreamWriter(Path, true);
            writer.WriteLine(timeNeeded ? DateTime.Now + " - " + message : message);
        }
    }
}