<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Store Locator Service</h1>
    <b>Description: </b> Find the address of the provided storeName closest to the zipcode.
    <br /><b>Service URL: </b><a href="http://localhost:24399/Service1.svc?wsdl">http://localhost:24399/Service1.svc?wsdl</a><br />
    <b>Method name: </b>getStoreLocation(string zipcode, string storeName)<br />
    <b>Parameters: </b>String zipcode, String Store Name<br />
    <b>Return type: </b>Address of the Store in String type<br />
    <h3>Try it: </h3>
    Enter zipcode:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Text1" runat="server" type="text" />
    <br />
    Enter Store Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Text2" runat="server" type="text" /><br />
&nbsp;<asp:Button ID="invokeButton" runat="server" OnClick="Button1_Click" Text="Invoke" />
        <br />
    <br />
        Address:<br />
<asp:Label ID="nameLabel" runat="server"></asp:Label>
        <br />
        <asp:Label ID="aptLabel" runat="server"></asp:Label>
        <br />
        <asp:Label ID="streetLabel" runat="server"></asp:Label>

    <br />
<asp:Label ID="cityLabel" runat="server"></asp:Label>
<br />
<asp:Label ID="countyLabel" runat="server"></asp:Label>
<br />
    <asp:Label ID="stateLabel" runat="server"></asp:Label>

    <br />
<asp:Label ID="countryLabel" runat="server"></asp:Label>
<br />
<asp:Label ID="zipLabel" runat="server"></asp:Label>

    <asp:Label ID="zipCode1" runat="server"></asp:Label>

    <br />
</asp:Content>
