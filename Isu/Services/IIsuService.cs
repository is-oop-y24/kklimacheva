﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Isu.Services
{
    public interface IIsuService
    {
        Group AddGroup(string name);
        Student AddStudent(Group group, string name);
        Student GetStudent(int id);
        Student FindStudent(string name);
        ReadOnlyCollection<Student> FindStudents(GroupName groupName);
        List<Student> FindStudents(CourseNumber courseNumber);
        Group FindGroup(GroupName groupName);
        List<Group> FindGroups(CourseNumber courseNumber);
        void ChangeStudentGroup(Student student, Group newGroup);
    }
}