using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;

namespace Ucar.BaseClass
{
    /// <summary>
    /// 反射机制相关方法的基类
    /// </summary>
    public class ReflectionBase
    {
        #region 创建一个类的实例化对象的方法
        /// <summary>
        /// 创建一个类的实例化对象的方法
        /// </summary>
        /// <param name="assemblyString">要加载的程序集的名称</param>
        /// <param name="typeName">要实例化的类的完全限定名称</param>
        /// <returns>类的实例化对象</returns>
        public static object CreateObject(string assemblyString, string typeName)
        {
            return Assembly.Load(assemblyString).CreateInstance(typeName);
        }
        #endregion

        #region 实例化一个类并调用指定方法的方法
        /// <summary>
        /// 实例化一个类并调用指定方法的方法
        /// </summary>
        /// <param name="assemblyString">要加载的程序集的名称</param>
        /// <param name="typeName">要实例化的类的完全限定名称</param>
        /// <param name="methodName">要调用的方法名</param>
        /// <param name="types">方法要传入参数的信息，无参数传null值</param>
        /// <param name="parameters">方法要传入参数的值，无参数传null值</param>
        /// <returns>方法的返回值</returns>
        public static object InvokeMethod(string assemblyString, string typeName, string methodName, Type[] types, object[] parameters)
        {
            Assembly assembly = Assembly.Load(assemblyString);
            Type type = assembly.GetType(typeName);
            object objClass = Activator.CreateInstance(type);
            if (types == null) types = new Type[0];
            MethodInfo methodInfo = type.GetMethod(methodName, types);
            return methodInfo.Invoke(objClass, parameters);
        }
        #endregion
    }
}
