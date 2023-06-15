<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<%--<%@ Register Assembly="KangHui.WebControls" Namespace="KangHui.WebControls" TagPrefix="cc1" %>--%>
<%@ Register Assembly="KangHui.WebControls" Namespace="KangHui.WebControls" TagPrefix="ccx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
            ErrorMessage="RequiredFieldValidator" Display="None"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
            <asp:RadioButtonList ID="rdlistProvince" runat="server">
    </asp:RadioButtonList>
        <asp:CheckBoxList ID="chkListProvince" runat="server">
        </asp:CheckBoxList>
    </div>
    </form>
    
</body>
</html>
