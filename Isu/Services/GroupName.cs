using System;
using Isu.Tools;

namespace Isu.Services
{
    public class GroupName
    {
        public GroupName(string groupName)
        {
            IsCorrect(groupName);
            Name = groupName;
            try
            {
                CourseNumber = new CourseNumber(Convert.ToInt32(groupName.Substring(Consts.CourseNumberPos, 1)));
            }
            catch (Exception)
            {
                throw new CourseNumberException("Invalid course number.");
            }
        }

        public string Name { get; }
        public CourseNumber CourseNumber { get; }

        private void IsCorrect(string groupName)
        {
            if (!(groupName[Consts.LetterPos] == Consts.Letter
                && groupName[Consts.DirectionNumPos] == Consts.DirectionNum
                && groupName.Length == Consts.GroupNameLength))
            {
                throw new GroupNameException("Isn't correct group name");
            }
        }
    }
}