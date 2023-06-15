using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MuDanCH.BLL;
using System.Text;
using System.Data;

namespace MuDanCH
{
	public partial class shouye : System.Web.UI.Page
	{
		MuDanCH.BLL.banner ban = new BLL.banner();
		MuDanCH.BLL.article art = new BLL.article();
		MuDanCH.BLL.product pro = new BLL.product();
		protected void Page_Load(object sender, EventArgs e)
		{
			repterbanner();
		}
		public void repterbanner()
		{
			DataSet ds = ban.GetList("isdelete = 0");
			repbanner.DataSource = ds;
			repbanner.DataBind();
		}
		public string  BDinftro()
		{
			string intro="欢迎使用慈航";
			DataSet ds = art.GetList(1, " isdelete = 0", " readcount desc");
			if (ds.Tables[0].Rows.Count > 0)
			{
				intro = ds.Tables[0].Rows[0]["detail"].ToString();
			}
			return intro;
		}

		/// <summary>
		/// 置顶产品绑定
		/// </summary>
		/// <returns></returns>
		public string InitTopProduct()
		{
			StringBuilder str = new StringBuilder();
			DataSet ds = pro.GetProductList(4, " and p.istop = 1", true);
			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				str.Append("<li>");
				str.Append("<img width=\"228\" height=\"221\" onclick=\"window.location.href='productlist.aspx?type=0&pid=" + ds.Tables[0].Rows[i]["pid"] + "'\" src =\"" + ds.Tables[0].Rows[i]["purl"] + "\" alt=\"产品展示\">");
				str.Append("<h3>" + ds.Tables[0].Rows[i]["pname"] + "</h3>");
				str.Append("<p>" + ds.Tables[0].Rows[i]["intro"] + "</p >");
				str.Append("<span><a href=\"productbd.aspx?type=0\">更多>></a></span>");
				str.Append("</li>");
			}
			return str.ToString();
		}

	}
}