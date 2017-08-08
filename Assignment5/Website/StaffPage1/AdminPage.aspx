<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="StaffPage1_AdmnPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 103px;
            width: 245px;
        }
        table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Admin Page&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="HomeButton" runat="server" OnClick="HomeButton_Click" Text="Home" />
&nbsp;&nbsp;
            <asp:Button ID="signoutButton" runat="server" OnClick="signoutButton_Click" Text="Sign Out" />
        </h1>
        <p>Welcome <asp:Label ID="userlbl" runat="server"></asp:Label>
            ,</p>
        <table>
            <tr>
	        <th>Service Name Input, output</th>
	        <th>Service description</th>
	        <th>Planned resource required to implement the resource</th>
            </tr>
            <tr>
			<td>String AddBooks(...)<br>Input: ISBN, title and description<br>Output: String status</td>
			<td>Adds the given book information to Books.xml </td>
			<td>Implemented using my own code. Adds the given book information to Books.xml.</td>
		  </tr>
               <tr>
	<td>Cookie</td>
	<td>Cookie is used to display the user ID</td>
	<td>Used the HttpCookie to retrieve the value from the cookie</td>
  </tr>
        </table>
        <h1>Add new books to Library&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </h1>
        <p>Book Title:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TitleTb" runat="server" Width="326px"></asp:TextBox>
        </p>
        <p>Book ISBN:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="IsbnTb" runat="server" Width="327px"></asp:TextBox>
        </p>
        <p>Book description:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="DescriptionTb" runat="server" Height="20px" Width="333px" style="margin-top: 10px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="ErrorLbl" runat="server"></asp:Label>
        </p></div>
        <asp:Button ID="AddBookButton" runat="server" OnClick="AddBookButton_Click" Text="Add Book" />
    </form>
</body>
</html>
