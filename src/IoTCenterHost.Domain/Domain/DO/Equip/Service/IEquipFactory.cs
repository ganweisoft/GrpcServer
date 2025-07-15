//  Copyright (c) 2020-2025 Shenzhen Ganwei Software Technology Co., Ltd
using IoTCenterHost.AppServices.Domain.Entity;
using IoTCenterHost.AppServices.Domain.PO;

namespace IoTCenterHost.AppServices.Domain.DO.Equip
{
    public interface IEquipFactory
    {
        EquipEntity BuildEntity(EquipPo equip);
    }
}
