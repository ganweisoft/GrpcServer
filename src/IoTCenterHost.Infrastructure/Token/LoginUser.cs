//  Copyright (c) 2025 Shenzhen Ganwei Software Technology Co., Ltd
using IoTCenterHost.Core.Abstraction.IotModels;

namespace IoTCenterHost.AppServices.Infrastructure.Token
{
    public class LoginUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Thumbnail { get; set; }
        public DateTime LoginTime { get; set; }
        public string LoginMark { get; set; }
        public GWUserItem UserItem { get; set; }
    }
}
