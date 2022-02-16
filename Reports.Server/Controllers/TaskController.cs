using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;
using Task = Reports.DAL.Entities.Task;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/tasks")]
    public class TaskController : ControllerBase
    {
        private const string PathToStorageTask = "./tasks.json";
        private ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }


        [HttpPut]
        [Route("/Change-State")]
        public Task ChangeState([FromQuery] Guid id, [FromQuery] TaskState newState)
        {
            DeserializeTasks();
            _service.ChangeTaskState(_service.FindById(id), newState);
            SerializeTasks();
            return _service.FindById(id);
        }

        [HttpPut]
        [Route("/Change-Employee")]
        public Task ChangeEmployee([FromQuery] Guid taskId, [FromQuery] Guid employeeId)
        {
            DeserializeTasks();
            _service.ChangeEmployee(_service.FindById(taskId), employeeId);
            SerializeTasks();
            return _service.FindById(taskId);
        }

        [HttpGet]
        [Route("/Get-All-Tasks")]
        public IActionResult GetAllTask()
        {
            DeserializeTasks();
            List<Task> result = _service.GetAllTasks();
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("/Get-Task-By-Id")]
        public IActionResult GetTaskById([FromQuery] Guid taskId)
        {
            DeserializeTasks();
            Task result = _service.FindById(taskId);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("/Get-Task-By-Date-Creation")]
        public IActionResult GetTaskByDateCreation([FromQuery] DateTime dateTimeCreation)
        {
            DeserializeTasks();
            Task result = _service.FindByDateCreation(dateTimeCreation);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("/Get-Task-By-Date-Changes")]
        public IActionResult GetTaskByDateChanges([FromQuery] DateTime dateTimeChanges)
        {
            DeserializeTasks();
            Task result = _service.FindByDateLastChanges(dateTimeChanges);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("/Get-Task-With-Changes")]
        public IActionResult GetTaskWithChanges()
        {
            DeserializeTasks();
            List<Task> result = _service.FindTaskWithChanges();
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
        

        private void SerializeTasks()
        {
            _service.SerializeTasks(PathToStorageTask);
        }

        private void DeserializeTasks()
        {
            _service.DeserializeTasks(PathToStorageTask);
        }
    }
}