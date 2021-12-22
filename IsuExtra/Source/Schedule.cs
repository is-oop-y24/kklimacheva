using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class Schedule
    {
        private Dictionary<Weekday, List<Lesson>> _schedule = new Dictionary<Weekday, List<Lesson>>();

        public Schedule() { }

        public void AddLesson(Weekday weekday, Lesson lesson)
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
            Array weekdays = Enum.GetValues(typeof(Weekday));
            return (from Weekday day in weekdays
                where _schedule.ContainsKey(day) && other.GetSchedule().ContainsKey(day)
                from lesson in _schedule[day]
                from lesson1 in other._schedule[day]
                where lesson.Number == lesson1.Number
                select lesson).Any();
        }

        public void RemoveLesson(Weekday weekday, Lesson lesson)
        {
            if (!_schedule.ContainsKey(weekday))
            {
                throw new ScheduleException("There are no classes on this day.");
            }
            else
            {
                _schedule[weekday].Remove(lesson);
            }
        }

        public Dictionary<Weekday, List<Lesson>> GetSchedule()
        {
            return _schedule;
        }
    }
}