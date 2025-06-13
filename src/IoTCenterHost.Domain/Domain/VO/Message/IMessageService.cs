using GWDataCenter;

namespace IoTCenterHost.AppServices.Domain.VO.Message
{
    public interface IMessageService
    {

        void ConfirmedRealTimeEventItem(RealTimeEventItem item);
        void DeleteDebugInfo(int iEquipNo);
        void AddMessage(MessageLevel level, string msgstr, int equipno, bool CanRepeat = true);
    }
}
