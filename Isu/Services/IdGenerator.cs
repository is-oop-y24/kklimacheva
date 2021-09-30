namespace Isu.Services
{
    public class IdGenerator
    {
        private static IdGenerator _instance;
        private IdGenerator() { }
        public int StudentId { get; set; } = 100000;
        public static IdGenerator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new IdGenerator();
            }

            return _instance;
        }

        public int CreateStudentId()
        {
            return _instance.StudentId++;
        }
    }
}