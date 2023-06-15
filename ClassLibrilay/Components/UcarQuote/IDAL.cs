using System;
using System.Collections.Generic;
using System.Text;

namespace KangHui.Components.UcarQuote
{
    /// <summary>
    /// 接口层IUcarQuoteDM 的摘要说明。
    /// </summary>
    internal interface IUcarQuoteDM
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(UcarQuoteDS model);
        int Add(UcarQuoteDS model, string connectionString);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        UcarQuoteDS GetModel(int UqID);
        UcarQuoteDS GetModel(int UqID, string connectionString);
        #endregion  成员方法
    }
}
