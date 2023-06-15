using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using KangHui.BaseClass;
using KangHui.Common;

namespace KangHui.Components.Caching
{
    /// <summary>
    /// 城市相关缓存信息的类
    /// </summary>
    public class City
    {
        #region 私有属性
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string connectionString = ConfigHelper.GetConnectionString("Ucar");
        
        /// <summary>
        /// 在应用程序的Web.config文件的databases Element for sqlDataDependency for caching元素中定义的数据库的名称
        /// </summary>
        private static string databaseEntryName = "Ucar";
        #endregion

        //********************************************
        //原有的获取缓存的方法

        #region 获得不包括全国的城市表缓存的方法
        /// <summary>
        /// 获得不包括全国的城市表缓存的方法
        /// </summary>
        /// <returns>不包括全国的城市表缓存</returns>
        public static DataView GetCityCache()
        {
            DataView dvCity = GetAllCityCache();
            if (dvCity != null) dvCity.RowFilter = "city_Id > 0";
            return dvCity;
        }
        #endregion

        #region 获得包括全国的城市表缓存的方法
        /// <summary>
        /// 获得包括全国的城市表缓存的方法
        /// </summary>
        /// <returns>包括全国的城市表缓存</returns>
        public static DataView GetAllCityCache()
        {
            string sql = "select city_Id,city_Name,pvc_Id from City";
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "City");
            DataView dvCity = cache.GetDataCache("Ucar_City");
            if (dvCity != null) dvCity.RowFilter = "";
            return dvCity;
        }
        #endregion

        #region 获得不包括全国的省份表缓存的方法
        /// <summary>
        /// 获得不包括全国的省份表缓存的方法
        /// </summary>
        /// <returns>不包括全国的省份表缓存</returns>
        public static DataView GetProvinceCache()
        {
            DataView dvProvince = GetAllProvinceCache();
            if (dvProvince != null) dvProvince.RowFilter = "pvc_Id > 0";
            return dvProvince;
        }
        #endregion

        #region 获得包括全国的省份表缓存的方法
        /// <summary>
        /// 获得包括全国的省份表缓存的方法
        /// </summary>
        /// <returns>包括全国的省份表缓存</returns>
        public static DataView GetAllProvinceCache()
        {
            string sql = "select pvc_Id,pvc_Name from Province";
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Province");
            DataView dvProvince = cache.GetDataCache("Ucar_Province");
            if (dvProvince != null) dvProvince.RowFilter = "";
            return dvProvince;
        }
        #endregion

        //********************************************

        //********************************************
        //2007-10-18新加入的获取缓存的方法

        #region 根据城市ID获得包括全国的城市表缓存的方法
        /// <summary>
        /// 根据城市ID获得包括全国的城市表缓存的方法
        /// </summary>
        /// <param name="objCityId">城市ID</param>
        /// <returns>包括全国的城市表缓存</returns>
        public static DataView GetAllCityCacheByCityId(object objCityId)
        {
            int cityId = ConvertHelper.GetInteger(objCityId);
            string sql = string.Concat("select * from City where city_Id=", cityId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "City");
            return cache.GetDataCache(string.Concat("Ucar_City_CityId_", cityId));
        }
        #endregion

        #region 根据省份ID获得包括全国的城市表缓存的方法
        /// <summary>
        /// 根据城市ID获得包括全国的城市表缓存的方法
        /// </summary>
        /// <param name="objCityId">省份ID</param>
        /// <returns>包括全国的城市表缓存</returns>
        public static DataView GetCityCacheByProvinceId(object objProvinceId)
        {
            int provinceId = ConvertHelper.GetInteger(objProvinceId);
            string sql = string.Concat("select * from City where pvc_Id=", provinceId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "City");
            return cache.GetDataCache(string.Concat("Ucar_City_ProvinceId_", provinceId));
        }
        #endregion

        #region 根据省份ID获得包括全国的省份表缓存的方法
        /// <summary>
        /// 根据省份ID获得包括全国的省份表缓存的方法
        /// </summary>
        /// <param name="objProvinceId">省份ID</param>
        /// <returns>包括全国的省份表缓存</returns>
        public static DataView GetAllProvinceCacheByProvinceId(object objProvinceId)
        {
            int provinceId = ConvertHelper.GetInteger(objProvinceId);
            string sql = string.Concat("select * from Province where pvc_Id=", provinceId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Province");
            return cache.GetDataCache(string.Concat("Ucar_Province_ProvinceId_", provinceId));
        }
        #endregion

        //********************************************

        #region 根据城市ID取城市名称的方法
        /// <summary>
        /// 根据城市ID取城市名称的方法
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <returns>城市名称</returns>
        public static string GetCityNameByCityId(object objCityId)
        {
            DataView dvCity = GetAllCityCacheByCityId(objCityId);
            if (dvCity != null)
            {
                if (dvCity.Count > 0)
                    return ConvertHelper.GetString(dvCity[0]["city_Name"]);
                else
                    return "";
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 根据城市ID取省份ID的方法
        /// <summary>
        /// 根据城市ID取省份ID的方法
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <returns>省份ID</returns>
        public static int GetProvinceIdByCityId(object objCityId)
        {
            DataView dvCity = GetAllCityCacheByCityId(objCityId);
            if (dvCity != null)
            {
                if (dvCity.Count > 0)
                    return ConvertHelper.GetInteger(dvCity[0]["pvc_Id"]);
                else
                    return -1;
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region 根据省份ID取省份名称的方法
        /// <summary>
        /// 根据省份ID取省份名称的方法
        /// </summary>
        /// <param name="provinceId">省份ID</param>
        /// <returns>省份名称</returns>
        public static string GetProvinceNameByProvinceId(object objProvinceId)
        {
            DataView dvProvince = GetAllProvinceCacheByProvinceId(objProvinceId);
            if (dvProvince != null)
            {
                if (dvProvince.Count > 0)
                    return ConvertHelper.GetString(dvProvince[0]["pvc_Name"]);
                else
                    return "";
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 根据城市ID取省份名称的方法
        /// <summary>
        /// 根据城市ID取省份名称的方法
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <returns>省份名称</returns>
        public static string GetProvinceNameByCityId(object objCityId)
        {
            int provinceId = GetProvinceIdByCityId(objCityId);
            return GetProvinceNameByProvinceId(provinceId);
        }
        #endregion

        #region 根据城市ID取省份城市名称的方法
        /// <summary>
        /// 根据城市ID取省份城市名称的方法
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <returns>省份城市名称</returns>
        public static string GetFullCityNameByCityId(object objCityId)
        {
            return GetFullCityNameByCityId(objCityId, " ");
        }
        /// <summary>
        /// 根据城市ID取省份城市名称的方法
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <param name="seperator">自定义分隔符</param>
        /// <returns>省份城市名称</returns>
        public static string GetFullCityNameByCityId(object objCityId, string seperator)
        {
            string cityName = GetCityNameByCityId(objCityId);
            string provinceName = GetProvinceNameByCityId(objCityId);
            return string.Concat(provinceName, seperator, cityName);
        }
        #endregion

        #region 根据省份ID取当前省份下所有城市ID的方法
        /// <summary>
        /// 根据省份ID取当前省份下所有城市ID的方法
        /// </summary>
        /// <param name="objProvinceId">省份ID</param>
        /// <returns>当前省份下所有城市ID</returns>
        public static string GetCityIDsByProvinceID(object objProvinceId)
        {
            DataView dvCity = GetCityCacheByProvinceId(objProvinceId);
            if (dvCity != null)
            {
                string ids = "";
                for (int i = 0; i < dvCity.Count; i++)
                {
                    int cityId = ConvertHelper.GetInteger(dvCity[i]["city_Id"]);
                    if (cityId > 0)
                        ids += cityId + ",";
                }
                return ids.TrimEnd(new char[] { ',' });
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
