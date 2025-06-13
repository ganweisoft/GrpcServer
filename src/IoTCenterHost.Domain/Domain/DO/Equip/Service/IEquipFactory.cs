using IoTCenterHost.AppServices.Domain.Entity;
using IoTCenterHost.AppServices.Domain.PO;

namespace IoTCenterHost.AppServices.Domain.DO.Equip
{
    public interface IEquipFactory
    {
        EquipEntity BuildEntity(EquipPo equip);
    }
}
