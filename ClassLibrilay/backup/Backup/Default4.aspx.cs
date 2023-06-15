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

using Ucar.Common;
using Ucar.Components.UcarBasicInfo;
using System.Collections.Generic;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //UcarBasicInfoDS model0 = new UcarBasicInfoDS();

            //List<UcarPictureInfoDS> models = new List<UcarPictureInfoDS>();
            //UcarPictureInfoDS model1 = new UcarPictureInfoDS();
            //model1.PicturePath = "asdfasdf";
            //UcarPictureInfoDS model2 = new UcarPictureInfoDS();
            //model2.PicturePath = "qwerzxcv";
            //models.Add(model1);
            //models.Add(model2);
            
            //BLL.AddWithTransaction(model0, null, null, models);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //ScriptHelper.ShowAlertScript(this, Request["name"] + "," + Request["id"]);
        //string path = "";
        //ImageHelper.SavePicToServer(FileUpload1.PostedFile, "E:\\Tech-Dev07\\B二手车\\Ucar类库\\Src\\ClassLibraryTest\\UploadPic\\", ref path, true, WaterMarkType.Text, WaterMarkPosition.BottomRight, "UCAR.CN");
        //ScriptHelper.ShowAlertScript(this, path);
        //ScriptHelper.ShowAlertAndCloseScript(this, "Close!!!");
    }
}
