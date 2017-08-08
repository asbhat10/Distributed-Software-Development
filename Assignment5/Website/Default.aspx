<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        Library Management System:</h1>
    <p>
        It is a system to manage users and books in a library. </p>
    <p>
        An admin can add books which will be stored in books.xml under the Assignment 5 project.</p>
    <p>
        A staff can view information about all the registered members and the books in the system.</p>
    <p>
        A member can view all the books available and borrow them. A member can also search for nearby libraries based on zipcode. </p>
    <h4>
        <asp:Label ID="LoggedInLbl" runat="server"></asp:Label>
    </h4>
    <p>
       <a href="http://webstrar7.fulton.asu.edu/index.html"> Index Page</a></p>
    <p>
        Member Pages</p>
<p>
        <asp:Button ID="MsignupButton" runat="server" Text="Member Signup" OnClick="MsignupButton_Click" Width="126px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="MLoginButton" runat="server" Text="Member Login" OnClick="MLoginButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="MemPageButton" runat="server" OnClick="MemPageButton_Click" Text="Member Page" />
</p>
    <p>
        Staff Pages</p>
<p>
        <asp:Button ID="SLoginButton" runat="server" Text="Staff Login" OnClick="SLoginButton_Click" />
</p>
<p>
        <asp:Button ID="SPageButton" runat="server" Text="Staff Page" OnClick="SPageButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="APageButton" runat="server" OnClick="APageButton_Click" Text="Admin Page" />
</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign Out" />
</asp:Content>
