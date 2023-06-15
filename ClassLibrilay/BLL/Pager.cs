using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using KangHui.WebControls;

namespace KangHui.BLL
{
    public class Pager
    {
        private static readonly KangHui.DAL.PagerDM dm = new KangHui.DAL.PagerDM();

        public static void BindDetectionGridView(GridView gv, AspNetPager pager, string strWhere)
        {
            dm.BindDetectionGridView(gv, pager, strWhere);
        }

        public static void BindDetectionItemGridView(GridView gv, AspNetPager pager, string strWhere)
        {
            dm.BindDetectionItemGridView(gv, pager, strWhere);
        }
    }
}
