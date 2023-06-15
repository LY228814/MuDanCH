using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using KangHui.Components.Caching;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //BindRepeater1();
        //HtmlMeta meta = new HtmlMeta();
        //meta.Name = "keywords";
        //meta.Content = "sss";
        //Header.Controls.Add(meta);
    }
    private void BindRepeater1()
    {
        //DataView dv = City.GetCityCache();
        //dv.RowFilter = "city_Id=201";
        //this.Repeater1.DataSource = dv;
        //this.Repeater1.DataBind();
        //Label1.Text = cd.Source.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
}
