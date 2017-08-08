<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberSignUp.aspx.cs" Inherits="MemberSignUp" %>

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
            <asp:Label ID="userLbl" runat="server"></asp:Label>
            ,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="HomeButton" runat="server" OnClick="HomeButton_Click" Text="Home" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SignOutButton" runat="server" OnClick="SignOutButton_Click" Text="Sign Out" />
        </h1>
        <table>
  <tr>
	<th>Service Name Input, output</th>
	<th>Service description</th>
	<th>Planned resource required to implement the resource</th>
<tr>
			<td>String SignUpMembers(...)<br>Input: User ID,encrypted password,Name and library card number<br>Output: String status</td>
			<td>Add the given member information to Members.xml</td>
			<td>Implemented using my own code. Adds the given member information to Members.xml if the user Id is not already present in the file.</td>
		  </tr>
             </table>
        <h1>Member Sign Up</h1>
        <p>&nbsp;Name: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="NameTb" runat="server" Width="148px"></asp:TextBox><br />
            <asp:Label ID="NameErrorLbl" runat="server"></asp:Label>
        </p>
        <p>User Id:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <asp:TextBox ID="UserIdTb" runat="server" Width="145px"></asp:TextBox><br />
            <asp:Label ID="UserIdErrorLbl" runat="server"></asp:Label>
        </p>
        <p>Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="PasswordTb" TextMode="Password" runat="server" Width="147px"></asp:TextBox><br />
            <asp:Label ID="PasswordErrorLbl" runat="server"></asp:Label>
        </p>
        <p>Library Card Number:
            <asp:TextBox ID="CardNoTb" runat="server" Width="147px"></asp:TextBox><br />
            <asp:Label ID="CardErrorLbl" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="signUpButton" runat="server" Text="Sign Up" OnClick="signUpButton_Click" />
        </p></div>
    </form>
</body>
</html>
