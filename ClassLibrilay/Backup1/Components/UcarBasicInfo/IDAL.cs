using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace KangHui.Components.UcarBasicInfo
{
    /// <summary>
    /// 接口层IUcarBasicInfoDM 的摘要说明。
    /// </summary>
    internal interface IUcarBasicInfoDM
    {
        #region 成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(UcarBasicInfoDS model, SqlConnection conn, SqlTransaction trans);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(UcarBasicInfoDS model, SqlConnection conn, SqlTransaction trans);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        UcarBasicInfoDS GetModel(int UcarID);
        UcarBasicInfoDS GetModel(int UcarID, string connectionString);
        #endregion
    }

    /// <summary>
    /// 接口层IUcarRefitInfoDM 的摘要说明。
    /// </summary>
    internal interface IUcarRefitInfoDM
    {
        #region 成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(UcarRefitInfoDS model, SqlConnection conn, SqlTransaction trans);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(UcarRefitInfoDS model, SqlConnection conn, SqlTransaction trans);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        UcarRefitInfoDS GetModel(int UcarID);
        UcarRefitInfoDS GetModel(int UcarID, string connectionString);
        #endregion
    }

    /// <summary>
    /// 接口层ISaleIntendInfoDM 的摘要说明。
    /// </summary>
    internal interface ISaleIntendInfoDM
    {
        #region 成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(SaleIntendInfoDS model, SqlConnection conn, SqlTransaction trans);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(SaleIntendInfoDS model, SqlConnection conn, SqlTransaction trans);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        SaleIntendInfoDS GetModel(int UcarID);
        SaleIntendInfoDS GetModel(int UcarID, string connectionString);
        #endregion
    }

    /// <summary>
    /// 接口层IUcarPictureInfoDM 的摘要说明。
    /// </summary>
    internal interface IUcarPictureInfoDM
    {
        #region 成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(UcarPictureInfoDS model, SqlConnection conn, SqlTransaction trans);
        /// <summary>
        /// 删除若干条数据
        /// </summary>
        void Delete(int UcarID, SqlConnection conn, SqlTransaction trans);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(int UcarID);
        DataSet GetList(int UcarID, string connectionString);
        #endregion
    }
}
