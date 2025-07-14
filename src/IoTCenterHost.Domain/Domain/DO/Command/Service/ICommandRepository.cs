//  Copyright (c) 2020 Shenzhen Ganwei Software Technology Co., Ltd
namespace IoTCenterHost.AppServices.Domain.DO.Equip.Service
{
    public interface ICommandRepository
    {
        void ResetEquipmentLinkage();
        bool HaveSet(int EquipNo);
        string GetSetListStr(int iEquipNo);
    }
}
