<%@ Page Title="" Language="C#" MasterPageFile="~/masterhome.Master" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="MuDanCH.productlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="list_ad"></div>
    <div class="blank"></div>
    <div class="mylist w1000 auto">
        <div class="list_l left">
            <dl>
                <dt>
                    <h2>
                        <asp:Label ID="leibie" runat="server" Text="牡丹瓷"></asp:Label></h2>
                </dt>
                <dd id="BDxilie" runat="server">

                </dd>
            </dl>
        </div>
        <!--列表右侧-->
        <div class="list_r right">
            <div class="list_show">
                <dl>
                    <dt>
                        <h2>产品详情</h2>
                        <span><a href="/index.aspx">首页</a> > <a href="#">花盘实底系列</a> > <a href="#">花开富贵</a></span>    </dt>
                    <dd>
                        <div class="wzxx-tit">花开富贵</div>
                        <div class="wzxx-time">发布时间：2017-08-03  阅读：1847</div>
                        <div class="wzxx-nr">
                            <h2 style="text-align: center;">
                                <span style="color: #64451D; font-family: SimSun;">精品手绘花开富贵-魏紫</span>
                            </h2>
                            <h3 style="text-align: center;">
                                <span style="color: #000000; font-family: SimSun;">36厘米</span>
                            </h3>
                            <p>
                                <span style="color: #000000; font-family: SimSun;">
                                    <img src="/kindeditor/asp.net/../attached/image/20170803/20170803140223_6663.jpg" alt="" /><img src="/kindeditor/asp.net/../attached/image/20170803/20170803140223_9944.jpg" alt="" /><br />
                                </span>
                            </p>
                        </div>
                        <div class="clear"></div>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>
