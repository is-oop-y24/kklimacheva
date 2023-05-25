using System;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {

        public Repository NewRepository { get; }

        public EmployeeService()
        {
            NewRepository = new Repository();
        }

        public Employee FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Employee FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SerializeTeamLeads(string pathToJson)
        {
            throw new NotImplementedException();
        }

        public Report FindReportById(Guid reportId)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity, Guid directorId)
        {
            throw new NotImplementedException();
        }

        public Repository GetRepository()
        {
            return NewRepository;
        }
    }
}