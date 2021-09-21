namespace Isu.Services
{
    public class Student
    {
        private readonly int _id;
        private readonly string _name;
        private string _studentGroup;

        public Student(string groupName, string name)
        {
            _studentGroup = groupName;
            _name = name;
            _id = new IdGenerator().GetId();
        }

        public string Name
        {
            get => _name;
        }

        public string GroupName
        {
            get => _studentGroup;
            set => _studentGroup = value;
        }

        public int Id
        {
            get => _id;
        }
    }
}