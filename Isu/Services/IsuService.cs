using System.Collections.Generic;
using System.Collections.ObjectModel;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService :
        IIsuService
    {
        private readonly List<Group> _listOfGroups = new List<Group>();

        public Student AddStudent(Group group, string name)
        {
            var newStudent = new Student(group.Name.Name, name);
            GetGroupFromIsu(group).AddStudent(newStudent);
            return newStudent;
        }

        public Student GetStudent(int id)
        {
            foreach (Group group in _listOfGroups)
            {
                foreach (Student student in group.GetStudents())
                {
                    if (student.GetId() == id)
                    {
                        return student;
                    }
                }
            }

            throw new IsuException("No such student ID.");
        }

        public ReadOnlyCollection<Student> FindStudents(GroupName groupName)
        {
            foreach (Group group in _listOfGroups)
            {
                if (group.Name.Equals(groupName))
                {
                    return group.GetStudents();
                }
            }

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var students = new List<Student>();
            foreach (Group group in _listOfGroups)
            {
                if (group.CourseNumber == courseNumber.GetNumber())
                {
                    students.AddRange(group.GetStudents());
                }
            }

            return students;
        }

        public Student FindStudent(string name)
        {
            foreach (Group group in _listOfGroups)
            {
                foreach (Student student in group.GetStudents())
                {
                    if (student.Name == name)
                    {
                        return student;
                    }
                }
            }

            return null;
        }

        public Group AddGroup(string name)
        {
            var newGroup = new Group(new GroupName(name));
            _listOfGroups.Add(newGroup);
            return newGroup;
        }

        public Group FindGroup(GroupName groupName)
        {
            foreach (Group group in _listOfGroups)
            {
                if (group.Name.Equals(groupName))
                {
                    return group;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var groups = new List<Group>();
            foreach (Group group in _listOfGroups)
            {
                if (group.CourseNumber == courseNumber.GetNumber())
                {
                    groups.Add(group);
                }
            }

            return groups;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            if (GetGroupFromIsu(newGroup).IsFull())
            {
                throw new IsuException("Error, group is full!");
            }

            foreach (Group group in _listOfGroups)
            {
                if (group.Name.Name == student.GroupName)
                {
                    group.RemoveStudent(student);
                }
                else if (group.Name.Equals(newGroup.Name))
                {
                    group.AddStudent(student);
                }
            }

            student.GroupName = newGroup.Name.Name;
        }

        private Group GetGroupFromIsu(Group group)
        {
            if (_listOfGroups.IndexOf(group) == -1)
            {
                throw new GroupOutOfRange("Group doesn't exist.");
            }

            return _listOfGroups[_listOfGroups.IndexOf(group)];
        }
    }
}