using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Caching;
using Ucar.Common;

namespace Ucar.BaseClass
{
    /// <summary>
    /// 数据缓存的基础类
    /// </summary>
    public class DataCache
    {
        #region 构造函数
        /// <summary>
        /// 数据缓存的基础类
        /// </summary>
        public DataCache()
        {
            m_source = DataCacheSource.Unknown;
        }
        /// <summary>
        /// 数据缓存的基础类
        /// </summary>
        /// <param name="commandText">查询语句</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public DataCache(string commandText, string connectionString)
        {
            m_commandText = commandText;
            m_connectionString = connectionString;
            m_source = DataCacheSource.Unknown;
        }
        /// <summary>
        /// 数据缓存的基础类
        /// </summary>
        /// <param name="commandText">查询语句</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseEntryName">在应用程序的Web.config文件的databases Element for sqlDataDependency for caching元素中定义的数据库的名称</param>
        /// <param name="tableName">与System.Web.Caching.SqlCacheDependency相关联的数据表的名称</param>
        public DataCache(string commandText, string connectionString, string databaseEntryName, string tableName)
        {
            m_commandText = commandText;
            m_connectionString = connectionString;
            m_databaseEntryName = databaseEntryName;
            m_tableName = tableName;
            m_source = DataCacheSource.Unknown;
        }
        #endregion

        #region 属性
        private string m_commandText;
        /// <summary>
        /// 查询语句
        /// </summary>
        public string CommandText
        {
            get { return m_commandText; }
            set { m_commandText = value; }
        }

        private string m_connectionString;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return m_connectionString; }
            set { m_connectionString = value; }
        }

        private string m_databaseEntryName;
        /// <summary>
        /// 在应用程序的Web.config文件的databases Element for sqlDataDependency for caching元素中定义的数据库的名称
        /// </summary>
        public string DatabaseEntryName
        {
            get { return m_databaseEntryName; }
            set { m_databaseEntryName = value; }
        }

        private string m_tableName;
        /// <summary>
        /// 与System.Web.Caching.SqlCacheDependency相关联的数据表的名称
        /// </summary>
        public string TableName
        {
            get { return m_tableName; }
            set { m_tableName = value; }
        }

        private string m_key;
        /// <summary>
        /// 缓存的键
        /// </summary>
        public string Key
        {
            get { return m_key; }
            set { m_key = value; }
        }

        private DataCacheSource m_source;
        /// <summary>
        /// 数据的来源
        /// </summary>
        public DataCacheSource Source
        {
            get { return m_source; }
            set { m_source = value; }
        }
        #endregion

        #region 获得数据缓存的方法
        /// <summary>
        /// 获得数据缓存的方法
        /// </summary>
        /// <returns>自定义视图</returns>
        public DataView GetDataCache()
        {
            return GetDataCache(Key);
        }
        /// <summary>
        /// 获得数据缓存的方法
        /// </summary>
        /// <param name="key">缓存的键</param>
        /// <returns>自定义视图</returns>
        public DataView GetDataCache(string cacheKey)
        {
            try
            {
                if (HttpRuntime.Cache[cacheKey] == null)
                {
                    return GetDataViewFromDataBase(cacheKey);
                }
                else
                {
                    return GetDataViewFromCache(cacheKey);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.ErrorLog(ex);
                //return null;
                throw new Exception(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private DataView GetDataViewFromDataBase(string key)
        {
            //取数据
            DataTable dt = DbHelperSQL.Query(CommandText, ConnectionString).Tables[0];
            DataView dv;
            lock (dt)
            {
                dv = new DataView(dt);
            }
            //if (DatabaseEntryName != null && TableName != null && dt != null)
            //{
            //    //启用更改通知
            //    SqlCacheDependencyAdmin.EnableNotifications(ConnectionString);
            //    //连接到 SQL Server 数据库并为 SqlCacheDependency 更改通知准备数据库表
            //    SqlCacheDependencyAdmin.EnableTableForNotifications(ConnectionString, TableName);
            //    //制定缓存策略
            //    SqlCacheDependency scd = new SqlCacheDependency(DatabaseEntryName, TableName);
            //    //插入缓存
            //    HttpRuntime.Cache.Insert(key, dt, scd);
            //}
            string expiredMinutesSetting = ConfigHelper.GetAppSetting("CacheExpiredMinutes");
            double expiredMinutes = ConvertHelper.GetDouble(expiredMinutesSetting);
            HttpRuntime.Cache.Insert(key, dt, null, System.DateTime.Now.AddMinutes(expiredMinutes), System.Web.Caching.Cache.NoSlidingExpiration);
            Source = DataCacheSource.Database;
            return dv;
        }

        private DataView GetDataViewFromCache(string key)
        {
            DataTable dt = (DataTable)HttpRuntime.Cache[key];
            DataView dv;
            lock (dt)
            {
                dv = new DataView(dt);
            }
            Source = DataCacheSource.Cache;
            return dv;
        }
        #endregion
    }

    #region 数据缓存来源
    public enum DataCacheSource
    {
        Database,
        Cache,
        Unknown
    }
    #endregion
}
