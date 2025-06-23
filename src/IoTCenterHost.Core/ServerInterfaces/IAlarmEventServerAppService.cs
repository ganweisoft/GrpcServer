//  Copyright (c) 2025 Shenzhen Ganwei Software Technology Co., Ltd
using GWDataCenter;
using IoTCenterHost.Core.Abstraction;
using IoTCenterHost.Core.Abstraction.AppServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IoTCenterHost.Core.ServerInterfaces
{
    public interface IAlarmEventServerAppService : IAlarmEventAppService
    {
        void FirstGetRealEventItem(Action<ObservableCollection<RealTimeEventItem>> action);

        List<WcfRealTimeEventItem> FirstGetRealEventItem(bool isFirst = false);

    }
}
