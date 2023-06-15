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
using KangHui.Common;
using System.Data.SqlClient;
using System.Text;

public partial class TestScript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            string aa = ConfigHelper.GetAppSetting("-@@!!@E@$@$非官方435423dsavvda",false);
        }
    }
    public void InitDropBind()
    {
        string sql = "SELECT * FROM City";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnect"].ConnectionString);
        SqlDataAdapter sda = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        //KangHui.Common.ControlHelper.BindCheckBoxList(this.chkList, ds, "city_Name", "city_Id");
        //KangHui.Common.ControlHelper.InitCheckBoxList(this.chkList, "102,105,108,111");


        ArrayList arr= KangHui.Common.ControlHelper.ConvertDataSetToArrayList(ds, 1);


        KangHui.Common.ControlHelper.BindCheckBoxList(this.chkList,arr);
        //StringBuilder sbStr = new StringBuilder();
        //for (int i = 0; i < arr.Count; i++)
        //{
        //    sbStr.Append(arr[i].ToString()+"< br />");
        //}
        //Response.Write(sbStr.ToString());
        ////DataSet ds = new DataSet();
        //DataTable dt = ds.Tables[0];
        //DataView dv = ds.Tables[0].DefaultView;

        //dt = dv.Table;
        //ds = dv.Table.DataSet;

        //dv.RowFilter = " Pid=8";
        //DataTable htb = new DataTable();
        //htb.Columns.Add("name");
        //DataColumn tc1 = new DataColumn();
        //tc1.Text = "刘备";
        
        //htb.Rows.Add(tc1);

        //DataTable dt = new DataTable();

        //dt.Columns.Add("matID", typeof(string));
        //dt.Columns.Add("matName", typeof(string));

        //DataRow dr = dt.NewRow();
        //dr[0] = "asd";
        //dr[1] = "haha";
        //dt.Rows.Add(dr);

        //DataRow dr2 = dt.NewRow();
        //dr2[0] = "张";
        //dr2[1] = "皇";
        //dt.Rows.Add(dr2); 

        //gvHash.DataSource = dt;
        //gvHash.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        KangHui.Common.ControlHelper.SelectAllCheckBoxListItems(this.chkList);

    }
}
