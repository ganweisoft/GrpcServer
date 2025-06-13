//using IoTCenterHost.AppServices.Domain.PO;
using GWDataCenter.Database;
using IoTCenterHost.AppServices.Domain.PO;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IoTCenterHost.AppServices.Infrastructure.Database
{
    public abstract class BaseRepository
    {
        public IServiceScopeFactory ServiceScopeFactory;

        public DbContext CurrentDb
        {
            get
            {
                if ((bool)GWDataCenter.DataCenter.brunning)
                    return ServiceScopeFactory.CreateScope().ServiceProvider.GetService<GanweiDbContext>();
                else
                    return null;
            }
        }
        public BaseRepository()
        {
        }
        public void UpdateDataTable(DataTable dt)
        {
            var Db = CurrentDb;

            using (var conn = Db.Database.GetDbConnection())
            {
                throw new NotImplementedException();
            }
        }
        public DataTable GetDataTable(string strSQL)
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add("default");
            DataTable dt = dataSet.Tables[0];
            try
            {
                var Db = CurrentDb;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                using (var conn = Db.Database.GetDbConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    using (var cmd = Db.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = strSQL;
                        dataSet.EnforceConstraints = false;
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            dt.Load(dataReader);
                        }
                    }
                    conn.Close();
                }
                stopwatch.Stop();
                if (stopwatch.Elapsed.TotalMilliseconds > 500)
                {
                    Serilog.Log.Logger.Debug($"执行SQL语句{strSQL}耗时{stopwatch.Elapsed.TotalSeconds}.");
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Logger.Error($"执行SQL语句失败，错误内容{ex},错误语句：{strSQL}");
                throw ex;
            }
            return dt;
        }
        public object ExecuteScalar(string strSQL)
        {
            object result = null;
            try
            {
                var Db = CurrentDb;
                using (var conn = Db.Database.GetDbConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    using (var cmd = Db.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = strSQL;
                        result = cmd.ExecuteScalar();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Logger.Error($"执行SQL语句失败，错误内容{ex},错误语句：{strSQL}");
                throw ex;
            }
            return result;
        }
        public void GetDataAdapter(string strSQL)
        {
            var Db = CurrentDb;

            using (var conn = Db.Database.GetDbConnection())
            {
                //IDataAdapter dataAdapter = new DataAdapter(strSQL, conn);
            }
        }
        public int ExecuteSql(string strSQL)
        {
            int rows = 0;
            var Db = CurrentDb;

            using (var trans = Db.Database.BeginTransaction())
            {
                try
                {
                    rows = Db.Database.ExecuteSqlRaw(strSQL);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    if (Db.Database.GetDbConnection().State == ConnectionState.Open)
                        trans.Rollback();
                    Serilog.Log.Logger.Error($"执行SQL语句失败，错误内容{ex},错误语句：{strSQL}");
                }

            }
            return rows;
        }
        public void ExecuteSql(string[] cmdtext)
        {
            var Db = CurrentDb;

            using (var trans = Db.Database.BeginTransaction())
            {
                foreach (var strSql in cmdtext)
                {
                    Db.Database.ExecuteSqlRaw(strSql);
                }
                trans.Commit();
            }
        }

        public IEnumerable<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> query) where TEntity : class
        {
            return CurrentDb.Set<TEntity>().AsNoTracking().Where(query);
        }
    }
}
