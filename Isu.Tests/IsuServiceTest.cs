using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            string groupName = "M3204";
            Group newGroup = _isuService.AddGroup(groupName);
            Student newStudent = _isuService.AddStudent(newGroup, "Kate Klimacheva");
            if (newStudent.GroupName != groupName && newGroup.GetStudents().IndexOf(newStudent) == -1)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group newGroup = _isuService.AddGroup("M3204");
                Student newStudent = _isuService.AddStudent(newGroup, "Kate Klimacheva");
                for (int i = 0; i < Consts.MaxStudentsPerGroup; ++i)
                {
                    newGroup.AddStudent(newStudent);
                }
                newGroup.AddStudent(newStudent);
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                _isuService.AddStudent(_isuService.AddGroup("N3204"), "Kate Klimacheva");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group currentStudentGroup = _isuService.AddGroup("M3204");
                Student newStudent = _isuService.AddStudent(currentStudentGroup, "Kate Klimacheva");
                Group newGroup = _isuService.AddGroup("M3205");
                for (int i = 0; i < Consts.MaxStudentsPerGroup; ++i)
                {
                    newGroup.AddStudent(newStudent);
                }
                _isuService.ChangeStudentGroup(newStudent, newGroup);
            });
        }
    }
}