using System.Collections.Generic;
using Reports.DAL.Entities;
using Task = Reports.DAL.Entities.Task;

namespace Reports.Server.Services
{
    public interface IReportService
    {
        TaskService GetTaskService();
        List<Task> GetWeeklyTask();
        void AddTaskToReport(Report report, Task task);
        void CloseReport(Report report);
        EmployeeService GetEmployeeService();
        void SetServices(EmployeeService employeeService, TaskService taskService);
    }
}