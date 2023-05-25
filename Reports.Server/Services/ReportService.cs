using System.Collections.Generic;
using Reports.DAL.Entities;
using Task = Reports.DAL.Entities.Task;

namespace Reports.Server.Services
{
    public class ReportService : IReportService
    {
        private EmployeeService _employeeService;
        private TaskService _taskService;
        private Repository _repository;

        public ReportService()
        {
            _employeeService = new EmployeeService();
            _taskService = new TaskService();
        }

        public List<Task> GetWeeklyTask()
        {
            return _taskService.FindTasksForPeriod(7);
        }
        

        public void AddTaskToReport(Report report, Task task)
        {
            report.AddTask(task);
        }

        public void CloseReport(Report report)
        {
            report.CloseReport();
        }
        

        public TaskService GetTaskService()
        {
            return _taskService;
        }
        public EmployeeService GetEmployeeService()
        {
            return _employeeService;
        }

        public void SetServices(EmployeeService employeeService, TaskService taskService)
        {
            _employeeService = employeeService;
            _taskService = taskService;
        }
    }
}