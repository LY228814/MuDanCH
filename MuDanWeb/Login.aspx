<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MuDanCH.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="js/jquery-3.5.1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle-box text-center loginscreen  animated fadeInDown">
        <div>
            <div>
                <h1 class="logo-name">C+H</h1>

            </div>
            <h3>欢迎使用 牡丹瓷行</h3>

            <div class="m-t" role="form" >
                <div class="form-group">
                    <asp:TextBox ID="Textname" CssClass="form-control put1" placeholder="请输入用户名"  maxlength="14" required="server"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
            <asp:TextBox ID="Textpwd" CssClass="form-control put1" placeholder="请输入用密码"  maxlength="14"   required="server" runat="server"></asp:TextBox>
                </div>
                 <div class="form-group">
            <div class="pull-right">
            <asp:Image Runat="server" ID="getcode" ClientIDMode="Static" ImageUrl="ValidateCode.aspx"></asp:Image>&nbsp;
                <a id="yzmsx" href="#" >点击刷新</a>
            </div>
            <asp:TextBox ID="TextYZ" CssClass="form-control put3 " Width="179px" placeholder="请输入验证码"  required="server" runat="server"></asp:TextBox>
                     <asp:Button ID="Button1" type="submit" CssClass="btn btn-primary block full-width m-b" runat="server" OnClientClick="return houtai()" Text="登 录" OnClick="Button1_Click" />
                </div>
                
                <p class="text-muted text-center"> <small>忘记密码,请联系管理员.</small> </p>

            </div>
        </div>
    </div>
     <script>
         $(function () {
             $("#<%= TextYZ.ClientID%>").css("display", "inline");
            $("#yzmsx").click(function () {
                $("#getcode").attr("src", "ValidateCode.aspx?" + Math.random());
            })
        });
     </script>

     <script type="text/javascript">
    function houtai() {
        if ($("#<%= Textname.ClientID%> ").val() != "" && $("#<%= Textpwd.ClientID%>").val() != "") {
            if ($("#<%= TextYZ.ClientID%>").val() != "") {
                if ($("#<%= TextYZ.ClientID%>").val() == $.cookie('code')) {
                    return true;
                } else {
                    alert("验证码错误,请重新输入!");
                    return false;
                }
            } else {
                alert("请输入验证码!");
                return false;
            }
        } else {
            alert("请输入账号或密码!");
            return false;
        }
         }
     </script>
   
         

</asp:Content>
