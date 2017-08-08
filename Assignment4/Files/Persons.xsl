<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <html>
            <body>
                <h1>Persons List</h1>
                <table border="1">
                    <tr bgcolor="yellow">
                        <td>
                            <b>First Name</b>
                        </td>
                        <td>
                            <b>Last Name</b>
                        </td>
                        <td>
                            <b>Id</b>
                        </td>
                        <td>
                            <b>Password</b>
                        </td>
                        <td>
                            <b>Encryption</b>
                        </td>
                        <td>
                            <b>Work Phone</b>
                        </td>
                        <td>
                            <b>Cell Phone</b>
                        </td>
                        <td>
                            <b>Service Provider</b>
                        </td>
                        <td>
                            <b>Category</b>
                        </td>
                    </tr>
                    <xsl:for-each select="Persons/Person">
                        <tr style="font-size: 10pt; font-family: verdana">
                            <td>
                                <xsl:value-of select="Name/First" />
                            </td>
                            <td>
                                <xsl:value-of select="Name/Last" />
                            </td>
                            <td>
                                <xsl:value-of select="Credential/Id" />
                            </td>
                            <td>
                                <xsl:value-of select="Credential/Password" />
                            </td>
							<td>
                                <xsl:value-of select="Credential/Password/@Encryption" />
                            </td>
                            <td>
                                <xsl:value-of select="Phone/Work" />
                            </td>
							<td>
                                <xsl:value-of select="Phone/Cell" />
                            </td>
							<td>
<xsl:choose>
								<xsl:when test="Phone/Cell/@Provider != ''">
									<xsl:value-of select="Phone/Cell/@Provider" />
									</xsl:when>
									<xsl:otherwise>
									<br />
								</xsl:otherwise>
</xsl:choose>
							</td>
							<td>
                                <xsl:value-of select="Category" />
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>