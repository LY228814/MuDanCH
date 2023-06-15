using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuDanCH
{
    public partial class imgshangcuan : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        public string imagetset
        {
            get
            {
                return HiddenField1.Value;
            }

            set
            {
                Imagetext.ImageUrl = value;
                HiddenField1.Value = value;
            }
        }
    }
}