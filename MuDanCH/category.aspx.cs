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
    public partial class category : System.Web.UI.Page
    {
        MuDanCH.BLL.category cate = new BLL.category();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dataloading();
            }
        }

        protected void sousuo_Click(object sender, EventArgs e)
        {
            Dataloading();
        }

        /// <summary>
        /// 加载数据并且绑定repeater
        /// </summary>
        private void Dataloading()
        {
            string strWhere;
            if (txtShuRu.Text.Trim() != "")
            {
                strWhere = "isdelete = '0' and categoryname like '%" + txtShuRu.Text.ToString() + "%'";
            }
            else
            {
                strWhere = "isdelete = '0'";
            }
            DataSet ds = cate.GetList(strWhere);
            categorytable.DataSource = ds;
            categorytable.DataBind();
            texttime.Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// 转换类型
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string type(object num)
        {
            switch (ConvertHelper.GetInteger(num))
            {
                case 1: return "牡丹石类型";
                case 2: return "牡丹瓷类型";
                case 3: return "白瓷类型";
                case 4: return "其他类型";
                default: return "其他";
            }
        }
        protected void categorytable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName== "Cupdate")
            {
                bool cb= cate.Delete(ConvertHelper.GetInteger( e.CommandArgument));
                if (cb)
                {
                    ScriptHelper.ShowAlertAndCloseScript(this.Page,"删除成功");
                    Dataloading();
                }
            }
            else
            {
                Response.Redirect("categoryinsert.aspx?cid"+ ConvertHelper.GetInteger(e.CommandArgument) + "+");
            }
        }
    }
}