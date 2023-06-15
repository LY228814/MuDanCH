<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="bannerinsert.aspx.cs" Inherits="MuDanCH.bannerinsert" %>

<%@ Register Src="~/imgshangcuan.ascx" TagPrefix="uc1" TagName="imgshangcuan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>轮播图添加 </h5>
                    </div>
                    <div class="ibox-content">
                        <div  class="form-horizontal">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">轮播图名字</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Textname" placeholder="输入轮播图名字" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>                            
                            </div>
                            <div class="hr-line-dashed"></div> 
                                 <div class="form-group">
                                <label class="col-sm-2 control-label">上传图片</label>
                                <div class="col-sm-6">
                                    <uc1:imgshangcuan runat="server" ID="imgshangcuan" />
                                 </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button ID="fromzl" CssClass="btn btn-primary" runat="server" Text="确认提交" OnClick="fromzl_Click" />
                                    <a class="btn btn-white" href="banner.aspx">取消</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
