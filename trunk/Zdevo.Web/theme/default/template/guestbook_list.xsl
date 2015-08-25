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
					<xsl:attribute name="href"><xsl:value-of select="//data/site/config/variable[@name='SITE_HOST']" />theme/<xsl:value-of select="//data/site/config/variable[@name='SITE_TEMPLATE']" />/code/Css.ashx?color=purple</xsl:attribute>
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
			<body class="guestbook list guestbook-list">
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

<xsl:apply-templates select="data/guestbooks" />

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
<xsl:text >&#173;</xsl:text>
						</div>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="guestbooks">
	
<!-- 文章输出区 -->
<xsl:for-each select="guestbook">
	<xsl:element name="div">
		<xsl:attribute name="class">post&#000032;guestbooks</xsl:attribute>
		<h2 class="post-title">
				<xsl:value-of select="title" />
		</h2>
		<div class="post-body"><xsl:value-of select="content" disable-output-escaping="yes" /></div>
	</xsl:element>

<div class="post comments">
<xsl:comment>comments</xsl:comment>
<xsl:if test="count(comments/comment)!=0">
<xsl:apply-templates select="comments/comment" />
</xsl:if>
</div>

<xsl:if test="count(comments/pagebar/page)!=0">
<xsl:apply-templates select="comments/pagebar" />
</xsl:if>

<xsl:if test="isclose='false'">
<xsl:apply-templates select="isclose" />
</xsl:if>

</xsl:for-each>


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


	<xsl:template match="comments/pagebar">
<!-- PageBar翻页条 -->
<xsl:element name="div">
	<xsl:attribute name="class">post pagebar commentpagebar</xsl:attribute>
		<xsl:for-each select="pagefrist">
			<xsl:element name="a"><xsl:attribute name="href">JavaScript:GetComment('<xsl:value-of select="url" />')</xsl:attribute>[&lt;&lt;]</xsl:element>
		</xsl:for-each>
		<xsl:for-each select="pageprevious">
			<xsl:element name="a"><xsl:attribute name="href">JavaScript:GetComment('<xsl:value-of select="url" />')</xsl:attribute>[&lt;]</xsl:element>
		</xsl:for-each>
		<xsl:for-each select="page">
			<xsl:element name="a"><xsl:attribute name="href">JavaScript:GetComment('<xsl:value-of select="url" />')</xsl:attribute>[<xsl:value-of select="number" />]</xsl:element>
		</xsl:for-each>
		<xsl:for-each select="pagenext">
			<xsl:element name="a"><xsl:attribute name="href">JavaScript:GetComment('<xsl:value-of select="url" />')</xsl:attribute>[&gt;]</xsl:element>
		</xsl:for-each>
		<xsl:for-each select="pagelast">
			<xsl:element name="a"><xsl:attribute name="href">JavaScript:GetComment('<xsl:value-of select="url" />')</xsl:attribute>[&gt;&gt;]</xsl:element>
		</xsl:for-each>
</xsl:element>
	</xsl:template>


	<xsl:template match="comment">
<!-- 评论输出区 -->
<xsl:for-each select=".">
	<xsl:element name="ul">
		<li>
			<xsl:attribute name="class">name</xsl:attribute>
			<cite>
			<xsl:if test="homepage!=''">
				<xsl:element name="a">
					<xsl:attribute name="id">cmt<xsl:value-of select="id" /></xsl:attribute>
					<xsl:attribute name="href"><xsl:value-of select="homepage" /></xsl:attribute>
					<xsl:attribute name="rel">nofollow</xsl:attribute>
					<xsl:value-of select="name" />
				</xsl:element>
			</xsl:if>
			<xsl:if test="homepage=''">
				<xsl:element name="a">
					<xsl:attribute name="id">cmt<xsl:value-of select="id" /></xsl:attribute>
					<xsl:value-of select="name" />
				</xsl:element>
			</xsl:if>
			</cite>
			<xsl:text >&#32;</xsl:text>
			<xsl:text >:</xsl:text>
			
			<xsl:if test="count(//data/user)>0">
				<xsl:element name="a">
					<xsl:attribute name="href">JavaScript:if(window.confirm("确认删除")){DelComment('<xsl:value-of select="../../delcommenturl" />','<xsl:value-of select="guid" />','<xsl:value-of select="../../getcommenturl" />')}</xsl:attribute>
					[删除]
				</xsl:element>
			</xsl:if>
		</li>
		<li>
			<xsl:attribute name="class">content</xsl:attribute>
			<xsl:value-of select="content" disable-output-escaping="yes" />
		</li>
		<li>
			<xsl:attribute name="class">time</xsl:attribute>
			<xsl:value-of select="postdatetime" />
		</li>
	</xsl:element>
</xsl:for-each>
	</xsl:template>


	<xsl:template match="isclose">
<!-- 评论框输出区 -->
<div class="post commentform">
	<form id="frmSumbit" action="">
		<p>
			<a id="comment">发表评论:</a>
		</p>
		<p>
			<input type="text" name="inpName" id="inpName" value="" tabindex="1" />
			<label for="inpName">名称(*)</label>
		</p>
		<p style="display:none;">
			<input type="text" name="inpEmail" id="inpEmail" value="" tabindex="2" />
			<label for="inpEmail">邮箱</label>
		</p>
		<p>
			<input type="text" name="inpHomePage" id="inpHomePage" value="" tabindex="3" />
			<label for="inpHomePage">网站</label>
		</p>
		<p>
			<label for="txaArticle">正文(*)</label>
		</p>
		<p>
			<textarea name="txaArticle" id="txaArticle" tabindex="4" rows="20" cols="60"><xsl:text >&#32;</xsl:text></textarea>
		</p>
		<p>
		<xsl:element name="input">
			<xsl:attribute name="id">btnSumbit</xsl:attribute>
			<xsl:attribute name="name">btnSumbit</xsl:attribute>
			<xsl:attribute name="type">submit</xsl:attribute>
			<xsl:attribute name="tabindex">5</xsl:attribute>
			<xsl:attribute name="value">提交</xsl:attribute>
			<xsl:attribute name="onclick">JavaScript:PostComment('<xsl:value-of select="../postcommenturl" />','<xsl:value-of select="../guid" />',$('inpName').getValue(),$('inpEmail').getValue(),$('inpHomePage').getValue(),$('txaArticle').getValue(),'<xsl:value-of select="../getcommenturl" />');return false;</xsl:attribute>
		</xsl:element>
		</p>
	</form>
</div>
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

</xsl:stylesheet>