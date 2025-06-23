//  Copyright (c) 2025 Shenzhen Ganwei Software Technology Co., Ltd
namespace IoTCenterHost.Core.Abstraction.BaseModels
{
    public enum GrpcEquipState
    {
        NoCommunication = 0,
        CommunicationOK = 1,
        HaveAlarm = 2,
        HaveSetParm = 3,
        Initial = 4,
        CheFang = 5,
        BackUp = 6
    }
}
