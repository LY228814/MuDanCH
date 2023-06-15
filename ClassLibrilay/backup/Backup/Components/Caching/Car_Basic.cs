using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Ucar.BaseClass;
using Ucar.Common;

namespace Ucar.Components.Caching
{
    /// <summary>
    /// 车型相关缓存信息的类
    /// </summary>
    public class Car_Basic
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

        #region 获得车型表可用数据缓存的方法
        /// <summary>
        /// 获得车型表可用数据缓存的方法
        /// </summary>
        /// <returns>车型表可用数据缓存</returns>
        public static DataView GetActiveCar_BasicCache()
        {
            DataView dvCar = GetCar_BasicCache();
            if (dvCar != null) dvCar.RowFilter = "IsState = 1";
            return dvCar;
        }
        #endregion

        #region 获得车型表全部数据缓存的方法
        /// <summary>
        /// 获得车型表全部数据缓存的方法
        /// </summary>
        /// <returns>车型表全部数据缓存</returns>
        public static DataView GetCar_BasicCache()
        {
            string sql = "select car_Id,cs_Id,car_Name,OldCar_Id,IsState from Car_Basic";
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Basic");
            DataView dvCar = cache.GetDataCache("Ucar_CarBasic");
            if (dvCar != null) dvCar.RowFilter = "";
            return dvCar;
        }
        #endregion

        #region 获得品牌表可用数据缓存的方法
        /// <summary>
        /// 获得品牌表可用数据缓存的方法
        /// </summary>
        /// <returns>品牌表可用数据缓存</returns>
        public static DataView GetActiveCar_BrandCache()
        {
            DataView dvBrand = GetCar_BrandCache();
            if (dvBrand != null) dvBrand.RowFilter = "IsState = 1";
            return dvBrand;
        }
        #endregion        

        #region 获得品牌表全部数据缓存的方法
        /// <summary>
        /// 获得品牌表全部数据缓存的方法
        /// </summary>
        /// <returns>品牌表全部数据缓存</returns>
        public static DataView GetCar_BrandCache()
        {
            string sql = "select cs_Id,cb_Id,cs_Name,OldCb_Id,IsState from Car_Serial";
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Serial");
            DataView dvBrand = cache.GetDataCache("Ucar_CarSerial");
            if (dvBrand != null) dvBrand.RowFilter = "";
            return dvBrand;
        }
        #endregion

        #region 获得厂商表可用数据缓存的方法
        /// <summary>
        /// 获得厂商表可用数据缓存的方法
        /// </summary>
        /// <returns>厂商表可用数据缓存</returns>
        public static DataView GetActiveCar_ProducerCache()
        {
            DataView dvProducer = GetCar_ProducerCache();
            if (dvProducer != null) dvProducer.RowFilter = "IsState = 1";
            return dvProducer;
        }
        #endregion

        #region 获得厂商表全部数据缓存的方法
        /// <summary>
        /// 获得厂商表全部数据缓存的方法
        /// </summary>
        /// <returns>厂商表全部数据缓存</returns>
        public static DataView GetCar_ProducerCache()
        {
            string sql = "select cb_Id,cb_Name,OldCs_Id,cp_Country,a.IsState from Car_Brand a inner join Car_Producer b on a.cp_Id=b.cp_Id";
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Brand");
            DataView dvProducer = cache.GetDataCache("Ucar_CarBrand");
            if (dvProducer != null) dvProducer.RowFilter = "";
            return dvProducer;
        }
        #endregion

        #region 获得厂商表国产可用数据缓存的方法
        /// <summary>
        /// 获得厂商表国产可用数据缓存的方法
        /// </summary>
        /// <returns>厂商表国产可用数据缓存</returns>
        public static DataView GetActiveLocalProducerCache()
        {
            DataView dvProducer = GetCar_ProducerCache();
            if (dvProducer != null) dvProducer.RowFilter = "IsState = 1 AND cp_Country='中国'";
            return dvProducer;
        }
        #endregion

        #region 获得厂商表进口可用数据缓存的方法
        /// <summary>
        /// 获得厂商表进口可用数据缓存的方法
        /// </summary>
        /// <returns>厂商表进口可用数据缓存</returns>
        public static DataView GetActiveForeignProducerCache()
        {
            DataView dvProducer = GetCar_ProducerCache();
            if (dvProducer != null) dvProducer.RowFilter = "IsState = 1 AND cp_Country<>'中国'";
            return dvProducer;
        }
        #endregion

        //********************************************

        //********************************************
        //2007-10-18新加入的获取缓存的方法

        #region 根据车型ID获得车型表数据缓存的方法
        /// <summary>
        /// 根据车型ID获得车型表数据缓存的方法
        /// </summary>
        /// <returns>车型表数据缓存</returns>
        public static DataView GetCar_BasicCacheByCarId(object objCarId)
        {
            long carId = ConvertHelper.GetLong(objCarId);
            string sql = string.Concat("select * from Car_Basic where car_Id=", carId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Basic");
            return cache.GetDataCache(string.Concat("Ucar_CarBasic_CarId_", carId));
        }
        #endregion

        #region 根据品牌ID获得车型表数据缓存的方法
        /// <summary>
        /// 根据车型ID获得车型表数据缓存的方法
        /// </summary>
        /// <returns>车型表数据缓存</returns>
        public static DataView GetActiveCar_BasicCacheByBrandId(object objBrandId)
        {
            int brandId = ConvertHelper.GetInteger(objBrandId);
            string sql = string.Concat("select * from Car_Basic where IsState=1 and cs_Id=", brandId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Basic");
            return cache.GetDataCache(string.Concat("Ucar_CarBasic_SerialId_", brandId));
        }
        #endregion

        #region 根据品牌ID获得品牌表数据缓存的方法
        /// <summary>
        /// 根据品牌ID获得品牌表数据缓存的方法
        /// </summary>
        /// <returns>品牌表数据缓存</returns>
        public static DataView GetCar_BrandCacheByBrandId(object objBrandId)
        {
            int brandId = ConvertHelper.GetInteger(objBrandId);
            string sql = string.Concat("select * from Car_Serial where cs_Id=", brandId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Serial");
            return cache.GetDataCache(string.Concat("Ucar_CarBrand_SerialId_", brandId));
        }
        #endregion

        #region 根据厂商ID获得品牌表数据缓存的方法
        /// <summary>
        /// 根据厂商ID获得品牌表数据缓存的方法
        /// </summary>
        /// <returns>品牌表数据缓存</returns>
        public static DataView GetCar_BrandCacheByProducerId(object objProducerId)
        {
            int producerId = ConvertHelper.GetInteger(objProducerId);
            string sql = string.Concat("select * from Car_Serial where IsState=1 and cb_Id=", producerId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Serial");
            return cache.GetDataCache(string.Concat("Ucar_CarBrand_BrandId_", producerId));
        }
        #endregion

        #region 根据厂商ID获得厂商表数据缓存的方法
        /// <summary>
        /// 根据厂商ID获得厂商表数据缓存的方法
        /// </summary>
        /// <returns>厂商表数据缓存</returns>
        public static DataView GetCar_ProducerCacheByProducerId(object objProducerId)
        {
            int producerId = ConvertHelper.GetInteger(objProducerId);
            string sql = string.Concat("select * from Car_Brand where cb_Id=", producerId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Brand");
            return cache.GetDataCache(string.Concat("Ucar_CarProducer_BrandId_", producerId));
        }
        #endregion

        //********************************************

        //********************************************
        //2008-09-03新加入的取所属国家和旧Id的方法

        #region 根据车型Id取所属国家名称的方法
        /// <summary>
        /// 根据车型Id取所属国家名称的方法
        /// </summary>
        /// <param name="objCarId">车型Id</param>
        /// <returns>所属国家名称</returns>
        public static string GetCountryNameByCarId(object objCarId)
        {
            int producerId = GetProducerIdByCarId(objCarId);
            DataView dv = GetCar_ProducerCache();
            if (dv != null)
            {
                dv.RowFilter = "cb_Id=" + producerId.ToString();
                if (dv.Count > 0)
                {
                    return ConvertHelper.GetString(dv[0]["cp_Country"]);
                }
            }
            return string.Empty;
        }
        #endregion

        #region 根据品牌Id取所属国家名称的方法
        /// <summary>
        /// 根据品牌Id取所属国家名称的方法
        /// </summary>
        /// <param name="objBrandId">品牌Id</param>
        /// <returns>所属国家名称</returns>
        public static string GetCountryNameByBrandId(object objBrandId)
        {
            int producerId = GetProducerIdByBrandId(objBrandId);
            DataView dv = GetCar_ProducerCache();
            if (dv != null)
            {
                dv.RowFilter = "cb_Id=" + producerId.ToString();
                if (dv.Count > 0)
                {
                    return ConvertHelper.GetString(dv[0]["cp_Country"]);
                }
            }
            return string.Empty;
        }
        #endregion

        #region 根据厂商Id取所属国家名称的方法
        /// <summary>
        /// 根据厂商Id取所属国家名称的方法
        /// </summary>
        /// <param name="objProducerId">厂商Id</param>
        /// <returns>所属国家名称</returns>
        public static string GetCountryNameByProducerId(object objProducerId)
        {
            int producerId = ConvertHelper.GetInteger(objProducerId);
            DataView dv = GetCar_ProducerCache();
            if (dv != null)
            {
                dv.RowFilter = "cb_Id=" + producerId.ToString();
                if (dv.Count > 0)
                {
                    return ConvertHelper.GetString(dv[0]["cp_Country"]);
                }
            }
            return string.Empty;
        }
        #endregion

        #region 根据新车型ID取老车型ID的方法
        /// <summary>
        /// 根据新车型ID取老车型ID的方法
        /// </summary>
        /// <param name="objCarId">新车型ID</param>
        /// <returns>老车型ID</returns>
        public static long GetOldCarIdByNewCarId(object objCarId)
        {
            DataView dvCar = GetCar_BasicCacheByCarId(objCarId);
            if (dvCar != null)
            {
                if (dvCar.Count > 0)
                {
                    return ConvertHelper.GetLong(dvCar[0]["OldCar_Id"]);
                }
            }
            return 0;
        }
        #endregion

        #region 根据老车型ID取新车型ID的方法
        /// <summary>
        /// 根据老车型ID取新车型ID的方法
        /// </summary>
        /// <param name="objCarId">老车型ID</param>
        /// <returns>新车型ID</returns>
        public static int GetNewCarIdByOldCarId(object objCarId)
        {
            long carId = ConvertHelper.GetLong(objCarId);
            string sql = string.Concat("select car_Id from Car_Basic where OldCar_Id=", carId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Basic");
            DataView dvCar = cache.GetDataCache(string.Concat("Ucar_CarBasic_OldCarId_", carId));
            if (dvCar != null)
            {
                if (dvCar.Count > 0)
                {
                    return ConvertHelper.GetInteger(dvCar[0]["car_Id"]);
                }
            }
            return 0;
        }
        #endregion

        #region 根据新品牌ID取老品牌ID的方法
        /// <summary>
        /// 根据新品牌ID取老品牌ID的方法
        /// </summary>
        /// <param name="objBrandId">新品牌ID</param>
        /// <returns>老品牌ID</returns>
        public static int GetOldBrandIdByNewBrandId(object objBrandId)
        {
            DataView dvBrand = GetCar_BrandCacheByBrandId(objBrandId);
            if (dvBrand != null)
            {
                if (dvBrand.Count > 0)
                {
                    return ConvertHelper.GetInteger(dvBrand[0]["OldCb_Id"]);
                }
            }
            return 0;
        }
        #endregion

        #region 根据老品牌ID取新品牌ID的方法
        /// <summary>
        /// 根据老品牌ID取新品牌ID的方法
        /// </summary>
        /// <param name="objBrandId">老品牌ID</param>
        /// <returns>新品牌ID</returns>
        public static int GetNewBrandIdByOldBrandId(object objBrandId)
        {
            int brandId = ConvertHelper.GetInteger(objBrandId);
            string sql = string.Concat("select cs_Id from Car_Serial where OldCb_Id=", brandId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Serial");
            DataView dvBrand = cache.GetDataCache(string.Concat("Ucar_CarSerial_OldCbId_", brandId));
            if (dvBrand != null)
            {
                if (dvBrand.Count > 0)
                {
                    return ConvertHelper.GetInteger(dvBrand[0]["cs_Id"]);
                }
            }
            return 0;
        }
        #endregion

        #region 根据新厂商ID取旧厂商ID的方法
        /// <summary>
        /// 根据新厂商ID取旧厂商ID的方法
        /// </summary>
        /// <param name="objProducerId">新厂商ID</param>
        /// <returns>旧厂商ID</returns>
        public static int GetOldProducerIdByNewProducerId(object objProducerId)
        {
            int producerId = ConvertHelper.GetInteger(objProducerId);
            string sql = string.Concat("select cb_Id from Car_Brand where OldCs_Id=", producerId);
            DataCache cache = new DataCache(sql, connectionString, databaseEntryName, "Car_Brand");
            DataView dvProducer = cache.GetDataCache(string.Concat("Ucar_CarBrand_OldCsId_", producerId));
            if (dvProducer != null)
            {
                if (dvProducer.Count > 0)
                {
                    return ConvertHelper.GetInteger(dvProducer[0]["OldCs_Id"]);
                }
            }
            return 0;
        }
        #endregion

        #region 根据旧厂商ID取新厂商ID的方法
        /// <summary>
        /// 根据旧厂商ID取新厂商ID的方法
        /// </summary>
        /// <param name="objProducerId">旧厂商ID</param>
        /// <returns>新厂商ID</returns>
        public static int GetNewProducerIdByOldProducerId(object objProducerId)
        {
            DataView dvProducer = GetCar_ProducerCacheByProducerId(objProducerId);
            if (dvProducer != null)
            {
                if (dvProducer.Count > 0)
                {
                    return ConvertHelper.GetInteger(dvProducer[0]["cb_Id"]);
                }
            }
            return 0;
        }
        #endregion

        //********************************************

        #region 根据车型ID取车型名称的方法
        /// <summary>
        /// 根据车型ID取车型名称的方法
        /// </summary>
        /// <param name="objCarId">车型ID</param>
        /// <returns>车型名称</returns>
        public static string GetCarNameByCarId(object objCarId)
        {
            DataView dvCar = GetCar_BasicCacheByCarId(objCarId);
            if (dvCar != null)
            {
                if (dvCar.Count > 0)
                    return ConvertHelper.GetString(dvCar[0]["car_Name"]);
                else
                    return "";
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 根据品牌ID取品牌名称的方法
        /// <summary>
        /// 根据品牌ID取品牌名称的方法
        /// </summary>
        /// <param name="objBrandId">品牌ID</param>
        /// <returns>品牌名称</returns>
        public static string GetBrandNameByBrandId(object objBrandId)
        {
            DataView dvBrand = GetCar_BrandCacheByBrandId(objBrandId);
            if (dvBrand != null)
            {
                if (dvBrand.Count > 0)
                    return ConvertHelper.GetString(dvBrand[0]["cs_Name"]);
                else
                    return "";
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 根据厂商ID取厂商名称的方法
        /// <summary>
        /// 根据厂商ID取厂商名称的方法
        /// </summary>
        /// <param name="objProducerId">厂商ID</param>
        /// <returns>厂商名称</returns>
        public static string GetProducerNameByProducerId(object objProducerId)
        {
            DataView dvProducer = GetCar_ProducerCacheByProducerId(objProducerId);
            if (dvProducer != null)
            {
                if (dvProducer.Count > 0)
                    return ConvertHelper.GetString(dvProducer[0]["cb_Name"]);
                else
                    return "";
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 根据车型ID取品牌ID的方法
        /// <summary>
        /// 根据车型ID取品牌ID的方法
        /// </summary>
        /// <param name="objCarId">车型ID</param>
        /// <returns>品牌ID</returns>
        public static int GetBrandIdByCarId(object objCarId)
        {
            DataView dvCar = GetCar_BasicCacheByCarId(objCarId);
            if (dvCar != null)
            {
                if (dvCar.Count > 0)
                    return ConvertHelper.GetInteger(dvCar[0]["cs_Id"]);
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 根据品牌ID取厂商ID的方法
        /// <summary>
        /// 根据品牌ID取厂商ID的方法
        /// </summary>
        /// <param name="objBrandId">品牌ID</param>
        /// <returns>厂商ID</returns>
        public static int GetProducerIdByBrandId(object objBrandId)
        {
            int brandId = ConvertHelper.GetInteger(objBrandId);
            DataView dvBrand = GetCar_BrandCacheByBrandId(objBrandId);
            if (dvBrand != null)
            {
                if (dvBrand.Count > 0)
                    return ConvertHelper.GetInteger(dvBrand[0]["cb_Id"]);
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 根据车型ID取厂商ID的方法
        /// <summary>
        /// 根据车型ID取厂商ID的方法
        /// </summary>
        /// <param name="objCarId">车型ID</param>
        /// <returns>厂商ID</returns>
        public static int GetProducerIdByCarId(object objCarId)
        {
            int brandId = GetBrandIdByCarId(objCarId);
            return GetProducerIdByBrandId(brandId);
        }
        #endregion

        #region 根据车型ID取品牌名称的方法
        /// <summary>
        /// 根据车型ID取品牌名称的方法
        /// </summary>
        /// <param name="objCarId">车型ID</param>
        /// <returns>品牌名称</returns>
        public static string GetBrandNameByCarId(object objCarId)
        {
            int brandId = GetBrandIdByCarId(objCarId);
            return GetBrandNameByBrandId(brandId);
        }
        #endregion

        #region 根据车型ID取厂商名称的方法
        /// <summary>
        /// 根据车型ID取厂商名称的方法
        /// </summary>
        /// <param name="objCarId">车型ID</param>
        /// <returns>厂商名称</returns>
        public static string GetProducerNameByCarId(object objCarId)
        {
            int producerId = GetProducerIdByCarId(objCarId);
            return GetProducerNameByProducerId(producerId);
        }
        #endregion

        #region 根据车型ID取品牌车型名称的方法
        /// <summary>
        /// 根据车型ID取品牌车型名称的方法
        /// </summary>
        /// <param name="objCarId">车型ID</param>
        /// <returns>品牌车型名称</returns>
        public static string GetBrandCarNameByCarId(object objCarId)
        {
            return GetBrandCarNameByCarId(objCarId, " ");
        }
        /// <summary>
        /// 根据车型ID取品牌车型名称的方法
        /// </summary>
        /// <param name="objCarId">车型ID</param>
        /// <param name="seperator">自定义分隔符</param>
        /// <returns>品牌车型名称</returns>
        public static string GetBrandCarNameByCarId(object objCarId, string seperator)
        {
            string brandName = GetBrandNameByCarId(objCarId);
            string carName = GetCarNameByCarId(objCarId);
            return brandName + seperator + carName;
        }
        #endregion

        #region 根据车型ID取厂商品牌车型名称的方法
        /// <summary>
        /// 根据车型ID取厂商品牌车型名称的方法
        /// </summary>
        /// <param name="objCarId">车型ID</param>
        /// <returns>厂商品牌车型名称</returns>
        public static string GetFullCarNameByCarId(object objCarId)
        {
            return GetFullCarNameByCarId(objCarId, " ");
        }
        /// <summary>
        /// 根据车型ID取厂商品牌车型名称的方法
        /// </summary>
        /// <param name="objCarId">车型ID</param>
        /// <param name="seperator">自定义分隔符</param>
        /// <returns>厂商品牌车型名称</returns>
        public static string GetFullCarNameByCarId(object objCarId, string seperator)
        {
            string producerName = GetProducerNameByCarId(objCarId);
            string brandName = GetBrandNameByCarId(objCarId);
            string carName = GetCarNameByCarId(objCarId);
            return producerName + seperator + brandName + seperator + carName;
        }
        #endregion

        #region 根据品牌ID取厂商名称的方法
        /// <summary>
        /// 根据品牌ID取厂商名称的方法
        /// </summary>
        /// <param name="objBrandId">品牌ID</param>
        /// <returns>厂商名称</returns>
        public static string GetProducerNameByBrandId(object objBrandId)
        {
            int producerId = GetProducerIdByBrandId(objBrandId);
            return GetProducerNameByProducerId(producerId);
        }
        #endregion

        #region 根据品牌ID取厂商品牌名称的方法
        /// <summary>
        /// 根据品牌ID取厂商品牌名称的方法
        /// </summary>
        /// <param name="objBrandId">品牌ID</param>
        /// <returns>厂商品牌名称</returns>
        public static string GetProducerBrandNameByBrandId(object objBrandId)
        {
            return GetProducerBrandNameByBrandId(objBrandId, " ");
        }
        /// <summary>
        /// 根据品牌ID取厂商品牌名称的方法
        /// </summary>
        /// <param name="objBrandId">品牌ID</param>
        /// <param name="seperator">自定义分隔符</param>
        /// <returns>厂商品牌名称</returns>
        public static string GetProducerBrandNameByBrandId(object objBrandId, string seperator)
        {
            string producerName = GetProducerNameByBrandId(objBrandId);
            string brandName = GetBrandNameByBrandId(objBrandId);
            return producerName + seperator + brandName;
        }
        #endregion

        #region 根据厂商ID取当前厂商下所有品牌ID的方法
        /// <summary>
        /// 根据厂商ID取当前厂商下所有品牌ID的方法
        /// </summary>
        /// <param name="objProducerId">厂商ID</param>
        /// <returns>当前厂商下所有品牌ID</returns>
        public static string GetBrandIdsByProducerId(object objProducerId)
        {
            int producerId = ConvertHelper.GetInteger(objProducerId);
            DataView dvBrand = GetActiveCar_BrandCache();
            if (dvBrand != null)
            {
                dvBrand.RowFilter = "cb_Id = " + producerId;
                string ids = "";
                for (int i = 0; i < dvBrand.Count; i++)
                {
                    int brandId = ConvertHelper.GetInteger(dvBrand[i]["cs_Id"]);
                    if (brandId > 0)
                        ids += brandId + ",";
                }
                return ids.TrimEnd(new char[] { ',' });
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 根据品牌ID取当前品牌下所有车型ID的方法
        /// <summary>
        /// 根据品牌ID取当前品牌下所有车型ID的方法
        /// </summary>
        /// <param name="objBrandId">品牌ID</param>
        /// <returns>当前品牌下所有车型ID</returns>
        public static string GetCarIdsByBrandId(object objBrandId)
        {
            int brandId = ConvertHelper.GetInteger(objBrandId);
            DataView dvCar = GetActiveCar_BasicCache();
            if (dvCar != null)
            {
                dvCar.RowFilter = "cs_Id = " + brandId;
                string ids = "";
                for (int i = 0; i < dvCar.Count; i++)
                {
                    long carId = ConvertHelper.GetLong(dvCar[i]["car_Id"]);
                    if (carId > 0)
                        ids += carId + ",";
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
