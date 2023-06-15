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
        MuDanCH.BLL.category cat = new BLL.category();
        MuDanCH.Model.article modelarc = new Model.article();
        MuDanCH.Model.news modelnews = new Model.news();
        MuDanCH.Model.product modelprod = new Model.product();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["type"] != null)  
                {
                    leibie.Text = "产品类型";
                    title.Text = "产品列表";
                    //type 产品类型参数 0 全部  1牡丹石  2牡丹瓷  3 白瓷 4其他 绑定该分类的全部
                    BDcategory(ConvertHelper.GetInteger(Request["type"]));
                    //cid分类参数 reptile 绑定
                    if (Request["pid"] != null)
                    {
                        BDproneirong(ConvertHelper.GetInteger(Request["pid"]));
                    }
                   /* else
                    {
                        BDpro(ConvertHelper.GetInteger(Request["type"]), ConvertHelper.GetInteger(Request["cid"]));
                    }*/
                }
                if (Request["newid"] != null)//newid新闻参数
                {
                    leibie.Text = "新闻类型";

                    BDxilie.InnerHtml = "<a href=\"ProductList.aspx?&newid=1\">公司新闻</a><a href=\"ProductList.aspx?&newid=2\">行业新闻</a>";
                    if (Request["nid"] != null)//nid 新闻参数分类
                    {
                        title.Text = "新闻内容";
                        BDnewscount(ConvertHelper.GetInteger(Request["nid"]));
                    }
                    else
                    {
                        title.Text = "新闻列表";
                        BDnews(ConvertHelper.GetInteger(Request["newid"]));
                    }
                }
                if (Request["aid"] != null)
                {
                    BDartice(ConvertHelper.GetInteger(Request["aid"]));
                }
            }
        }
        /// <summary>
        /// 新闻列表绑定
        /// </summary>
        /// <param name="newid">新闻分类条件</param>
        public void BDnews(int newid)
        {
            StringBuilder strB = new StringBuilder();
            DataSet ds = new DataSet();
            if (newid == 0)
            {
                ds = newcon.GetList(" isdelete = 0 ");
            }
            else
            {
                ds = newcon.GetList(" isdelete = 0 and type=" + newid + " ");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                strB.Append(" <ul class=\"newsul\" > ");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strB.Append("<li style=\"width: 720px\" ><a style=\"width: 550px\" href =\"ProductList.aspx?newid=" + newid + "&nid=" + ds.Tables[0].Rows[i]["nid"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a><span>" + ds.Tables[0].Rows[i]["creattime"].ToString() + "</span></li>");
                }
            }
            else
            {
                strB.Append("<h2>还没有内容,请关注后续</h2>");
            }
            leibie.Text = "新闻类型";
            title.Text = "新闻列表";
            neirong.InnerHtml = strB.ToString();
        }
        /// <summary>
        /// 新闻内容绑定
        /// </summary>
        /// <param name="nid">新闻id</param>
        public void BDnewscount(int nid)
        {
            StringBuilder strB = new StringBuilder();
            modelnews = newcon.GetModel(nid);
            strB.Append("<div class=\"wzxx-tit\">");
            strB.Append(modelnews.title);
            strB.Append("</div><div class=\"wzxx-time\">发布时间：" + modelnews.creattime + " </div><div class=\"wzxx-nr\"><p style=\"text - align:center; \">");
            strB.Append(modelnews.detail);
            strB.Append("<br /></span></p></div><div class=\"clear\"></div>");
            neirong.InnerHtml = strB.ToString();
        }
        /// <summary>
        /// 固定内容绑定
        /// </summary>
        /// <param name="aid"> //企业简介 0 玉石文化 1 招贤纳士 2 招商加盟 3 联系我们 4 </param>
        public void BDartice(int aid)
        {
            StringBuilder strB = new StringBuilder();
            modelarc = art.GetModel(aid);
            title.Text = modelarc.title;
            leibie.Text = modelarc.title;
            neirong.InnerHtml = modelarc.detail;
            BDxilie.InnerHtml = "<li><a href=\"shouye.aspx\">网站首页</a></li><li><a href=\"ProductList.aspx?aid=0\">企业简介</a></li><li><a href=\"ProductList.aspx?aid=1\">玉石文化</a></li><li><a href=\"ProductList.aspx?type=0\">产品中心</a></li><li><a href=\"ProductList.aspx?&newid=0\">新闻中心</a></li><li><a href=\"ProductList.aspx?aid=2\">招贤纳士</a></li><li><a href=\"ProductList.aspx?aid=3\">招商加盟</a></li><li><a href=\"ProductList.aspx?aid=4\">联系我们</a></li>";
        }
        /// <summary>
        /// 产品类型绑定
        /// </summary>
        /// <param name="type">类型</param>
        public void BDcategory(int type)
        {
            StringBuilder strB = new StringBuilder();
            DataSet ds = new DataSet();

            if (type == 0)
            {
                ds = cat.GetList(" isdelete = 0 ");
            }
            else if (type != 0)
            {
                ds = cat.GetList(" isdelete=0 and type=" + type + "");
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strB.Append("<a href=\"productbd.aspx?type=" + type + "&cid=");
                    strB.Append(ds.Tables[0].Rows[i]["cid"].ToString() + "\">");
                    strB.Append(ds.Tables[0].Rows[i]["categoryname"].ToString());
                    strB.Append("</a>");
                }
            }
            BDxilie.InnerHtml = strB.ToString();
        }
        /// <summary>
        /// 产品绑定
        /// </summary>
        /// <param name="cid"></param>
       /* public void BDpro(int type, int cid)
        {
            StringBuilder strB = new StringBuilder();
            DataSet ds = new DataSet();
            if (cid == 0)
            {
                ds = pro.GetList(" isdelete = 0 ");
            }
            else
            {
                ds = pro.GetList(" isdelete = 0 and cid=" + cid + "");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                strB.Append("<ul>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strB.Append("<li><a href=\"ProductList.aspx?type=" + type + "&cid=" + cid + "&pid=" + ds.Tables[0].Rows[i]["pid"].ToString() + "\" ><img src =\"" + ds.Tables[0].Rows[i]["purl"].ToString() + "\" height = \"228\" width = \"221\" alt = \"" + ds.Tables[0].Rows[i]["intro"].ToString() + "\" ></a><p>" + ds.Tables[0].Rows[i]["pname"].ToString() + "</p></li>");
                }
                strB.Append("</ul>");
            }
            else
            {
                strB.Append("<h2>还没有内容,请关注后续</h2>");
            }
            neirong.InnerHtml = strB.ToString();
        }*/
        /// <summary>
        /// 产品内容绑定
        /// </summary>
        public void BDproneirong(int pid)
        {
            StringBuilder strB = new StringBuilder();
            modelprod = pro.GetModel(pid);
            strB.Append("<div class=\"wzxx-tit\">");
            strB.Append(modelprod.pname);
            strB.Append("</div><div class=\"wzxx-time\">发布时间：" + modelprod.createtime + " </div><div class=\"wzxx-nr\"> <p><span style=\"font-size:32px;\">" + modelprod.intro + "</span></p><p><span style=\"font-size:32px;\">");
            strB.Append("<img width=\"300\" height=\"250\" src=\"" + modelprod.purl+ "\" alt=\"\" /> 产品介绍:<br /><br />");
            strB.Append(modelprod.detail);
            strB.Append("<br /></span></p></div><div class=\"clear\"></div>");
            neirong.InnerHtml = strB.ToString();
        }
    }
}