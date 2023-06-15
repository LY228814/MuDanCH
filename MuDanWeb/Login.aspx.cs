using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MuDanCH.BLL;
using MuDanCH.Model;
using KangHui.Common;
using System.Data;

namespace MuDanCH
{
    public partial class Login : System.Web.UI.Page
    {
        MuDanCH.BLL.Manage user = new BLL.Manage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        
        if (Textpwd.Text.ToString()!="")
        {
           DataSet ds = user.GetList(" Uadmin = '"+ ConvertHelper.GetString( Textname.Text)+ "'");
                if (ds.Tables[0].Rows.Count>0)
                {

                    if (ds.Tables[0].Rows[0]["Upwd"].ToString() == ConvertHelper.GetString(Textpwd.Text))
                    {
                        Response.Cookies["userpwd"].Value = Textname.Text.ToString().Trim() + "&" + ConvertHelper.GetString(Textpwd.Text);
                        Response.Cookies["userpwd"].Path = "Login.aspx";
                        //Session["judge"] = "yidenglu";
                        Session["Uname"] = Textname.Text.ToString();
                        Response.Redirect("Index.aspx");
                    }
                    Response.Write("<script> alert('密码错误') </script>");
                }
                Response.Write("<script> alert('用户不存在') </script>");
            }
            Response.Write("<script> alert('请输入账号和密码') </script>");
        }
    }
}