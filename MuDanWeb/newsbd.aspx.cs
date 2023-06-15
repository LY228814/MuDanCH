using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MuDanCH.Model;
using System.Text;
using System.Data;
using MuDanCH.BLL;
using KangHui.Common;

namespace MuDanWeb
{
    public partial class newsbd : System.Web.UI.Page
    {
        MuDanCH.BLL.news newbd = new MuDanCH.BLL.news();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitProduct(ConvertHelper.GetInteger(Request["nid"]));
        }
        public int fhtype()
        {
            return ConvertHelper.GetInteger(Request["type"]);
        }
        public void InitProduct(int cid)
        {
            if (cid > 0)
            {
                //newbd.InitProductByPager(prolist, pager, "p.isdelete=0 and nid=" + ConvertHelper.GetInteger(Request["nid"]) + "");
            }
            else
            {
             //   newbd.InitProductByPager(prolist, pager, "p.isdelete=0 ");
            }
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
          //  InitProduct(ConvertHelper.GetInteger(Request["type"]), ConvertHelper.GetInteger(Request["cid"]));
        }
    }
}