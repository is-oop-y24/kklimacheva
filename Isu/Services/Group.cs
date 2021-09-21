using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class Group
    {
        private GroupName _groupName;
        private List<Student> _students = new List<Student>();

        public Group(GroupName groupName)
        {
            _groupName = groupName;
        }

        public string Name => _groupName.Name;

        public int CourseNumber => _groupName.CourseNumber.GetNumber();

        public List<Student> Students
        {
            get { return _students; }
        }

        public bool IsFull()
        {
            return _students.Count == Consts.MaxStudentsPerGroup;
        }

        public void AddStudent(Student student)
        {
            if (IsFull())
            {
                throw new IsuException("Group is full. Unable to add new student.");
            }

            _students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            _students.Remove(student);
        }
    }
}