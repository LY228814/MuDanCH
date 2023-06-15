using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using KangHui.Common;

namespace KangHui.Components.UcarBasicInfo
{
    /// <summary>
    /// 业务逻辑类BLL 的摘要说明。
    /// </summary>
    public class BLL
    {
        private static readonly IUcarBasicInfoDM dalUcarBasicInfo = DALFactory.CreateUcarBasicInfo();
        private static readonly IUcarRefitInfoDM dalUcarRefitInfo = DALFactory.CreateUcarRefitInfo();
        private static readonly ISaleIntendInfoDM dalSaleIntendInfo = DALFactory.CreateSaleIntendInfo();
        private static readonly IUcarPictureInfoDM dalUcarPictureInfo = DALFactory.CreateUcarPictureInfo();
        private static readonly TranstarTempDM dalTranstarTemp = new TranstarTempDM();

        #region 用事务添加优卡车源的方法
        /// <summary>
        /// 用事务添加优卡车源的方法
        /// </summary>
        /// <param name="modelUcarBasicInfo">车源基本信息表的实体类</param>
        /// <param name="modelUcarRefitInfo">车源改装信息表的实体类</param>
        /// <param name="modelSaleIntendInfo">销售意向信息表的实体类</param>
        /// <param name="modelUcarPictureInfos">车源图片信息表的实体类</param>
        /// <returns>添加结果</returns>
        public static bool AddWithTransaction(UcarBasicInfoDS modelUcarBasicInfo, UcarRefitInfoDS modelUcarRefitInfo, SaleIntendInfoDS modelSaleIntendInfo, List<UcarPictureInfoDS> modelUcarPictureInfos)
        {
            int ucarID = 0;
            return AddWithTransaction(modelUcarBasicInfo, modelUcarRefitInfo, modelSaleIntendInfo, modelUcarPictureInfos, ConfigHelper.GetConnectionString("Ucar"), ref ucarID);
        }
        /// <summary>
        /// 用事务添加优卡车源的方法
        /// </summary>
        /// <param name="modelUcarBasicInfo">车源基本信息表的实体类</param>
        /// <param name="modelUcarRefitInfo">车源改装信息表的实体类</param>
        /// <param name="modelSaleIntendInfo">销售意向信息表的实体类</param>
        /// <param name="modelUcarPictureInfos">车源图片信息表的实体类</param>
        /// <param name="ucarID">车源ID</param>
        /// <returns>添加结果</returns>
        public static bool AddWithTransaction(UcarBasicInfoDS modelUcarBasicInfo, UcarRefitInfoDS modelUcarRefitInfo, SaleIntendInfoDS modelSaleIntendInfo, List<UcarPictureInfoDS> modelUcarPictureInfos, ref int ucarID)
        {
            return AddWithTransaction(modelUcarBasicInfo, modelUcarRefitInfo, modelSaleIntendInfo, modelUcarPictureInfos, ConfigHelper.GetConnectionString("Ucar"), ref ucarID);
        }
        /// <summary>
        /// 用事务添加优卡车源的方法
        /// </summary>
        /// <param name="modelUcarBasicInfo">车源基本信息表的实体类</param>
        /// <param name="modelUcarRefitInfo">车源改装信息表的实体类</param>
        /// <param name="modelSaleIntendInfo">销售意向信息表的实体类</param>
        /// <param name="modelUcarPictureInfos">车源图片信息表的实体类</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns>添加结果</returns>
        public static bool AddWithTransaction(UcarBasicInfoDS modelUcarBasicInfo, UcarRefitInfoDS modelUcarRefitInfo, SaleIntendInfoDS modelSaleIntendInfo, List<UcarPictureInfoDS> modelUcarPictureInfos, string connectionString)
        {
            int ucarID = 0;
            return AddWithTransaction(modelUcarBasicInfo, modelUcarRefitInfo, modelSaleIntendInfo, modelUcarPictureInfos, connectionString, ref ucarID);
        }
        /// <summary>
        /// 用事务添加优卡车源的方法
        /// </summary>
        /// <param name="modelUcarBasicInfo">车源基本信息表的实体类</param>
        /// <param name="modelUcarRefitInfo">车源改装信息表的实体类</param>
        /// <param name="modelSaleIntendInfo">销售意向信息表的实体类</param>
        /// <param name="modelUcarPictureInfos">车源图片信息表的实体类</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="ucarID">车源ID</param>
        /// <returns>添加结果</returns>
        public static bool AddWithTransaction(UcarBasicInfoDS modelUcarBasicInfo, UcarRefitInfoDS modelUcarRefitInfo, SaleIntendInfoDS modelSaleIntendInfo, List<UcarPictureInfoDS> modelUcarPictureInfos, string connectionString, ref int ucarID)
        {
            if (modelUcarBasicInfo == null) return false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        ucarID = dalUcarBasicInfo.Add(modelUcarBasicInfo, conn, trans);

                        if (modelUcarRefitInfo == null) modelUcarRefitInfo = new UcarRefitInfoDS();
                        modelUcarRefitInfo.UcarID = ucarID;
                        dalUcarRefitInfo.Add(modelUcarRefitInfo, conn, trans);

                        if (modelSaleIntendInfo == null) modelSaleIntendInfo = new SaleIntendInfoDS();
                        modelSaleIntendInfo.UcarID = ucarID;
                        dalSaleIntendInfo.Add(modelSaleIntendInfo, conn, trans);

                        if (modelUcarPictureInfos != null && modelUcarPictureInfos.Count > 0)
                        {
                            for (int i = 0; i < modelUcarPictureInfos.Count; i++)
                            {
                                if (modelUcarPictureInfos[i] != null)
                                {
                                    modelUcarPictureInfos[i].UcarID = ucarID;
                                    dalUcarPictureInfo.Add(modelUcarPictureInfos[i], conn, trans);
                                }
                            }
                        }

                        trans.Commit();

                        //try
                        //{
                        //    UcarService.CreateHtml service = new UcarService.CreateHtml();
                        //    service.CreateCarInfoTemplate(ucarID);
                        //}
                        //catch (Exception ex)
                        //{
                        //    LogHelper.ErrorLog(ex);
                        //}

                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        LogHelper.ErrorLog(ex);
                        return false;
                    }
                }
            }
        }
        #endregion

        #region 用事务编辑优卡车源的方法
        /// <summary>
        /// 用事务编辑优卡车源的方法
        /// </summary>
        /// <param name="modelUcarBasicInfo">车源基本信息表的实体类</param>
        /// <param name="modelUcarRefitInfo">车源改装信息表的实体类</param>
        /// <param name="modelSaleIntendInfo">销售意向信息表的实体类</param>
        /// <param name="modelUcarPictureInfos">车源图片信息表的实体类</param>
        /// <returns>编辑结果</returns>
        public static bool UpdateWithTransaction(UcarBasicInfoDS modelUcarBasicInfo, UcarRefitInfoDS modelUcarRefitInfo, SaleIntendInfoDS modelSaleIntendInfo, List<UcarPictureInfoDS> modelUcarPictureInfos)
        {
            return UpdateWithTransaction(modelUcarBasicInfo, modelUcarRefitInfo, modelSaleIntendInfo, modelUcarPictureInfos, ConfigHelper.GetConnectionString("Ucar"));
        }
        /// <summary>
        /// 用事务编辑优卡车源的方法
        /// </summary>
        /// <param name="modelUcarBasicInfo">车源基本信息表的实体类</param>
        /// <param name="modelUcarRefitInfo">车源改装信息表的实体类</param>
        /// <param name="modelSaleIntendInfo">销售意向信息表的实体类</param>
        /// <param name="modelUcarPictureInfos">车源图片信息表的实体类</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns>编辑结果</returns>
        public static bool UpdateWithTransaction(UcarBasicInfoDS modelUcarBasicInfo, UcarRefitInfoDS modelUcarRefitInfo, SaleIntendInfoDS modelSaleIntendInfo, List<UcarPictureInfoDS> modelUcarPictureInfos, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        int ucarID = 0;

                        if (modelUcarBasicInfo != null)
                        {
                            ucarID = modelUcarBasicInfo.UcarID;
                            dalUcarBasicInfo.Update(modelUcarBasicInfo, conn, trans);
                        }

                        if (modelUcarRefitInfo != null)
                        {
                            if (ucarID == 0) ucarID = modelUcarRefitInfo.UcarID;
                            dalUcarRefitInfo.Update(modelUcarRefitInfo, conn, trans);
                        }

                        if (modelSaleIntendInfo != null)
                        {
                            if (ucarID == 0) ucarID = modelSaleIntendInfo.UcarID;
                            dalSaleIntendInfo.Update(modelSaleIntendInfo, conn, trans);
                        }

                        if (modelUcarPictureInfos != null && modelUcarPictureInfos.Count > 0)
                        {
                            if (ucarID == 0 & modelUcarPictureInfos[0] != null) ucarID = modelUcarPictureInfos[0].UcarID;
                            dalUcarPictureInfo.Delete(ucarID, conn, trans);

                            for (int i = 0; i < modelUcarPictureInfos.Count; i++)
                            {
                                if (modelUcarPictureInfos[i] != null & modelUcarPictureInfos[i].PicturePath != "")
                                    dalUcarPictureInfo.Add(modelUcarPictureInfos[i], conn, trans);
                            }
                        }

                        trans.Commit();

                        //try
                        //{
                        //    UcarService.CreateHtml service = new UcarService.CreateHtml();
                        //    service.CreateCarInfoTemplate(ucarID);
                        //}
                        //catch (Exception ex)
                        //{
                        //    LogHelper.ErrorLog(ex);
                        //}

                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        LogHelper.ErrorLog(ex);
                        return false;
                    }
                }
            }
        }
        #endregion

        #region 获取实体类的方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UcarBasicInfoDS GetUcarBasicInfoModel(int UcarID)
        {
            return dalUcarBasicInfo.GetModel(UcarID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UcarBasicInfoDS GetUcarBasicInfoModel(int UcarID, string connectionString)
        {
            return dalUcarBasicInfo.GetModel(UcarID, connectionString);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UcarRefitInfoDS GetUcarRefitInfoModel(int UcarID)
        {
            return dalUcarRefitInfo.GetModel(UcarID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UcarRefitInfoDS GetUcarRefitInfoModel(int UcarID, string connectionString)
        {
            return dalUcarRefitInfo.GetModel(UcarID, connectionString);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SaleIntendInfoDS GetSaleIntendInfoModel(int UcarID)
        {
            return dalSaleIntendInfo.GetModel(UcarID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SaleIntendInfoDS GetSaleIntendInfoModel(int UcarID, string connectionString)
        {
            return dalSaleIntendInfo.GetModel(UcarID, connectionString);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetUcarPictureInfoList(int UcarID)
        {
            return dalUcarPictureInfo.GetList(UcarID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetUcarPictureInfoList(int UcarID, string connectionString)
        {
            return dalUcarPictureInfo.GetList(UcarID, connectionString);
        }
        #endregion

        #region 车商通访问优卡临时方法
        /// <summary>
        /// 获得车商通经销商在优卡的ID的方法
        /// </summary>
        public static int GetUcarVendorID(int tvID, int cgID)
        {
            return dalTranstarTemp.GetUcarVendorID(tvID, cgID);
        }
        /// <summary>
        /// 获得车商通经销商在优卡的ID的方法
        /// </summary>
        public static int GetUcarVendorID(int tvID, int cgID, string connectionString)
        {
            return dalTranstarTemp.GetUcarVendorID(tvID, cgID, connectionString);
        }

        /// <summary>
        /// 获得优卡ID的方法
        /// </summary>
        public static int GetUcarID(int ucarSerialNumber, int userID)
        {
            return dalTranstarTemp.GetUcarID(ucarSerialNumber, userID);
        }
        /// <summary>
        /// 获得优卡ID的方法
        /// </summary>
        public static int GetUcarID(int ucarSerialNumber, int userID, string connectionString)
        {
            return dalTranstarTemp.GetUcarID(ucarSerialNumber, userID, connectionString);
        }
        #endregion
    }
}
