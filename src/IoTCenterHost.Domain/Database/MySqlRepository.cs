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
    public class MySqlRepository : BaseRepository, IDatabaseRepository
    {  
        public MySqlRepository(IServiceScopeFactory serviceScope)
        {
            ServiceScopeFactory = serviceScope;          
        }
        //public MySqlRepository(GanweiDbContext gWDataContext)  
        //{
        //    Db = gWDataContext;
        //}
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
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add("default");
            DataTable dataTable = dataSet.Tables[0];
            try
            {

                if (string.IsNullOrEmpty(sql))
                {
                    throw new Exception("请输入查询语句");
                }
                sql = sql.Replace("\t", " ").Replace("\r", "").Replace("\r  ", " ").Replace("\n", " ").Replace("\r\r", " ");


                using (DbConnection connection = OpenConnection())
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = $" select count(*) from({ sql}) pgtb";
                        total = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    using (var cmd = connection.CreateCommand())
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
                        sql = $"select * from ({sql}) pgtb {orderCause} limit {pageSize} offset  {pageSize * (pageIndex - 1)} ";
                        //dataTable = GetDataTable(sql);
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
                }
            }
            catch (Exception ex)
            {
                GWDataCenter.DataCenter.Write2Log($"执行SQL语句失败，错误内容{ex},错误语句：{sql}", LogLevel.Error);
                throw;
            }
            return dataTable;
        }

        private DbConnection OpenConnection()
        {
            var Db = CurrentDb;
            var connection = Db.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                Db.Database.OpenConnection();
                connection = Db.Database.GetDbConnection();
            }

            return connection;
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
                        cmd.CommandText = $"{strSql};SELECT LAST_INSERT_ID();";
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
                    GWDataCenter.DataCenter.Write2Log($"数据操作失败：{ex.Message},错误语句为{strSql}", LogLevel.Error);
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
