namespace IoTCenterHost.Core.Abstraction.AppServices
{
    public interface IoTCenterAppService
    {
        string GetVersionInfo();


        void ResetProcTimeManage();
        void ResetGWDataRecordItems();
        void ResetDelayActionPlan();
        void MResetYcYxNo(int EquipNo, string sType, int YcYxNo);

        string GetPropertyFromPropertyService(string PropertyName, string NodeName, string DefaultValue);

        void SetPropertyToPropertyService(string PropertyName, string NodeName, string Value);

    }
}
