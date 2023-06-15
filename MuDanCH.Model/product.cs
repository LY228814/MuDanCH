/**  版本信息模板在安装目录下，可自行修改。
* product.cs
*
* 功 能： N/A
* 类 名： product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021/3/16 19:08:31   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace MuDanCH.Model
{
	/// <summary>
	/// product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class product
	{
		public product()
		{ }
		#region Model
		private int _pid;
		private string _pname;
		private string _purl;
		private int _cid;
		private string _intro;
		private string _author;
		private DateTime _createtime;
		private string _detail;
		private int _isdelete = 0;
		private int _istop = 0;
		/// <summary>
		/// 
		/// </summary>
		public int pid
		{
			set { _pid = value; }
			get { return _pid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string pname
		{
			set { _pname = value; }
			get { return _pname; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string purl
		{
			set { _purl = value; }
			get { return _purl; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int cid
		{
			set { _cid = value; }
			get { return _cid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string intro
		{
			set { _intro = value; }
			get { return _intro; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string author
		{
			set { _author = value; }
			get { return _author; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime createtime
		{
			set { _createtime = value; }
			get { return _createtime; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string detail
		{
			set { _detail = value; }
			get { return _detail; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int isdelete
		{
			set { _isdelete = value; }
			get { return _isdelete; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int istop
		{
			set { _istop = value; }
			get { return _istop; }
		}
		#endregion Model

	}
}


