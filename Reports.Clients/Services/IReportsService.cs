namespace Reports.Clients.Services
{
    public interface IReportsService
    {
        void CreateEmployee(string name);
        string FindEmployeeById(string id);
        void DeleteEmployee(string id);
        string GetAllEmployees();
        void AddTask(string instance);
        string GetAllTasks();
        string GetAllReports();
        void UpdateTask(string newRelatedTask, string responsibleEmployeeId);
        void UpdateTaskResponsibleEmployee(string newEmployeeId, string taskId);
        string GetTasksWithChanges();
        string GetReportByEmployee(string responsibleEmployeeId);
        void UpdateReportInstance(string newInstance, string responsibleEmployeeId);
        string GetTasksByCreationTime(string time);
        string GetTaskById(string id);
    }
}