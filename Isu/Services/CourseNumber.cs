using Isu.Tools;

namespace Isu.Services
{
    public class CourseNumber
    {
        private int _number;
        public CourseNumber(int courseNumber)
        {
            if (courseNumber < Consts.MinCourseNumber || courseNumber > Consts.MaxCourseNumber)
            {
                throw new IsuException("Invalid course number");
            }

            _number = courseNumber;
        }

        public int GetNumber()
        {
            return _number;
        }
    }
}