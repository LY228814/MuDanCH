using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MuDanCH.BLL;
using MuDanCH.Model;
using KangHui.Common;

namespace MuDanCH
{
    public partial class banner : System.Web.UI.Page
    {
        MuDanCH.BLL.banner cate = new BLL.banner();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                homepage();
            }
        }
        public void homepage()
        {

            DataSet ds = cate.GetList("isdelete = '0'");
            bannertable.DataSource = ds;
            bannertable.DataBind();

        }

        protected void bannertable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "bupdate")
            {
                bool cb = cate.Delete(ConvertHelper.GetInteger(e.CommandArgument));
                if (cb)
                {
                    ScriptHelper.ShowAlertAndCloseScript(this.Page, "删除成功");
                    homepage();
                }
            }
            else
            {
                Response.Redirect("bannerinsert.aspx?bid=" + ConvertHelper.GetInteger(e.CommandArgument) + "");
            }
        }

    }
}