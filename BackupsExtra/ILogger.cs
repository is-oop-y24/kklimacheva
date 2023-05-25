namespace BackupsExtra
{
    public interface ILogger
    {
        void Log(string message, bool timeNeeded);
    }
}