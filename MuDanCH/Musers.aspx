<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="Musers.aspx.cs" Inherits="MuDanCH.Musers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="wrapper wrapper-content  ">
                <div class="ibox">
                    <div class="ibox-content">
                        <span class="text-muted small pull-right">最后刷新：<i class="fa fa-clock-o"></i> 2015-09-01 12:00</span>
                        <h2>用户管理</h2>                      
                        <div class="clients-list">                       
                            <div class="tab-content">
                                <div id="tab-1" class="tab-pane active">
                                    <div class="full-height-scroll">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-hover">
                                                <thead>
                                                    <tr>
                                                        <td><h3>账号</h3></td>
                                                        <td><h3>密码</h3></td>
                                                        <td><h3>手机号</h3></td>
                                                        <td><h3>创建时间</h3></td>
                                                        <td><h3>操作</h3></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                   <asp:Repeater ID="managetable" runat="server">
                                                        <ItemTemplate>
                                                             <tr>
                                                        <td><%# Eval("Uadmin") %></td>
                                                        <td><%# Eval("Upwd") %></td>
                                                        <td><%# Eval("phone") %></td>
                                                        <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("creattime") %>'></asp:Label></td><td >
                                                            <asp:LinkButton ID="Acreate" CommandArgument='<%# Eval("Uid") %>' CommandName="Acreate" runat="server">查看密码</asp:LinkButton>
                                                        </td>
                                                     </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                               </div>
						</div>
					</div>
</div>
		    </div>
    </div>
</asp:Content>
