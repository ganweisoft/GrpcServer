//  Copyright (c) 2020 Shenzhen Ganwei Software Technology Co., Ltd
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using IoTCenterHost.Proto;

namespace IoTCenterHost.AppServices.GrpcConstracts.IotHostService
{
    public partial class IotHostService : IotService.IotServiceBase
    {
        public override Task<Empty> DoExProcSetParm(DoExProcSetParmRequest request, ServerCallContext context)
        {
            return Task.FromResult(new Empty());
        }
    }
}
