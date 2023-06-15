<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestScript.aspx.cs" Inherits="TestScript" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" language="javascript">
    function IsConfim(){
        if(confirm('你确定点我吗ddddd？'))
            {return true;}
        else 
            {return false;}
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
    <a href="Mail.aspx">跳转</a>
    <asp:DropDownList ID="drpList" runat="server"></asp:DropDownList>
        <asp:RadioButtonList ID="rbtnList" runat="server">
        </asp:RadioButtonList>
        <asp:CheckBoxList ID="chkList" runat="server">
            </asp:CheckBoxList>
        <asp:GridView ID="gvHash" runat="server">
            
        </asp:GridView>
    </div>
    </form>
</body>
</html>
