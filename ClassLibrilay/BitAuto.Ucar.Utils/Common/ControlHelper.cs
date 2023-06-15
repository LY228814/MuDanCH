using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace KangHui.JianHui.Utils.Common
{
    /// <summary>
    /// 对控件进行操作的功能类
    /// </summary>
    public class ControlHelper
    {
        #region 绑定下拉框的方法
        /// <summary>
        /// 绑定下拉框的方法
        /// </summary>
        /// <param name="ddl">下拉框</param>
        /// <param name="aList">数据集合</param>
        public static void BindDropDownList(DropDownList ddl, ArrayList aList)
        {
            ddl.Items.Clear();
            ddl.DataSource = aList;
            ddl.DataBind();
        }
        /// <summary>
        /// 绑定下拉框的方法
        /// </summary>
        /// <param name="ddl">下拉框</param>
        /// <param name="ds">数据集</param>
        public static void BindDropDownList(DropDownList ddl, DataSet ds)
        {
            BindDropDownList(ddl, ds, ds.Tables[0].Columns[1].Caption, ds.Tables[0].Columns[0].Caption);
        }
        /// <summary>
        /// 绑定下拉框的方法
        /// </summary>
        /// <param name="ddl">下拉框</param>
        /// <param name="ds">数据集</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        public static void BindDropDownList(DropDownList ddl, DataSet ds, string textField, string valueField)
        {
            BindDropDownList(ddl, ds.Tables[0].DefaultView, textField, valueField);
        }
        /// <summary>
        /// 绑定下拉框的方法
        /// </summary>
        /// <param name="ddl">下拉框</param>
        /// <param name="dv">自定义视图</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        public static void BindDropDownList(DropDownList ddl, DataView dv, string textField, string valueField)
        {
            ddl.Items.Clear();
            ddl.DataSource = dv;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
        }
        #endregion

        #region 根据值初始化下拉框的方法
        /// <summary>
        /// 根据值初始化下拉框的方法
        /// </summary>
        /// <param name="ddl">下拉框</param>
        /// <param name="value">值</param>
        public static void InitDropDownListByValue(DropDownList ddl, string value)
        {
            if (ddl.Items.FindByValue(value) != null)
            {
                ddl.SelectedValue = value;
            }
        }
        #endregion

        #region 绑定单选框列表的方法
        /// <summary>
        /// 绑定单选框列表的方法
        /// </summary>
        /// <param name="rbl">单选框列表</param>
        /// <param name="aList">数据集合</param>
        public static void BindRadioButtonList(RadioButtonList rbl, ArrayList aList)
        {
            rbl.Items.Clear();
            rbl.DataSource = aList;
            rbl.DataBind();
        }
        /// <summary>
        /// 绑定单选框列表的方法
        /// </summary>
        /// <param name="rbl">单选框列表</param>
        /// <param name="ds">数据集</param>
        public static void BindRadioButtonList(RadioButtonList rbl, DataSet ds)
        {
            BindRadioButtonList(rbl, ds, ds.Tables[0].Columns[1].Caption, ds.Tables[0].Columns[0].Caption);
        }
        /// <summary>
        /// 绑定单选框列表的方法
        /// </summary>
        /// <param name="rbl">单选框列表</param>
        /// <param name="ds">数据集</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        public static void BindRadioButtonList(RadioButtonList rbl, DataSet ds, string textField, string valueField)
        {
            BindRadioButtonList(rbl, ds.Tables[0].DefaultView, textField, valueField);
        }
        /// <summary>
        /// 绑定单选框列表的方法
        /// </summary>
        /// <param name="rbl">单选框列表</param>
        /// <param name="dv">自定义视图</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        public static void BindRadioButtonList(RadioButtonList rbl, DataView dv, string textField, string valueField)
        {
            rbl.Items.Clear();
            rbl.DataSource = dv;
            rbl.DataTextField = textField;
            rbl.DataValueField = valueField;
            rbl.DataBind();
        }
        #endregion

        #region 绑定复选框列表的方法
        /// <summary>
        /// 绑定复选框列表的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        /// <param name="aList">数据集合</param>
        public static void BindCheckBoxList(CheckBoxList cbl, ArrayList aList)
        {
            cbl.Items.Clear();
            cbl.DataSource = aList;
            cbl.DataBind();
        }
        /// <summary>
        /// 绑定复选框列表的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        /// <param name="ds">数据集</param>
        public static void BindCheckBoxList(CheckBoxList cbl, DataSet ds)
        {
            BindCheckBoxList(cbl, ds, ds.Tables[0].Columns[1].Caption, ds.Tables[0].Columns[0].Caption);
        }
        /// <summary>
        /// 绑定复选框列表的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        /// <param name="ds">数据集</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        public static void BindCheckBoxList(CheckBoxList cbl, DataSet ds, string textField, string valueField)
        {
            BindCheckBoxList(cbl, ds.Tables[0].DefaultView, textField, valueField);
        }
        /// <summary>
        /// 绑定复选框列表的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        /// <param name="dv">自定义视图</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        public static void BindCheckBoxList(CheckBoxList cbl, DataView dv, string textField, string valueField)
        {
            cbl.Items.Clear();
            cbl.DataSource = dv;
            cbl.DataTextField = textField;
            cbl.DataValueField = valueField;
            cbl.DataBind();
        }
        #endregion

        #region 初始化复选框列表的方法
        /// <summary>
        /// 初始化复选框列表的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        /// <param name="strs">数据字符串数组</param>
        public static void InitCheckBoxList(CheckBoxList cbl, string[] strs)
        {
            foreach (ListItem item in cbl.Items)
            {
                foreach (string s in strs)
                {
                    if (item.Value == s)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 初始化复选框列表的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        /// <param name="str">逗号分割的数据字符串</param>
        public static void InitCheckBoxList(CheckBoxList cbl, string str)
        {
            string[] strs = str.Split(new char[] { ',' });
            InitCheckBoxList(cbl, strs);
        }
        #endregion

        #region 获取复选框列表值的方法
        /// <summary>
        /// 获取复选框列表值的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        /// <returns>复选框列表值</returns>
        public static string GetCheckBoxListValues(CheckBoxList cbl)
        {
            string returnValue = string.Empty;
            foreach (ListItem item in cbl.Items)
            {
                if (item.Selected)
                {
                    returnValue += item.Value + ",";
                }
            }
            return returnValue.TrimEnd(new char[] { ',' });
        }
        /// <summary>
        /// 获取复选框列表值的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        /// <returns>复选框列表值</returns>
        public static string[] GetCheckBoxListValueArray(CheckBoxList cbl)
        {
            string values = GetCheckBoxListValues(cbl);
            return values.Split(new char[] { ',' });
        }
        #endregion

        #region 全选复选框列表的方法
        /// <summary>
        /// 全选复选框列表的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        public static void SelectAllCheckBoxListItems(CheckBoxList cbl)
        {
            foreach (ListItem item in cbl.Items)
            {
                item.Selected = true;
            }
        }
        #endregion

        #region 取消全选复选框列表的方法
        /// <summary>
        /// 取消全选复选框列表的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        public static void CancelSelectAllCheckBoxListItems(CheckBoxList cbl)
        {
            foreach (ListItem item in cbl.Items)
            {
                item.Selected = false;
            }
        }
        #endregion
    }
}
