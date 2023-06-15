<%@ Page Title="" Language="C#" MasterPageFile="~/MBindex.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MuDanCH.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <script src="js/content.js?v=1.0.0"></script>
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" full-height-layout" style="overflow: hidden;" id="wrapper">
			<!--左侧导航开始-->
			<nav class="navbar-default navbar-static-side" role="navigation">
				<div class="nav-close"><i class="fa fa-times-circle"></i></div>
				<div class="sidebar-collapse " >
					<ul class="nav" id="side-menu" >
						<li class="nav-header">
							<div class="dropdown profile-element">
								<span><img alt="image" class="img-circle" src="img/profile_small.jpg" /></span>
								<a data-toggle="dropdown" class="dropdown-toggle" href="#">
									<span class="clear">
										<span class="block m-t-xs"><strong class="font-bold">Beaut-zihan</strong></span>
										<span class="text-muted text-xs block">超级管理员<b class="caret"></b></span>
									</span>
								</a>
								<ul class="dropdown-menu animated fadeInRight m-t-xs">
									<li><a class="J_menuItem" href="form_avatar.html">修改头像</a></li>
									<li><a class="J_menuItem" href="profile.html">个人资料</a></li>
									<li><a class="J_menuItem" href="contacts.html">联系我们</a></li>
									<li><a class="J_menuItem" href="mailbox.html">信箱</a></li>
									<li class="divider"></li>
									<li><a href="login.html">安全退出</a></li>
								</ul>
							</div>
							<div class="logo-element">C+H</div>
						</li>
                        <li>
							<a class="J_menuItem" href="index_v1.aspx"><i class="fa fa-home"></i> <span class="nav-label">首页</span></a>
						</li>
						<li>
							<a href="#">
								<i class="fa fa-edit"></i>
								<span class="nav-label">用户管理</span>
								<span class="fa arrow"></span>
							</a>
							<ul class="nav nav-second-level">
								<li>
									<a class="J_menuItem" href="Musers.aspx">查看管理员</a>
								</li>
								<li>
									<a class="J_menuItem" href="Musersinsert.aspx">添加管理员</a>
								</li>
							</ul>
						</li>
						<li>
							<a href="#">
								<i class="fa fa-desktop"></i>
								<span class="nav-label">页面展示信息</span>
								<span class="fa arrow"></span>
							</a>
							<ul class="nav nav-second-level">
								<li>
									<a class="J_menuItem" href="Pagesetup.aspx">网站描述</a>
								</li>
								<li>
									<a class="J_menuItem" href="banner.aspx">轮播图片</a>
								</li>
								<li>
									<a class="J_menuItem" href="bannerinsert.aspx">添加轮播图片</a>
								</li>
							</ul>
						</li>

                        <li>
							<a href="#">
								<i class="glyphicon glyphicon-tasks"></i>
								<span class="nav-label">产品管理</span>
								<span class="fa arrow"></span>
							</a>
							<ul class="nav nav-second-level">
								<li>
									<a class="J_menuItem" href="category.aspx">查看产品类型</a>
								</li>
                                <li>
                                    <a class="J_menuItem" href="product.aspx">查看产品列表</a>
								</li>
								<li>
									<a class="J_menuItem" href="categoryinsert.aspx">添加类型</a>
								</li>
								<li>
									<a class="J_menuItem" href="productinsert.aspx">添加产品</a>
								</li>
							</ul>
						</li>
                        <li>
							<a href="#">
								<i class="glyphicon glyphicon-globe"></i>
								<span class="nav-label">新闻管理</span>
								<span class="fa arrow"></span>
							</a>
							<ul class="nav nav-second-level">
								<li>
									<a class="J_menuItem" href="news.aspx">新闻列表</a>
								</li>
								<li>
									<a class="J_menuItem" href="newsinsert.aspx">添加新闻</a>
								</li>
							</ul>
						</li>

						<li>
							<a href="#">
								<i class="glyphicon glyphicon-list"></i>
								<span class="nav-label">文章管理</span>
								<span class="fa arrow"></span>
							</a>
							<ul class="nav nav-second-level">
								<li><a class="J_menuItem" href="article.aspx">文章列表</a></li>
								<li><a class="J_menuItem" href="articleinsert.aspx">添加文章</a></li>
							</ul>
						</li>

						<li>
							<a class="J_menuItem" href="recyclebin.aspx"><i class="glyphicon glyphicon-trash"></i> <span class="nav-label">回收站</span></a>
						</li>
					</ul>
				</div>
			</nav>
			<!--左侧导航结束-->
			<!--右侧部分开始-->
			<div id="page-wrapper" class="gray-bg dashbard-1">
				<div class="row border-bottom">
					<nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0;">
						<div class="navbar-header">
							<a class="navbar-minimalize minimalize-styl-2 btn btn-primary" href="#"><i class="fa fa-bars"></i></a>
							<div role="search" class="navbar-form-custom" >
								<div class="form-group">
									<h3>欢迎使用MuDanCH后台管理系统</h3>
								</div>
							</div>
						</div>
						<ul class="nav navbar-top-links navbar-right">
							<li class="dropdown hidden-xs">
								<a class="right-sidebar-toggle" aria-expanded="false"> <i class="fa fa-tasks"></i> 主题 </a>
							</li>
						</ul>
					</nav>
				</div>
				<div class="row content-tabs">
					<button class="roll-nav roll-left J_tabLeft"><i class="fa fa-backward"></i></button>
					<nav class="page-tabs J_menuTabs">
						<div class="page-tabs-content">
							<a href="javascript:;" class="active J_menuTab" data-id="index_v1.html">首页</a>
						</div>
					</nav>
					<button class="roll-nav roll-right J_tabRight"><i class="fa fa-forward"></i></button>
					<div class="btn-group roll-nav roll-right">
						<button class="dropdown" data-toggle="dropdown">页签操作<span class="caret"></span></button>
						<ul role="menu" class="dropdown-menu dropdown-menu-right">
							<li class="tabCloseCurrent"><a>关闭当前</a></li>
							<li class="J_tabCloseOther"><a>关闭其他</a></li>
							<li class="J_tabCloseAll"><a>全部关闭</a></li>
						</ul>
					</div>
					<a href="#" class="roll-nav roll-right tabReload"><i class="fa fa-refresh"></i> 刷新</a>
				</div>
				<div class="row J_mainContent" id="content-main">
					<iframe class="J_iframe"  name="iframe0" width="100%" height="100%" src="index_v1.aspx?v=4.1" seamless="seamless"></iframe>
				</div>
				<div class="footer">
					<div class="pull-right">&copy; 2014-2015 <a href="http://www.zi-han.net/" target="_blank">zihan's blog</a></div>
				</div>
			</div>
			<!--右侧部分结束-->
			<!--右侧边栏开始-->
			<div id="right-sidebar">
				<div class="sidebar-container">
					<ul class="nav nav-tabs navs-3">
						<li class="active">
							<a data-toggle="tab" href="#tab-1"> <i class="fa fa-gear"></i> 主题 </a>
						</li>
					</ul>
					<div class="tab-content">
						<div id="tab-1" class="tab-pane active">
							<div class="sidebar-title">
								<h3><i class="fa fa-comments-o"></i> 主题设置</h3>
								<small><i class="fa fa-tim"></i> 你可以从这里选择和预览主题的布局和样式，这些设置会被保存在本地，下次打开的时候会直接应用这些设置。</small>
							</div>
							<div class="skin-setttings">
								<div class="title">主题设置</div>
								<div class="setings-item">
									<span>收起左侧菜单</span>
									<div class="switch">
										<div class="onoffswitch">
											<input type="checkbox" name="collapsemenu" class="onoffswitch-checkbox" id="collapsemenu" />
											<label class="onoffswitch-label" for="collapsemenu">
												<span class="onoffswitch-inner"></span>
												<span class="onoffswitch-switch"></span>
											</label>
										</div>
									</div>
								</div>
								<div class="setings-item">
									<span>固定顶部</span>

									<div class="switch">
										<div class="onoffswitch">
											<input type="checkbox" name="fixednavbar" class="onoffswitch-checkbox" id="fixednavbar" />
											<label class="onoffswitch-label" for="fixednavbar">
												<span class="onoffswitch-inner"></span>
												<span class="onoffswitch-switch"></span>
											</label>
										</div>
									</div>
								</div>
								<div class="setings-item">
									<span>
										固定宽度
									</span>

									<div class="switch">
										<div class="onoffswitch">
											<input type="checkbox" name="boxedlayout" class="onoffswitch-checkbox" id="boxedlayout" />
											<label class="onoffswitch-label" for="boxedlayout">
												<span class="onoffswitch-inner"></span>
												<span class="onoffswitch-switch"></span>
											</label>
										</div>
									</div>
								</div>
								<div class="title">皮肤选择</div>
								<div class="setings-item default-skin nb">
									<span class="skin-name">
										<a href="#" class="s-skin-0">
											默认皮肤
										</a>
									</span>
								</div>
								<div class="setings-item blue-skin nb">
									<span class="skin-name">
										<a href="#" class="s-skin-1">
											蓝色主题
										</a>
									</span>
								</div>
								<div class="setings-item yellow-skin nb">
									<span class="skin-name">
										<a href="#" class="s-skin-3">
											黄色/紫色主题
										</a>
									</span>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<!--右侧边栏结束-->
		</div>

</asp:Content>
