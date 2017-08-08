<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>URL to index page: <a href="http://webstrar7.fulton.asu.edu/index.html">Index Page</a></a></h1>
        <h1>User Sign up Service</h1>
    <b>Description: </b> Store the user's user name and password in an XML file
    <br /><b>Service URL: </b><a href="http://webstrar7.fulton.asu.edu/Page1/Service1.svc?wsdl">http://webstrar7.fulton.asu.edu/Page1/Service1.svc?wsdl</a><br />
    <b>Method name: </b>PutUsersToFile(string user, string password)<br />
    <b>Parameters: </b>string user, string password <br />
    <b>Return type: </b>Boolean value returning the status<br />
    <h3>Try it: </h3>
    Enter username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="userText" runat="server" type="text" />
    <br />
    Enter Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="passText" runat="server" type="password" /><br />
&nbsp;<asp:Button ID="signupInvokeButton" runat="server" OnClick="SignUpButton_Click" Text="Invoke Sign Up" />
        <br />
    Status:
    <asp:Label ID="StatusLabel" runat="server"></asp:Label>
    <br />
    <br />
    <h1>User Sign in Service</h1>
    <b>Description: </b> Check if the user is registered
    <br /><b>Service URL: </b><a href="http://webstrar7.fulton.asu.edu/Page1/Service1.svc?wsdl">http://webstrar7.fulton.asu.edu/Page1/Service1.svc?wsdl</a><br />
    <b>Method name: </b>GetUserFromFile(string user, string password)<br />
    <b>Parameters: </b>string user, string password <br />
    <b>Return type: </b>Boolean value returning the status<br />
    <h3>Try it: </h3>
    Enter username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="userTextin" runat="server" type="text" />
    <br />
    Enter Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="passTextin" runat="server" type="password" /><br />
&nbsp;<asp:Button ID="signinInvokeButton" runat="server" OnClick="SignInButton_Click" Text="Invoke Sign In" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="signout" runat="server" OnClick="Signout_Click" Text="Sign Out" />
        <br />
    Status:
    <asp:Label ID="StatusLabel0" runat="server"></asp:Label>
    <br />
    Logged in User:<asp:Label ID="loggedinuser" runat="server"></asp:Label>
&nbsp;<h1>Weather Service</h1>
    <b>Description: </b>Create a 5-day weather forecast service of zipcode location based on National Weather Service<br />
    <b>Service URL: </b><a href="http://webstrar7.fulton.asu.edu/Page1/Service1.svc?wsdl">http://webstrar7.fulton.asu.edu/Page1/Service1.svc?wsdl</a><br />
    <b>Method name: </b>getWeather5day(string zipcode)<br />
    <b>Parameters: </b>String zipcode<br />
    <b>Return type: </b>Array of Strings (String[]). First five values are the maximum temperature and the next five are the minimum temperatures for the next five days.<br />
    <h3>Try it: </h3><br />
   
    <asp:Label ID="Label3" runat="server" Text="Enter Zipcode:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="zipText" type="text"  runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="weather_button" runat="server" OnClick="Weather_Click" Text="Invoke Weather Service" Width="210px" Height="30px" />
    <br />
    <br />
    Weather Forecast for the next 5 days<br />
    Days&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Maximum Temperature&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Minimum Temperature<br />
    Day 1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
    <br />
    Day 2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
    <br />
    Day 3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
    <br />
    Day 4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
    <br />
    Day 5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
    <br />
    <h1>Store Locator Service</h1>
    <b>Description: </b> Find the address of the provided storeName closest to the zipcode.
    <br /><b>Service URL: </b><a href="http://webstrar7.fulton.asu.edu/Page1/Service1.svc?wsdl">http://webstrar7.fulton.asu.edu/Page1/Service1.svc?wsdl</a><br />
    <b>Method name: </b>getStoreLocation(string zipcode, string storeName)<br />
    <b>Parameters: </b>String zipcode, String Store Name<br />
    <b>Return type: </b>Address of the Store in String type<br />
    <h3>Try it: </h3>
    Enter zipcode:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Text1" runat="server" type="text" />
    <br />
    Enter Store Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Text2" runat="server" type="text" /><br />
&nbsp;<asp:Button ID="storeInvokeButton" runat="server" OnClick="StoreButton_Click" Text="Invoke Store Locator" />
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
    <h1>CryptoGraphy Service</h1>
    <b>Description: </b>Encrypt or Decrypt a text<br />
    <b>Service URL: </b><a href="http://webstrar7.fulton.asu.edu/page0/Service1.svc">http://webstrar7.fulton.asu.edu/page0/Service1.svc</a><br />
    <b>Method name: </b>Encrypt(string text)<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Decrypt (String cipherText)<br />
    <b>Parameters: </b>String text<br />
    <b>Return type: </b>String<br />
    <h3>Try it: </h3>
    <br />
    <asp:Label ID="Label14" runat="server" Text="Enter text:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <input id="plaintext" runat="server" type="text" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="encrypt_button" runat="server" Height="30px" OnClick="encrypt_Click" Text="Encrypt" Width="65px" />
    <br />
    Encrypted Text:&nbsp;&nbsp;&nbsp;
    <asp:Label ID="encryptLabel" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label15" runat="server" Text="Enter cipher text:"></asp:Label>
    &nbsp;
    <input id="ciphertext" runat="server" type="text" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="decrypt_button" runat="server" Height="30px" OnClick="decrypt_Click" Text="Decrypt" Width="65px" />

    <br />
    Decrypted Text:&nbsp;&nbsp;&nbsp;
    <asp:Label ID="decryptlabel" runat="server"></asp:Label>

    <br />
    <h1>Place Checkin Service</h1>
    <b>Description: </b> Check in to a nearby place
    <br /><b>Service URL: </b><a href="http://webstrar7.fulton.asu.edu/Page1/Service1.svc?wsdl">http://webstrar7.fulton.asu.edu/Page1/Service1.svc?wsdl</a><br />
    <b>Method name: </b>PutPlaceToFile(String place,String username)<br />
    <b>Parameters: </b>String placeAddress, String username<br />
    <b>Return type: </b>Boolean status<br />
    <h3>Try it: </h3>
    Enter zipcode:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="zipcheck" runat="server" type="text" />
    <br />
    Enter Place Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="placecheck" runat="server" type="text" /><br />
&nbsp;<asp:Button ID="checkInvokeButton" runat="server" OnClick="checkButton_Click" Text="Invoke Checkin" style="height: 26px" />
        <br />
    <br />
        Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="address" runat="server"></asp:Label>
    <br />
    Loggedin User: <asp:Label ID="username" runat="server"></asp:Label>
    <br />
    Status:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="statustext" runat="server"></asp:Label>
    <br />
    </div>
    </form>
</body>
</html>
