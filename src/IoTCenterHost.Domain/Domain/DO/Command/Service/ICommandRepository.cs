//  Copyright (c) 2025 Shenzhen Ganwei Software Technology Co., Ltd
namespace IoTCenterHost.AppServices.Domain.DO.Equip.Service
{
    public interface ICommandRepository
    {
        void ResetEquipmentLinkage();
        bool HaveSet(int EquipNo);
        string GetSetListStr(int iEquipNo);
    }
}
