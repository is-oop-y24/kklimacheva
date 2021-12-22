using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public interface IIsuExtraService
    {
        ElectiveCourse AddNewCourse(string name, char megafaculty);
        GroupExtra AddNewGroup(Group group, Schedule schedule);
        void AddStudentToGroup(Student student, GroupExtra group);
        void AddStudentToCourse(Student student, ElectiveCourse course);
        void RemoveStudentFromCourse(Student student, ElectiveCourse course);
        IReadOnlyList<Stream> GetElectiveCourseStreams(ElectiveCourse course);
        List<Student> GetElectiveCourseStudents(ElectiveCourse course);
        List<Student> GetStudentsWithoutCourse(GroupExtra group);
    }
}