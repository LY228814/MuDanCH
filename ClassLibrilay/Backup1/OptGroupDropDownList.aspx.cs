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
using System.Data;

public partial class OptGroupDropDownList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownListBind();
        }
    }

    private void DropDownListBind()
    {
        //ListItem li = new ListItem("中国", "optgroup");
        //ogddlArea.Items.Add(li);

        //li = new ListItem("北京", "北京");
        //ogddlArea.Items.Add(li);

        //li = new ListItem("上海", "上海");
        //ogddlArea.Items.Add(li);

        //li = new ListItem("深圳", "深圳");
        //ogddlArea.Items.Add(li);


        //li = new ListItem("美国", "optgroup");
        //ogddlArea.Items.Add(li);

        //li = new ListItem("华盛顿", "华盛顿");
        //ogddlArea.Items.Add(li);

        //li = new ListItem("纽约", "纽约");
        //ogddlArea.Items.Add(li);
        DataTable tb = new DataTable();
        tb.Columns.Add("name", Type.GetType("System.String"));
        tb.Columns.Add("value", Type.GetType("System.String"));
        DataRow dr = tb.NewRow();
        dr[0] = "中国";
        dr[1] = "optgroup";
        tb.Rows.Add(dr);
        DataRow dr1 = tb.NewRow();
        dr1[0] = "北京";
        dr1[1] = "1";
        tb.Rows.Add(dr1);
        DataRow dr2 = tb.NewRow();
        dr2[0] = "上海";
        dr2[1] = "2";
        tb.Rows.Add(dr2);
        DataRow dr3 = tb.NewRow();
        dr3[0] = "美国";
        dr3[1] = "optgroup";
        tb.Rows.Add(dr3);
        DataRow dr4 = tb.NewRow();
        dr4[0] = "洛杉矶";
        dr4[1] = "1";
        tb.Rows.Add(dr4);
        DataRow dr5 = tb.NewRow();
        dr5[0] = "华盛顿";
        dr5[1] = "2";
        tb.Rows.Add(dr5);
        ogddlArea.DataSource = tb;
        ogddlArea.DataTextField = "name";
        ogddlArea.DataValueField = "value";
        ogddlArea.DataBind();
    }

}
