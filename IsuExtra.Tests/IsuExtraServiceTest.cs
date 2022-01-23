using Isu.Services;
using IsuExtra.Source;
using IsuExtra.Tools;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class IsuExtraServiceTest
    {
        private IIsuExtraService _isuExtraService;

        [SetUp]
        public void Setup()
        {
            _isuExtraService = new IsuExtraService();
        }

        [Test]
        public void AddStudentToHisFacultyElectiveCourse_ThrowException()
        {
            Assert.Catch<IsuExtraException>(() =>
            {
                var student = new Student("M3204", "Kate Klimacheva");
                var newElective = new ElectiveCourse("Programming", 'M');
               _isuExtraService.AddStudentToCourse(student, newElective); 
            });
        }

        [Test]
        public void AddStudentToElectiveCourse_StudentAlreadyHasTwoCourses_ThrowException()
        {
            Assert.Catch<IsuExtraException>(() =>
            {
                var student = new Student("M3204", "Kate Klimacheva");
                var newGroup = new Group(new GroupName("M3204"));
                var newSchedule = new Schedule();
                var newLesson = new Lesson("English", 1, 3202, new Teacher("Josh O."));
                newSchedule.AddLesson(DayOfWeek.Friday, newLesson);
                var newExtraGroup = new GroupExtra(newGroup, newSchedule);
                newExtraGroup.AddStudent(student);
                ElectiveCourse newElective = _isuExtraService.AddNewCourse("Calculus", 'I');
                ElectiveCourse newElective1 = _isuExtraService.AddNewCourse("Robotics", 'Q');
                ElectiveCourse newElective2 = _isuExtraService.AddNewCourse("Painting", 'Z');
                newElective.AddStream(new Stream(new Schedule()));
                newElective1.AddStream(new Stream(new Schedule()));
                newElective2.AddStream(new Stream(new Schedule()));
                _isuExtraService.AddStudentToCourse(student, newElective);
                _isuExtraService.AddStudentToCourse(student, newElective1);
                _isuExtraService.AddStudentToCourse(student, newElective2);
            });
        }

        [Test]
        public void AddStudentToElectiveCourse_ScheduleHasIntersection_ThrowException()
        {
            Assert.Catch<IsuExtraException>(() =>
            {
                var student = new Student("M3204", "Kate Klimacheva");
                var newGroup = new Group(new GroupName("M3204"));
                var newSchedule = new Schedule();
                var newLesson1 = new Lesson("OOP", 1, 230, new Teacher("Alex B."));
                var newLesson2 = new Lesson("Maths", 2, 466, new Teacher("Anna V."));
                newSchedule.AddLesson(DayOfWeek.Friday, newLesson1);
                newSchedule.AddLesson(DayOfWeek.Monday, newLesson2);
                var courseSchedule = new Schedule();
                GroupExtra newExtraGroup = _isuExtraService.AddNewGroup(newGroup, newSchedule);
                _isuExtraService.AddStudentToGroup(student, newExtraGroup);
                var lesson3 = new Lesson("Linear algebra", 2, 348, new Teacher("Maria M."));
                courseSchedule.AddLesson(DayOfWeek.Monday, lesson3);
                ElectiveCourse newElective = _isuExtraService.AddNewCourse("Calculus", 'I');
                newElective.AddStream(new Stream(courseSchedule));
                _isuExtraService.AddStudentToCourse(student, newElective);
            });
        }
    }
}