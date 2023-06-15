using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Reflection;
using KangHui.Common;
using KangHui.Components.Caching;
using KangHui.Components.UcarBasicInfo;
using KangHui.BaseClass;
using System.Data.SqlClient;

public partial class Default5 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //decimal i = ConvertHelper.GetDecimal(12321.4546);
        //int i = 12321;
        //Response.Write(i.ToString("n3"));
        //MailHelper.SendEmail("liqn@bitauto.com,liying@bitauto.com", "李莹是美女", "美死了，美不胜收！！！", false);
        Response.Write(DateTime.Now.ToString("Y"));
        rdlistProvinceBind();
        string connstring = ConfigurationManager.ConnectionStrings["Ucar"].ConnectionString;
        string connstr = ConfigHelper.GetConnectionString("Ucar");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Assembly a = Assembly.Load("Ucar.Common");
        //Type t = a.GetType("Ucar.Common.SmsHelper");
        ////动态生成类的实例
        //Object theObj = Activator.CreateInstance(t);
        ////参数信息
        //Type[] paramTypes = new Type[2];
        //paramTypes[0] = Type.GetType("System.String");
        //paramTypes[1] = Type.GetType("System.String");
        //MethodInfo mi = t.GetMethod("SendLongMessage", paramTypes);
        ////参数值
        //Object[] parameters = new Object[2];
        //parameters[0] = "13810194005,13241955727";
        //parameters[1] = "通过反射机制发送的短信！！！";
        //Object returnValue = mi.Invoke(theObj, parameters);
        //Response.Write(returnValue);

        Assembly a = Assembly.Load("Ucar.Common");
        Type t = a.GetType("Ucar.Common.EncryptionHelper");
        //动态生成类的实例
        Object theObj = Activator.CreateInstance(t);
        //参数信息
        Type[] paramTypes = new Type[1];
        paramTypes[0] = Type.GetType("System.String");
        MethodInfo mi = t.GetMethod("DesEncrypt", paramTypes);
        //参数值
        Object[] parameters = new Object[1];
        parameters[0] = "liqiunan";
        Object returnValue = mi.Invoke(theObj, parameters);
        //Response.Write(ReflectionBase.InvokeMethod("Ucar.Common", "Ucar.Common.StringHelper", "GetCurrentDateString", null, null));
    }
    protected void SubmitOnceButton1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "666";
    }
    public void rdlistProvinceBind()
    {
        string connstring = ConfigHelper.GetConnectionString("MyConnect");
        //SqlConnection con = new SqlConnection(connstring);
        //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Province", con);
        //DataSet ds = new DataSet();
        //sda.Fill(ds);
        DataSet ds = DbHelperSQL.Query("SELECT * FROM Province", connstring);
        ControlHelper.BindRadioButtonList(this.rdlistProvince, ds, "pvc_Name", "pvc_Id");
        ControlHelper.BindCheckBoxList(this.chkListProvince, ds, "pvc_Name", "pvc_Id");

        //chkListProvince.DataSource = ds;
        //chkListProvince.DataTextField = "pvc_Name";
        //chkListProvince.DataValueField = "pvc_Id";
        //chkListProvince.DataBind();
    }
}
