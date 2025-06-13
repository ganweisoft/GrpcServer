using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTCenterHost.Core.Abstraction;
using IoTCenterHost.Core.Abstraction.AppServices;
using IoTCenterHost.AppServices.Infrastructure.IotCenter;
using GWDataCenter;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace IoTCenterHost.AppServices.AppServices
{
    public class GWExProcAppServiceImpl : BaseAppServiceImpl, IGWExProcAppService
    {
        private readonly IotCenterService _iotCenterService;
        private readonly ILogger _logger;

        public GWExProcAppServiceImpl(IotCenterService iotCenterService,IHttpContextAccessor contextAccessor, ILogger logger) : base(contextAccessor, logger)
        {
            _iotCenterService = iotCenterService;
            _logger = logger;
        }

        public void DoExProcSetParm(string ModuleNm, string cmd1, string cmd2, string cmd3)
        {
            _iotCenterService.DoExProcSetParm(ModuleNm, cmd1, cmd2, cmd3); 
        }
    }
}
