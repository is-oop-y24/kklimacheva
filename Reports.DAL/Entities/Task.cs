using System;
using System.Collections.Generic;

namespace Reports.DAL.Entities
{
    public class Task
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public List<TaskChanges> Changes { get; set; }

        public DateTime CreationData { get; set; }

        public DateTime LastDateChanges { get; set; }

        public TaskState State { get; set; }

        public Task() { }
        
        public Task(Employee employee)
        {
            CreationData = DateTime.Today;
            State = TaskState.Open;
            Id = Guid.NewGuid();
            EmployeeId = employee.Id;
            Changes = new List<TaskChanges>();
        }

        public void ChangeEmployee(Guid id)
        {
            EmployeeId = id;
            LastDateChanges = DateTime.Now;
        }

        public Task ChangeState(TaskState state)
        {
            State = state;
            LastDateChanges = DateTime.Now;
            return this;
        }
    }
}