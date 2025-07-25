//  Copyright (c) 2020-2025 Shenzhen Ganwei Software Technology Co., Ltd
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
