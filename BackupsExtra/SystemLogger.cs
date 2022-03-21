using System;
using System.IO;

namespace BackupsExtra
{
    public class SystemLogger : ILogger
    {
        public SystemLogger(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public void Log(string message)
        {
            File.AppendAllText(Path, DateTime.Now + " " + message);
        }
    }
}