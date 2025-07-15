//  Copyright (c) 2020-2025 Shenzhen Ganwei Software Technology Co., Ltd
using IoTCenterHost.AppServices.Infrastructure.Token;

namespace IoTCenterHost.AppServices.Infrastructure.IotCenter
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
