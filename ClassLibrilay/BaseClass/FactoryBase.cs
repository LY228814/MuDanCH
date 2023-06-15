using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;

namespace Ucar.BaseClass
{
    /// <summary>
    /// 工厂模式相关方法的基类
    /// </summary>
    public class FactoryBase
    {
        #region 创建对象
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="assemblyString">描述要加载的程序集的System.Reflection.AssemblyName对象</param>
        /// <param name="typeName">要查找的类型的System.Type.FullName</param>
        /// <returns>创建的对象</returns>
        protected static object CreateObject(string assemblyString, string typeName)
        {
            return Assembly.Load(assemblyString).CreateInstance(typeName);
        }
        #endregion
    }
}
