using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MuDanCH.BLL;
using MuDanCH.Model;
using KangHui.Common;

namespace MuDanCH
{
    public partial class Musers : System.Web.UI.Page
    {
        MuDanCH.BLL.Manage man = new BLL.Manage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                homepage();
            }
        }
        public void homepage()
        {

            DataSet ds = man.GetList("isdelete = '0'");
            managetable.DataSource = ds;
            managetable.DataBind();

        }
    }
}