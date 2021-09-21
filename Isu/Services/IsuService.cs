using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService :
        IIsuService
    {
        private readonly List<Group> _isu = new List<Group>();

        public Student AddStudent(Group group, string name)
        {
            var newStudent = new Student(group.Name, name);
            GetGroupFromIsu(group).AddStudent(newStudent);
            return newStudent;
        }

        public Student GetStudent(int id)
        {
            foreach (Group group in _isu)
            {
                foreach (Student student in group.Students)
                {
                    if (student.Id == id)
                    {
                        return student;
                    }
                }
            }

            throw new IsuException("No such student ID.");
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            foreach (Group group in _isu)
            {
                if (group.Name == groupName.Name)
                {
                    return group.Students;
                }
            }

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var students = new List<Student>();
            foreach (Group group in _isu)
            {
                if (group.CourseNumber == courseNumber.GetNumber())
                {
                    students.AddRange(group.Students);
                }
            }

            return students;
        }

        public Student FindStudent(string name)
        {
            foreach (Group group in _isu)
            {
                foreach (Student student in group.Students)
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
            _isu.Add(newGroup);
            return newGroup;
        }

        public Group FindGroup(GroupName groupName)
        {
            foreach (Group group in _isu)
            {
                if (group.Name == groupName.Name)
                {
                    return group;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var groups = new List<Group>();
            foreach (Group group in _isu)
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

            foreach (Group group in _isu)
            {
                if (group.Name == student.GroupName)
                {
                    group.RemoveStudent(student);
                }
                else if (group.Name == newGroup.Name)
                {
                    group.AddStudent(student);
                }
            }

            student.GroupName = newGroup.Name;
        }

        private Group GetGroupFromIsu(Group group)
        {
            return _isu[_isu.IndexOf(group)];
        }
    }
}