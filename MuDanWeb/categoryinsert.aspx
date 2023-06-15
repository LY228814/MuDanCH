<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="categoryinsert.aspx.cs" Inherits="MuDanCH.categoryinsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>产品系列添加</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="form-horizontal">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">系列名</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Textname" runat="server" placeholder="请输入添加系列名" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                                <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">选择类型</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="leixinglist" CssClass="form-control" Style="display: inline;" runat="server">
                                        <asp:ListItem Value="0">请选择类型</asp:ListItem>
                                        <asp:ListItem Value="1">牡丹石类型</asp:ListItem>
                                        <asp:ListItem Value="2">牡丹瓷类型</asp:ListItem>
                                        <asp:ListItem Value="3">白瓷类型</asp:ListItem>
                                        <asp:ListItem Value="4">其他类型</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">简介</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Textjj" runat="server" placeholder="请输入系列名简介" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button ID="tijiao" CssClass="btn btn-primary" runat="server" Text="确认提交" OnClick="tijiao_Click" />
                                    <a class="btn btn-white" href="category.aspx">取消</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
