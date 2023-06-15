<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="imgshangcuan.ascx.cs" Inherits="MuDanCH.imgshangcuan" %>
<link href="webuploader/webuploader.css" rel="stylesheet" />
        <script src="js/jquery.min.js"></script>
        <script src="webuploader/webuploader.js"></script>

            <div id="uploader" class="wu-example">
                    <!--用来存放文件信息-->
                    <div id="thelist" class="uploader-list"></div>
                    <div class="btns">

                        
                        <asp:Image ID="Imagetext" ImageUrl="img/webuploader.png" width="120" height="80" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <div id="picker">选择文件</div>
                    </div>
                </div>
 <script>

           var uploader = WebUploader.create({
               // swf文件路径
               swf: '/webuploader/Uploader.swf',
               // 文件接收服务端。
               server: 'fileupload.ashx',
               // 选择文件的按钮。可选。
               // 内部根据当前运行是创建，可能是input元素，也可能是flash.
               pick: '#picker',
               //自动上传 不需要按钮触发
               auto:true
           });

           //图片上传成功事件
           uploader.on('uploadSuccess', function (file, response) {
               var imgname = file.name;
               var url = "/images/" + imgname;
               $('#<%=Imagetext.ClientID%>').attr("src", url);
               $("#<%=HiddenField1.ClientID%>").val(url);
           });

           uploader.on('uploadError', function (file) {
               $('#' + file.id).find('p.state').text('上传出错');
           });
       </script>