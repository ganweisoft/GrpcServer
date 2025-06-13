using IoTCenterHost.Core.Abstraction.EnumDefine;
using System.Threading.Tasks;

namespace IoTCenterHost.Core.Abstraction.AppServices
{
    public interface IAccountAppService
    {
        Task<ResponseModel> Login(string user, string pwd, GwClientType client);

        void CloseSession();
    }
}
