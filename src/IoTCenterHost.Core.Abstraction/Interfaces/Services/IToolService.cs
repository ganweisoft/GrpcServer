//  Copyright (c) 2020 Shenzhen Ganwei Software Technology Co., Ltd
namespace IoTCenterHost.Core.Abstraction.Interfaces.Services
{
    public interface IToolService
    {
        public string Decrypt(string str, string purpose = "");
        public string Encrypt(string str, string purpose = "");

        public string DecryptOld(string str);
        public string EncryptOld(string str);
    }
}
