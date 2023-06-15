using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class CheckBoxDrpRedio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            InitChcekboxList();
            KangHui.Common.ControlHelper.InitCheckBoxList(this.drpList, "10,15,9,8,1");
        }
    }
    public void InitChcekboxList()
    {
        DataSet ds = KangHui.BaseClass.DbHelperSQL.Query("SELECT * FROM S_Province", ConfigurationManager.ConnectionStrings["MyConnect"].ConnectionString);
        KangHui.Common.ControlHelper.BindCheckBoxList(this.drpList, ds);
    }
    protected void btnRead_Click(object sender, EventArgs e)
    {
        Response.Write(KangHui.Common.ControlHelper.GetCheckBoxListValues(this.drpList));

        //char x = '%';
        //DataTable dt = new DataTable();
        //Table dt = new Table();
        //HtmlTable td = new HtmlTable();
    }

    /*
     * array 和arrylist 和数组的区别和共同点？
     * 
    */

}
