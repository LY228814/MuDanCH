using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections;
using Ucar.Common;

/// <summary>
/// PageBase 的摘要说明
/// </summary>
public class PageBase : Page
{
    private ArrayList SubmittedItems
    {
        get { return (ViewState["SubmittedItems"] == null) ? new ArrayList() : (ArrayList)ViewState["SubmittedItems"]; }
        set { ViewState["SubmittedItems"] = value; }
    }

    protected bool IsSubmitted(string id)
    {
        return SubmittedItems.IndexOf(id) >= 0;
    }

    protected void AddSubmittedItem(string id)
    {
        ArrayList al = SubmittedItems;
        al.Add(id);
        SubmittedItems = al;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
}
