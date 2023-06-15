<%@ Page Title="" Language="C#" MasterPageFile="~/masterhome.Master" AutoEventWireup="true" CodeBehind="shouye.aspx.cs" Inherits="MuDanCH.shouye" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <!--幻灯片开始-->
            <div class="container">
                <div class="bannerbox">
                    <div id="focus">
                        <ul>
                            <asp:Repeater ID="repbanner" runat="server">
                                <ItemTemplate>
                                    <li><a href="#">
                                        <img width="1440" height="460" src="<%# Eval("purl")%>" alt="<%# Eval("pname")%>" />
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
              <div class="myline"></div>
            </div>

            <!--四个分类导航-->
            <div class="w1000 auto fenlei">
                <ul>
                    <li>
                        <h3><a href="ProductIntro.aspx?id=1">牡丹石</a></h3>
                        <a href="/">牡丹石与国色牡丹，共聚大唐官窑，经过火的考验...</a> </li>
                    <li>
                        <h3><a href="ProductIntro.aspx?id=2">牡丹瓷</a></h3>
                        <a href="/">牡丹瓷瓷与国色牡丹，共聚大唐官窑，经过火的考验...</a> </li>
                    <li>
                        <h3><a href="ProductIntro.aspx?id=3">白瓷</a></h3>
                        <a href="/">唐白瓷与国色牡丹，共聚大唐官窑，经过火的考验...</a> </li>
                    <li>
                        <h3><a href="ProductIntro.aspx?id=4">其他</a></h3>
                        <a href="/">各种瓷器瓷与国色牡丹，共聚大唐官窑，经过火的考验...</a> </li>
                </ul>
            </div>
            <div class="blank"></div>
            <div class="w1000 auto myabout">
                <div class="about left">
                    <dl>
                        <dt>
                            <h2>关于我们</h2>
                            <span><a href="#">
                                <img src="images/ind_15.png" /></a></span></dt>
                        <dd>
                            <img src="images/ind_21.jpg" alt="" class="about_pic" />
                            <div class="about_r">
                               <p><%=BDinftro() %></p>

                            </div>
                        </dd>
                    </dl>

                </div>
                <!--about右侧-->
                <div class="contact right">
                    <a href="#">
                        <img src="images/ind_17.jpg" alt="" /></a>
                    <a href="#">
                        <img src="images/ind_24.jpg" alt="" /></a>
                </div>
            </div>
            <!--产品展示-->
            <div class="show w1000 auto">
                <dl>
                    <dt><>产品展示</>
                        <span><a href="#">
                            <img src="images/ind_15.png" /></a></span></dt>
                    <dd>
                        <ul class="myshow">
                            <%=InitTopProduct() %>
                            
                        </ul>
                    </dd>

                </dl>
                <div class="clear"></div>
            </div>
</asp:Content>
