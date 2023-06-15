/**  版本信息模板在安装目录下，可自行修改。
* news.cs
*
* 功 能： N/A
* 类 名： news
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021/3/16 19:08:30   N/A    初版
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
	/// news:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class news
	{
		public news()
		{ }
		#region Model
		private int _nid;
		private string _title;
		private int _type;
		private string _intro;
		private string _author;
		private string _detail;
		private DateTime _creattime;
		private int _istop = 0;
		private int _isdelete = 0;
		/// <summary>
		/// 
		/// </summary>
		public int nid
		{
			set { _nid = value; }
			get { return _nid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set { _title = value; }
			get { return _title; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int type
		{
			set { _type = value; }
			get { return _type; }
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
		public string detail
		{
			set { _detail = value; }
			get { return _detail; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime creattime
		{
			set { _creattime = value; }
			get { return _creattime; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int istop
		{
			set { _istop = value; }
			get { return _istop; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int isdelete
		{
			set { _isdelete = value; }
			get { return _isdelete; }
		}
		#endregion Model

	}
}

