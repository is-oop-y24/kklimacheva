using System;
using System.Collections.Generic;

namespace Reports.DAL.Entities
{
    public class Employee
    {
        public Guid DirectorId { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
        
        public List<Task> Tasks { get; set; }

        public Employee()
        {
        }
        
        public Employee(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }
    }
}