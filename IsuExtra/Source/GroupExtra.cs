using Isu.Services;
using IsuExtra.Source;

namespace IsuExtra
{
    public class GroupExtra
    {
        private readonly Schedule _schedule;
        private Group _group;

        public GroupExtra(Group group, Schedule schedule)
        {
            _group = group;
            _schedule = schedule;
        }

        public Group GroupInstance()
        {
            return _group;
        }

        public void AddStudent(Student student)
        {
            _group.AddStudent(student);
        }

        public Schedule Schedule()
        {
            return _schedule;
        }
    }
}