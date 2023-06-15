using System;
using System.Collections.Generic;
using System.Text;

namespace KangHui.Components.UcarQuote
{
    /// <summary>
    /// 业务逻辑类BLL 的摘要说明。
    /// </summary>
    public class BLL
    {
        private static readonly IUcarQuoteDM dal = DALFactory.CreateUcarQuote();

		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public static int Add(UcarQuoteDS model)
		{
			return dal.Add(model);
		}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(UcarQuoteDS model, string connectionString)
        {
            return dal.Add(model, connectionString);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public static UcarQuoteDS GetModel(int UqID)
		{
			return dal.GetModel(UqID);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UcarQuoteDS GetModel(int UqID, string connectionString)
        {
            return dal.GetModel(UqID, connectionString);
        }

		#endregion  成员方法
    }
}
