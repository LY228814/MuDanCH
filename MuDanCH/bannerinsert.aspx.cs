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
    public partial class bannerinsert : System.Web.UI.Page
    {
        MuDanCH.BLL.banner banner = new BLL.banner();
        MuDanCH.Model.banner modelbanner = new Model.banner();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["bid"] != null)
                {
                    modelbanner= banner.GetModel(ConvertHelper.GetInteger(Request["bid"]));
                    Textname.Text = modelbanner.pname;
                    imgshangcuan.imagetset = modelbanner.purl;
                }
            }
        }


        protected void fromzl_Click(object sender, EventArgs e)
        {
            modelbanner.createtime = DateTime.Now;
            modelbanner.pname = Textname.Text.ToString();
            modelbanner.purl = imgshangcuan.imagetset.ToString();
            if (Request["bid"] == null)
            {
                int hs = banner.Add(modelbanner);
                if (hs > 0)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加成功", "banner.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加失败请重试", "bannerinsert.aspx");
                }
            }
            else
            {
                modelbanner.bid = ConvertHelper.GetInteger(ConvertHelper.GetInteger(Request["bid"]));
                bool cbs = banner.Update(modelbanner);
                if (cbs)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新成功", "banner.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新失败请重试", "bannerinsert.aspx");
                }
            }
        }
    }
}