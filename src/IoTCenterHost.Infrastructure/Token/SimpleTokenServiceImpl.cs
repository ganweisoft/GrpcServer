//  Copyright (c) 2025 Shenzhen Ganwei Software Technology Co., Ltd
using IoTCenterHost.Core.Abstraction;
using Microsoft.Extensions.Configuration;

namespace IoTCenterHost.AppServices.Infrastructure.Token
{
    public class SimpleTokenServiceImpl : BaseTokenServiceImpl, ITokenService
    {
        public SimpleTokenServiceImpl(IMemoryCacheService memoryCache, IConfiguration configuration) : base(memoryCache, configuration)
        {
        }
        public string WriteToken(string connectId, LoginUser loginUser)
        {
            string token = Guid.NewGuid().ToString();
            base.SetTokenToMemory<LoginUser>(token, loginUser);
            return token;
        }
        public string RefreshToken(string connectId, string token)
        {
            LoginUser loginUser = GetLoginUser(token);
            return WriteToken(connectId, loginUser);
        }
    }
}
