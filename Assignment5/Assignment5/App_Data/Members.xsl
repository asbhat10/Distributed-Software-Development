<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>  <body>
			<table border="1">
				<tr bgcolor="yellow"> 
					<td><b>Name</b></td> 
					<td><b>ID</b></td> 
					<td><b>Card Number</b></td> 
                                        <td><b>Borrowed Books</b></td> 
				</tr>
				<xsl:for-each select="users/user">
					<xsl:sort select="Name" />
					<tr style="font-size: 10pt; font-family: verdana">
						<td><xsl:value-of select="name"/></td>
						<td><xsl:value-of select="id"/></td>
						<td><xsl:value-of select="card"/></td>
                        <xsl:for-each select="book">					    
				            <td><xsl:value-of select="title"/></td>							
						</xsl:for-each>
					</tr>
				</xsl:for-each>
			</table>
		</body> </html>
	</xsl:template>
</xsl:stylesheet>
