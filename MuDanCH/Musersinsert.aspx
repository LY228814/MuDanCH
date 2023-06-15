<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="Musersinsert.aspx.cs" Inherits="MuDanCH.Musersinsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>管理员</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="form-horizontal">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">账号</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Textname" placeholder="请输入账号" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                                    <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">密码</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Textpwd" placeholder="请输入密码" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">手机号</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Textphone" placeholder="请输入手机号" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                     <asp:Button ID="fromzl" CssClass="btn btn-primary" runat="server" Text="确认提交" OnClick="fromzl_Click" />
                                    <a class="btn btn-white" href="Musers.aspx">取消</a>                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
