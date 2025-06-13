using IoTCenterHost.AppServices.Domain.PO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IoTCenterHost.AppServices.Domain.DO
{
    public class GWAssemblyRepository : IGWAssemblyRepository
    {
        public GanweiDbContext _ganweiDbContext;
        private IServiceScopeFactory serviceScopeFactory;

        //public GWAssemblyRepository(GanweiDbContext ganweiDbContext)
        //{
        //    _ganweiDbContext = ganweiDbContext;
        //}
        public GWAssemblyRepository(IServiceScopeFactory serviceScope)
        {
            serviceScopeFactory = serviceScope;
            if ((bool)GWDataCenter.DataCenter.brunning)
                _ganweiDbContext = serviceScopeFactory.CreateScope().ServiceProvider.GetService<GanweiDbContext>();
        }
        public void AddEntity(GWAssembly assembly)
        {
            if (!_ganweiDbContext.GWAssembly.Any(u => u.AssemblyName == assembly.AssemblyName))
            {
                _ganweiDbContext.GWAssembly.Add(assembly);
                _ganweiDbContext.SaveChanges();
            }
            else
                throw new Exception("数据库已存在同名组件");
        }

        public GWAssembly GetId(int id)
        {
            return _ganweiDbContext.GWAssembly.Find(id);
        }

        public IEnumerable<GWAssembly> GetList(Expression<Func<GWAssembly, bool>> expression)
        {
            return _ganweiDbContext.GWAssembly.Where(expression);
        }

        public void Update(GWAssembly gWAssembly)
        {
            _ganweiDbContext.Update(gWAssembly);
            _ganweiDbContext.SaveChanges();
        }
    }
}
