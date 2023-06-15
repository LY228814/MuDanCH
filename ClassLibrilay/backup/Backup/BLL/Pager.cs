using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using Ucar.WebControls;

namespace Ucar.BLL
{
    public class Pager
    {
        private static readonly Ucar.DAL.PagerDM dm = new Ucar.DAL.PagerDM();

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
