using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Ucar.BaseClass;
using Ucar.Common;

namespace Ucar.Components.UcarQuote
{
    /// <summary>
    /// 数据访问类UcarQuoteDM。
    /// </summary>
    internal class UcarQuoteDM : IUcarQuoteDM
    {
        private string m_connectionString = ConfigHelper.GetConnectionString("Ucar");

        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UcarQuoteDS model)
        {
            return Add(model, m_connectionString);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UcarQuoteDS model, string connectionString)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UcarQuote(");
            strSql.Append("UcarID,UserID,UserType,QuoteType,QuoterMobile,QuoteAmount,QuoteReason,QuoteTime,QuoteStatus)");
            strSql.Append(" values (");
            strSql.Append("@UcarID,@UserID,@UserType,@QuoteType,@QuoterMobile,@QuoteAmount,@QuoteReason,@QuoteTime,@QuoteStatus)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UcarID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@QuoteType", SqlDbType.Int,4),
					new SqlParameter("@QuoterMobile", SqlDbType.VarChar,20),
					new SqlParameter("@QuoteAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@QuoteReason", SqlDbType.NVarChar,200),
					new SqlParameter("@QuoteTime", SqlDbType.DateTime),
					new SqlParameter("@QuoteStatus", SqlDbType.Int,4),
					new SqlParameter("@CanDiscuss", SqlDbType.Int,4)};
            parameters[0].Value = model.UcarID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserType;
            parameters[3].Value = model.QuoteType;
            parameters[4].Value = model.QuoterMobile;
            parameters[5].Value = model.QuoteAmount;
            parameters[6].Value = model.QuoteReason;
            parameters[7].Value = model.QuoteTime;
            if (model.QuoteTime == DateTime.MinValue) parameters[7].Value = DBNull.Value;
            parameters[8].Value = model.QuoteStatus;
            parameters[9].Value = model.CanDiscuss;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), connectionString, parameters);
            return ConvertHelper.GetInteger(obj);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UcarQuoteDS GetModel(int UqID)
        {
            return GetModel(UqID, m_connectionString);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UcarQuoteDS GetModel(int UqID, string connectionString)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from UcarQuote ");
            strSql.Append(" where UqID=@UqID");
            SqlParameter[] parameters = {
					new SqlParameter("@UqID", SqlDbType.Int,4)};
            parameters[0].Value = UqID;
            UcarQuoteDS model = new UcarQuoteDS();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), connectionString, parameters);
            model.UqID = UqID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UcarID"].ToString() != "")
                {
                    model.UcarID = int.Parse(ds.Tables[0].Rows[0]["UcarID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QuoteType"].ToString() != "")
                {
                    model.QuoteType = int.Parse(ds.Tables[0].Rows[0]["QuoteType"].ToString());
                }
                model.QuoterMobile = ds.Tables[0].Rows[0]["QuoterMobile"].ToString();
                if (ds.Tables[0].Rows[0]["QuoteAmount"].ToString() != "")
                {
                    model.QuoteAmount = decimal.Parse(ds.Tables[0].Rows[0]["QuoteAmount"].ToString());
                }
                model.QuoteReason = ds.Tables[0].Rows[0]["QuoteReason"].ToString();
                if (ds.Tables[0].Rows[0]["QuoteTime"].ToString() != "")
                {
                    model.QuoteTime = DateTime.Parse(ds.Tables[0].Rows[0]["QuoteTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QuoteStatus"].ToString() != "")
                {
                    model.QuoteStatus = int.Parse(ds.Tables[0].Rows[0]["QuoteStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CanDiscuss"].ToString() != "")
                {
                    model.CanDiscuss = int.Parse(ds.Tables[0].Rows[0]["CanDiscuss"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion  成员方法
    }
}
