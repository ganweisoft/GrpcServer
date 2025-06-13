using IoTCenterHost.AppServices.Domain.DomainBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IoTCenterHost.AppServices.Infrastructure.Database
{
    public interface IDatabaseRepository
    {
        /// <summary>
        /// 分页查询动态类型
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sortField"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        DataTable SqlQueryDynamic(string sql, string sortField, bool isAsc, int pageSize, int pageIndex, out int total);
        /// <summary>
        /// 整表修改
        /// </summary>
        /// <param name="dt"></param>
        void UpdateDataTable(DataTable dt);
        /// <summary>
        /// 根据sql语句获取列表
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        DataTable GetDataTable(string strSQL);
        /// <summary>
        /// 执行sql返回首行首列的值
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        object ExecuteScalar(string strSQL);
        /// <summary>
        /// 获取DataAdapter
        /// </summary>
        /// <param name="strSQL"></param>
        void GetDataAdapter(string strSQL);
        /// <summary>
        /// 执行SQL,返回受影响的行数
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        int ExecuteSql(string strSQL);
        /// <summary>
        /// 执行多条sql语句
        /// </summary>
        /// <param name="cmdtext"></param>
        void ExecuteSql(string[] cmdtext);
        /// <summary>
        /// 执行sql语句并返回主键id
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        int ExecuteSqlWithRecordId(string strSql, string tableName);

        /// <summary>
        /// 泛型查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> query) where TEntity : class;
    }
}
