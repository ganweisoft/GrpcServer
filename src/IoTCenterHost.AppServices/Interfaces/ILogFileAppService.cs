using IoTCenterHost.Core.Abstraction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTCenterHost.AppServices.Interfaces
{
    public interface ILogFileAppService
    {
        List<LogTreeResponse> GetTree(string path, out long length, string rootPath);

        string GetLogFileName(string input);

        Task<List<string>> ReadLog(QueryLogRequest logRequest, string fileName);
    }
}
