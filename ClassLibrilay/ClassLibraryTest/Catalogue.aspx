<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Catalogue.aspx.cs" Inherits="Catalogue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ucar公用类库目录</title>
</head>
<body style="font-size:14px;">
    <form id="form1" runat="server">
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" ExpandDepth="0" ShowLines="True" CollapseImageToolTip="" ExpandImageToolTip="">
        </asp:TreeView>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="False" SiteMapProvider="CatalogueSiteMap" />
    </form>
</body>
</html>
