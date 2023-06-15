<%@ Page Title="" Language="C#" MasterPageFile="~/masterhome.Master" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="MuDanCH.productlist" %>
<%@ Register Assembly="KangHui.WebControls" Namespace="KangHui.WebControls" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="list_ad"></div>
    <div class="blank"></div>
    <div class="mylist w1000 auto">
        <div class="list_l left">
            <dl>
                <dt>
                    <h2>
                        <asp:Label ID="leibie" runat="server" Text="牡丹瓷"></asp:Label>
                    </h2>
                </dt>
                <dd id="BDxilie" runat="server">
                    
                </dd>
            </dl>
        </div>
        <!--列表右侧-->
        <div class="list_r right">
            <div class="list_pic">
                <dl>
                    <dt>
                        <h2><asp:Label ID="title" runat="server" Text="内容"></asp:Label></h2>
                       <span><a href="shouye.aspx">返回首页</a> >>></span>
                    </dt>
                    <dd>
                       <div id="neirong" style="height:467px" runat="server"></div>
                        <uc1:AspNetPager runat="server" ID="pager" PageSize="5"></uc1:AspNetPager>
                        <div class="clear"></div>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
        <div class="blank"></div>
    <div class="clear"></div>
</asp:Content>
