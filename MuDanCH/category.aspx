<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="MuDanCH.category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="wrapper wrapper-content  animated fadeInRight">
                <div class="ibox">
                    <div class="ibox-content">
                        <span class="text-muted small pull-right">最后刷新：<i class="fa fa-clock-o"></i><asp:Label ID="texttime" runat="server" Text="*"></asp:Label></span>
                        <h2>产品类型</h2>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-2"></div>
                             <div class="col-sm-5">
                                <div class="input-group">
                                    <asp:TextBox ID="txtShuRu" placeholder="请输入产品类型关键词" CssClass="input-sm form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="sousuo" CssClass="btn btn-sm btn-primary" runat="server" Text="搜索" OnClick="sousuo_Click"  />
                                        <a href="categoryinsert.aspx" class="btn btn-sm btn-primary">添加</a>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="clients-list">
                            <div class="tab-content">
                                <div id="tab-1" class="tab-pane active">
                                    <div class="full-height-scroll">
                                        <div class="table-responsive">
                                            
                                            <table class="table table-striped table-hover">
                                                <thead>
                                                    <tr>
                                                        <td><h3>选择</h3></td>
                                                        <td><h3>产品系列</h3></td>
                                                        <td><h3>产品类型</h3></td>
                                                        <td><h3>产品简介</h3></td>
                                                        <td><h3>创建时间</h3>
                                                        </td>
                                                        <td class="client-status"><h3>操作</h3>
                                                        </td>
                                                     </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="categorytable" runat="server" OnItemCommand="categorytable_ItemCommand">
                                                        <ItemTemplate>
                                                             <tr>
                                                                 <td>
                                                      <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                                                        <td><%# Eval("categoryname") %></td>
                                                        <td><%# type( Eval("type")) %></td>
                                                        <td><%# Eval("intro") %></td>
                                                        <td><i class="fa fa-clock-o"> </i><%# Eval("createtime") %></td>
                                                        <td >
                                                            <asp:LinkButton ID="Cupdate" CommandArgument='<%# Eval("cid") %>' CommandName="Cupdate" runat="server">修改</asp:LinkButton>|
                                                            <asp:LinkButton ID="Cdelete" CommandArgument='<%# Eval("cid") %>' CommandName="Cdelete" runat="server">删除</asp:LinkButton>
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
    <div id="small-chat" style="margin-bottom:50PX">
				<span class="badge badge-warning pull-right"></span>
				<a class="open-small-chat" href="categoryinsert.aspx" title="点击添加类型">
					<i class="glyphicon glyphicon-plus"></i>
				</a>
			</div>
</asp:Content>
