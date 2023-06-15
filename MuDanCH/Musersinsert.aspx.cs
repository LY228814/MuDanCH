using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KangHui.Common;

namespace MuDanCH
{
    public partial class Musersinsert : System.Web.UI.Page
    {
        MuDanCH.BLL.Manage Mana = new BLL.Manage();
        MuDanCH.Model.Manage modelmana = new Model.Manage();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void fromzl_Click(object sender, EventArgs e)
        {
            modelmana.creattime = DateTime.Now;
            modelmana.Uadmin = Textname.Text.ToString();
            modelmana.Upwd = Textpwd.Text.ToString();
            modelmana.phone = Textphone.Text.ToString();
                int hs = Mana.Add(modelmana);
                if (hs > 0)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加成功", "Musers.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加失败请重试", "Musersinsert.aspx");
                }
            }
    }
}