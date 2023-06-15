<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="newsinsert.aspx.cs" Inherits="MuDanCH.newsinsert" %>
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
                        <h5>新闻添加</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="form-horizontal">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">新闻标题</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Texttitle" placeholder="输入新闻标题" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                                 <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">选择新闻类型</label>
                                <div class="col-sm-6">
                                    <asp:RadioButton ID="RBqy" value="1" Checked="true" Text="企业新闻" GroupName="xinwen" runat="server" />
                                    <asp:RadioButton ID="RBhn" value="2" Text="行内新闻" GroupName="xinwen" runat="server" />
                                </div>
                            </div>
                                  <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">新闻简介</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Textintro" placeholder="输入新闻简介" CssClass="form-control" runat="server"></asp:TextBox>
                                     </div>
                            </div>
                                 <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">新闻作者</label>
                                <div class="col-sm-6">
                                   <asp:TextBox ID="Textauthor" placeholder="添输入作者名" CssClass="form-control" runat="server"></asp:TextBox>
                                     </div>
                            </div>
                                 <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">新闻内容</label>
                                <div class="col-sm-6">
                                    <textarea id="txtDetail" cols="100" rows="30" style="width: 700px; height: 500px; visibility: hidden;" runat="server"></textarea>
                                </div>
                            </div>
                                  <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button ID="tianjia" CssClass="btn btn-primary" runat="server" Text="确认提交" OnClick="tianjia_Click" />
                                    <a class="btn btn-white" href="news.aspx">取消</a>
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
