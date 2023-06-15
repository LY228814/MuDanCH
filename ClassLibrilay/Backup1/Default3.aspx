<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <meta name="keywords" content="车辆所在地 厂商 原始购车日期（精确到年） 车系 车型 车主期望售价 车辆来源，优卡二手车，二手车评估，二手车咨询，二手车置换，二手车买卖，二手车最新报价">    
</head>
<body>
    <form id="form1" runat="server">
        数据来源：<asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:DataGrid runat="server" ID="Repeater1">
        </asp:DataGrid>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </form>
</body>
</html>
