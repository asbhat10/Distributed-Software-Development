<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Verify.aspx.cs" Inherits="Verify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p><asp:Button ID="HomeButton" runat="server" OnClick="HomeButton_Click" Text="Home" />
        </p>
        <p>Functionality:</p>
        <p>Image verifier function is implemented using the following services in ASU public repository:</p>
        <table>
            <tr>
                 <th>Service Name Input, output</th>
	        <th>Service description</th>
            </tr>
            <tr>
                 <td>Image verifier in SVC
	        <td>	
WCF-based WSDL-SOAP service with two operations:
 Stream GetImage() and GetVerifierString(string length)
http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifierSvc/Service.svc</td>
            </tr>
            <tr>
                 <td>Image Verifier in RESTful
	        <td>	
WCF RESTful service with GetImage/3Nt$@ operation
 http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/3Nt$@
            </tr>
        </table>
        <p>Enter Captcha:<asp:Image ID="CaptchaImage" runat="server" />
        </p>
        <p>
            <asp:TextBox ID="CaptchaTb" runat="server" Width="174px"></asp:TextBox>
&nbsp;
            <asp:Button ID="ReloadImageButton" runat="server" Text="Reload Captcha" Width="157px" OnClick="ReloadImageButton_Click" style="height: 26px" /><br />
             <asp:Label ID="captchaErrorLbl" runat="server"></asp:Label>
        </p>
    <div>
    
        <asp:Button ID="nextButton" runat="server" OnClick="nextButton_Click" Text="Next" />
    
    </div>
    </form>
</body>
</html>
