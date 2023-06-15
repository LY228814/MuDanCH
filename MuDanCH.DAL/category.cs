/**  版本信息模板在安装目录下，可自行修改。
* category.cs
*
* 功 能： N/A
* 类 名： category
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021/3/16 19:08:29   N/A    初版
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
	/// 数据访问类:category
	/// </summary>
	public partial class category
	{
        string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
        public category()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("cid", "category", connstr); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from category");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
			parameters[0].Value = cid;

			return DbHelperSQL.Exists(strSql.ToString(), connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MuDanCH.Model.category model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into category(");
			strSql.Append("categoryname,intro,createtime,type,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@categoryname,@intro,@createtime,@type,@isdelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@categoryname", SqlDbType.NVarChar,20),
					new SqlParameter("@intro", SqlDbType.NVarChar,-1),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@isdelete", SqlDbType.Int,4)};
			parameters[0].Value = model.categoryname;
			parameters[1].Value = model.intro;
			parameters[2].Value = model.createtime;
			parameters[3].Value = model.type;
			parameters[4].Value = model.isdelete;

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
		public bool Update(MuDanCH.Model.category model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update category set ");
			strSql.Append("categoryname=@categoryname,");
			strSql.Append("intro=@intro,");
			strSql.Append("createtime=@createtime,");
			strSql.Append("type=@type,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@categoryname", SqlDbType.NVarChar,20),
					new SqlParameter("@intro", SqlDbType.NVarChar,-1),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4)};
			parameters[0].Value = model.categoryname;
			parameters[1].Value = model.intro;
			parameters[2].Value = model.createtime;
			parameters[3].Value = model.type;
			parameters[4].Value = model.isdelete;
			parameters[5].Value = model.cid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(), connstr, parameters);
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
		public bool Delete(int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from category ");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
			parameters[0].Value = cid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(), connstr, parameters);
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
		public bool DeleteList(string cidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from category ");
			strSql.Append(" where cid in ("+cidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(), connstr);
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
		public MuDanCH.Model.category GetModel(int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 cid,categoryname,intro,createtime,type,isdelete from category ");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
			parameters[0].Value = cid;

			MuDanCH.Model.category model=new MuDanCH.Model.category();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(), connstr, parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public MuDanCH.Model.category DataRowToModel(DataRow row)
		{
			MuDanCH.Model.category model=new MuDanCH.Model.category();
			if (row != null)
			{
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["categoryname"]!=null)
				{
					model.categoryname=row["categoryname"].ToString();
				}
				if(row["intro"]!=null)
				{
					model.intro=row["intro"].ToString();
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["type"]!=null && row["type"].ToString()!="")
				{
					model.type=int.Parse(row["type"].ToString());
				}
				if(row["isdelete"]!=null && row["isdelete"].ToString()!="")
				{
					model.isdelete=int.Parse(row["isdelete"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select cid,categoryname,intro,createtime,type,isdelete ");
			strSql.Append(" FROM category ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" cid,categoryname,intro,createtime,type,isdelete ");
			strSql.Append(" FROM category ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM category ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.cid desc");
			}
			strSql.Append(")AS Row, T.*  from category T ");
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
			parameters[0].Value = "category";
			parameters[1].Value = "cid";
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

