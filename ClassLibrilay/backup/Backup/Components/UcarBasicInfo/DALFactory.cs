using System;
using System.Collections.Generic;
using System.Text;

using Ucar.BaseClass;

namespace Ucar.Components.UcarBasicInfo
{
    internal class DALFactory
    {
        /// <summary>
        /// 创建UcarBasicInfoDM数据层接口
        /// </summary>
        public static IUcarBasicInfoDM CreateUcarBasicInfo()
        {
            return (IUcarBasicInfoDM)ReflectionBase.CreateObject("Ucar.Components", "Ucar.Components.UcarBasicInfo.UcarBasicInfoDM");
        }

        /// <summary>
        /// 创建UcarRefitInfoDM数据层接口
        /// </summary>
        public static IUcarRefitInfoDM CreateUcarRefitInfo()
        {
            return (IUcarRefitInfoDM)ReflectionBase.CreateObject("Ucar.Components", "Ucar.Components.UcarBasicInfo.UcarRefitInfoDM");
        }

        /// <summary>
        /// 创建SaleIntendInfoDM数据层接口
        /// </summary>
        public static ISaleIntendInfoDM CreateSaleIntendInfo()
        {
            return (ISaleIntendInfoDM)ReflectionBase.CreateObject("Ucar.Components", "Ucar.Components.UcarBasicInfo.SaleIntendInfoDM");
        }

        /// <summary>
        /// 创建UcarPictureInfoDM数据层接口
        /// </summary>
        public static IUcarPictureInfoDM CreateUcarPictureInfo()
        {
            return (IUcarPictureInfoDM)ReflectionBase.CreateObject("Ucar.Components", "Ucar.Components.UcarBasicInfo.UcarPictureInfoDM");
        }
    }
}
