using System;
using System.Collections.Generic;
using System.Text;

using Ucar.BaseClass;

namespace Ucar.Components.UcarQuote
{
    /// <summary>
    /// 抽象工厂模式创建DAL。(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口)
    /// </summary>
    internal class DALFactory
    {
        /// <summary>
        /// 创建UcarQuoteDM数据层接口
        /// </summary>
        public static IUcarQuoteDM CreateUcarQuote()
        {
            return (IUcarQuoteDM)ReflectionBase.CreateObject("Ucar.Components", "Ucar.Components.UcarQuote.UcarQuoteDM");
        }
    }
}
