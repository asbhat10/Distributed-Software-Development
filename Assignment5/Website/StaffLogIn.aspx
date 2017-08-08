<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffLogIn.aspx.cs" Inherits="StaffLogIn" %>

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
                </tr>
                <tr>

			<td>bool checkUserCredentialsForStaff(string id, string password)<br>Input: User ID and encrypted password<br>Output: String status</td>
			<td>Checks if the given credentials are present in members.xml</td>
			<td>Implemented using my own code.It parses the Staff.xml file and returns true if the credentials match.</td>
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
	    <td>Role of the user is parsed from the xml file and it is stored in the session variable. It is used to redirect to the appropriate staff page.</td>
	    <td>Used the HttpSessionState.Page.Session to store it into the session</td>
      </tr>
            </table>
        <h1>Staff Log in Page</h1>
        <p>Sample Credentials:</p>
        Staff<br />
        Username: staff1<br />
        password: :pass </br>
        Admin<br />
        Username: admin1<br />
        password: :pass </br>
        <p>User Name:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="UserNameTb" runat="server" style="margin-bottom: 0px" Width="276px"></asp:TextBox>
        </p>
        <p>Password:<asp:TextBox ID="PasswordTb" TextMode="Password" runat="server" style="margin-left: 30px" Width="280px"></asp:TextBox>
        </p><td><asp:CheckBox Text="Keep me signed in" ID="Persistent" 
						RunAt="server"/> </td>
        <p>
            <asp:Button ID="LogInButton" runat="server" Text="Log in" OnClick="LogInButton_Click" />
        </p>
        <p>
            <asp:Label ID="LoginErrorLbl" runat="server"></asp:Label>
        </p></div>
    </form>
</body>
</html>
