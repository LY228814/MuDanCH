/**  版本信息模板在安装目录下，可自行修改。
* article.cs
*
* 功 能： N/A
* 类 名： article
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021/3/16 19:08:28   N/A    初版
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
	/// 数据访问类:article
	/// </summary>
	public partial class article
	{
        string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
		public article()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("aid", "article", connstr); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int aid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from article");
			strSql.Append(" where aid=@aid");
			SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4)
			};
			parameters[0].Value = aid;

			return DbHelperSQL.Exists(strSql.ToString(),connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MuDanCH.Model.article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into article(");
			strSql.Append("title,intro,auther,detail,createtime,readcount,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@title,@intro,@auther,@detail,@createtime,@readcount,@isdelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@intro", SqlDbType.NVarChar,-1),
					new SqlParameter("@auther", SqlDbType.NVarChar,20),
					new SqlParameter("@detail", SqlDbType.NVarChar,-1),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@readcount", SqlDbType.Int,4),
					new SqlParameter("@isdelete", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.intro;
			parameters[2].Value = model.auther;
			parameters[3].Value = model.detail;
			parameters[4].Value = model.createtime;
			parameters[5].Value = model.readcount;
			parameters[6].Value = model.isdelete;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),connstr, parameters);
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
		public bool Update(MuDanCH.Model.article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update article set ");
			strSql.Append("title=@title,");
			strSql.Append("intro=@intro,");
			strSql.Append("auther=@auther,");
			strSql.Append("detail=@detail,");
			strSql.Append("createtime=@createtime,");
			strSql.Append("readcount=@readcount,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where aid=@aid");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@intro", SqlDbType.NVarChar,-1),
					new SqlParameter("@auther", SqlDbType.NVarChar,20),
					new SqlParameter("@detail", SqlDbType.NVarChar,-1),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@readcount", SqlDbType.Int,4),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@aid", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.intro;
			parameters[2].Value = model.auther;
			parameters[3].Value = model.detail;
			parameters[4].Value = model.createtime;
			parameters[5].Value = model.readcount;
			parameters[6].Value = model.isdelete;
			parameters[7].Value = model.aid;

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
		public bool Delete(int aid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from article ");
			strSql.Append(" where aid=@aid");
			SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4)
			};
			parameters[0].Value = aid;

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
		public bool DeleteList(string aidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from article ");
			strSql.Append(" where aid in ("+aidlist + ")  ");
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
		public MuDanCH.Model.article GetModel(int aid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 aid,title,intro,auther,detail,createtime,readcount,isdelete from article ");
			strSql.Append(" where aid=@aid");
			SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4)
			};
			parameters[0].Value = aid;

			MuDanCH.Model.article model=new MuDanCH.Model.article();
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
		public MuDanCH.Model.article DataRowToModel(DataRow row)
		{
			MuDanCH.Model.article model=new MuDanCH.Model.article();
			if (row != null)
			{
				if(row["aid"]!=null && row["aid"].ToString()!="")
				{
					model.aid=int.Parse(row["aid"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["intro"]!=null)
				{
					model.intro=row["intro"].ToString();
				}
				if(row["auther"]!=null)
				{
					model.auther=row["auther"].ToString();
				}
				if(row["detail"]!=null)
				{
					model.detail=row["detail"].ToString();
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["readcount"]!=null && row["readcount"].ToString()!="")
				{
					model.readcount=int.Parse(row["readcount"].ToString());
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
			strSql.Append("select aid,title,intro,auther,detail,createtime,readcount,isdelete ");
			strSql.Append(" FROM article ");
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
			strSql.Append(" aid,title,intro,auther,detail,createtime,readcount,isdelete ");
			strSql.Append(" FROM article ");
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
			strSql.Append("select count(1) FROM article ");
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
				strSql.Append("order by T.aid desc");
			}
			strSql.Append(")AS Row, T.*  from article T ");
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
			parameters[0].Value = "article";
			parameters[1].Value = "aid";
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

