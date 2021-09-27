namespace Isu.Services
{
    public class Student
    {
        public Student(string groupName, string name)
        {
            GroupName = groupName;
            Name = name;
            Id = IdGenerator.GetInstance();
        }

        public string Name { get; }

        public string GroupName { get; set; }

        public IdGenerator Id { get; }

        public int GetId()
        {
            return Id.StudentId;
        }
    }
}