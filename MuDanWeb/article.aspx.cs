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
    public partial class article : System.Web.UI.Page
    {

        MuDanCH.BLL.article art = new BLL.article();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dataloading();
            }
        }

        protected void sousuo_Click(object sender, EventArgs e)
        {
            Dataloading();
        }

        /// <summary>
        /// 加载数据并且绑定repeater
        /// </summary>
        private void Dataloading()
        {
            string strWhere;
            if (SStext.Text.Trim() != "")
            {
                strWhere = "isdelete = '0' and title like '%" + SStext.Text.ToString() + "%'";
            }
            else {
            strWhere = "isdelete = '0'";
                 }
            DataSet ds = art.GetList(strWhere);
            articletable.DataSource = ds;
            articletable.DataBind();
        }

        protected void articletable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "Acreate")
            {
                bool cb = art.Delete(ConvertHelper.GetInteger(e.CommandArgument));
                if (cb)
                {
                    ScriptHelper.ShowAlertAndCloseScript(this.Page, "删除成功");
                    Dataloading();
                }
            }
            else
            {
                Response.Redirect("articleinsert.aspx?aid=" + ConvertHelper.GetInteger(e.CommandArgument) + "");
            }
        }
    }
}