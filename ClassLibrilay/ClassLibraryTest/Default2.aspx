<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="KangHui.WebControls" Namespace="KangHui.WebControls" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
    function aa(){}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            数字文本框：<cc1:NumericTextBox ID="NumericTextBox1" runat="server" Text="" SetFocusOnError="true" NumberType="Decimal" IntegerLength="9" />
            <br />
            文字文本框：<cc1:StringTextBox ID="StringTextBox1" runat="server" Text="" EnabledRegularExpressionValidation="True" SetFocusOnError="True" ValidationExpression="^\d{0,8}([.]{1}\d{1,2})?$" RegularExpressionType="MobilePhoneNumber" />
            <br />
            <cc1:CtrlEnterButton ID="CtrlEnterButton1" runat="server" Text="[Ctrl+Enter]" OnClick="CtrlEnterButton1_Click" />
            <asp:Button ID="Button1" runat="server" Text="Button" /><br />
            <cc1:Calendar ID="Calendar1" runat="server" AfterDefaultYearCount="5" BeforeDefaultYearCount="3" DefaultYear="2000"></cc1:Calendar>&nbsp;<br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
            
            </div>
    </form>
</body>
</html>
