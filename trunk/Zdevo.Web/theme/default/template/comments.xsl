<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml">
	<xsl:output method="xml" encoding="UTF-8" indent="yes"/>

	<xsl:template match="zdevo">
		<xsl:apply-templates select="//data/article/comments/comment" />
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
</xsl:stylesheet>