<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>
<%@ Register Assembly="KangHui.WebControls" Namespace="KangHui.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script language="javascript" type="text/javascript">
    function aa(){
        alert('b');
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="aa" runat="server" 
            Text="asdgfasf" onclick="aa_Click"/>
            <asp:TextBox ID="txtceshi" runat="server"></asp:TextBox>
            <asp:GridView ID="gvxml" runat="server">
            </asp:GridView>
    </div>
    <cc1:MarqueePanel ID="maqStudents" runat="server" />
    <cc1:NumericTextBox ID="txtnum" runat="server" />
    <cc1:StringTextBox ID="txtcard" runat="server" RegularExpressionType="IDCard" />
    
    <asp:FileUpload ID="FileUpload1" runat="server" />
    
    
    </form>
    
</body>
</html>
