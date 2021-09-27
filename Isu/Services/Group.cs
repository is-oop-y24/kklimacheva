using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class Group
    {
        private readonly GroupName _groupName;

        public Group(GroupName groupName)
        {
            _groupName = groupName;
        }

        public string Name => _groupName.Name;

        public int CourseNumber => _groupName.CourseNumber.GetNumber();

        public List<Student> Students { get; } = new List<Student>();

        public bool IsFull()
        {
            return Students.Count == Consts.MaxStudentsPerGroup;
        }

        public void AddStudent(Student student)
        {
            if (IsFull())
            {
                throw new IsuException("Group is full. Unable to add new student.");
            }

            Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
    }
}