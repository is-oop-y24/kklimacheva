using System.Collections.Generic;
using Isu.Services;
using IsuExtra.Source;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class Stream
    {
        private readonly Schedule _streamSchedule;
        private readonly List<Student> _students = new List<Student>();

        public Stream(Schedule schedule)
        {
            _streamSchedule = schedule;
        }

        public IReadOnlyList<Student> Students()
        {
            return _students;
        }

        public void AddStudent(Student student)
        {
            if (IsFull())
            {
                throw new StreamException("Can't add student. Stream is full.");
            }

            _students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            _students.Remove(student);
        }

        public Schedule Schedule()
        {
            return _streamSchedule;
        }

        public bool IsFull()
        {
            return _students.Count == ConstsExtra.MaxStudentsPerStream;
        }
    }
}