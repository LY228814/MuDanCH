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
    public partial class articleinsert : System.Web.UI.Page
    {

        MuDanCH.BLL.article article = new BLL.article();
        MuDanCH.Model.article modelarticle = new Model.article();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["aid"] != null)
                {
                    modelarticle = article.GetModel(ConvertHelper.GetInteger(Request["aid"]));
                    Texttitle.Text = modelarticle.title;
                    Textinfo.Text = modelarticle.intro;
                    Textname.Text = modelarticle.auther;
                    txtDetail.InnerText = modelarticle.detail;

                }
            }
        }

        protected void fromzl_Click(object sender, EventArgs e)
        {
            modelarticle.createtime = DateTime.Now;
            modelarticle.title = Texttitle.Text.ToString();
            modelarticle.intro = Textinfo.Text.ToString();
            modelarticle.auther = Textname.Text.ToString();
            modelarticle.detail = txtDetail.InnerText.ToString();
            if (Request["aid"] == null)
            {
                int hs = article.Add(modelarticle);
                if (hs > 0)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加成功", "article.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加失败请重试", "articleinsert.aspx");
                }
            }
            else
            {
                modelarticle.aid = ConvertHelper.GetInteger(Request["aid"]);
                bool cbs = article.Update(modelarticle);
                if (cbs)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新成功", "article.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新失败请重试", "articleinsert.aspx");
                }
            }
        }
    }
}