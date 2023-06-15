using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Ucar.Common;
using Ucar.WebControls;

namespace Ucar.BaseClass
{
    /// <summary>
    /// 分页方法的基础类
    /// </summary>
    public class PagerBase
    {
        #region 使用PK存储过程方式分页的方法

        #region 获取数据源的方法
        /// <summary>
        /// 获取数据源的方法
        /// </summary>
        /// <param name="PageIndex">页索引</param>
        /// <param name="PageSize">每页条目数</param>
        /// <param name="selectFields">要查询的字段</param>
        /// <param name="tableNames">要查询的表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="rows">总行数</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns></returns>
        public static DataSet GetDataSource(int PageIndex, int PageSize, string selectFields, string tableNames, string strWhere, string orderField, OrderType orderType, ref int rows, string connectionString)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 1000),
                    new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1500),
                    new SqlParameter("@Counts", SqlDbType.Int)
					};
            parameters[0].Value = tableNames;
            parameters[1].Value = selectFields;
            parameters[2].Value = orderField;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = (int)orderType;
            parameters[6].Value = strWhere;
            parameters[7].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure("p_GetRecordByPageOrder", parameters, "ds", connectionString);
            rows = ConvertHelper.GetInteger(parameters[7].Value);
            return ds;
        }
        #endregion

        #region 绑定带分页的GridView的方法
        /// <summary>
        /// 绑定带分页的GridView的方法
        /// </summary>
        /// <param name="gv">GridView控件</param>
        /// <param name="pager">Pager控件</param>
        /// <param name="selectFields">要查询的字段</param>
        /// <param name="tableNames">要查询的表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void BindData(GridView gv, AspNetPager pager, string selectFields, string tableNames, string strWhere, string orderField, OrderType orderType, string connectionString)
        {
            int rows = 0;
            DataSet ds = GetDataSource(pager.CurrentPageIndex, pager.PageSize, selectFields, tableNames, strWhere, orderField, orderType, ref rows, connectionString);
            pager.RecordCount = rows;
            gv.DataSource = ds;
            gv.DataBind();
        }
        #endregion

        #region 绑定带分页的DataList的方法
        /// <summary>
        /// 绑定带分页的DataList的方法
        /// </summary>
        /// <param name="dl">DataList控件</param>
        /// <param name="pager">Pager控件</param>
        /// <param name="selectFields">要查询的字段</param>
        /// <param name="tableNames">要查询的表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void BindData(DataList dl, AspNetPager pager, string selectFields, string tableNames, string strWhere, string orderField, OrderType orderType, string connectionString)
        {
            int rows = 0;
            DataSet ds = GetDataSource(pager.CurrentPageIndex, pager.PageSize, selectFields, tableNames, strWhere, orderField, orderType, ref rows, connectionString);
            pager.RecordCount = rows;
            dl.DataSource = ds;
            dl.DataBind();
        }
        #endregion

        #region 绑定带分页的Repeater的方法
        /// <summary>
        /// 绑定带分页的Repeater的方法
        /// </summary>
        /// <param name="dl">Repeater控件</param>
        /// <param name="pager">Pager控件</param>
        /// <param name="selectFields">要查询的字段</param>
        /// <param name="tableNames">要查询的表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void BindData(Repeater rp, AspNetPager pager, string selectFields, string tableNames, string strWhere, string orderField, OrderType orderType, string connectionString)
        {
            int rows = 0;
            DataSet ds = GetDataSource(pager.CurrentPageIndex, pager.PageSize, selectFields, tableNames, strWhere, orderField, orderType, ref rows, connectionString);
            pager.RecordCount = rows;
            rp.DataSource = ds;
            rp.DataBind();
        }
        #endregion

        #region 设置自定义信息的方法
        /// <summary>
        /// 设置自定义信息的方法
        /// </summary>
        /// <param name="pager">分页控件</param>
        public static void SetCustomInfoHtmlA(AspNetPager pager)
        {
            pager.CustomInfoHTML = "共" + pager.RecordCount + "条记录  ";
            pager.CustomInfoHTML += "第" + pager.CurrentPageIndex + "/" + pager.PageCount + "页";
        }

        /// <summary>
        /// 设置自定义信息的方法
        /// </summary>
        /// <param name="pager">分页控件</param>
        public static void SetCustomInfoHtmlB(AspNetPager pager)
        {
            pager.CustomInfoHTML = "页数" + pager.CurrentPageIndex + "/" + pager.PageCount;
            pager.CustomInfoHTML += " 每页" + pager.PageSize + "条 ";
            pager.CustomInfoHTML += " 共" + pager.RecordCount + "条记录";
        }
        #endregion

        #endregion

        #region 使用NotIn存储过程方式分页的方法

        #region 获取数据源的方法
        /// <summary>
        /// 获取数据源的方法
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="selectFields">查询字段名</param>
        /// <param name="tableNames">查询表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="groupField">分组条件</param>
        /// <param name="orderField">排序条件</param>
        /// <param name="pkField">主键字段</param>
        /// <param name="rows">总行数</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns>当前页的数据集</returns>
        public static DataSet GetDataSourceWithNotInProc(int pageIndex, int pageSize, string selectFields, string tableNames, string strWhere, string groupField, string orderField, string pkField, ref int rows, string connectionString)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 1000),
                    new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
					new SqlParameter("@keyCol", SqlDbType.VarChar, 100),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,8000),
                    new SqlParameter("@strGroupBy", SqlDbType.VarChar,1000),
                    new SqlParameter("@strOrder", SqlDbType.VarChar,1000),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@Counts", SqlDbType.Int)
					};
            parameters[0].Value = tableNames;
            parameters[1].Value = selectFields;
            parameters[2].Value = pkField;
            parameters[3].Value = strWhere;
            parameters[4].Value = groupField;
            parameters[5].Value = orderField;
            parameters[6].Value = pageSize;
            parameters[7].Value = pageIndex;
            parameters[8].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure("p_GetPageData_NotIn", parameters, "ds", connectionString);
            rows = ConvertHelper.GetInteger(parameters[8].Value);
            return ds;
        }
        #endregion

        #region 绑定带分页的GridView的方法
        /// <summary>
        /// 绑定带分页的GridView的方法
        /// </summary>
        /// <param name="gv">GridView控件</param>
        /// <param name="pager">Pager控件</param>
        /// <param name="selectFields">查询字段名</param>
        /// <param name="tableNames">查询表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="groupField">分组条件</param>
        /// <param name="orderField">排序条件</param>
        /// <param name="pkField">主键字段</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void BindDataWithNotInProc(GridView gv, AspNetPager pager, string selectFields, string tableNames, string strWhere, string groupField, string orderField, string pkField, string connectionString)
        {
            int rows = 0;
            DataSet ds = GetDataSourceWithNotInProc(pager.CurrentPageIndex, pager.PageSize, selectFields, tableNames, strWhere, groupField, orderField, pkField, ref rows, connectionString);
            pager.RecordCount = rows;
            gv.DataSource = ds;
            gv.DataBind();
        }
        #endregion

        #region 绑定带分页的DataList的方法
        /// <summary>
        /// 绑定带分页的DataList的方法
        /// </summary>
        /// <param name="dl">DataList控件</param>
        /// <param name="pager">Pager控件</param>
        /// <param name="selectFields">查询字段名</param>
        /// <param name="tableNames">查询表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="groupField">分组条件</param>
        /// <param name="orderField">排序条件</param>
        /// <param name="pkField">主键字段</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void BindDataWithNotInProc(DataList dl, AspNetPager pager, string selectFields, string tableNames, string strWhere, string groupField, string orderField, string pkField, string connectionString)
        {
            int rows = 0;
            DataSet ds = GetDataSourceWithNotInProc(pager.CurrentPageIndex, pager.PageSize, selectFields, tableNames, strWhere, groupField, orderField, pkField, ref rows, connectionString);
            pager.RecordCount = rows;
            dl.DataSource = ds;
            dl.DataBind();
        }
        #endregion

        #region 绑定带分页的Repeater的方法
        /// <summary>
        /// 绑定带分页的Repeater的方法
        /// </summary>
        /// <param name="dl">Repeater控件</param>
        /// <param name="pager">Pager控件</param>
        /// <param name="selectFields">查询字段名</param>
        /// <param name="tableNames">查询表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="groupField">分组条件</param>
        /// <param name="orderField">排序条件</param>
        /// <param name="pkField">主键字段</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void BindDataWithNotInProc(Repeater rp, AspNetPager pager, string selectFields, string tableNames, string strWhere, string groupField, string orderField, string pkField, string connectionString)
        {
            int rows = 0;
            DataSet ds = GetDataSourceWithNotInProc(pager.CurrentPageIndex, pager.PageSize, selectFields, tableNames, strWhere, groupField, orderField, pkField, ref rows, connectionString);
            pager.RecordCount = rows;
            rp.DataSource = ds;
            rp.DataBind();
        }
        #endregion

        #endregion

        #region 使用填充数据集方式分页的方法

        #region 绑定带分页的GridView的方法
        /// <summary>
        /// 绑定带分页的GridView的方法
        /// </summary>
        /// <param name="gv">GridView控件</param>
        /// <param name="pager">Pager控件</param>
        /// <param name="sql">查询语句</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void BindData(GridView gv, AspNetPager pager, string sql, string connectionString)
        {
            int rows = 0;
            DataSet ds = FillDataSet(pager.CurrentPageIndex, pager.PageSize, sql, ref rows, connectionString);
            pager.RecordCount = rows;
            gv.DataSource = ds;
            gv.DataBind();
        }
        #endregion

        #region 绑定带分页的DataList的方法
        /// <summary>
        /// 绑定带分页的DataList的方法
        /// </summary>
        /// <param name="dl">DataList控件</param>
        /// <param name="pager">Pager控件</param>
        /// <param name="sql">查询语句</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void BindData(DataList dl, AspNetPager pager, string sql, string connectionString)
        {
            int rows = 0;
            DataSet ds = FillDataSet(pager.CurrentPageIndex, pager.PageSize, sql, ref rows, connectionString);
            pager.RecordCount = rows;
            dl.DataSource = ds;
            dl.DataBind();
        }
        #endregion

        #region 绑定带分页的Repeater的方法
        /// <summary>
        /// 绑定带分页的Repeater的方法
        /// </summary>
        /// <param name="dl">Repeater控件</param>
        /// <param name="pager">Pager控件</param>
        /// <param name="selectFields">查询语句</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void BindData(Repeater rp, AspNetPager pager, string sql, string connectionString)
        {
            int rows = 0;
            DataSet ds = FillDataSet(pager.CurrentPageIndex, pager.PageSize, sql, ref rows, connectionString);
            pager.RecordCount = rows;
            rp.DataSource = ds;
            rp.DataBind();
        }
        #endregion
        
        #region 获得带分页的数据列表
        /// <summary>
        /// 获得带分页的数据列表
        /// </summary>
        /// <param name="_pageIndex">页索引</param>
        /// <param name="_pageSize">每页条目数</param>
        /// <param name="sql">查询语句</param>
        /// <param name="_rows">总行数</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public DataSet GetList(int _pageIndex, int _pageSize, string sql, ref int _rows, string connectionString)
        {
            return FillDataSet(_pageIndex, _pageSize, sql, ref _rows, connectionString);
        }
        #endregion

        #region 获得不带分页的数据列表
        /// <summary>
        /// 获得不带分页的数据列表
        /// </summary>
        /// <param name="selectFields">查询语句</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public DataSet GetList(string sql, string connectionString)
        {
            return FillDataSet(sql, connectionString);
        }
        #endregion
        
        #region 用于填充数据集的方法
        public static DataSet FillDataSet(int _pageIndex, int _pageSize, string sql, ref int _rows, string connString)
        {
            if (_pageIndex > 0)
                _pageIndex--;

            SqlDataAdapter da = new SqlDataAdapter(sql, connString);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            try
            {
                da.Fill(ds, _pageIndex * _pageSize, _pageSize, ds.Tables[0].TableName);
                _rows = GetRecordCount(sql, connString);

                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataSet FillDataSet(string sql, string connString)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, connString);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            try
            {
                da.Fill(ds.Tables[0]);
                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 获得查询结果总行数的方法
        public static int GetRecordCount(string _sql, string connString)
        {
            _sql = _sql.ToLower().Trim();

            int i = _sql.LastIndexOf("order by");
            if (i > 0)
                _sql = _sql.Remove(i, _sql.Length - i);

            //int j = _sql.LastIndexOf("group by");
            //if (j > 0)
            //    _sql = _sql.Remove(j, _sql.Length - j);

            //int startIndex = 7;
            //int endIndex = _sql.IndexOf("from");
            //string selectFields = _sql.Substring(startIndex, endIndex - startIndex - 1);
            //_sql = _sql.Replace(selectFields, "count(*)");

            _sql = "SELECT COUNT (*) FROM (" + _sql + ") AS myView";
            object obj = DbHelperSQL.GetSingle(_sql, connString);
            return ConvertHelper.GetInteger(obj);
        }
        #endregion

        #endregion
    }

    #region 排序类型
    /// <summary>
    /// 排序类型
    /// </summary>
    public enum OrderType
    {
        ASC = 0,
        DESC
    }
    #endregion
}
