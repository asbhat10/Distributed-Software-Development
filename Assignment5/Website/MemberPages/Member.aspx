<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="MemberPages_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}
</style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome
            <asp:Label ID="idLbl" runat="server"></asp:Label>
            ,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="HomeButton" runat="server" OnClick="HomeButton_Click" Text="Home" />
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="signOutButton" runat="server" OnClick="signOutButton_Click" Text="Sign out" />
        </h1>
        <h1>Services used in this page:</h1>
        <table>
  <tr>
	<th>Service Name Input, output</th>
	<th>Service description</th>
	<th>Planned resource required to implement the resource</th>
  </tr>

  <tr>
	<td>String[] getLatLong(zipcode)<br>Input: String zipcode<br>Output: Array of string with latitude<br>             and longitude</td>
	<td>Calculates the latitude and longitude<br>using the zip code.</td>
	<td>It is implemented using the national weather service provided at http://graphical.weather.gov/xml/SOAP_server/ndfdXMLserver.php?wsdl .</td>
  </tr>
  <tr>
	<td>Library Locator Service<br>Input:String zipcode<br>Output: Address of the 5 nearest libraries</td>
	<td>Returns the address of the 5 nearest libraries using the latitude and longitude provided by the getLatLong service.</td>
	<td>It is implemented using the Google places api. </td>
  </tr>
  <tr>
	<td>ArrayList getAllBooks()<br>Input: None<br>Output: Returns the arraylist of all titles</td>
	<td>It gets the titles of all the books stored in Books.xml under App_Data of the Assignment5 project.</td>
	<td>Implemented it using my own code. It parses the Books.xml file and returns the list of all titles.</td>
  </tr>
  <tr>
	<td>String[] getBookDetails(String name)<br>Input: String name of the book<br>Output: An array containing isbn and description</td>
	<td>Service parses the Books.xml and returns the details of the book based on the title.</td>
	<td>Implemented using my own code. It parses the Books.xml and returns the isbn and the description of the book matching the title.</td>
  </tr>
  <tr>
	<td>Boolean addBorrowed(String title, String userId)<br>Input: Title of the book and user Id<br>Output: Boolean status</td>
	<td>This service adds the book title to the User.xml file under the user matching the userID.</td>
	<td>Implemented using my own code. It parses the Members.xml files and adds the title of the book to the user matching the user ID.</td>
  </tr>
   <tr>
	<td>Cookie</td>
	<td>Cookie is used to display the user ID</td>
	<td>Used the HttpCookie to retrieve the value from the cookie</td>
  </tr>
</table>
        <h1>Search for Nearby Libraries</h1><br />
        Enter Zipcode:
        <asp:TextBox ID="zipCodeTB" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        <br />
        <br />
        NearBy Libraries<br />
    <div>
        
        <asp:Label ID="LibrariesLabel" runat="server"></asp:Label>
        <br />
        <br />
        <h1>Books Catalog</h1></div>
        <asp:ListBox ID="BookList" runat="server" Height="324px" Width="575px"></asp:ListBox>
        <br />
        <asp:Button ID="DetailButton" runat="server" Text="View Book Details" OnClick="DetailButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BorrowButton" runat="server" Text="Borrow Book" OnClick="BorrowButton_Click" />
        <br />
        Book Details<br />
        Title :
        <asp:Label ID="TitleLbl" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="BorrowStatusLbl" runat="server"></asp:Label>
        <br />
        ISBN:
        <asp:Label ID="IsbnLbl" runat="server"></asp:Label>
        <br />
        Description:
        <asp:Label ID="DescLbl" runat="server"></asp:Label>
    </form>
</body>
</html>
