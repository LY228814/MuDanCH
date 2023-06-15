/**  版本信息模板在安装目录下，可自行修改。
* product.cs
*
* 功 能： N/A
* 类 名： product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021/3/16 19:08:31   N/A    初版
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
using System.Web.UI.WebControls;
using KangHui.WebControls;

namespace MuDanCH.DAL
{
	/// <summary>
	/// 数据访问类:product
	/// </summary>
	public partial class product
	{

	string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
	public product()
		{ }
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pid)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from product");
			strSql.Append(" where pid=@pid");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4)
			};
			parameters[0].Value = pid;

			return DbHelperSQL.Exists(strSql.ToString(), connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MuDanCH.Model.product model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into product(");
			strSql.Append("pname,purl,cid,intro,author,createtime,detail,isdelete,istop)");
			strSql.Append(" values (");
			strSql.Append("@pname,@purl,@cid,@intro,@author,@createtime,@detail,@isdelete,@istop)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pname", SqlDbType.VarChar,50),
					new SqlParameter("@purl", SqlDbType.VarChar,-1),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@intro", SqlDbType.NVarChar,-1),
					new SqlParameter("@author", SqlDbType.VarChar,20),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@detail", SqlDbType.VarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@istop", SqlDbType.Int,4)};
			parameters[0].Value = model.pname;
			parameters[1].Value = model.purl;
			parameters[2].Value = model.cid;
			parameters[3].Value = model.intro;
			parameters[4].Value = model.author;
			parameters[5].Value = model.createtime;
			parameters[6].Value = model.detail;
			parameters[7].Value = model.isdelete;
			parameters[8].Value = model.istop;

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
		public bool Update(MuDanCH.Model.product model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update product set ");
			strSql.Append("pname=@pname,");
			strSql.Append("purl=@purl,");
			strSql.Append("cid=@cid,");
			strSql.Append("intro=@intro,");
			strSql.Append("author=@author,");
			strSql.Append("createtime=@createtime,");
			strSql.Append("detail=@detail,");
			strSql.Append("isdelete=@isdelete,");
			strSql.Append("istop=@istop");
			strSql.Append(" where pid=@pid");
			SqlParameter[] parameters = {
					new SqlParameter("@pname", SqlDbType.VarChar,50),
					new SqlParameter("@purl", SqlDbType.VarChar,-1),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@intro", SqlDbType.NVarChar,-1),
					new SqlParameter("@author", SqlDbType.VarChar,20),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@detail", SqlDbType.VarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@pid", SqlDbType.Int,4)};
			parameters[0].Value = model.pname;
			parameters[1].Value = model.purl;
			parameters[2].Value = model.cid;
			parameters[3].Value = model.intro;
			parameters[4].Value = model.author;
			parameters[5].Value = model.createtime;
			parameters[6].Value = model.detail;
			parameters[7].Value = model.isdelete;
			parameters[8].Value = model.istop;
			parameters[9].Value = model.pid;

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
		public bool Delete(int pid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from product ");
			strSql.Append(" where pid=@pid");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4)
			};
			parameters[0].Value = pid;

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
		public bool DeleteList(string pidlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from product ");
			strSql.Append(" where pid in (" + pidlist + ")  ");
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
		public MuDanCH.Model.product GetModel(int pid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 pid,pname,purl,cid,intro,author,createtime,detail,isdelete,istop from product ");
			strSql.Append(" where pid=@pid");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4)
			};
			parameters[0].Value = pid;

			MuDanCH.Model.product model = new MuDanCH.Model.product();
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
		public MuDanCH.Model.product DataRowToModel(DataRow row)
		{
			MuDanCH.Model.product model = new MuDanCH.Model.product();
			if (row != null)
			{
				if (row["pid"] != null && row["pid"].ToString() != "")
				{
					model.pid = int.Parse(row["pid"].ToString());
				}
				if (row["pname"] != null)
				{
					model.pname = row["pname"].ToString();
				}
				if (row["purl"] != null)
				{
					model.purl = row["purl"].ToString();
				}
				if (row["cid"] != null && row["cid"].ToString() != "")
				{
					model.cid = int.Parse(row["cid"].ToString());
				}
				if (row["intro"] != null)
				{
					model.intro = row["intro"].ToString();
				}
				if (row["author"] != null)
				{
					model.author = row["author"].ToString();
				}
				if (row["createtime"] != null && row["createtime"].ToString() != "")
				{
					model.createtime = DateTime.Parse(row["createtime"].ToString());
				}
				if (row["detail"] != null)
				{
					model.detail = row["detail"].ToString();
				}
				if (row["isdelete"] != null && row["isdelete"].ToString() != "")
				{
					model.isdelete = int.Parse(row["isdelete"].ToString());
				}
				if (row["istop"] != null && row["istop"].ToString() != "")
				{
					model.istop = int.Parse(row["istop"].ToString());
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
			strSql.Append("select pid,pname,purl,cid,intro,author,createtime,detail,isdelete,istop ");
			strSql.Append(" FROM product ");
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
			strSql.Append(" pid,pname,purl,cid,intro,author,createtime,detail,isdelete,istop ");
			strSql.Append(" FROM product ");
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
			strSql.Append("select count(1) FROM product ");
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
				strSql.Append("order by T.pid desc");
			}
			strSql.Append(")AS Row, T.*  from product T ");
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
			parameters[0].Value = "product";
			parameters[1].Value = "pid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		public DataSet GetProductList ( string strWhere,bool credel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT p.*,categoryname from product as p inner join category as c on p.cid=c.cid");
            if (credel)
            {
                strSql.Append(" where p.isdelete = 0 ");
            }
            else
            {
                strSql.Append(" where p.isdelete != 0 ");
            }

            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), connstr);
        }

		public DataSet GetProductList(int hs,string strWhere, bool credel)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT");
            if (hs>0)
            {
				strSql.Append(" top " + hs);
			}
			strSql.Append(" p.*,type,categoryname from product as p inner join category as c on p.cid=c.cid  where  c.isdelete = 0");

			if (strWhere.Trim() != "")
			{
				strSql.Append(strWhere);
			}
			if (credel)
			{
				strSql.Append(" order by p.createtime  desc");
			}
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/// <summary>
		/// 产品字段修改
		/// </summary>
		/// <param name="setstr">修改字段</param>
		/// <param name="strwhere">查询条件</param>
		/// <returns></returns>
		public int proupdate (string setstr,string strwhere)
        {
			StringBuilder strbd = new StringBuilder();
			strbd.Append("update product set  "+setstr+"  where pid = "+ strwhere + "");
			int hs= DbHelperSQL.ExecuteSql(strbd.ToString(),connstr);
			return hs;
		}

		/// <summary>
		
		/// </summary>
		/// <param name="rpt"></param>
		/// <param name="pager"></param>
		/// <param name="strWhere"></param>
		public void InitProductByPager(Repeater rpt, AspNetPager pager, string strWhere)
		{

			//根据条件拼接SQL语句
			StringBuilder str = new StringBuilder();
			str.Append("select p.*,cate.categoryname,cate.type from product as p inner join category as cate on p.cid=cate.cid");
			if (strWhere != "")
			{
				str.Append(" where " + strWhere);
			}
			//调用了分页控件的绑定方法
			/// Repeater   rpt   控件的ID  AspNetPager pager 分页控件的ID sql:SQL语句  connectionString:数据库连接地址
			PagerBase.BindData(rpt, pager, str.ToString(), connstr);
		}
		#endregion  ExtensionMethod
	}
}

