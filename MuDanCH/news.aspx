<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="MuDanCH.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="kindeditor/themes/default/default.css" rel="stylesheet" />
    <link rel="stylesheet" href="kindeditor/plugins/code/prettify.css" />
    <script charset="utf-8" src="kindeditor/kindeditor-all.js"></script>
    <script charset="utf-8" src="kindeditor/lang/zh-CN.js"></script>
    <script charset="utf-8" src="kindeditor/plugins/code/prettify.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="wrapper wrapper-content  animated fadeInRight">
             <div class="ibox">
                    <div class="ibox-content">
                        <span class="text-muted small pull-right">最后更新：<i class="fa fa-clock-o"></i> 2015-09-01 12:00</span>
                        <h2>新闻管理</h2>
                         <div class="row">
                            <div class="col-sm-2"></div>
                             <div class="col-sm-5">
                                <div class="input-group">
                                    <asp:TextBox ID="txtShuRu" placeholder="请输入关键词" CssClass="input-sm form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="sousuo" CssClass="btn btn-sm btn-primary" runat="server" Text="搜索" OnClick="sousuo_Click"  />
                                        <a href="newsinsert.aspx" class="btn btn-sm btn-primary">添加</a>
                                    </span>
                                </div>
                            </div>
                        </div>

                        <div class="clients-list">
                            <span class="pull-right small text-muted">共有 <asp:Label ID="num" runat="server" Text="*"></asp:Label> 篇新闻</span>
                            <ul class="nav nav-tabs">                              
                                <li class="active"><a data-toggle="tab" href="#tab-1"><i class="fa fa-user"></i> <asp:Label ID="creatxw" runat="server" Text="企业新闻"></asp:Label></a>
                                </li>
                                <li class=""><a data-toggle="tab" href="#tab-2"><i class="fa fa-briefcase"></i> 行内新闻</a>
                                </li>
                            
                            </ul>
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
                                                        <td><h3>操作</h3></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                   <asp:Repeater ID="Qnewstable" runat="server">
                                                        <ItemTemplate>
                                                             <tr>
                                                        <td><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                                                        <td><%# Eval("title") %></td>
                                                        <td><%# Eval("intro") %></td>
                                                        <td><%# Eval("author") %></td>
                                                        <td >
                                                            <asp:LinkButton ID="Ccreate" CommandArgument='<%# Eval("nid") %>' CommandName="Ccreate" runat="server">查看</asp:LinkButton>|
                                                            <asp:LinkButton ID="Cdelete" CommandArgument='<%# Eval("nid") %>' CommandName="Cdelete" runat="server">删除</asp:LinkButton>
                                                        </td>
                                                     </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                  </div>
                                <div id="tab-2" class="tab-pane">
                                         <div class="full-height-scroll">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-hover">
                                                <thead>
                                                    <tr>
                                                        <td><h3>选择</h3></td>
                                                        <td><h3>标题</h3></td>
                                                        <td><h3>简介</h3></td>
                                                        <td><h3>作者</h3></td>
                                                        <td><h3>操作</h3></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                   <asp:Repeater ID="Hnewstable" runat="server">
                                                        <ItemTemplate>
                                                             <tr>
                                                        <td><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                                                        <td><%# Eval("title") %></td>
                                                        <td><%# Eval("intro") %></td>
                                                        <td><%# Eval("author") %></td>
                                                        <td >
                                                            <asp:LinkButton ID="Ccreate" CommandArgument='<%# Eval("nid") %>' CommandName="Ccreate" runat="server">查看</asp:LinkButton>|
                                                            <asp:LinkButton ID="Cdelete" CommandArgument='<%# Eval("nid") %>' CommandName="Cdelete" runat="server">删除</asp:LinkButton>
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
				<a class="open-small-chat" href="newsinsert.aspx" title="点击添加新闻">
					<i class="glyphicon glyphicon-plus"></i>
				</a>
			</div>
</asp:Content>
