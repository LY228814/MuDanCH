using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MuDanCH.BLL;
using MuDanCH.Model;
using KangHui.Common;
using System.Text;
using System.Data;

namespace MuDanCH
{
    public partial class productinsert : System.Web.UI.Page
    {
        MuDanCH.BLL.category cate = new BLL.category();
        MuDanCH.BLL.product prod = new BLL.product();
        MuDanCH.Model.product modelprod = new Model.product();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitCateGory();
                if (Request["pid"] != null)
                {
                    modelprod = prod.GetModel(ConvertHelper.GetInteger(Request["pid"]));
                    Textname.Text = modelprod.pname;
                    Textjj.Text = modelprod.intro;
                    ddlprop.SelectedValue = modelprod.cid.ToString();
                    Textzz.Text = modelprod.author;
                    txtDetail.InnerText = modelprod.detail;
                    imgshangcuan.imagetset = modelprod.purl;
                }
            }
        }
        public void InitCateGory()
        {
            DataSet ds = cate.GetList("isdelete=0");
            ddlprop.DataSource = ds;
            ddlprop.DataTextField = "categoryname";
            ddlprop.DataValueField = "cid";
            ddlprop.DataBind();
            ddlprop.Items.Insert(0, new ListItem("请选择分类", "0"));
        }
        /// <summary>
        /// 添加和更新方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tijiao_Click(object sender, EventArgs e)
        {
            modelprod.createtime = DateTime.Now;
            modelprod.pname = Textname.Text.ToString();
            modelprod.intro = Textjj.Text.ToString();
            modelprod.cid = ConvertHelper.GetInteger(ddlprop.SelectedValue);
            modelprod.author= Textzz.Text.ToString();
            modelprod.detail = txtDetail.InnerText.ToString();
            modelprod.purl = imgshangcuan.imagetset;
            if (Request["pid"] == null)
            {
                int hs = prod.Add(modelprod);
                if (hs > 0)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加成功", "product.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加失败请重试", "productinsert.aspx");
                }
            }
            else
            {
                modelprod.pid = ConvertHelper.GetInteger(Request["pid"]);
                bool cbs = prod.Update(modelprod);
                if (cbs)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新成功", "product.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新失败请重试", "productinsert.aspx");
                }
            }
        }
    }
}