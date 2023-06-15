<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>

<%@ Register Assembly="Ucar.WebControls" Namespace="Ucar.WebControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        交易类别：<asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="0">收购</asp:ListItem>
            <asp:ListItem Value="1">寄售</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
        <asp:GridView ID="GridView1" runat="server" Width="100%">
        </asp:GridView>
        <cc1:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Right" NumericButtonTextFormatString="[{0}]" OnPageChanged="AspNetPager1_PageChanged" PageSize="100" ShowBoxThreshold="10" ShowInputBox="Always" SubmitButtonText="跳转" TextAfterInputBox="页" TextBeforeInputBox="转到第" Width="100%" FirstPageText="[首页]" LastPageText="[末页]" NextPageText="[下页]" PrevPageText="[上页]" NumericButtonCount="3" ShowPageIndex="False" AlwaysShow="True">
        </cc1:AspNetPager>
        <asp:GridView ID="GridView2" runat="server" Width="100%">
        </asp:GridView>
    </div>
        <cc1:AspNetPager ID="AspNetPager2" runat="server" OnPageChanged="AspNetPager2_PageChanged"
            Width="100%" ShowCustomInfoSection="Left">
        </cc1:AspNetPager>
    </form>
</body>
</html>
