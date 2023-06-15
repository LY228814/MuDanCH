/**  版本信息模板在安装目录下，可自行修改。
* news.cs
*
* 功 能： N/A
* 类 名： news
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021/3/16 19:08:30   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KangHui.Common;
using KangHui.BaseClass;
namespace MuDanCH.DAL
{
	/// <summary>
	/// 数据访问类:news
	/// </summary>
	public partial class news
	{
		string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
		public news()
		{ }
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int nid)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from news");
			strSql.Append(" where nid=@nid");
			SqlParameter[] parameters = {
					new SqlParameter("@nid", SqlDbType.Int,4)
			};
			parameters[0].Value = nid;

			return DbHelperSQL.Exists(strSql.ToString(),connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MuDanCH.Model.news model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into news(");
			strSql.Append("title,type,intro,author,detail,creattime,istop,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@title,@type,@intro,@author,@detail,@creattime,@istop,@isdelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@intro", SqlDbType.VarChar,500),
					new SqlParameter("@author", SqlDbType.VarChar,20),
					new SqlParameter("@detail", SqlDbType.VarChar,-1),
					new SqlParameter("@creattime", SqlDbType.DateTime),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@isdelete", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.type;
			parameters[2].Value = model.intro;
			parameters[3].Value = model.author;
			parameters[4].Value = model.detail;
			parameters[5].Value = model.creattime;
			parameters[6].Value = model.istop;
			parameters[7].Value = model.isdelete;

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
		public bool Update(MuDanCH.Model.news model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update news set ");
			strSql.Append("title=@title,");
			strSql.Append("type=@type,");
			strSql.Append("intro=@intro,");
			strSql.Append("author=@author,");
			strSql.Append("detail=@detail,");
			strSql.Append("creattime=@creattime,");
			strSql.Append("istop=@istop,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where nid=@nid");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@intro", SqlDbType.VarChar,500),
					new SqlParameter("@author", SqlDbType.VarChar,20),
					new SqlParameter("@detail", SqlDbType.VarChar,-1),
					new SqlParameter("@creattime", SqlDbType.DateTime),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@nid", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.type;
			parameters[2].Value = model.intro;
			parameters[3].Value = model.author;
			parameters[4].Value = model.detail;
			parameters[5].Value = model.creattime;
			parameters[6].Value = model.istop;
			parameters[7].Value = model.isdelete;
			parameters[8].Value = model.nid;

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
		public bool Delete(int nid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from news ");
			strSql.Append(" where nid=@nid");
			SqlParameter[] parameters = {
					new SqlParameter("@nid", SqlDbType.Int,4)
			};
			parameters[0].Value = nid;

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
		public bool DeleteList(string nidlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from news ");
			strSql.Append(" where nid in (" + nidlist + ")  ");
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
		public MuDanCH.Model.news GetModel(int nid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 nid,title,type,intro,author,detail,creattime,istop,isdelete from news ");
			strSql.Append(" where nid=@nid");
			SqlParameter[] parameters = {
					new SqlParameter("@nid", SqlDbType.Int,4)
			};
			parameters[0].Value = nid;

			MuDanCH.Model.news model = new MuDanCH.Model.news();
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
		public MuDanCH.Model.news DataRowToModel(DataRow row)
		{
			MuDanCH.Model.news model = new MuDanCH.Model.news();
			if (row != null)
			{
				if (row["nid"] != null && row["nid"].ToString() != "")
				{
					model.nid = int.Parse(row["nid"].ToString());
				}
				if (row["title"] != null)
				{
					model.title = row["title"].ToString();
				}
				if (row["type"] != null && row["type"].ToString() != "")
				{
					model.type = int.Parse(row["type"].ToString());
				}
				if (row["intro"] != null)
				{
					model.intro = row["intro"].ToString();
				}
				if (row["author"] != null)
				{
					model.author = row["author"].ToString();
				}
				if (row["detail"] != null)
				{
					model.detail = row["detail"].ToString();
				}
				if (row["creattime"] != null && row["creattime"].ToString() != "")
				{
					model.creattime = DateTime.Parse(row["creattime"].ToString());
				}
				if (row["istop"] != null && row["istop"].ToString() != "")
				{
					model.istop = int.Parse(row["istop"].ToString());
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
			strSql.Append("select nid,title,type,intro,author,detail,creattime,istop,isdelete ");
			strSql.Append(" FROM news ");
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
			strSql.Append(" nid,title,type,intro,author,detail,creattime,istop,isdelete ");
			strSql.Append(" FROM news ");
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
			strSql.Append("select count(1) FROM news ");
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
				strSql.Append("order by T.nid desc");
			}
			strSql.Append(")AS Row, T.*  from news T ");
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
			parameters[0].Value = "news";
			parameters[1].Value = "nid";
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

