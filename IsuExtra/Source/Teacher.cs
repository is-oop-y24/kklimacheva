using Isu.Services;

namespace IsuExtra
{
    public class Teacher
    {
        public Teacher(string name)
        {
            Name = name;
            Id = IdGenerator.GetInstance().CreateStudentId();
        }

        public string Name { get; }
        public int Id { get; }
    }
}