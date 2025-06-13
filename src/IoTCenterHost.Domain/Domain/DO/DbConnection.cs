using IoTCenterHost.Core.Abstraction;
using IoTCenterHost.Core.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using IoTCenterHost.Core;
using Newtonsoft.Json;

namespace IoTCenterHost.AppServices.Domain
{

    /// <summary>
    /// 数据库连接
    /// </summary>
    public class DbConnection
    {
        public DbConnection()
        {

        }
        public string DbName { get; set; }
        public string Source { get; set; }
        public string IP { get; set; }
        public string Pwd { get; set; }
        public string Uid { get; set; }
        public string Select { get; set; }
        public string Port { get; set; }
        public string DataFilePath { get; set; }

        public bool IsSelect
        {
            get
            {
                return string.Equals(Select, "true", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public static string ConfigurationXml
        {
            get
            {
                var directoryInfo = new System.IO.DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent.Parent.FullName;
                return Path.Combine(directoryInfo, "data", "AlarmCenter", "AlarmCenterProperties.xml");
            }
        }

        public bool HasDbKey()
        {
            return false;
        }
    }

    /// <summary>
    /// MySQL连接字符串
    /// </summary>
    public class MySqlDbConnection
    {
        public const string MySqlDbName = "MySql";

        public DbConnection DbConnection { get; set; }

        public MySqlDbConnection()
        {

        }

        public MySqlDbConnection(DbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }

        public MySqlDbConnection Create()
        {
            string database = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.Database");//GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.Database", "");
            string ip = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.IP");//GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.IP", "");
            string isEncryptStr = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "JiaMi");//GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "JiaMi", "");
            string port = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PORT");//GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PORT", "");
            string select = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.Select");
            string pwd = string.Empty;
            if (string.Equals(isEncryptStr, "true", StringComparison.InvariantCultureIgnoreCase))
            {
                pwd = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PWD").DecryptStr();//GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PWD", "").DecryptStr();
            }
            else
                pwd = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PWD"); //GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PWD", "");
            string uid = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.UID");// GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.UID", "");

            DbConnection = new DbConnection
            {
                DbName = MySqlDbName,
                Source = database,
                IP = ip,
                Port = port,
                Select = select,
                Uid = uid,
                DataFilePath = "",
                Pwd = pwd
            };
            return this;
        }


        public static bool HasDbKey()
        {
            return !string.IsNullOrWhiteSpace(FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{MySqlDbName}.Database"));
        }

        public static bool IsSelected()
        {
            return string.Equals(FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{MySqlDbName}.Select").ToUpper(), "true", StringComparison.InvariantCultureIgnoreCase);
        }



        public void Save()
        {
            if (!string.IsNullOrEmpty(DbConnection.Uid))
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.Database", DbConnection.Source);
            if (!string.IsNullOrEmpty(DbConnection.Uid))
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.UID", DbConnection.Uid);
            if (!string.IsNullOrEmpty(DbConnection.IP))
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.IP", DbConnection.IP);
            if (!string.IsNullOrEmpty(DbConnection.Port))
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PORT", DbConnection.Port);
            if (!string.IsNullOrEmpty(DbConnection.Pwd))
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PWD", DbConnection.Pwd);
            if (DbConnection.IsSelect)
            {
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.Select", System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(DbConnection.Select));
            }
            else
            {
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.Select", System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(DbConnection.Select));
            }
        }
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(DbConnection.DbName))
                return $"Data Source={DbConnection.IP};port={DbConnection.Port};Initial Catalog={DbConnection.Source};user id={DbConnection.Uid};password={DbConnection.Pwd};default command timeout=120;charset=utf8mb4;";
            return string.Empty;
        }
    }

    public class SqliteConnection
    {
        public const string SqliteDbName = "SQLite";
        public string configurationXml = "";

        public DbConnection DbConnection { get; set; }

        public SqliteConnection()
        {

        }

        public SqliteConnection(DbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }

        public SqliteConnection Create()
        {
            string fileName = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "SQLite.DefaultPath"); ;
            string select = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "SQLite.Select");
            DbConnection = new DbConnection
            {
                DbName = SqliteDbName,
                Select = select,
                DataFilePath = fileName
            };
            return this;
        }

        public static new bool HasDbKey()
        {
            return !string.IsNullOrWhiteSpace(FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{SqliteDbName}.DefaultPath"));
        }

        public static bool IsSelected()
        {
            return string.Equals(FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{SqliteDbName}.Select").ToUpper(), "true", StringComparison.InvariantCultureIgnoreCase);
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public void Save()
        {
            if (DbConnection.IsSelect)
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "SQLite.Select", System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(DbConnection.Select));
            else
            {
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "SQLite.Select", System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(DbConnection.Select));
            }
        }
    }

    public class PostgreConnection : DbConnection
    {
        public const string PostgreDbName = "Postgre";

        public DbConnection DbConnection { get; set; }

        public PostgreConnection Create()
        {
            return new PostgreConnection();
        }

        public static new bool HasDbKey()
        {
            return !string.IsNullOrWhiteSpace(FileExtension.ReadXml(ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{PostgreDbName}.Database"));
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Set()
        {

        }
    }

    public class KingbaseConnection : DbConnection
    {
        public const string KingbaseDbName = "Kingbase";

        public DbConnection DbConnection { get; set; }

        public KingbaseConnection Create()
        {
            string database = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.Database");//GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.Database", "");
            string ip = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.IP");//GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.IP", "");
            string isEncryptStr = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", "JiaMi");//GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "JiaMi", "");
            string port = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.PORT");//GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PORT", "");
            string select = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.Select");
            string pwd = string.Empty;
            if (string.Equals(isEncryptStr, "true", StringComparison.InvariantCultureIgnoreCase))
            {
                pwd = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.PWD").DecryptStr();//GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PWD", "").DecryptStr();
            }
            else
                pwd = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.PWD"); //GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.PWD", "");
            string uid = FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.UID");// GWDataCenter.DataCenter.GetPropertyFromPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", "MySql.UID", "");

            DbConnection = new DbConnection
            {
                DbName = KingbaseDbName,
                Source = database,
                IP = ip,
                Port = port,
                Select = select,
                Uid = uid,
                DataFilePath = "",
                Pwd = pwd
            };
            return this;
        }


        public static new bool HasDbKey()
        {
            return !string.IsNullOrWhiteSpace(FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.Database"));
        }

        public static bool IsSelected()
        {
            return string.Equals(FileExtension.ReadXml(DbConnection.ConfigurationXml, "AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.Select").ToUpper(), "true", StringComparison.InvariantCultureIgnoreCase);
        }


        public void Save()
        {
            if (!string.IsNullOrEmpty(DbConnection.Uid))
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.Database", DbConnection.Source);
            if (!string.IsNullOrEmpty(DbConnection.Uid))
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.UID", DbConnection.Uid);
            if (!string.IsNullOrEmpty(DbConnection.IP))
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.IP", DbConnection.IP);
            if (!string.IsNullOrEmpty(DbConnection.Port))
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.PORT", DbConnection.Port);
            if (!string.IsNullOrEmpty(DbConnection.Pwd))
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.PWD", DbConnection.Pwd);
            if (DbConnection.IsSelect)
            {
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.Select", System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(DbConnection.Select));
            }
            else
            {
                GWDataCenter.DataCenter.SetPropertyToPropertyService("AlarmCenter.Gui.OptionPanels.DatabaseOptions", $"{KingbaseDbName}.Select", System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(DbConnection.Select));
            }
        }
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(DbConnection.DbName))
                return $"Server={DbConnection.IP};User ID={DbConnection.Uid};Password={DbConnection.Pwd};Database={DbConnection.Source};Port={DbConnection.Port}";
            return string.Empty;
        }
    }

}
