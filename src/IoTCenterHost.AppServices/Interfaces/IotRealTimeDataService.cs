//  Copyright (c) 2020 Shenzhen Ganwei Software Technology Co., Ltd
using IoTCenterHost.AppServices.AppServices;

namespace IoTCenterHost.AppServices.Interfaces
{
    public interface IotRealTimeDataService
    {
        void CreateRealDataItem();
        void RemoveRealData(string connectId);


        RealTimeDataItem GetIotRealTimeData(string connectId);

        RealTimeDataItem GetRealTimeDataItem();
        RealTimeDataItem GetIotRealTimeData(string connectId, LoginUser loginUser);
    }
}
