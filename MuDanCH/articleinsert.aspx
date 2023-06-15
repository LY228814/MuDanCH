<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="articleinsert.aspx.cs" Inherits="MuDanCH.articleinsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link href="kindeditor/themes/default/default.css" rel="stylesheet" />
    <link rel="stylesheet" href="kindeditor/plugins/code/prettify.css" />
    <script charset="utf-8" src="kindeditor/kindeditor-all.js"></script>
    <script charset="utf-8" src="kindeditor/lang/zh-CN.js"></script>
    <script charset="utf-8" src="kindeditor/plugins/code/prettify.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>文章添加</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="form-horizontal">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">标题</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Texttitle" placeholder="请输入标题" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">简介</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Textinfo" placeholder="请输入简介" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">作者</label>
                                <div class="col-sm-6">
                                   <asp:TextBox ID="Textname" placeholder="请输入作者名字" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">内容</label>
                                <div class="col-sm-6">
                                    <textarea id="txtDetail" cols="100" rows="30" style="width: 700px; height: 500px; visibility: hidden;" runat="server"></textarea>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                     <asp:Button ID="fromzl" CssClass="btn btn-primary" runat="server" Text="确认提交" OnClick="fromzl_Click" />
                                    <a class="btn btn-white" href="article.aspx">取消</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        KindEditor.ready(function (K) {
            var editor1 = K.create('#<%=txtDetail.ClientID%>', {
                cssPath: 'kindeditor/plugins/code/prettify.css',
                uploadJson: 'kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: 'kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
</asp:Content>
