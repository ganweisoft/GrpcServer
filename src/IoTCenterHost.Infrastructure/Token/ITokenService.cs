//  Copyright (c) 2020 Shenzhen Ganwei Software Technology Co., Ltd
namespace IoTCenterHost.AppServices.Infrastructure.Token
{
    public interface ITokenService
    {
        string WriteToken(string connectId, LoginUser loginUser);
        void SetTokenEmpired(string token);
        string RefreshToken(string connectId, string token);
        bool IsTokenAlive(string token);
        LoginUser GetLoginUser(string token);
        void SetTokenToMemory<T>(string token, T obj);
    }
}
