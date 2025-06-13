using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IoTCenterHost.AppServices.Domain.DO
{
    public interface IGWAssemblyRepository
    {
        IEnumerable<GWAssembly> GetList(Expression<Func<GWAssembly, bool>> expression);
        /// <summary>
        /// 组件
        /// </summary>
        /// <param name="assembly"></param>
        void AddEntity(GWAssembly assembly);

        GWAssembly GetId(int id);

        void Update(GWAssembly gWAssembly);
    }
}
