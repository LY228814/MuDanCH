<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="article.aspx.cs" Inherits="MuDanCH.article" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            right: 26px;
            bottom: 215px;
            width: 61px;
            height: 62px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content ">
                <div class="ibox">
                    <div class="ibox-content">
                        <span class="text-muted small pull-right">最后更新：<i class="fa fa-clock-o"></i> 2015-09-01 12:00</span>
                        <h2>文章管理</h2> 
                     </div>
                    <div class="ibox-content">
                        <div class="row">
                        <div class="col-sm-2"></div>
                        <div class="col-sm-8">
                          <div class="input-group">
                            <asp:TextBox ID="SStext" type="text" placeholder="请输入文章标题关键字" CssClass="input form-control" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="sousuo" CssClass="btn btn-sm btn-primary" runat="server" Text="搜索" OnClick="sousuo_Click" />
                                        <a href="articleinsert.aspx" class="btn btn-sm btn-primary">添加</a>
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
                                                        <td><h3>标题</h3></td>
                                                        <td><h3>简介</h3></td>
                                                        <td><h3>作者</h3></td>
                                                        <td><h3>创建时间</h3></td>
                                                        <td><h3>阅读次数</h3></td>
                                                        <td><h3>操作</h3></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                   <asp:Repeater ID="articletable" runat="server" OnItemCommand="articletable_ItemCommand">
                                                        <ItemTemplate>
                                                             <tr>
                                                        <td><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                                                        <td><%# Eval("title") %></td>
                                                        <td><%# Eval("intro") %></td>
                                                        <td><%# Eval("auther") %></td>
                                                        <td><%# Eval("createtime") %></td>
                                                        <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("readcount") %>'></asp:Label></td><td >
                                                            <asp:LinkButton ID="Acreate" CommandArgument='<%# Eval("aid") %>' CommandName="Acreate" runat="server">修改</asp:LinkButton>|
                                                            <asp:LinkButton ID="Adelete" CommandArgument='<%# Eval("aid") %>' CommandName="Adelete" runat="server">删除</asp:LinkButton>
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
				<a class="open-small-chat" href="articleinsert.aspx" title="点击添加文章">
					<i class="glyphicon glyphicon-plus"></i>
				</a>
			</div>
</asp:Content>
