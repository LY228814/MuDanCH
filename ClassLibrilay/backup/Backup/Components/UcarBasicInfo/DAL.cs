using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Ucar.BaseClass;
using Ucar.Common;

namespace Ucar.Components.UcarBasicInfo
{
    /// <summary>
    /// 数据访问类UcarBasicInfoDM。
    /// </summary>
    internal class UcarBasicInfoDM : IUcarBasicInfoDM
    {
        private string m_connectionString = ConfigHelper.GetConnectionString("Ucar");

        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UcarBasicInfoDS model, SqlConnection conn, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UcarBasicInfo(");
            strSql.Append("UcarSerialNumber,CarID,UserID,UcarType,Color,VinCode,BuyCarDate,LicenseLocation,UcarLocation,DrivingMileage,SaleWithLicense,CarType,MaintainRecord,ExamineExpireDate,InsuranceExpireDate,TollExpireDate,StateDescription,CardCode,CardRangeID,Source,CreateTime,StatusModifyTime,UcarStatus,UserType,IsAuthenticated,SystemId)");
            strSql.Append(" values (");
            strSql.Append("@UcarSerialNumber,@CarID,@UserID,@UcarType,@Color,@VinCode,@BuyCarDate,@LicenseLocation,@UcarLocation,@DrivingMileage,@SaleWithLicense,@CarType,@MaintainRecord,@ExamineExpireDate,@InsuranceExpireDate,@TollExpireDate,@StateDescription,@CardCode,@CardRangeID,@Source,@CreateTime,@StatusModifyTime,@UcarStatus,@UserType,@IsAuthenticated,@SystemId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarSerialNumber", SqlDbType.VarChar,20),
					new SqlParameter("@CarID", SqlDbType.BigInt,8),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UcarType", SqlDbType.Int,4),
					new SqlParameter("@Color", SqlDbType.NVarChar,10),
					new SqlParameter("@VinCode", SqlDbType.VarChar,50),
					new SqlParameter("@BuyCarDate", SqlDbType.DateTime),
					new SqlParameter("@LicenseLocation", SqlDbType.Int,4),
					new SqlParameter("@UcarLocation", SqlDbType.Int,4),
					new SqlParameter("@DrivingMileage", SqlDbType.Int,4),
					new SqlParameter("@SaleWithLicense", SqlDbType.Int,4),
					new SqlParameter("@CarType", SqlDbType.Int,4),
					new SqlParameter("@MaintainRecord", SqlDbType.Int,4),
                    new SqlParameter("@ExamineExpireDate", SqlDbType.DateTime),
					new SqlParameter("@InsuranceExpireDate", SqlDbType.DateTime),
					new SqlParameter("@TollExpireDate", SqlDbType.DateTime),
					new SqlParameter("@StateDescription", SqlDbType.NVarChar),
					new SqlParameter("@CardCode", SqlDbType.VarChar,200),
                    new SqlParameter("@CardRangeID", SqlDbType.Int,4),
					new SqlParameter("@Source", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@StatusModifyTime", SqlDbType.DateTime),
					new SqlParameter("@UcarStatus", SqlDbType.Int,4),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@IsAuthenticated", SqlDbType.Int,4),
                    new SqlParameter("@SystemId", SqlDbType.Int,4)};
            parameters[0].Value = model.UcarSerialNumber;
            parameters[1].Value = model.CarID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UcarType;
            parameters[4].Value = model.Color;
            parameters[5].Value = model.VinCode;
            parameters[6].Value = model.BuyCarDate;
            if (model.BuyCarDate == DateTime.MinValue) parameters[6].Value = DBNull.Value;
            parameters[7].Value = model.LicenseLocation;
            parameters[8].Value = model.UcarLocation;
            parameters[9].Value = model.DrivingMileage;
            parameters[10].Value = model.SaleWithLicense;
            parameters[11].Value = model.CarType;
            parameters[12].Value = model.MaintainRecord;
            parameters[13].Value = model.ExamineExpireDate;
            if (model.ExamineExpireDate == DateTime.MinValue) parameters[13].Value = DBNull.Value;
            parameters[14].Value = model.InsuranceExpireDate;
            if (model.InsuranceExpireDate == DateTime.MinValue) parameters[14].Value = DBNull.Value;
            parameters[15].Value = model.TollExpireDate;
            if (model.TollExpireDate == DateTime.MinValue) parameters[15].Value = DBNull.Value;
            parameters[16].Value = model.StateDescription;
            parameters[17].Value = model.CardCode;
            parameters[18].Value = model.CardRangeID;
            parameters[19].Value = model.Source;
            parameters[20].Value = model.CreateTime;
            if (model.CreateTime == DateTime.MinValue) parameters[20].Value = DBNull.Value;
            parameters[21].Value = model.StatusModifyTime;
            if (model.StatusModifyTime == DateTime.MinValue) parameters[21].Value = DBNull.Value;
            parameters[22].Value = model.UcarStatus;
            parameters[23].Value = model.UserType;
            parameters[24].Value = model.IsAuthenticated;
            parameters[25].Value = model.SystemId;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), conn, trans, parameters);
            return ConvertHelper.GetInteger(obj);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(UcarBasicInfoDS model, SqlConnection conn, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UcarBasicInfo set ");
            strSql.Append("UcarSerialNumber=@UcarSerialNumber,");
            strSql.Append("CarID=@CarID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Color=@Color,");
            strSql.Append("VinCode=@VinCode,");
            strSql.Append("BuyCarDate=@BuyCarDate,");
            strSql.Append("LicenseLocation=@LicenseLocation,");
            strSql.Append("UcarLocation=@UcarLocation,");
            strSql.Append("DrivingMileage=@DrivingMileage,");
            strSql.Append("SaleWithLicense=@SaleWithLicense,");
            strSql.Append("CarType=@CarType,");
            strSql.Append("MaintainRecord=@MaintainRecord,");
            strSql.Append("ExamineExpireDate=@ExamineExpireDate,");
            strSql.Append("InsuranceExpireDate=@InsuranceExpireDate,");
            strSql.Append("TollExpireDate=@TollExpireDate,");
            strSql.Append("StateDescription=@StateDescription,");
            strSql.Append("CardCode=@CardCode,");
            strSql.Append("CardRangeID=@CardRangeID,");
            strSql.Append("Source=@Source,");
            //strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("StatusModifyTime=@StatusModifyTime,");
            strSql.Append("UcarStatus=@UcarStatus,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("IsAuthenticated=@IsAuthenticated");
            strSql.Append(" where UcarID=@UcarID");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarID", SqlDbType.Int,4),
					new SqlParameter("@UcarSerialNumber", SqlDbType.VarChar,20),
					new SqlParameter("@CarID", SqlDbType.BigInt,8),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UcarType", SqlDbType.Int,4),
					new SqlParameter("@Color", SqlDbType.NVarChar,10),
					new SqlParameter("@VinCode", SqlDbType.VarChar,50),
					new SqlParameter("@BuyCarDate", SqlDbType.DateTime),
					new SqlParameter("@LicenseLocation", SqlDbType.Int,4),
					new SqlParameter("@UcarLocation", SqlDbType.Int,4),
					new SqlParameter("@DrivingMileage", SqlDbType.Int,4),
					new SqlParameter("@SaleWithLicense", SqlDbType.Int,4),
					new SqlParameter("@CarType", SqlDbType.Int,4),
					new SqlParameter("@MaintainRecord", SqlDbType.Int,4),
                    new SqlParameter("@ExamineExpireDate", SqlDbType.DateTime),
					new SqlParameter("@InsuranceExpireDate", SqlDbType.DateTime),
					new SqlParameter("@TollExpireDate", SqlDbType.DateTime),
					new SqlParameter("@StateDescription", SqlDbType.NVarChar),
					new SqlParameter("@CardCode", SqlDbType.VarChar,200),
                    new SqlParameter("@CardRangeID", SqlDbType.Int,4),
					new SqlParameter("@Source", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@StatusModifyTime", SqlDbType.DateTime),
					new SqlParameter("@UcarStatus", SqlDbType.Int,4),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@IsAuthenticated", SqlDbType.Int,4)};
            parameters[0].Value = model.UcarID;
            parameters[1].Value = model.UcarSerialNumber;
            parameters[2].Value = model.CarID;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.UcarType;
            parameters[5].Value = model.Color;
            parameters[6].Value = model.VinCode;
            parameters[7].Value = model.BuyCarDate;
            if (model.BuyCarDate == DateTime.MinValue) parameters[7].Value = DBNull.Value;
            parameters[8].Value = model.LicenseLocation;
            parameters[9].Value = model.UcarLocation;
            parameters[10].Value = model.DrivingMileage;
            parameters[11].Value = model.SaleWithLicense;
            parameters[12].Value = model.CarType;
            parameters[13].Value = model.MaintainRecord;
            parameters[14].Value = model.ExamineExpireDate;
            if (model.ExamineExpireDate == DateTime.MinValue) parameters[14].Value = DBNull.Value;
            parameters[15].Value = model.InsuranceExpireDate;
            if (model.InsuranceExpireDate == DateTime.MinValue) parameters[15].Value = DBNull.Value;
            parameters[16].Value = model.TollExpireDate;
            if (model.TollExpireDate == DateTime.MinValue) parameters[16].Value = DBNull.Value;
            parameters[17].Value = model.StateDescription;
            parameters[18].Value = model.CardCode;
            parameters[19].Value = model.CardRangeID;
            parameters[20].Value = model.Source;
            parameters[21].Value = model.CreateTime;
            if (model.CreateTime == DateTime.MinValue) parameters[21].Value = DBNull.Value;
            parameters[22].Value = model.StatusModifyTime;
            if (model.StatusModifyTime == DateTime.MinValue) parameters[22].Value = DBNull.Value;
            parameters[23].Value = model.UcarStatus;
            parameters[24].Value = model.UserType;
            parameters[25].Value = model.IsAuthenticated;

            DbHelperSQL.ExecuteSql(strSql.ToString(), conn, trans, parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UcarBasicInfoDS GetModel(int UcarID)
        {
            return GetModel(UcarID, m_connectionString);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UcarBasicInfoDS GetModel(int UcarID, string connenctionString)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from UcarBasicInfo ");
            strSql.Append(" where UcarID=@UcarID");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarID", SqlDbType.Int,4)};
            parameters[0].Value = UcarID;
            UcarBasicInfoDS model = new UcarBasicInfoDS();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), connenctionString, parameters);
            model.UcarID = UcarID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UcarSerialNumber = ds.Tables[0].Rows[0]["UcarSerialNumber"].ToString();
                if (ds.Tables[0].Rows[0]["CarID"].ToString() != "")
                {
                    model.CarID = long.Parse(ds.Tables[0].Rows[0]["CarID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UcarType"].ToString() != "")
                {
                    model.UcarType = int.Parse(ds.Tables[0].Rows[0]["UcarType"].ToString());
                }
                model.Color = ds.Tables[0].Rows[0]["Color"].ToString();
                model.VinCode = ds.Tables[0].Rows[0]["VinCode"].ToString();
                if (ds.Tables[0].Rows[0]["BuyCarDate"].ToString() != "")
                {
                    try
                    {
                        model.BuyCarDate = DateTime.Parse(ds.Tables[0].Rows[0]["BuyCarDate"].ToString());
                    }
                    catch
                    {
                        LogHelper.ErrorLog(new Exception("BuyCarDate转换错误：" + ds.Tables[0].Rows[0]["BuyCarDate"].ToString()));
                    }
                }
                if (ds.Tables[0].Rows[0]["LicenseLocation"].ToString() != "")
                {
                    model.LicenseLocation = int.Parse(ds.Tables[0].Rows[0]["LicenseLocation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UcarLocation"].ToString() != "")
                {
                    model.UcarLocation = int.Parse(ds.Tables[0].Rows[0]["UcarLocation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DrivingMileage"].ToString() != "")
                {
                    model.DrivingMileage = int.Parse(ds.Tables[0].Rows[0]["DrivingMileage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SaleWithLicense"].ToString() != "")
                {
                    model.SaleWithLicense = int.Parse(ds.Tables[0].Rows[0]["SaleWithLicense"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CarType"].ToString() != "")
                {
                    model.CarType = int.Parse(ds.Tables[0].Rows[0]["CarType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaintainRecord"].ToString() != "")
                {
                    model.MaintainRecord = int.Parse(ds.Tables[0].Rows[0]["MaintainRecord"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExamineExpireDate"].ToString() != "")
                {
                    model.ExamineExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExamineExpireDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InsuranceExpireDate"].ToString() != "")
                {
                    model.InsuranceExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["InsuranceExpireDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TollExpireDate"].ToString() != "")
                {
                    model.TollExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["TollExpireDate"].ToString());
                }
                model.StateDescription = ds.Tables[0].Rows[0]["StateDescription"].ToString();
                model.CardCode = ds.Tables[0].Rows[0]["CardCode"].ToString();
                if (ds.Tables[0].Rows[0]["CardRangeID"].ToString() != "")
                {
                    model.CardRangeID = int.Parse(ds.Tables[0].Rows[0]["CardRangeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Source"].ToString() != "")
                {
                    model.Source = int.Parse(ds.Tables[0].Rows[0]["Source"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StatusModifyTime"].ToString() != "")
                {
                    model.StatusModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["StatusModifyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UcarStatus"].ToString() != "")
                {
                    model.UcarStatus = int.Parse(ds.Tables[0].Rows[0]["UcarStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsAuthenticated"].ToString() != "")
                {
                    model.IsAuthenticated = int.Parse(ds.Tables[0].Rows[0]["IsAuthenticated"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SystemId"].ToString() != "")
                {
                    model.SystemId = int.Parse(ds.Tables[0].Rows[0]["SystemId"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }

    /// <summary>
	/// 数据访问类UcarRefitInfoDM。
	/// </summary>
    internal class UcarRefitInfoDM : IUcarRefitInfoDM
    {
        private string m_connectionString = ConfigHelper.GetConnectionString("Ucar");

        #region 成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UcarRefitInfoDS model, SqlConnection conn, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UcarRefitInfo(");
            strSql.Append("UcarID,Stereo,Seat,Lighting,Tire,Chassis,Power)");
            strSql.Append(" values (");
            strSql.Append("@UcarID,@Stereo,@Seat,@Lighting,@Tire,@Chassis,@Power)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UcarID", SqlDbType.Int,4),
                    new SqlParameter("@Stereo", SqlDbType.NVarChar,50),
                    new SqlParameter("@Seat", SqlDbType.NVarChar,50),
                    new SqlParameter("@Lighting", SqlDbType.NVarChar,50),
                    new SqlParameter("@Tire", SqlDbType.NVarChar,50),
                    new SqlParameter("@Chassis", SqlDbType.NVarChar,50),
                    new SqlParameter("@Power", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UcarID;
            parameters[1].Value = model.Stereo;
            parameters[2].Value = model.Seat;
            parameters[3].Value = model.Lighting;
            parameters[4].Value = model.Tire;
            parameters[5].Value = model.Chassis;
            parameters[6].Value = model.Power;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), conn, trans, parameters);
            return ConvertHelper.GetInteger(obj);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(UcarRefitInfoDS model, SqlConnection conn, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UcarRefitInfo set ");
            strSql.Append("Stereo=@Stereo,");
            strSql.Append("Seat=@Seat,");
            strSql.Append("Lighting=@Lighting,");
            strSql.Append("Tire=@Tire,");
            strSql.Append("Chassis=@Chassis,");
            strSql.Append("Power=@Power");
            strSql.Append(" where UcarID=@UcarID");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarID", SqlDbType.Int,4),
					new SqlParameter("@Stereo", SqlDbType.NVarChar,50),
					new SqlParameter("@Seat", SqlDbType.NVarChar,50),
					new SqlParameter("@Lighting", SqlDbType.NVarChar,50),
					new SqlParameter("@Tire", SqlDbType.NVarChar,50),
					new SqlParameter("@Chassis", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UcarID;
            parameters[1].Value = model.Stereo;
            parameters[2].Value = model.Seat;
            parameters[3].Value = model.Lighting;
            parameters[4].Value = model.Tire;
            parameters[5].Value = model.Chassis;
            parameters[6].Value = model.Power;

            DbHelperSQL.ExecuteSql(strSql.ToString(), conn, trans, parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UcarRefitInfoDS GetModel(int UriID)
        {
            return GetModel(UriID, m_connectionString);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UcarRefitInfoDS GetModel(int UcarID, string connectionString)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from UcarRefitInfo ");
            strSql.Append(" where UcarID=@UcarID");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarID", SqlDbType.Int,4)};
            parameters[0].Value = UcarID;
            UcarRefitInfoDS model = new UcarRefitInfoDS();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), connectionString, parameters);
            model.UcarID = UcarID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UriID"].ToString() != "")
                {
                    model.UriID = int.Parse(ds.Tables[0].Rows[0]["UriID"].ToString());
                }
                model.Stereo = ds.Tables[0].Rows[0]["Stereo"].ToString();
                model.Seat = ds.Tables[0].Rows[0]["Seat"].ToString();
                model.Lighting = ds.Tables[0].Rows[0]["Lighting"].ToString();
                model.Tire = ds.Tables[0].Rows[0]["Tire"].ToString();
                model.Chassis = ds.Tables[0].Rows[0]["Chassis"].ToString();
                model.Power = ds.Tables[0].Rows[0]["Power"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }

    /// <summary>
	/// 数据访问类SaleIntendInfoDM。
	/// </summary>
    internal class SaleIntendInfoDM : ISaleIntendInfoDM
    {
        private string m_connectionString = ConfigHelper.GetConnectionString("Ucar");

        #region 成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SaleIntendInfoDS model, SqlConnection conn, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SaleIntendInfo(");
            strSql.Append("UcarID,IntendSalePrice,CanDiscuss,TransferNewCar,TransferCarBrand1,TransferCarBrand2,UcarValidity,AcceptDetection,IsReasonable,OpenMobile)");
            strSql.Append(" values (");
            strSql.Append("@UcarID,@IntendSalePrice,@CanDiscuss,@TransferNewCar,@TransferCarBrand1,@TransferCarBrand2,@UcarValidity,@AcceptDetection,@IsReasonable,@OpenMobile)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarID", SqlDbType.Int,4),
					new SqlParameter("@IntendSalePrice", SqlDbType.Decimal,9),
					new SqlParameter("@CanDiscuss", SqlDbType.Int,4),
					new SqlParameter("@TransferNewCar", SqlDbType.Int,4),
					new SqlParameter("@TransferCarBrand1", SqlDbType.Int,4),
					new SqlParameter("@TransferCarBrand2", SqlDbType.Int,4),
					new SqlParameter("@UcarValidity", SqlDbType.Int,4),
					new SqlParameter("@AcceptDetection", SqlDbType.Int,4),
					new SqlParameter("@IsReasonable", SqlDbType.Int,4),
					new SqlParameter("@OpenMobile", SqlDbType.Int,4)};
            parameters[0].Value = model.UcarID;
            parameters[1].Value = model.IntendSalePrice;
            parameters[2].Value = model.CanDiscuss;
            parameters[3].Value = model.TransferNewCar;
            parameters[4].Value = model.TransferCarBrand1;
            parameters[5].Value = model.TransferCarBrand2;
            parameters[6].Value = model.UcarValidity;
            parameters[7].Value = model.AcceptDetection;
            parameters[8].Value = model.IsReasonable;
            parameters[9].Value = model.OpenMobile;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), conn, trans, parameters);
            return ConvertHelper.GetInteger(obj);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(SaleIntendInfoDS model, SqlConnection conn, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SaleIntendInfo set ");
            strSql.Append("IntendSalePrice=@IntendSalePrice,");
            strSql.Append("CanDiscuss=@CanDiscuss,");
            strSql.Append("TransferNewCar=@TransferNewCar,");
            strSql.Append("TransferCarBrand1=@TransferCarBrand1,");
            strSql.Append("TransferCarBrand2=@TransferCarBrand2,");
            strSql.Append("UcarValidity=@UcarValidity,");
            strSql.Append("AcceptDetection=@AcceptDetection,");
            strSql.Append("IsReasonable=@IsReasonable,");
            strSql.Append("OpenMobile=@OpenMobile");
            strSql.Append(" where UcarID=@UcarID");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarID", SqlDbType.Int,4),
					new SqlParameter("@IntendSalePrice", SqlDbType.Decimal,9),
					new SqlParameter("@CanDiscuss", SqlDbType.Int,4),
					new SqlParameter("@TransferNewCar", SqlDbType.Int,4),
					new SqlParameter("@TransferCarBrand1", SqlDbType.Int,4),
					new SqlParameter("@TransferCarBrand2", SqlDbType.Int,4),
					new SqlParameter("@UcarValidity", SqlDbType.Int,4),
					new SqlParameter("@AcceptDetection", SqlDbType.Int,4),
					new SqlParameter("@IsReasonable", SqlDbType.Int,4),
					new SqlParameter("@OpenMobile", SqlDbType.Int,4)};
            parameters[0].Value = model.UcarID;
            parameters[1].Value = model.IntendSalePrice;
            parameters[2].Value = model.CanDiscuss;
            parameters[3].Value = model.TransferNewCar;
            parameters[4].Value = model.TransferCarBrand1;
            parameters[5].Value = model.TransferCarBrand2;
            parameters[6].Value = model.UcarValidity;
            parameters[7].Value = model.AcceptDetection;
            parameters[8].Value = model.IsReasonable;
            parameters[9].Value = model.OpenMobile;

            DbHelperSQL.ExecuteSql(strSql.ToString(), conn, trans, parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SaleIntendInfoDS GetModel(int UcarID)
        {
            return GetModel(UcarID, m_connectionString);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SaleIntendInfoDS GetModel(int UcarID, string connectionString)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SaleIntendInfo ");
            strSql.Append(" where UcarID=@UcarID");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarID", SqlDbType.Int,4)};
            parameters[0].Value = UcarID;
            SaleIntendInfoDS model = new SaleIntendInfoDS();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), connectionString, parameters);
            model.UcarID = UcarID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SiiID"].ToString() != "")
                {
                    model.SiiID = int.Parse(ds.Tables[0].Rows[0]["SiiID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IntendSalePrice"].ToString() != "")
                {
                    model.IntendSalePrice = decimal.Parse(ds.Tables[0].Rows[0]["IntendSalePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CanDiscuss"].ToString() != "")
                {
                    model.CanDiscuss = int.Parse(ds.Tables[0].Rows[0]["CanDiscuss"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TransferNewCar"].ToString() != "")
                {
                    model.TransferNewCar = int.Parse(ds.Tables[0].Rows[0]["TransferNewCar"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TransferCarBrand1"].ToString() != "")
                {
                    model.TransferCarBrand1 = int.Parse(ds.Tables[0].Rows[0]["TransferCarBrand1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TransferCarBrand2"].ToString() != "")
                {
                    model.TransferCarBrand2 = int.Parse(ds.Tables[0].Rows[0]["TransferCarBrand2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UcarValidity"].ToString() != "")
                {
                    model.UcarValidity = int.Parse(ds.Tables[0].Rows[0]["UcarValidity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AcceptDetection"].ToString() != "")
                {
                    model.AcceptDetection = int.Parse(ds.Tables[0].Rows[0]["AcceptDetection"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsReasonable"].ToString() != "")
                {
                    model.IsReasonable = int.Parse(ds.Tables[0].Rows[0]["IsReasonable"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OpenMobile"].ToString() != "")
                {
                    model.OpenMobile = int.Parse(ds.Tables[0].Rows[0]["OpenMobile"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }

    /// <summary>
	/// 数据访问类UcarPictureInfoDM。
	/// </summary>
    internal class UcarPictureInfoDM : IUcarPictureInfoDM
    {
        private string m_connectionString = ConfigHelper.GetConnectionString("Ucar");

        #region 成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UcarPictureInfoDS model, SqlConnection conn, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UcarPictureInfo(");
            strSql.Append("UcarID,PicturePath)");
            strSql.Append(" values (");
            strSql.Append("@UcarID,@PicturePath)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarID", SqlDbType.Int,4),
					new SqlParameter("@PicturePath", SqlDbType.VarChar,100)};
            parameters[0].Value = model.UcarID;
            parameters[1].Value = model.PicturePath;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), conn, trans, parameters);
            return ConvertHelper.GetInteger(obj);
        }

        /// <summary>
        /// 删除若干条数据
        /// </summary>
        public void Delete(int UcarID, SqlConnection conn, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete UcarPictureInfo ");
            strSql.Append(" where UcarID=@UcarID");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarID", SqlDbType.Int,4)
				};
            parameters[0].Value = UcarID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), conn, trans, parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int UcarID)
        {
            return GetList(UcarID, m_connectionString);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int UcarID, string connectionString)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [PicturePath] ");
            strSql.Append(" FROM UcarPictureInfo ");
            strSql.Append(" where [UcarID]=" + UcarID);
            return DbHelperSQL.Query(strSql.ToString(), connectionString);
        }
        #endregion
    }

    /// <summary>
    /// 车商通临时数据访问类
    /// </summary>
    internal class TranstarTempDM
    {
        private string m_connectionString = ConfigHelper.GetConnectionString("Ucar");

        #region 成员方法
        /// <summary>
        /// 获得车商通经销商在优卡的ID的方法
        /// </summary>
        public int GetUcarVendorID(int tvID, int cgID)
        {
            return GetUcarVendorID(tvID, cgID, m_connectionString);
        }
        /// <summary>
        /// 获得车商通经销商在优卡的ID的方法
        /// </summary>
        public int GetUcarVendorID(int tvID, int cgID, string connectionString)
        {
            string sql = "select tvg_Id from Transtar_VendorGroup where tv_Id={0} and cg_Id={1}";
            object obj = DbHelperSQL.GetSingle(string.Format(sql, tvID, cgID), connectionString);
            return ConvertHelper.GetInteger(obj);
        }

        /// <summary>
        /// 获得优卡ID的方法
        /// </summary>
        public int GetUcarID(int ucarSerialNumber, int userID)
        {
            return GetUcarID(ucarSerialNumber, userID, m_connectionString);
        }
        /// <summary>
        /// 获得优卡ID的方法
        /// </summary>
        public int GetUcarID(int ucarSerialNumber, int userID, string connectionString)
        {
            string sql = "select UcarID from UcarBasicInfo where UcarSerialNumber='{0}' and UserID={1} and UcarType=2";
            object obj = DbHelperSQL.GetSingle(string.Format(sql, ucarSerialNumber, userID), connectionString);
            return ConvertHelper.GetInteger(obj);
        }
        #endregion
    }
}
