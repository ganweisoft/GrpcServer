//  Copyright (c) 2020 Shenzhen Ganwei Software Technology Co., Ltd
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
