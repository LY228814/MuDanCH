using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Web;

namespace Ucar.Common
{
    /// <summary>
    /// 用于对Excel文件进行处理的类
    /// </summary>
    public class ExcelHelper
    {
        #region 将数据导出到Excel的方法
		/// <summary>
        /// 将数据导出到Excel的方法
		/// </summary>
		/// <param name="_caption">含有表头标题文字字符串数组</param>
        /// <param name="ds">数据集</param>
        /// <param name="ef">导出格式</param>
        /// <param name="FileName">导出文件名</param>
		public static void ExportToExcel(string[] _caption, DataSet ds, ExportFormat ef, string FileName) 
		{			
			DataTable dt = ds.Tables[0];
			for (int i=0; i<_caption.Length; i++)
			{
				if (i<dt.Columns.Count)
					dt.Columns[i].Caption = _caption[i];
				else
					break;
			}
			ExportToExcel(ds, ef, FileName);
        }
        #endregion

        #region 私有方法
        private static void ExportToExcel(DataSet ds, ExportFormat ef, string FileName) 
		{
			HttpResponse resp;
			resp = HttpContext.Current.Response;
			resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
			resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
			resp.Charset = "UTF-8";    
   
			string colHeaders = "", ls_item = "";
			int i=0;

			//定义表对象与行对像，同时用DataSet对其值进行初始化
			DataTable dt = ds.Tables[0];
			DataRow[] myRow = dt.Select(""); 
			// typeid=="1"时导出为EXCEL格式文件；typeid=="2"时导出为XML格式文件
			if(ef == ExportFormat.ExcelFormat)
			{
				resp.ContentType = "application/ms-excel";//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
				//取得数据表各列标题，各标题之间以\t分割，最后一个列标题后加回车符
				for(i = 0; i < dt.Columns.Count - 1; i++)
					colHeaders += dt.Columns[i].Caption.ToString() + "\t";
				colHeaders += dt.Columns[i].Caption.ToString() + "\n";   
				//向HTTP输出流中写入取得的数据信息
				resp.Write(colHeaders); 
				//逐行处理数据  
				foreach(DataRow row in myRow)
				{
					//在当前行中，逐列获得数据，数据之间以\t分割，结束时加回车符\n
					for(i = 0; i < dt.Columns.Count - 1; i++)
						ls_item += row[i].ToString().Replace("\t","") + "\t";     
					ls_item += row[i].ToString().Replace("\t","") +"\n";
					//当前行数据写入HTTP输出流，并且置空ls_item以便下行数据    
					resp.Write(ls_item);
					ls_item = "";
				}
			}
			else
			{
				if(ef==ExportFormat.XMLFormat)
				{ 
					//从DataSet中直接导出XML数据并且写到HTTP输出流中
					resp.Write(ds.GetXml());
				}    
			}
			//写缓冲区中的数据到HTTP头文件中
			resp.End();
        }
        #endregion
    }

    #region 导出Excel的格式(枚举)
    /// <summary>
	/// 导出Excel的格式
	/// </summary>
	public enum ExportFormat
	{
		ExcelFormat = 0,			//Excel格式
		XMLFormat					//XML格式
    }
    #endregion
}
