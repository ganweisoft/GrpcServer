//  Copyright (c) 2025 Shenzhen Ganwei Software Technology Co., Ltd
using GWDataCenter;
using IoTCenterHost.Core.Abstraction.AppServices;
using System.Collections.Generic;

namespace IoTCenterHost.Core.ServerInterfaces
{
    public interface IYXServerAppService : IYXAppService
    {
        List<YXItem> GetTotalYXDataEx(bool isDynamic);
    }
}
