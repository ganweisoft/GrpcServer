//  Copyright (c) 2025 Shenzhen Ganwei Software Technology Co., Ltd
using IoTCenterHost.AppServices.Domain;

namespace IoTCenterHost.AppServices.Interfaces
{
    public interface IHostConfigurationAppService
    {
        PropertiesXml GetPropertiesXmlModel();

        void SetPropertiesXmlModel(PropertiesXml propertiesXmlModel);
    }
}
