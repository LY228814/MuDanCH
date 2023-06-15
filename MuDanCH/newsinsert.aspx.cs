using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KangHui.Common;

namespace MuDanCH
{
    public partial class newsinsert : System.Web.UI.Page
    {
        MuDanCH.BLL.news newss = new BLL.news();
        MuDanCH.Model.news modelnews = new Model.news();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["nid"] != null)
                {
                    modelnews = newss.GetModel(ConvertHelper.GetInteger(Request["nid"]));
                    Texttitle.Text = modelnews.title;
                    Textintro.Text = modelnews.intro;
                    Textauthor.Text = modelnews.author;
                    txtDetail.InnerText = modelnews.detail;

                }
            }
        }

        protected void tianjia_Click(object sender, EventArgs e)
        {
            modelnews.title = Texttitle.Text.ToString();
            modelnews.intro = Textintro.Text.ToString();
            modelnews.author = Textauthor.Text.ToString();
            modelnews.detail = txtDetail.InnerText.ToString();
            if (RBqy.Checked)
            {
                modelnews.type = 1;
            }
            else
            {
                modelnews.type = 2;
            }
            if (Request["nid"] == null)
            {
                int hs = newss.Add(modelnews);
                if (hs > 0)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加成功", "news.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加失败请重试", "newsinsert.aspx");
                }
            }
            else
            {
                modelnews.nid = ConvertHelper.GetInteger(Request["nid"]);
                bool cbs = newss.Update(modelnews);
                if (cbs)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新成功", "news.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新失败请重试", "newsinsert.aspx");
                }
            }
        }
    }
}