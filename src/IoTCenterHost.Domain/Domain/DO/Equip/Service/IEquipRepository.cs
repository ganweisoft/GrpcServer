//  Copyright (c) 2020-2025 Shenzhen Ganwei Software Technology Co., Ltd
using GWDataCenter;

namespace IoTCenterHost.AppServices.Domain.DO.Equip
{
    public interface IEquipRepository
    {
        EquipItem GetEquip(int equipNo);
        GWDataCenter.EquipState GetEquipStateFromEquipNo(int iEquipNo);
        Dictionary<int, GWDataCenter.EquipState> GetEquipStateDict();


        Dictionary<int, GWDataCenter.EquipState> GetEquipStateDict(IEnumerable<int> equipList);

        string GetEquipListStr(int iEquipNo);
        string GetEquipListStr();
        void SetEquipNmAsync(int EquipNo, string Nm);
    }
}
