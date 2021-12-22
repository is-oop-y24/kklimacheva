namespace IsuExtra
{
    public class Lesson
    {
        public Lesson(string name, int number, int classroomNumber, Teacher teacher)
        {
            Name = name;
            Number = number;
            ClassroomNumber = classroomNumber;
            Teacher = teacher;
        }

        public int Number { get; }
        public Teacher Teacher { get; }
        public int ClassroomNumber { get; }
        public string Name { get; }
    }
}