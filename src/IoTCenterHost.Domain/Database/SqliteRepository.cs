using IoTCenterHost.AppServices.Domain.PO;
using GWDataCenter.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using GWDataCenter;

namespace IoTCenterHost.AppServices.Infrastructure.Database
{
    public class SqliteRepository :BaseRepository, IDatabaseRepository
    { 

        public SqliteRepository(IServiceScopeFactory serviceScope) 
        {
            ServiceScopeFactory = serviceScope;
        }
        /// <summary>
        /// 根据sql查询动态类型和分页信息
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable SqlQueryDynamic(string sql, string sortField, bool isAsc, int pageSize, int pageIndex, out int total)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new Exception("请输入查询语句");
            }
            sql = sql.Replace("\t", " ").Replace("\r  ", " ").Replace("\n", " ").Replace("\r\r", " ");

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add("default");
            DataTable dataTable = dataSet.Tables[0];
            total = Convert.ToInt32(ExecuteScalar($" select count(*) from ({sql})"));
            var Db = CurrentDb;
            using (var cmd = Db.Database.GetDbConnection().CreateCommand())
            {
                string orderCause = "";
                if (!string.IsNullOrEmpty(sortField))
                    if (isAsc)
                    {
                        orderCause = $" order by {sortField} asc";
                    }
                    else
                    {
                        orderCause = $" order by {sortField} desc";
                    }
                sql = $"select * from ({sql}) {orderCause} limit {pageSize} offset  {pageSize * (pageIndex - 1)} "; 
                cmd.CommandText = sql;

                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                using (var dataReader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                {
                    dataSet.EnforceConstraints = false;
                    dataTable.Load(dataReader);
                }
            }
            return dataTable;
        } 
        /// <summary>
        /// 执行插入语句，并返回记录id
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int ExecuteSqlWithRecordId(string strSql, string tableName)
        {
            int rowId = 0;
            var Db = CurrentDb;
            var conn = Db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            using (var trans = conn.BeginTransaction())
            {
                try
                { 
                    using (var cmd = Db.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = $"{strSql};select last_insert_rowid() from {tableName}";
                        cmd.Transaction = trans;
                        DbDataReader reader = cmd.ExecuteReader();
                        trans.Commit();
                        if (reader.Read())
                        {
                            rowId = int.Parse(reader[0].ToString());
                            reader.Close();
                        }
                        else
                            rowId = 0;
                    }  
                }
                catch (Exception ex)
                {
                    GWDataCenter.DataCenter.Write2Log("数据操作失败：" + ex.Message, LogLevel.Error);
                    trans.Rollback();
                }
                finally
                {
                    conn.Close();
                }

                return rowId;
            }
        }
    }
}
