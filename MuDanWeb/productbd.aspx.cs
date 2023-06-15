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
    public partial class productbd : System.Web.UI.Page
    {
        MuDanCH.BLL.product pro = new MuDanCH.BLL.product();
        MuDanCH.BLL.category cat = new MuDanCH.BLL.category();
        protected void Page_Load(object sender, EventArgs e)
        {
            reptercat(ConvertHelper.GetInteger(Request["type"]));
            InitProduct(ConvertHelper.GetInteger(Request["type"]), ConvertHelper.GetInteger(Request["cid"]));
        }

        public int fhtype()
        {
            return ConvertHelper.GetInteger(Request["type"]);
        }
        public void reptercat( int type)
        {
            StringBuilder strB = new StringBuilder();
            DataSet ds = new DataSet();

            if (type == 0)
            {
                ds = cat.GetList(" isdelete = 0 ");
            }
            else
            {
                ds = cat.GetList(" isdelete=0 and type=" + type + "");
            }
            procat.DataSource = ds;
            procat.DataBind();
        }

        public void InitProduct(int type ,int cid)
        {
            if (cid>0)
            {
                pro.InitProductByPager(prolist, pager, "p.isdelete=0 and p.cid=" + ConvertHelper.GetInteger(Request["cid"]) + "");
            }
            else if (type>0)
            {
                pro.InitProductByPager(prolist, pager, "p.isdelete=0 and type=" + ConvertHelper.GetInteger(Request["type"]) + "");
            }
            else
            {
                pro.InitProductByPager(prolist, pager, "p.isdelete=0 ");
            }
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            InitProduct(ConvertHelper.GetInteger(Request["type"]), ConvertHelper.GetInteger(Request["cid"]));
        }
    }
}