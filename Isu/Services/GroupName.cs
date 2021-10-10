using System;
using Isu.Tools;

namespace Isu.Services
{
    public class GroupName : IEquatable<GroupName>
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
                throw new CourseNumberException("Invalid course number. Unable to convert string to int.");
            }
        }

        public string Name { get; }
        public CourseNumber CourseNumber { get; }

        public bool Equals(GroupName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((GroupName)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, CourseNumber);
        }

        private static void IsCorrect(string groupName)
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