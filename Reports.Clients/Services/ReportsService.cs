using System.IO;
using System.Net;
using System.Text;

namespace Reports.Clients.Services
{
    public class ReportsService : IReportsService
    {
        public void CreateEmployee(string name)
        {
            WebRequest request = HttpWebRequest.CreateHttp($"http://localhost:5000/employee/?name={name}");
            request.Method = WebRequestMethods.Http.Post;
            request.GetResponse();
        }

        public string FindEmployeeById(string id)
        {
            WebRequest request = HttpWebRequest.CreateHttp($"http://localhost:5000/employee/?name={id}");
            request.Method = WebRequestMethods.Http.Get;
            WebResponse response = request.GetResponse();
            return ResponseResult(response);
        }

        public void DeleteEmployee(string id)
        {
            WebRequest request = HttpWebRequest.CreateHttp($"http://localhost:5000/employee/?id={id}");
            request.Method = "DELETE";
            request.GetResponse();
        }

        public string GetAllEmployees()
        {
            WebRequest request = HttpWebRequest.CreateHttp("http://localhost:5000/employee/?getAll=true");
            request.Method = WebRequestMethods.Http.Get;
            WebResponse response = request.GetResponse();
            return ResponseResult(response);
        }

        public void UpdateTaskResponsibleEmployee(string newEmployeeId, string taskId)
        {
            WebRequest request =
                HttpWebRequest.CreateHttp(
                    $"http://localhost:5000/task/?newEmployeeId={newEmployeeId}&taskId={taskId}");
            request.Method = WebRequestMethods.Http.Put;
            request.GetResponse();
        }

        public void AddTask(string instance)
        {
            WebRequest request = HttpWebRequest.CreateHttp($"http://localhost:5000/task/?instance={instance}");
            request.Method = WebRequestMethods.Http.Post;
            request.GetResponse();
        }

        public string GetAllTasks()
        {
            WebRequest request = HttpWebRequest.CreateHttp($"http://localhost:5000/task/?getAll=true");
            request.Method = WebRequestMethods.Http.Get;
            WebResponse response = request.GetResponse();
            return ResponseResult(response);
        }

        public string GetTasksByCreationTime(string time)
        {
            WebRequest request = HttpWebRequest.CreateHttp($"http://localhost:5000/task/?creationTime={time}");
            request.Method = WebRequestMethods.Http.Get;
            WebResponse response = request.GetResponse();
            return ResponseResult(response);
        }

        public string GetTasksWithChanges()
        {
            WebRequest request = HttpWebRequest.CreateHttp($"http://localhost:5000/task/?isChanged=true");
            request.Method = WebRequestMethods.Http.Get;
            WebResponse response = request.GetResponse();
            return ResponseResult(response);
        }

        public string GetTaskById(string id)
        {
            WebRequest request = HttpWebRequest.CreateHttp($"http://localhost:5000/task/?taskId={id}");
            request.Method = WebRequestMethods.Http.Get;
            WebResponse response = request.GetResponse();
            return ResponseResult(response);
        }

        public void UpdateReportInstance(string newInstance, string responsibleEmployeeId)
        {
            WebRequest request =
                HttpWebRequest.CreateHttp(
                    $"http://localhost:5000/report/?newInstance={newInstance}&employee={responsibleEmployeeId}");
            request.Method = WebRequestMethods.Http.Put;
            request.GetResponse();
        }

        public string GetAllReports()
        {
            WebRequest request = HttpWebRequest.CreateHttp("http://localhost:5000/report/?getAll=true");
            request.Method = WebRequestMethods.Http.Get;
            WebResponse response = request.GetResponse();
            return ResponseResult(response);
        }

        public string GetReportByEmployee(string responsibleEmployeeId)
        {
            WebRequest request = HttpWebRequest.CreateHttp($"http://localhost:5000/report/?responsibleEmployee={responsibleEmployeeId}");
            request.Method = WebRequestMethods.Http.Get;
            WebResponse response = request.GetResponse();
            return ResponseResult(response);
        }

        public void UpdateTask(string newRelatedTask, string responsibleEmployeeId)
        {
            WebRequest request =
                HttpWebRequest.CreateHttp(
                    $"http://localhost:5000/report/?relatedTask={newRelatedTask}&employee={responsibleEmployeeId}");
            request.Method = WebRequestMethods.Http.Put;
            request.GetResponse();
        } 
        
        private string ResponseResult(WebResponse resp)
        {
            Stream responseStream = resp.GetResponseStream();
            using var readStream = new StreamReader(responseStream, Encoding.UTF8);
            string responseResult = readStream.ReadToEnd();
            return responseResult;
        }
    }
}