namespace Isu.Services
{
    public class Student
    {
        private readonly int _id;
        public Student(string groupName, string name)
        {
            GroupName = groupName;
            Name = name;
            _id = IdGenerator.GetInstance().CreateStudentId();
        }

        public string Name { get; }

        public string GroupName { get; set; }

        public int GetId()
        {
            return _id;
        }
    }
}