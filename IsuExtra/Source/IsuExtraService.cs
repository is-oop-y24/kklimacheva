using System.Collections.Generic;
using System.Linq;
using Isu.Services;
using IsuExtra.Source;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class IsuExtraService : IIsuExtraService
    {
        private readonly List<ElectiveCourse> _courses = new List<ElectiveCourse>();
        private readonly List<GroupExtra> _groups = new List<GroupExtra>();

        public ElectiveCourse AddNewCourse(string name, char megafaculty)
        {
            var newCourse = new ElectiveCourse(name, megafaculty);
            _courses.Add(newCourse);
            return newCourse;
        }

        public GroupExtra AddNewGroup(Group group, Schedule schedule)
        {
            var newExtraGroup = new GroupExtra(group, schedule);
            _groups.Add(newExtraGroup);
            return newExtraGroup;
        }

        public void AddStudentToGroup(Student student, GroupExtra group)
        {
            group.AddStudent(student);
        }

        public void AddStudentToCourse(Student student, ElectiveCourse course)
        {
            if (course.Megafaculty() == student.GroupName[Consts.LetterPos])
            {
                throw new ElectiveCourseException("Can't add student to the course of his megafaculty.");
            }

            int count = StudentElectiveCoursesNumber(student);

            if (count == ConstsExtra.MaxElectiveCoursesPerStudent)
            {
                throw new ElectiveCourseException(
                    "Can't add student to this elective course.Reached max amount of courses per student.");
            }

            Schedule studentSchedule = _groups.Where(group => group.GroupInstance().GetStudents().Contains(student)).Select(group => group.Schedule()).FirstOrDefault();

            Stream stream1 = null;
            foreach (Stream stream in course.Streams())
            {
                if (stream.Schedule().HasLessonCoincidence(studentSchedule)) continue;
                stream.AddStudent(student);
                stream1 = stream;
            }

            if (stream1 == null)
            {
                throw new ElectiveCourseException("Can't add student to this course. Has schedule intersection");
            }
        }

        public void RemoveStudentFromCourse(Student student, ElectiveCourse course)
        {
            foreach (Stream stream in course.Streams())
            {
                if (!stream.Students().Contains(student))
                {
                    continue;
                }

                stream.RemoveStudent(student);
            }
        }

        public IReadOnlyList<Stream> GetElectiveCourseStreams(ElectiveCourse course)
        {
            if (!_courses.Contains(course))
            {
                throw new ElectiveCourseExistenceException("No such elective course in ITMO.");
            }

            return course.Streams();
        }

        public List<Student> GetElectiveCourseStudents(ElectiveCourse course)
        {
            var students = new List<Student>();
            foreach (Stream stream in course.Streams())
            {
                students.AddRange(stream.Students());
            }

            return students;
        }

        public List<Student> GetStudentsWithoutCourse(GroupExtra group)
        {
            return (from student in @group.GroupInstance().GetStudents()
                from course in _courses
                from stream in course.Streams()
                where !stream.Students().Contains(student)
                select student).ToList();
        }

        private int StudentElectiveCoursesNumber(Student student)
        {
            return _courses.SelectMany(course => course.Streams()).Count(stream => stream.Students().Contains(student));
        }
    }
}