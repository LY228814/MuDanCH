 using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace KangHui.Common
{
    /// <summary>
    /// 对控件进行操作的类
    /// </summary>
    public static class ControlHelper
    {
        #region 绑定下拉框的方法
        /// <summary>
        /// 绑定下拉框的方法
        /// </summary>
        /// <param name="drop">下拉框</param>
        /// <param name="aList">数据集合</param>
        public static void BindDropDownList(DropDownList drop, ArrayList aList)
        {
            if (drop == null) return; 
            drop.Items.Clear();
            drop.DataSource = aList;
            drop.DataBind();
        }
        
        /// <summary>
        /// 绑定下拉框的方法
        /// </summary>
        /// <param name="drop">下拉框</param>
        /// <param name="ds">数据集</param>
        public static void BindDropDownList(DropDownList drop, DataSet ds)
        {
            BindDropDownList(drop, ds, ds.Tables[0].Columns[1].Caption, ds.Tables[0].Columns[0].Caption);
        }

        /// <summary>
        /// 绑定下拉框的方法
        /// </summary>
        /// <param name="drop">下拉框</param>
        /// <param name="ds">数据集</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        public static void BindDropDownList(DropDownList drop, DataSet ds, string textField, string valueField)
        {
            BindDropDownList(drop, ds.Tables[0].DefaultView, textField, valueField);
        }

        /// <summary>
        /// 绑定下拉框的方法
        /// </summary>
        /// <param name="drop">下拉框</param>
        /// <param name="ds">自定义视图</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        public static void BindDropDownList(DropDownList drop, DataView dv, string textField, string valueField)
        {
            if (drop == null) return;
            drop.Items.Clear();
            drop.DataSource = dv;
            drop.DataTextField = textField;
            drop.DataValueField = valueField;
            drop.DataBind();
        }
        #endregion

        #region 初始化下拉框的方法
        /// <summary>
        /// 根据值初始化下拉框的方法
        /// </summary>
        /// <param name="drop">下拉框</param>
        /// <param name="value">值</param>
        public static void InitDropDownListByValue(DropDownList drop, string value)
        {
            if (drop == null) return;
            if (drop.Items.FindByValue(value) != null)
                drop.SelectedValue = value;
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
            if (rbl == null) return;
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
        /// <param name="ds">自定义视图</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        public static void BindRadioButtonList(RadioButtonList rbl, DataView dv, string textField, string valueField)
        {
            if (rbl == null) return;
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
            if (cbl == null) return;
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
        /// <param name="ds">自定义视图</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        public static void BindCheckBoxList(CheckBoxList cbl, DataView dv, string textField, string valueField)
        {
            if (cbl == null) return;
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
            if (cbl == null) return;
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                for (int j = 0; j < strs.Length; j++)
                {
                    if (cbl.Items[i].Value == strs[j])
                    {
                        cbl.Items[i].Selected = true;
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
            if (cbl == null) return "";
            string returnValue = "";
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                if (cbl.Items[i].Selected)
                    returnValue += cbl.Items[i].Value + ",";
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

        #region 判断数据集是否有数据的方法
        /// <summary>
        /// 判断数据集是否有数据的方法
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <returns>是否有数据</returns>
        public static bool IsDataSetHasData(DataSet ds)
        {
            return (ds != null) & (ds.Tables[0].Rows.Count > 0);
        }
        #endregion

        #region 判断数据表是否有数据的方法
        /// <summary>
        /// 判断数据表是否有数据的方法
        /// </summary>
        /// <param name="ds">数据表</param>
        /// <returns>是否有数据</returns>
        public static bool IsDataTableHasData(DataTable dt)
        {
            return (dt != null) & (dt.Rows.Count > 0);
        }
        #endregion

        #region 全选复选框列表的方法
        /// <summary>
        /// 全选复选框列表的方法
        /// </summary>
        /// <param name="cbl">复选框列表</param>
        public static void SelectAllCheckBoxListItems(CheckBoxList cbl)
        {
            if (cbl == null) return;
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                cbl.Items[i].Selected = true;
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
            if (cbl == null) return;
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                cbl.Items[i].Selected = false;
            }
        }
        #endregion

        #region 将数据集转成数据集合的方法
        /// <summary>
        /// 将数据集转成数据集合的方法
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <returns>数据集合</returns>
        public static ArrayList ConvertDataSetToArrayList(DataSet ds)
        {
            return ConvertDataSetToArrayList(ds, 0);
        }
        /// <summary>
        /// 将数据集转成数据集合的方法
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="columnIndex">列索引</param>
        /// <returns>数据集合</returns>
        public static ArrayList ConvertDataSetToArrayList(DataSet ds, int columnIndex)
        {
            ArrayList aList = new ArrayList();
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    aList.Add(ds.Tables[0].Rows[i][columnIndex]);
                }
            }
            return aList;
        }
        /// <summary>
        /// 将数据集转成数据集合的方法
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="columnName">列名称</param>
        /// <returns>数据集合</returns>
        public static ArrayList ConvertDataSetToArrayList(DataSet ds, string columnName)
        {
            ArrayList aList = new ArrayList();
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    aList.Add(ds.Tables[0].Rows[i][columnName]);
                }
            }
            return aList;
        }
        #endregion

        #region 将数据集合转成字符串数组的方法
        public static string[] ConvertArrayListToStringArray(ArrayList aList)
        {
            string[] strs = new string[aList.Count];
            for (int i = 0; i < aList.Count; i++)
            {
                strs[i] = ConvertHelper.GetString(aList[i]);
            }
            return strs;
        }
        #endregion
    }
}
