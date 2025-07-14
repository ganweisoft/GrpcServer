//  Copyright (c) 2020 Shenzhen Ganwei Software Technology Co., Ltd
using IoTCenterHost.AppServices.Domain;

namespace IoTCenterHost.AppServices.Interfaces
{
    public interface IHostConfigurationAppService
    {
        PropertiesXml GetPropertiesXmlModel();

        void SetPropertiesXmlModel(PropertiesXml propertiesXmlModel);
    }
}
