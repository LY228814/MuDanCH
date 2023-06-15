using System;
namespace MuDanCH.Model
{
	/// <summary>
	/// Manage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Manage
	{
		public Manage()
		{ }
		#region Model
		private int _uid;
		private string _uadmin;
		private string _upwd;
		private string _phone;
		private int _type;
		private DateTime _creattime;
		private string _uurl;
		private int _isdelete = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Uid
		{
			set { _uid = value; }
			get { return _uid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Uadmin
		{
			set { _uadmin = value; }
			get { return _uadmin; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Upwd
		{
			set { _upwd = value; }
			get { return _upwd; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone
		{
			set { _phone = value; }
			get { return _phone; }
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
		public DateTime creattime
		{
			set { _creattime = value; }
			get { return _creattime; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Uurl
		{
			set { _uurl = value; }
			get { return _uurl; }
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

