//  Copyright (c) 2020 Shenzhen Ganwei Software Technology Co., Ltd
using System.Threading.Tasks;

namespace IoTCenterHost.Core.Abstraction.Interfaces.Services
{
    public interface IGreetService
    {
        Task<bool> GreetAsync();

        Task<(bool, string)> GreetExAsync();
    }
}
