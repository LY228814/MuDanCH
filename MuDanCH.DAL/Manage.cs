using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KangHui.BaseClass;
using KangHui.Common;
namespace MuDanCH.DAL
{
	/// <summary>
	/// 数据访问类:Manage
	/// </summary>
	public partial class Manage
	{
		string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
		public Manage()
		{ }
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Uid)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Manage");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

			return DbHelperSQL.Exists(strSql.ToString(),connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MuDanCH.Model.Manage model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into Manage(");
			strSql.Append("Uadmin,Upwd,phone,type,creattime,Uurl,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@Uadmin,@Upwd,@phone,@type,@creattime,@Uurl,@isdelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Uadmin", SqlDbType.NVarChar,50),
					new SqlParameter("@Upwd", SqlDbType.NVarChar,50),
					new SqlParameter("@phone", SqlDbType.NChar,11),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@creattime", SqlDbType.DateTime),
					new SqlParameter("@Uurl", SqlDbType.NVarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4)};
			parameters[0].Value = model.Uadmin;
			parameters[1].Value = model.Upwd;
			parameters[2].Value = model.phone;
			parameters[3].Value = model.type;
			parameters[4].Value = model.creattime;
			parameters[5].Value = model.Uurl;
			parameters[6].Value = model.isdelete;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(), connstr, parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MuDanCH.Model.Manage model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update Manage set ");
			strSql.Append("Uadmin=@Uadmin,");
			strSql.Append("Upwd=@Upwd,");
			strSql.Append("phone=@phone,");
			strSql.Append("type=@type,");
			strSql.Append("creattime=@creattime,");
			strSql.Append("Uurl=@Uurl,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uadmin", SqlDbType.NVarChar,50),
					new SqlParameter("@Upwd", SqlDbType.NVarChar,50),
					new SqlParameter("@phone", SqlDbType.NChar,11),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@creattime", SqlDbType.DateTime),
					new SqlParameter("@Uurl", SqlDbType.NVarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@Uid", SqlDbType.Int,4)};
			parameters[0].Value = model.Uadmin;
			parameters[1].Value = model.Upwd;
			parameters[2].Value = model.phone;
			parameters[3].Value = model.type;
			parameters[4].Value = model.creattime;
			parameters[5].Value = model.Uurl;
			parameters[6].Value = model.isdelete;
			parameters[7].Value = model.Uid;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), connstr, parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Uid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from Manage ");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), connstr, parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Uidlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from Manage ");
			strSql.Append(" where Uid in (" + Uidlist + ")  ");
			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), connstr);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MuDanCH.Model.Manage GetModel(int Uid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 Uid,Uadmin,Upwd,phone,type,creattime,Uurl,isdelete from Manage ");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

			MuDanCH.Model.Manage model = new MuDanCH.Model.Manage();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), connstr, parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MuDanCH.Model.Manage DataRowToModel(DataRow row)
		{
			MuDanCH.Model.Manage model = new MuDanCH.Model.Manage();
			if (row != null)
			{
				if (row["Uid"] != null && row["Uid"].ToString() != "")
				{
					model.Uid = int.Parse(row["Uid"].ToString());
				}
				if (row["Uadmin"] != null)
				{
					model.Uadmin = row["Uadmin"].ToString();
				}
				if (row["Upwd"] != null)
				{
					model.Upwd = row["Upwd"].ToString();
				}
				if (row["phone"] != null)
				{
					model.phone = row["phone"].ToString();
				}
				if (row["type"] != null && row["type"].ToString() != "")
				{
					model.type = int.Parse(row["type"].ToString());
				}
				if (row["creattime"] != null && row["creattime"].ToString() != "")
				{
					model.creattime = DateTime.Parse(row["creattime"].ToString());
				}
				if (row["Uurl"] != null)
				{
					model.Uurl = row["Uurl"].ToString();
				}
				if (row["isdelete"] != null && row["isdelete"].ToString() != "")
				{
					model.isdelete = int.Parse(row["isdelete"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select Uid,Uadmin,Upwd,phone,type,creattime,Uurl,isdelete ");
			strSql.Append(" FROM Manage ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" Uid,Uadmin,Upwd,phone,type,creattime,Uurl,isdelete ");
			strSql.Append(" FROM Manage ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) FROM Manage ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString(), connstr);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby);
			}
			else
			{
				strSql.Append("order by T.Uid desc");
			}
			strSql.Append(")AS Row, T.*  from Manage T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Manage";
			parameters[1].Value = "Uid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


