<%@ Page Title="" Language="C#" MasterPageFile="~/masterhome.Master" AutoEventWireup="true" CodeBehind="newsbd.aspx.cs" Inherits="MuDanWeb.newsbd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="KangHui.WebControls" Namespace="KangHui.WebControls" TagPrefix="uc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="list_ad"></div>
    <div class="blank"></div>
    <div class="mylist w1000 auto">
        <div class="list_l left">
            <dl>
                <dt>
                    <h2>
                        <asp:Label ID="leibie" runat="server" Text="新闻列表"></asp:Label></h2>
                </dt>
                <dd id="BDxilie">
                     <asp:Repeater ID="procat" runat="server">
                    <ItemTemplate>
                        <a href="productbd.aspx?type=<%=fhtype() %>&cid=<%# Eval("cid") %>"><%# Eval("categoryname") %></a>
                    </ItemTemplate>
                </asp:Repeater>
                </dd>
            </dl>
        </div>
        <!--列表右侧-->
        <div class="list_r right">
            <div class="list_pic">
                <dl>
                    <dt><h2><asp:Label ID="title" runat="server" Text="内容"></asp:Label></h2>
                       <!-- <span><a href="shouye.aspx">首页</a> > <a href="#">花盘实底系列</a> > <a href="#">花开富贵</a></span>-->    </dt>
                    <dd>
                       <div id="neirong" style="height:467px" runat="server">
                            <ul>
                           <asp:Repeater ID="prolist" runat="server">
                               <ItemTemplate>
                                   <li>
                                       <a href="productlist.aspx?type=<%# Eval("type")%>&pid=<%# Eval("pid") %>">
                                           <img src="<%# Eval("purl") %>" height="228" width="221" alt="">
                                       </a><p><%# Eval("pname") %></p>

                                   </li>
                               </ItemTemplate>
                           </asp:Repeater>
                               </ul>
                       </div>
                        <uc1:AspNetPager runat="server" ID="pager" PageSize="5"></uc1:AspNetPager>
                        <div class="clear"></div>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>
