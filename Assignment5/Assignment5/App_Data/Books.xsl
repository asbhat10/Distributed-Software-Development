<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>  <body>
			<table border="1">
				<tr bgcolor="yellow"> 
					<td><b>Title</b></td> 
					<td><b>ISBN</b></td> 
					<td><b>Description</b></td> 
				</tr>
				<xsl:for-each select="books/book">
					<xsl:sort select="Name" />
					<tr style="font-size: 10pt; font-family: verdana">
						<td><xsl:value-of select="title"/></td>
						<td><xsl:value-of select="isbn"/></td>
						<td><xsl:value-of select="description"/></td>
					</tr>
				</xsl:for-each>
			</table>
		</body> </html>
	</xsl:template>
</xsl:stylesheet>
