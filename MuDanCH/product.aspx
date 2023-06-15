<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="MuDanCH.product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content">
        <div class="ibox">
             <div class="ibox-content">
                 <span class="text-muted small pull-right">最后更新 <asp:Label ID="Gxtime" runat="server" Text=""></asp:Label></span>
                  <h2>产品列表</h2>
                 </div>    
             <div class="ibox-content"> 
                   <div class="row">
                       <div class="col-sm-2"></div>
                            <div class="col-sm-5 m-b-xs">
                                <asp:DropDownList ID="ddlpro" CssClass="input-sm form-control input-s-sm inline" runat="server">
                                    <asp:ListItem Value="0">请选择系列</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             <div class="col-sm-3">
                                <div class="input-group">
                                    <asp:TextBox ID="txtShuRu" placeholder="请输入关键词" CssClass="input-sm form-control" runat="server" style="left: 0px; top: 0px; width: 100%"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="sousuo" CssClass="btn btn-sm btn-primary" runat="server" Text="搜索" OnClick="sousuo_Click" />
                                        <a href="productinsert.aspx" class="btn btn-sm btn-primary">添加</a>
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
                                                        <td><h5>是否首推</h5></td>
                                                        <td><h5>名字</h5></td>
                                                        <td><h5>图片</h5></td>
                                                        <td><h5>类型</h5></td>
                                                        <td><h5>作者</h5></td>
                                                        <td><h5>简介</h5></td>
                                                        <td><h5>创建时间</h5></td>
                                                        <td><h5>推荐</h5></td>
                                                        <td><h5 >操作</h5></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                   <asp:Repeater ID="producttable" runat="server" OnItemCommand="producttable_ItemCommand" >
                                                        <ItemTemplate>
                                                             <tr>
                                                        <td> <%# shoutui(Eval("istop"))%></td>
                                                        <td><%# Eval("pname") %></td>
                                                        <td>
                                                            <asp:Image ID="Image1" ImageUrl='<%# Eval("purl") %>' Width="50" Height="50" runat="server" /></td>
                                                        <td><%# type(Eval("cid")) %></td>
                                                        <td><%# Eval("author") %></td>
                                                        <td style="width:80px; height:80px" ><%# Eval("intro") %></td>
                                                        <td><%# Eval("createtime") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("pid") %>' CommandName="zhiding" runat="server">首推</asp:LinkButton>|
                                                            <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("pid") %>' CommandName="buzhiding" runat="server">不首推</asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="Acreate" CommandArgument='<%# Eval("pid") %>' CommandName="Pupdate" runat="server">修改</asp:LinkButton>|
                                                            <asp:LinkButton ID="Adelete" CommandArgument='<%# Eval("pid") %>' CommandName="Pdelete" runat="server">删除</asp:LinkButton>
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
				<a class="open-small-chat" href="productinsert.aspx" title="点击添加产品">
					<i class="glyphicon glyphicon-plus"></i>
				</a>
			</div>
</asp:Content>
