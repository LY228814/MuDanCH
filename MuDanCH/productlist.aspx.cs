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

namespace MuDanCH
{
    public partial class productlist : System.Web.UI.Page
    {
        MuDanCH.BLL.product pro = new BLL.product();
        MuDanCH.BLL.news newcon = new BLL.news();
        MuDanCH.BLL.article art = new BLL.article();
        MuDanCH.Model.article modelarc = new Model.article();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (true)
                {
                    if (Request["type"]!=null)
                    {

                        //type 产品类型参数 0 全部  1牡丹石  2牡丹瓷  3 白瓷 4其他 绑定该分类的全部
                        BDarticle(ConvertHelper.GetInteger(Request["type"]));
                        //cid分类参数 reptile 绑定
                    }
                    if (Request["new"] != null)
                    {
                        //new新闻参数
                        //nid 新闻参数分类
                    }
                    if (Request["cid"] != null)
                    {
                        //招商加盟 0
                        //联系我们1
                        //招贤纳士2
                        //玉石文化3
                        //企业简介4 `
                    }
                }
            }
        }
        public void reptlist()
        {

        }

        public void BDarticle(int type)
        {
            StringBuilder strB = new StringBuilder();
            DataSet ds = new DataSet();
            if (type == 0)
            {
                ds = pro.GetList("isdelete = 0 ");
            }
            else if (type != 0)
            {
                ds = pro.GetList("isdelete = 0 and cid = "+ type + "");
            }

            if (ds.Tables[0].Rows.Count>0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        strB.Append("<a href =\"ProductList.aspx?type=2&ProductType =");
                        strB.Append(ds.Tables[0].Rows[0][""].ToString()+ ">");
                        strB.Append(ds.Tables[0].Rows[0][""].ToString());
                        strB.Append("</a>");
                    }
                }
            BDxilie.InnerHtml = strB.ToString();


        }
    }
}