<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestForDomain.aspx.cs" Inherits="TestForDomain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script src="js/jquery-1.4.2.min.js" language="javascript" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    function test(){
        var  url= 'http://buy-tuan.com/api/list/json.aspx?city=bj&qy=01&fl=0&page=1&pagenum=20&sort=mr'; //"../../UserControls/JqueryCityLoad.aspx";
           var times=new Date().getTime();
           $.get(url,{time:times},function(data){
             alert(data);
           });
    }
    
    
    </script>
</head>
<body onload="test();">
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
