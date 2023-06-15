using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MuDanCH.BLL;
using MuDanCH.Model;
using KangHui.Common;

namespace MuDanCH
{
    public partial class categoryinsert : System.Web.UI.Page
    {
        MuDanCH.BLL.category cate = new BLL.category();
        MuDanCH.Model.category modelcate = new Model.category();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cid"] != null)
                {
                    modelcate = cate.GetModel(ConvertHelper.GetInteger(Request["cid"]));
                    Textname.Text = modelcate.categoryname;
                    leixinglist.SelectedValue = ConvertHelper.GetString( modelcate.type);
                    Textjj.Text = modelcate.intro;

                }
            }
        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            modelcate.createtime = DateTime.Now;
            modelcate.categoryname = Textname.Text.ToString();
            modelcate.intro = Textjj.Text.ToString();
            modelcate.type = ConvertHelper.GetInteger( leixinglist.SelectedValue);
            if (Request[""] == null)
            {
                int hs = cate.Add(modelcate);
                if(hs > 0)
                 {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加成功", "category.aspx");
                }
            else
            {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加失败请重试", "categoryinsert.aspx");
                }
            }
            else {
                modelcate.cid = ConvertHelper.GetInteger( Request["cid"]);
                bool cbs = cate.Update(modelcate);
                if (cbs)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新成功", "category.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新失败请重试", "categoryinsert.aspx");
                }
            }


        }
    }
}