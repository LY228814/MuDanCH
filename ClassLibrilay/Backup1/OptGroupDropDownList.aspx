<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OptGroupDropDownList.aspx.cs" Inherits="OptGroupDropDownList" %>
<%@ Register Namespace="KangHui.WebControls" Assembly="KangHui.WebControls" TagPrefix="ogddl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>分组下拉列表示例</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ogddl:OptGroupDropDownList id="ogddlArea" runat="server"></ogddl:OptGroupDropDownList>
    </div>
    </form>
</body>
</html>
