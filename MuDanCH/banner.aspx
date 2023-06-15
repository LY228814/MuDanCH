<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="banner.aspx.cs" Inherits="MuDanCH.banner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content">
        <div class="ibox">
            <div class="ibox-content">
                <span class="text-muted small pull-right">最后更新：<i class="fa fa-clock-o"></i> 2015-09-01 12:00</span>
                <h2>轮播图</h2>
                <div class="row">
                    <asp:Repeater ID="bannertable" runat="server" OnItemCommand="bannertable_ItemCommand" >
                        <ItemTemplate>
                            <div class="col-sm-4">
                        <div class="ibox-title">
                            <h5><%# Eval("pname") %></h5>
                            <i class="fa fa-clock-o"> </i> <asp:Label ID="Label1" runat="server" Text='<%# Eval("createtime") %>'></asp:Label>
                            <div class="ibox-tools">
                                    操作<asp:LinkButton ID="bupdate" CommandArgument='<%# Eval("bid") %>' CommandName="bupdate" runat="server">修改</asp:LinkButton>
                                        <asp:LinkButton ID="bdelete" CommandArgument='<%# Eval("bid") %>' CommandName="bdelete" runat="server">删除</asp:LinkButton>
                            </div>
                        </div>
                        <div class="ibox-content"> 
                            <asp:Image ID="Image1" Width="300" Height="200" ImageUrl='<%# Eval("purl") %>' runat="server" />
                        </div>
                        </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </div>
            </div>
        </div>
    </div>
    <div id="small-chat" style="margin-bottom:50PX">
				<span class="badge badge-warning pull-right"></span>
				<a class="open-small-chat" href="bannerinsert.aspx" title="点击添加轮播图">
					<i class="glyphicon glyphicon-plus"></i>
				</a>
			</div>
</asp:Content>
