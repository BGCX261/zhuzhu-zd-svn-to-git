<?xml version="1.0" encoding="UTF-8" ?>
<!--
'///////////////////////////////////////////////////////////////////////////////
'//              Z-Blog
'// 作    者:    朱煊(zx.asd)
'// 版权所有:    Copyright 2004 RainbowSoft Studio.
'// 技术支持:    rainbowsoft@163.com
'// 程序名称:    
'// 程序版本:    
'// 单元名称:    
'// 开始时间:    2005.08.02
'// 最后修改:    
'// 备    注:    XSLT模板 for default.asp
'///////////////////////////////////////////////////////////////////////////////
-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml">
	<xsl:output method="xml" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" encoding="utf-8" indent="yes"/>
	<xsl:template match="zdevo">
		<html>
			<head>
				<meta http-equiv="Content-Type" content="application/xhtml+xml; charset=utf-8"/>
				<title><xsl:value-of select="//data/site/title" /><xsl:text>_</xsl:text><xsl:value-of select="//data/headtitle" /></title>
				<xsl:element name="link">
					<xsl:attribute name="rel">stylesheet</xsl:attribute>
					<xsl:attribute name="rev">stylesheet</xsl:attribute>
					<xsl:attribute name="href"><xsl:value-of select="//data/site/config/variable[@name='SITE_HOST']" />theme/<xsl:value-of select="//data/site/config/variable[@name='SITE_TEMPLATE']" />/code/Css.ashx?color=crimson</xsl:attribute>
					<xsl:attribute name="type">text/css</xsl:attribute>
					<xsl:attribute name="media">screen</xsl:attribute>
				</xsl:element>
 				<xsl:element name="script">
					<xsl:attribute name="src"><xsl:value-of select="//data/site/config/variable[@name='SITE_HOST']" />theme/default/script/mootools.js</xsl:attribute>
					<xsl:attribute name="type">text/javascript</xsl:attribute>
					<xsl:text >&#173;</xsl:text>
				</xsl:element>
 				<xsl:element name="script">
					<xsl:attribute name="src"><xsl:value-of select="//data/site/config/variable[@name='SITE_HOST']" />theme/default/script/common.js</xsl:attribute>
					<xsl:attribute name="type">text/javascript</xsl:attribute>
					<xsl:text >&#173;</xsl:text>
				</xsl:element>
 				<xsl:element name="link">
					<xsl:attribute name="rel">alternate</xsl:attribute>
					<xsl:attribute name="type">application/rss+xml</xsl:attribute>
					<xsl:attribute name="href"><xsl:value-of select="//data/site/column[@id='index']/rss" /></xsl:attribute>
					<xsl:attribute name="title"><xsl:value-of select="//data/site/title" /></xsl:attribute>
				</xsl:element>
 				<xsl:element name="link">
					<xsl:attribute name="rel">EditURI</xsl:attribute>
					<xsl:attribute name="type">application/rsd+xml</xsl:attribute>
					<xsl:attribute name="href"><xsl:value-of select="//data/site/rsdurl" /></xsl:attribute>
				</xsl:element>
 				<xsl:element name="link">
					<xsl:attribute name="rel">wlwmanifest</xsl:attribute>
					<xsl:attribute name="type">application/wlwmanifest+xml</xsl:attribute>
					<xsl:attribute name="href"><xsl:value-of select="//data/site/wlwmanifesturl" /></xsl:attribute>
				</xsl:element>
			</head>
			<body class="index">

				<div id="divAll">
					<div id="divPage">
					<div id="divMiddle">
					<div id="divMiddleLeft">
					<div id="divMiddleRight">
						<div id="divTop">
							<div id="divTitle">
								<h1 id="Title">
									<xsl:element name="a">
										<xsl:attribute name="href"><xsl:value-of select="//data/site/url" /></xsl:attribute>
										<xsl:value-of select="//data/site/title" />
									</xsl:element>
								</h1>
								<h3 id="SubTitle"><xsl:value-of select="//data/site/subtitle" /></h3>
							</div>
							<div id="divNavBar">
								<h3>导航</h3>
								<ul>
<xsl:apply-templates select="data/site/column" />
								</ul>
							</div>
						</div>
						<div id="divMain">

<xsl:apply-templates select="data/posts" />

						</div>
						<div id="divSidebar">

							<div class="function">
							<h3>新评论(留言)</h3>
							<ul>
<xsl:apply-templates select="data/comments" />
							</ul>
							</div>

						</div>
						<div id="divBottom">
							<h3 id="PowerBy">Powered by <a href="http://www.zdevo.com/" title="zdevo"><xsl:value-of select="//data/site/config/variable[@name='APPLICATION_PRODUCT_NAME']" /><xsl:text > </xsl:text><xsl:value-of select="//data/site/config/variable[@name='APPLICATION_PRODUCT_VERSION']" /></a>,Template by <a href="http://www.zdevo.com/" title="zdevo">Nagrand</a>.</h3>
							<h2 id="CopyRight"><xsl:value-of select="//data/site/config/variable[@name='APPLICATION_COPYRIGHT']" /></h2>
						</div>
					</div>
					</div>
					</div>
					</div>
				</div>
						<div id="divSidebar2">
							<div class="function">
							<!-- <h3>About Me</h3> -->
							<ul>
								<li><img style="border:5px solid #EEE;" src="http://lh4.google.com/rainbowsoft/R5oqcCOK4SE/AAAAAAAABIA/Z5bPpGq_a_Q/s160-c/ZyTZvI.jpg" alt="" title="" height="96" width="96" /></li>
								<li><a href="http://www.blogger.com/profile/15071571611261989536">Profile in blogger.com</a></li>
							</ul>
							</div>


							<div class="function">
							<!-- <h3>About Me</h3> -->
							<ul>
								<li>
								
	<xsl:if test="count(//data/user)>0">
		<p><xsl:value-of select="//data/user/name" />已登陆</p>
		<p>
			<xsl:element name="a">
				<xsl:attribute name="href">JavaScript:Logout('<xsl:value-of select="//data/site/loginurl" />')</xsl:attribute>
				[退出]
			</xsl:element>
		
		</p>
	</xsl:if>

	<xsl:if test="count(//data/user)=0">
<form method="post" action="--WEBBOT-SELF--">
	<p>用户名：<br/><input type="text" name="inpUserName" id="inpUserName" style="width:100px;" size="12"/></p>
	<p>密码：<br/><input type="password" name="inpPassWord" id="inpPassWord" style="width:100px;" size="12"/></p>
	<p>
	<xsl:element name="input">
	<xsl:attribute name="type">submit</xsl:attribute>
	<xsl:attribute name="value">登陆</xsl:attribute>
	<xsl:attribute name="onclick">JavaScript:Login('<xsl:value-of select="//data/site/loginurl" />',$('inpUserName').getValue(),$('inpPassWord').getValue());return false;</xsl:attribute>
	</xsl:element>
	</p>
</form>	
	</xsl:if>				
								
								
								</li>
							</ul>
							</div>

							<div class="function" style="text-align:center;">
								<xsl:element name="a">
									<xsl:attribute name="href"><xsl:value-of select="//data/site/column[@id='index']/rss" /></xsl:attribute>
									<xsl:element name="img">
										<xsl:attribute name="src"><xsl:value-of select="//data/site/config/variable[@name='SITE_HOST']" />theme/default/style/image/konqsidebar_news.png</xsl:attribute>
										<xsl:attribute name="alt">Rss Feed</xsl:attribute>
										<xsl:attribute name="title">Rss Feed</xsl:attribute>
									</xsl:element>
								</xsl:element>
								  <p>
    <a href="http://validator.w3.org/check?uri=referer"><img
        src="http://www.w3.org/Icons/valid-xhtml11"
        alt="Valid XHTML 1.1" height="31" width="88" /></a>
  </p>
  <p>
 <a href="http://jigsaw.w3.org/css-validator/">
  <img style="border:0;width:88px;height:31px"
       src="http://jigsaw.w3.org/css-validator/images/vcss" 
       alt="Valid CSS!" />
 </a>
  </p>
  <p>
  <a href="http://validator.w3.org/feed/check.cgi?url=http%3A//www.zdevo.com/feed/rss/default.aspx"><img src="http://validator.w3.org/feed/images/valid-rss.png" alt="[Valid RSS]" title="Validate my RSS feed" /></a>
  </p>

							</div>

						</div>

			</body>
		</html>
	</xsl:template>

	<xsl:template match="posts">

	<xsl:element name="div">
		<xsl:attribute name="class">post&#000032;index</xsl:attribute>
		<h4 class="post-date"><xsl:value-of select=".//postdate[1]" /></h4>
	</xsl:element>

<xsl:for-each select="*">

	<xsl:if test="name()='twitter'">
<xsl:apply-templates select="." />
	</xsl:if>
	<xsl:if test="name()='article'">
<xsl:apply-templates select="." />
	</xsl:if>
	<xsl:if test="name()='bookmark'">
<xsl:apply-templates select="." />
	</xsl:if>
	<xsl:if test="name()='gallery'">
<xsl:apply-templates select="." />
	</xsl:if>
	<xsl:if test="name()='share'">
<xsl:apply-templates select="." />
	</xsl:if>

</xsl:for-each>

	</xsl:template>

	<xsl:template match="article">

<!-- 文章输出区 -->
	<xsl:element name="div">
		<xsl:attribute name="class">post&#000032;articles&#000032;cate<xsl:value-of select="catalog/id" />&#000032;auth<xsl:value-of select="user/id" /></xsl:attribute>
		<h4 class="post-date"><xsl:value-of select="posttime" /></h4>
		<h2 class="post-title">
			<xsl:element name="a">
				<xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>
				<xsl:value-of select="title" />
				<xsl:if test="catalog/name!=''">&#000032;(<xsl:value-of select="catalog/name" />)</xsl:if>
			</xsl:element>
		</h2>
		<div class="post-body"><xsl:value-of select="content" disable-output-escaping="yes" /></div>
<!-- 		<h6 class="post-footer">
			发布:<xsl:value-of select="user/name" />&#000032;|&#000032;分类:<xsl:value-of select="catalog/name" />&#000032;&#000032;
		</h6> -->
	</xsl:element>

	</xsl:template>
	

	<xsl:template match="twitter">

<!-- twitter输出区 -->

	<xsl:element name="div">
		<xsl:attribute name="class">post&#000032;twitters&#000032;twitters-<xsl:value-of select="source" /></xsl:attribute>
		<h4 class="post-date"><xsl:value-of select="posttime" /></h4>
 		<div class="post-body">

	<xsl:element name="p">

		<xsl:element name="a">
			<xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>
			<xsl:value-of select="content" disable-output-escaping="yes" /> 
		</xsl:element>


<!-- <xsl:text >(</xsl:text>
<xsl:if test="spandays!='0'">
<xsl:value-of select="spandays" />天前
</xsl:if>
<xsl:if test="spandays='0'">

	<xsl:if test="spanhours!='0'">
	<xsl:value-of select="spanhours" />小时前
	</xsl:if>

	<xsl:if test="spanhours='0'">
	<xsl:value-of select="spanminutes" />分钟前
	</xsl:if>

</xsl:if>
<xsl:text >发布&#000032;</xsl:text>by<xsl:text >&#173;</xsl:text><xsl:value-of select="source" /><xsl:text >)</xsl:text> -->
<!-- (by<xsl:text >&#173;</xsl:text><xsl:value-of select="source" />) -->
	</xsl:element>
		</div>
	</xsl:element>

	</xsl:template>


	<xsl:template match="bookmark">

<!-- Bookmarks输出区 -->
	<xsl:element name="div">
		<xsl:attribute name="class">post&#000032;bookmarks&#000032;bookmarks-<xsl:value-of select="source" /></xsl:attribute>
		<h4 class="post-date"><xsl:value-of select="posttime" /></h4>
		<h2 class="post-title">
		<xsl:element name="a">
			<xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>
			<xsl:value-of select="title" /> 
		</xsl:element>
		</h2>
	</xsl:element>

	</xsl:template>


	<xsl:template match="share">

<!-- Share输出区 -->
	<xsl:element name="div">
		<xsl:attribute name="class">post&#000032;shares&#000032;shares-<xsl:value-of select="source" /></xsl:attribute>
		<h4 class="post-date"><xsl:value-of select="posttime" /></h4>
		<h2 class="post-title">
		<xsl:element name="a">
			<xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>
			<xsl:value-of select="title" /> 
		</xsl:element>
		</h2>
		<div class="post-body"><xsl:value-of select="content" disable-output-escaping="yes" /></div>
	</xsl:element>

	</xsl:template>




	<xsl:template match="gallery">

<!-- Gallery输出区 -->
	<xsl:element name="div">
		<xsl:attribute name="class">post&#000032;gallerys&#000032;gallerys-<xsl:value-of select="source" /></xsl:attribute>
		<h4 class="post-date"><xsl:value-of select="posttime" /></h4>
		<h2 class="post-title">
		<xsl:element name="a">
			<xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>
			<xsl:value-of select="title" /><xsl:text >&#173;</xsl:text>(<xsl:value-of select="source" />)
		</xsl:element>
		</h2>
		<div class="post-body"><xsl:value-of select="content" disable-output-escaping="yes" /></div>
	</xsl:element>

	</xsl:template>



	<xsl:template match="column">

<!-- Navbar输出区 -->
<xsl:for-each select=".">
	<xsl:element name="li">
		<xsl:element name="a">
			<xsl:attribute name="href"><xsl:value-of select="//data/site/config/variable[@name='SITE_HOST']" /><xsl:value-of select="url" /></xsl:attribute>
			<xsl:value-of select="name" /> 
		</xsl:element>
	</xsl:element>

</xsl:for-each>

	</xsl:template>





	<xsl:template match="comments">
<!-- 评论输出区 -->
<xsl:for-each select="comment">
<xsl:element name="li">
	<xsl:element name="a">
		<xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>
		<xsl:value-of select="name" /><xsl:text>&#000032;</xsl:text><xsl:value-of select="postdatetime" />:
	</xsl:element>
	<xsl:value-of select="content" disable-output-escaping="yes" />
</xsl:element>
</xsl:for-each>
	</xsl:template>

</xsl:stylesheet>