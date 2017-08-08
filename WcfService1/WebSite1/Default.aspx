<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    </br>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Enter the temperature to be converted"></asp:Label>
        <input id="inputText" type="text"  runat="server" /></div>
    </br>
    <div>
        <asp:Button ID="ctofButton" runat="server" Text="Celsius to Fahrenheit" OnClick="ctofButton_Click" />
        <asp:Button ID="ftocButton" runat="server" Text="Fahrenheit to Celsius" OnClick="ftocButton_Click" />
    </div>
    </br>
    <asp:Label ID="Label2" runat="server" Text="Converted temperature is: "></asp:Label>
    <asp:Label ID="convertedTemp" runat="server" Text="Print here"></asp:Label>

    
</asp:Content>
