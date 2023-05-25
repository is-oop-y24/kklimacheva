using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Reports.DAL.Entities;
using Task = Reports.DAL.Entities.Task;

namespace Reports.Server.Services
{
    public class TaskService : ITaskService
    {
        public List<Task> Tasks { get; set; }

        public TaskService()
        {
            Tasks = new List<Task>();
        }

        public List<Task> GetAllTasks()
        {
            return Tasks;
        }
        public Task FindById(Guid id)
        {
            return Tasks.FirstOrDefault(item => item.Id.Equals(id));
        }

        public Task FindByDateCreation(DateTime days)
        {
            return Tasks.FirstOrDefault(item => item.CreationData.Equals(days));
        }

        public Task FindByDateLastChanges(DateTime days)
        {
            return Tasks.FirstOrDefault(item => item.LastDateChanges.Equals(days));
        }

        public List<Task> FindTasksForPeriod(int days)
        {
            return Tasks.Where(item => DateTime.Now.Day < days + item.CreationData.Day).ToList();
        }

        public Task FindByEmployee(Employee employee)
        {
            return Tasks.FirstOrDefault(item => item.EmployeeId.Equals(employee.Id));
        }

        public List<Task> FindTaskWithChanges()
        {
            return Tasks.Where(item => item.Changes.Count != 0).ToList();
        }

        public Task CreateTask(Employee employee)
        {
            var newTask = new Task(employee);
            employee.AddTask(newTask);
            Tasks.Add(newTask);
            return newTask;
        }

        public Task ChangeTaskState(Task task, TaskState state)
        {
            return task.ChangeState(state);
        }

        public Task ChangeEmployee(Task task, Guid id)
        {
            task.ChangeEmployee(id);
            return task;
        }

        public void SerializeTasks(string pathToJson)
        {
            if (File.Exists(pathToJson))
            {
                File.Delete(pathToJson);
            }

            CheckNullPath(pathToJson);
            string output = JsonConvert.SerializeObject(Tasks, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });
            var fileStream = new FileStream(pathToJson, FileMode.Append);
            byte[] array = System.Text.Encoding.Default.GetBytes(output);
            fileStream.Write(array, 0, array.Length);
            fileStream.Dispose();
        }

        public void DeserializeTasks(string pathToJson)
        {
            if (!File.Exists(pathToJson))
            {
                return;
            }

            CheckNullPath(pathToJson);
            var streamReader = new StreamReader(pathToJson);
            string text = streamReader.ReadToEnd();
            streamReader.Dispose();
            List<Task> newTaskService = JsonConvert.DeserializeObject<List<Task>>(text,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,
                });

            Tasks = newTaskService;
        }

        private static void CheckNullPath(string path)
        {
            if (path == null)
            {
                throw new ReportServerException("Path cannot be null");
            }
        }
    }
}