using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/employees")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        

        [HttpPost]
        [Route("/Create-Employee")]
        public Employee CreateEmployee([FromQuery] string nameTeamLead, [FromQuery] Guid idTeamLead,
            [FromQuery] string nameDirector, [FromQuery] Guid idDirector,
            [FromQuery] string name)
        {
            if (!string.IsNullOrWhiteSpace(nameTeamLead))
            {
                Employee result = _service.FindByName(nameTeamLead);
                if (result == null)
                {
                    throw new ReportServerException("TeamLead hasn't been founded");
                }
            }

            if (idTeamLead != Guid.Empty)
            {
                Employee result = _service.FindById(idTeamLead);
                if (result == null)
                {
                    throw new ReportServerException("TeamLead hasn't been founded");
                }
            }

            if (!string.IsNullOrWhiteSpace(nameDirector))
            {
                Employee result = _service.FindByName(nameDirector);
                if (result == null)
                {
                    throw new ReportServerException("Director hasn't been founded");
                }
            }

            if (idDirector != Guid.Empty)
            {
                Employee result = _service.FindById(idDirector);
                if (result == null)
                {
                    throw new ReportServerException("Director hasn't been founded");
                }

                throw new ReportServerException("This person isn't director");
            }

            throw new Exception("Can't create new Employee");
        }

        [HttpPut]
        [Route("/Update-Employee")]
        public void Update([FromQuery] string nameEmployee, [FromQuery] Guid idEmployee, [FromQuery] Guid idDirector)
        {
            if (idEmployee != Guid.Empty)
            {
                _service.Update(_service.FindById(idEmployee), idDirector);
            }

            if (nameEmployee != null)
            {
                _service.Update(_service.FindByName(nameEmployee), idDirector);
            }
        }

        [HttpDelete]
        [Route("/Delete-Employee")]
        public void Delete([FromQuery] Guid id)
        {
            _service.Delete(id);
        }

        [HttpGet]
        [Route("/Get-Employee")]
        public IActionResult Find([FromQuery] string name, [FromQuery] Guid id)
        {
            if (!string.IsNullOrWhiteSpace(name))
            { 
                Employee result = _service.FindByName(name);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }

            if (id != Guid.Empty)
            {
                Employee result = _service.FindById(id);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }

            return StatusCode((int) HttpStatusCode.BadRequest);
        }
    }
}