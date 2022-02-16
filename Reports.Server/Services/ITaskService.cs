using System;
using System.Collections.Generic;
using Reports.DAL.Entities;
using Task = Reports.DAL.Entities.Task;

namespace Reports.Server.Services
{
    public interface ITaskService
    {
        Task FindById(Guid id);
        List<Task> GetAllTasks();
        Task FindByDateCreation(DateTime days);
        Task FindByDateLastChanges(DateTime days);
        Task FindByEmployee(Employee employee);
        List<Task> FindTaskWithChanges();
        Task CreateTask(Employee employee);
        Task ChangeTaskState(Task task, TaskState state);
        Task ChangeEmployee(Task task, Guid id);
        void DeserializeTasks(string pathToJson);
        void SerializeTasks(string pathToJson);
    }
}