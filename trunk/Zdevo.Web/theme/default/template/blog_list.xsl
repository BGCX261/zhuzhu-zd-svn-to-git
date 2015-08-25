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

<xsl:if test="//data/pagenow='default'">
<title><xsl:value-of select="//data/headtitle" /><xsl:text>_</xsl:text>首页<xsl:text> | </xsl:text><xsl:value-of select="//data/site/title"/></title>
</xsl:if>
<xsl:if test="//data/pagenow!='default'">
<title><xsl:value-of select="//data/headtitle" /><xsl:text>_</xsl:text>第<xsl:value-of select="//data/pagenow" />页<xsl:text> | </xsl:text><xsl:value-of select="//data/site/title"/></title>
</xsl:if>

				<xsl:element name="link">
					<xsl:attribute name="rel">stylesheet</xsl:attribute>
					<xsl:attribute name="rev">stylesheet</xsl:attribute>
					<xsl:attribute name="href"><xsl:value-of select="//data/site/config/variable[@name='SITE_HOST']" />theme/<xsl:value-of select="//data/site/config/variable[@name='SITE_TEMPLATE']" />/code/Css.ashx?r=69&amp;g=161&amp;b=220</xsl:attribute>
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
			</head>
			<body class="blog list blog-list">
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
								<h3>导航栏</h3>
								<ul>
<xsl:apply-templates select="data/site/column" />
								</ul>
							</div>
						</div>
						<div id="divMain">

<xsl:apply-templates select="data/articles" />

						</div>
						<div id="divSidebar">
<xsl:text >&#173;</xsl:text>
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
							<h3>分类</h3>
							<ul>
<xsl:apply-templates select="data/catalogs" />
							</ul>
							</div>
<xsl:text >&#173;</xsl:text>
						</div>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="articles">
	
<xsl:apply-templates select="pagebar" />

<!-- 文章输出区 -->
<xsl:for-each select="article">
	<xsl:element name="div">
		<xsl:attribute name="class">post&#000032;articles&#000032;cate<xsl:value-of select="category/id" />&#000032;auth<xsl:value-of select="user/id" /></xsl:attribute>
		<h4 class="post-date"><xsl:value-of select="postdatetime" /></h4>
		<h2 class="post-title">
			<xsl:element name="a">
				<xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>
				<xsl:value-of select="title" />
			</xsl:element>
		</h2>
		<div class="post-body"><xsl:value-of select="content" disable-output-escaping="yes" /></div>
		<h6 class="post-footer">
			发布:<xsl:value-of select="user/name" />&#000032;|&#000032;分类:<xsl:value-of select="catalog/name" />&#000032;|&#000032;评论:<xsl:value-of select="commentnums" />&#000032;|&#000032;
		</h6>
	</xsl:element>
</xsl:for-each>

<xsl:apply-templates select="pagebar" />
	</xsl:template>
	
	<xsl:template match="data/articles/pagebar">
<!-- PageBar翻页条 -->
<xsl:element name="div">
	<xsl:attribute name="class">post pagebar</xsl:attribute>
		<xsl:for-each select="pagefrist">
			<xsl:element name="a"><xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>[&lt;&lt;]</xsl:element>
		</xsl:for-each>
		<xsl:for-each select="pageprevious">
			<xsl:element name="a"><xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>[&lt;]</xsl:element>
		</xsl:for-each>
		<xsl:for-each select="page">
			<xsl:element name="a"><xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>[<xsl:value-of select="number" />]</xsl:element>
		</xsl:for-each>
		<xsl:for-each select="pagenext">
			<xsl:element name="a"><xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>[&gt;]</xsl:element>
		</xsl:for-each>
		<xsl:for-each select="pagelast">
			<xsl:element name="a"><xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>[&gt;&gt;]</xsl:element>
		</xsl:for-each>
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


	<xsl:template match="catalogs">

<!-- 分类输出区 -->
<xsl:for-each select="catalog">
	<xsl:element name="li">
		<xsl:element name="a">
			<xsl:attribute name="href"><xsl:value-of select="url" /></xsl:attribute>
<xsl:value-of select="name" /> 
		</xsl:element>
	</xsl:element>

</xsl:for-each>

	</xsl:template>


</xsl:stylesheet>