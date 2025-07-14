//  Copyright (c) 2020 Shenzhen Ganwei Software Technology Co., Ltd
using IoTCenterHost.Core.Abstraction.EnumDefine;

namespace IoTCenterHost.Core.Abstraction.BaseModels
{
    public class GrpcChangedEquip
    {
        public int iStaNo;
        public int iEqpNo;
        public ChangedEquipState State;
    }
}
