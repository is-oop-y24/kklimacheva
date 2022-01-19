using System;
using System.Collections.Generic;
using System.Linq;
using IsuExtra.Tools;

namespace IsuExtra.Source
{
    public class Schedule
    {
        private Dictionary<DayOfWeek, List<Lesson>> _schedule = new Dictionary<DayOfWeek, List<Lesson>>();

        public Schedule() { }

        public void AddLesson(DayOfWeek weekday, Lesson lesson)
        {
            if (!_schedule.ContainsKey(weekday))
            {
                _schedule.Add(weekday, new List<Lesson>());
            }
            else if (_schedule[weekday].Any(lesson1 => lesson1.Number == lesson.Number))
            {
                throw new ScheduleException("Can't add lesson to schedule.");
            }

            _schedule[weekday].Add(lesson);
        }

        public bool HasLessonCoincidence(Schedule other)
        {
            Array weekdays = Enum.GetValues(typeof(DayOfWeek));
            return (from DayOfWeek day in weekdays
                where _schedule.ContainsKey(day) && other.GetSchedule().ContainsKey(day)
                from lesson in _schedule[day]
                from lesson1 in other._schedule[day]
                where lesson.Number == lesson1.Number
                select lesson).Any();
        }

        public void RemoveLesson(DayOfWeek weekday, Lesson lesson)
        {
            if (!_schedule.ContainsKey(weekday))
            {
                throw new ScheduleException("There are no classes on this day.");
            }

            _schedule[weekday].Remove(lesson);
        }

        public Dictionary<DayOfWeek, List<Lesson>> GetSchedule()
        {
            return _schedule;
        }
    }
}