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

using Ucar.Common;
using Ucar.BLL;
using Ucar.BaseClass;

public partial class _Default : System.Web.UI.Page
{
    #region 查询条件
    protected string QueryString
    {
        get
        {
            return ConvertHelper.GetString(ViewState["QueryString"]);
        }
        set
        {
            ViewState["QueryString"] = value;
        }
    }
    #endregion

    #region 私有方法
    private void BindGrid()
    {
        Pager.BindDetectionGridView(GridView1, AspNetPager1, "");
    }
    private void BindGrid2()
    {
        //Pager.BindDetectionItemGridView(GridView2, AspNetPager2, "");
        string sql = "select CarID,UseExpireDate,sum(PurchasePrice) as TotalPrice,count(*) as counts from v_PurchaseByYearReport where  SiID=2 and [TvaID] in (SELECT TvaID FROM TranstarVendorAccount WHERE (Status = 1)) and ExchangeType = 0 group by CarID,UseExpireDate";
        PagerBase.BindData(GridView2, AspNetPager2, sql, "server=192.168.1.244;uid=sa;pwd=sa;database=Transtar2007");
        PagerBase.SetCustomInfoHtmlB(AspNetPager2);
    }

    private void InitQueryString()
    {
        QueryString = "SE_car_basic.secb_SaleCharacter=" + DropDownList1.SelectedValue;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //InitQueryString();
            //BindGrid();
            BindGrid2();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        AspNetPager1.CurrentPageIndex = 1; //这句很重要
        InitQueryString();
        BindGrid();
    }
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        BindGrid2();
    }
}
