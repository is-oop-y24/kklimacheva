using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;
using Task = Reports.DAL.Entities.Task;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/reports")]
    public class ReportController : ControllerBase
    {
        private const string PathToStorageTask = "./tasks.json";
        private ITaskService _taskService = new TaskService();
        private IEmployeeService _employeeService = new EmployeeService();
        private IReportService _reportService;

        public ReportController(IReportService service)
        {
            _reportService = service;
        }


        [HttpGet]
        [Route("/Get-Weekly-Tasks")]
        public IActionResult GetWeeklyTasks()
        {
            DeserializeTasks();
            _reportService.SetServices((EmployeeService) _employeeService, (TaskService) _taskService);
            List<Task> result = _reportService.GetWeeklyTask();
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        private void DeserializeTasks()
        {
            _taskService.DeserializeTasks(PathToStorageTask);
        }
    }
}