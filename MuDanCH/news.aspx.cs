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
    public partial class WebForm1 : System.Web.UI.Page
    {
        MuDanCH.BLL.news cate = new BLL.news();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                homepage();
            }
        }
        public void homepage()
        {
            DataSet ds = cate.GetList("isdelete = '0' and type='1'");
            Qnewstable.DataSource = ds;
            Qnewstable.DataBind();

            ds = cate.GetList("isdelete = '0' and type='2'");
            Hnewstable.DataSource = ds;
            Hnewstable.DataBind();
            num.Text= ConvertHelper.GetString( cate.GetRecordCount(""));
        }


        protected void sousuo_Click(object sender, EventArgs e)
        {
            if (txtShuRu.Text.Trim() !="")
            {
                DataSet ds = cate.GetList("isdelete = '0' and title like '%"+ txtShuRu.Text.ToString()+ "%'");
                Qnewstable.DataSource = ds;
                Qnewstable.DataBind();
                //搜索结果
                num.Text = ConvertHelper.GetString(cate.GetRecordCount(""));
                creatxw.Text = "搜索结果";
            }
        }
    }
}