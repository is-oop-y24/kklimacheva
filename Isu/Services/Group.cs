using System.Collections.Generic;
using System.Collections.ObjectModel;
using Isu.Tools;

namespace Isu.Services
{
    public class Group
    {
        private readonly GroupName _groupName;
        private List<Student> _students = new List<Student>();

        public Group(GroupName groupName)
        {
            _groupName = groupName;
        }

        public GroupName Name => _groupName;

        public int CourseNumber => _groupName.CourseNumber.GetNumber();

        public bool IsFull()
        {
            return _students.Count == Consts.MaxStudentsPerGroup;
        }

        public ReadOnlyCollection<Student> GetStudents()
        {
            return _students.AsReadOnly();
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