<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MembersLogin.aspx.cs" Inherits="MembersLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style> table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}</style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome <asp:Label ID="userLbl" runat="server"></asp:Label>
            ,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="HomeButton" runat="server" OnClick="HomeButton_Click" Text="Home" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SignOutButton" runat="server" OnClick="SignOutButton_Click" Text="Sign Out" />
        </h1>
    <div>
    <table>
                <tr>
	            <th>Service Name Input, output</th>
	            <th>Service description</th>
	            <th>Planned resource required to implement the resource</th>
                </tr>
<tr>

			<td>string checkUserCredentials(string id, string password)<br>Input: User ID and encrypted password<br>Output: String status</td>
			<td>Checks if the given credentials are in Members.xml</td>
			<td>Implemented using my own code. It parses the Members.xml file and returns true if the credentials match.</td>
		  </tr>
                    <tr>

			<td>string Encrypt(string plainString)<br>Input: PlainString<br>Output: Encrypted String</td>
			<td>Encrypts the given Plain String</td>
			<td>Implemented using the System.Security.Cryptography library.</td>
		  </tr>
                   <tr>
	    <td>Cookie</td>
	    <td>Cookie is used to display the user ID</td>
	    <td>Used the HttpCookie to retrieve the value from the cookie</td>
      </tr>
                    <tr>
	    <td>Session</td>
	    <td>Role is stored as member in the session variable.</td>
	    <td>Used the HttpSessionState.Page.Session to store it into the session</td>
      </tr>
            </table>

        <h1>Members Log in Page</h1>
        <p>Sample Credentials:</p>
        Username: ab10<br />
        password: :pass </br>
        <p>User Id:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="userIdTb" runat="server"></asp:TextBox>
        </p>
        <p>Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="PasswordTb" TextMode="Password" runat="server" />
        <p>
            <asp:Label ID="LoginErrorLbl" runat="server"></asp:Label>
<p>
            <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Log in" />
    <td><asp:CheckBox Text="Keep me signed in" ID="Persistent" 
						RunAt="server"/> </td>

        </p></div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
