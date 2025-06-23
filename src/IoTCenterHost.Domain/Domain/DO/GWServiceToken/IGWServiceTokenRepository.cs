//  Copyright (c) 2025 Shenzhen Ganwei Software Technology Co., Ltd
using System.Linq.Expressions;

namespace IoTCenterHost.AppServices.Domain.DO.GWServiceToken
{
    public interface IGWServiceTokenRepository
    {
        IEnumerable<GWServiceToken> GetList(Expression<Func<GWServiceToken, bool>> expression);

        void AddEntity(GWServiceToken serviceToken);
    }
}
