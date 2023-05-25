using System;
using System.Collections.Generic;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IEmployeeService
    {
        Employee FindByName(string name);
        Employee FindById(Guid id);
        void Delete(Guid id);
        void SerializeTeamLeads(string pathToJson);
        Report FindReportById(Guid reportId);
        void Update(Employee entity, Guid directorId);

        Repository GetRepository();
    }
}