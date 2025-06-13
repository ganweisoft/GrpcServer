using GWDataCenter;

namespace IoTCenterHost.AppServices.Infrastructure.IotCenter
{
    public class IotCenterServiceImpl : IotCenterService
    {
        const string versionNo = "6.1.0";
        public IotCenterServiceImpl()
        {

        }

        public bool Confirm2NormalState(int iEqpNo, string sYcYxType, int iYcYxNo)
        {
            EquipItem Item = StationItem.GetEquipItemFromEquipNo(iEqpNo);
            return Item.ICommunication.Confirm2NormalState(sYcYxType, iYcYxNo);
        }


        public string GetVersionInfo()
        {
            string version = versionNo;
            if (string.IsNullOrEmpty(version))
                return DataCenter.GetVersionInfo();
            return version;
        }

        public void AddConfirmedMessage(RealTimeEventItem ConfirmRealTimeEventItem)
        {
            MessageService.AddConfirmedMessage(ConfirmRealTimeEventItem);
        }

        public void StartService()
        {
            GWDataCenter.DataCenter.Start();
        }

        public void StopService()
        {
            GWDataCenter.DataCenter.Stop();
        }

        public void RebootService()
        {
            StopService();
            StartService();
        }
    }
}
