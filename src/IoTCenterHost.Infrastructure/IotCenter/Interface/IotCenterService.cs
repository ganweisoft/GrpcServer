//  Copyright (c) 2025 Shenzhen Ganwei Software Technology Co., Ltd
using GWDataCenter;

namespace IoTCenterHost.AppServices.Infrastructure.IotCenter
{
    public interface IotCenterService
    {
        void StartService();
        void StopService();
        void RebootService();

        bool Confirm2NormalState(int iEqpNo, string sYcYxType, int iYcYxNo);
        string GetVersionInfo();
        void AddConfirmedMessage(RealTimeEventItem ConfirmRealTimeEventItem);
    }
}
