using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MuDanCH.Model;
using KangHui.Common;
using System.Text;
using MuDanCH.BLL;

namespace MuDanCH
{
    public partial class product : System.Web.UI.Page
    {
        MuDanCH.BLL.product prod = new BLL.product();
        MuDanCH.BLL.category cate = new BLL.category();
        MuDanCH.Model.category modelcat = new Model.category();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitCateGory();
                GetProductRepeater();
            }
        }
        public void homepage()
        {

            DataSet ds = prod.GetList(" isdelete = '0'");
            producttable.DataSource = ds;
            producttable.DataBind();

        }
        /// <summary>
        /// 产品类型下拉框绑定
        /// </summary>
        public void InitCateGory()
        {
            DataSet ds = cate.GetList("isdelete=0");
            ddlpro.DataSource = ds;
            ddlpro.DataTextField = "categoryname";
            ddlpro.DataValueField = "cid";
            ddlpro.DataBind();
            ddlpro.Items.Insert(0, new ListItem("请选择分类", "0"));
        }

        protected void sousuo_Click(object sender, EventArgs e)
        {
            GetProductRepeater();
        }

        public void GetProductRepeater(bool credel=true)
        {
            StringBuilder str = new StringBuilder();
            if (ddlpro.SelectedValue != "0")
            {
                str.Append(" and pname like '%" + txtShuRu.Text.Trim() + "%' and c.cid=" + ddlpro.SelectedValue + "");
            }
            else
            {
                str.Append(" and pname like '%" + txtShuRu.Text.Trim() + "%'");
            }
            DataSet ds = prod.GetProductList(str.ToString(), credel);
            producttable.DataSource = ds;
            producttable.DataBind();
            Gxtime.Text = DateTime.Now.ToString();
        }
        public string type(object num)
        {
            modelcat= cate.GetModel(ConvertHelper.GetInteger(num));
            if (modelcat!=null)
            {
                return modelcat.categoryname;
            }
            return "其他";
        }
        protected void producttable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Pdelete")
            {
                bool cb = prod.Delete(ConvertHelper.GetInteger(e.CommandArgument));
                if (cb)
                {
                    ScriptHelper.ShowAlertAndCloseScript(this.Page, "删除成功");
                    GetProductRepeater();
                }
                else
                {
                    ScriptHelper.ShowAlertAndCloseScript(this.Page, "删除失败");
                }
            }
            else if (e.CommandName == "zhiding")
            {
                prod.proupdate(" istop = 1 ",e.CommandArgument.ToString());
                GetProductRepeater();
            }
            else if (e.CommandName == "buzhiding")
            {
                prod.proupdate(" istop = 0 ", e.CommandArgument.ToString());
                GetProductRepeater();
            }else
            {
                Response.Redirect("productinsert.aspx?pid=" + ConvertHelper.GetInteger(e.CommandArgument) + "");
            }
        }

        public string shoutui(object istop)
        {
            if (ConvertHelper.GetInteger(istop)==0)
            {
                return  "未首推";
            }
            return "已首推";
        }
    }
}