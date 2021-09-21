namespace Isu.Services
{
    public class IdGenerator
    {
        private static int _studentId = 100000;

        public int GetId()
        {
            _studentId++;
            return _studentId;
        }
    }
}