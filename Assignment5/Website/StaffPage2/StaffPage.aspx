<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffPage.aspx.cs" Inherits="StaffPage2_StaffPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Welcome
        <asp:Label ID="idLbl" runat="server"></asp:Label>
        ,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="HomeButton" runat="server" OnClick="HomeButton_Click" Text="Home" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="signoutButton" runat="server" OnClick="signoutButton_Click" Text="Sign out" />
        </h1>
         <table>
  <tr>
	<th>Service Name Input, output</th>
	<th>Service description</th>
	<th>Planned resource required to implement the resource</th>
  </tr>
             <tr>
			<td>string transformationMembers()<br>Input: None<br>Output: String status</td>
			<td>Applies the Members.xsl transformation to Members.xml</td>
			<td>Implemented using my own code.Applies the Members.xsl transformation to Members.xml using System.Xml.Xsl.</td>
		  </tr>
		  <tr>
			<td>string transformationBooks()<br>Input: None<br>Output: String status</td>
			<td>Applies the Books.xsl transformation to Books.xml</td>
			<td>Implemented using my own code.Applies the Books.xsl transformation to Books.xml using System.Xml.Xsl.</td>
		  </tr>
         <tr>
	    <td>Cookie</td>
	    <td>Cookie is used to display the user ID</td>
	    <td>Used the HttpCookie to retrieve the value from the cookie</td>
      </tr>
             </table>
        <h1>User Information&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </h1>
    </div>
        <asp:Label ID="UsersInfoLbl" runat="server"></asp:Label>
        <br />
        <h1>Books Information</h1>
        <asp:Label ID="BooksInfoLbl" runat="server"></asp:Label>
    </form>
</body>
</html>
