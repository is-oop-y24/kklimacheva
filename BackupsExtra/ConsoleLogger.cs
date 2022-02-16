using System;

namespace BackupsExtra
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger() { }

        public void Log(string message, bool timeNeeded)
        {
            Console.WriteLine(timeNeeded ? DateTime.Now + " - " + message : message);
        }
    }
}