<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Try It</h1>
        <h2>Verification</h2>
        <b>Description:</b> Service to validate the XML against the provided XSD.<br />
        <b>Service URL:</b> <a href="http://localhost:1028/Service1.svc">http://localhost:1028/Service1.svc</a><br/>
        <b>Method:</b> ValidateXML(string xsdURL, String xmlURL)<br/>
        <b>Parameters:</b> URL of the XML and XSD files<br/>
        <b>Output:</b> Error message or &quot;No Errors&quot;<br/>
        <p>URL for the XML:
            <asp:TextBox ID="xmlURLText" runat="server" Width="652px"></asp:TextBox>
        </p>
        <p>URL for the XSD:&nbsp;
            <asp:TextBox ID="xsdURLText" runat="server" Width="647px"></asp:TextBox>
        </p>
        <asp:Button ID="validateButton" runat="server" OnClick="validateButton_Click" Text="Invoke" Width="88px" />
        <br />
        <asp:Label ID="errorLabel" runat="server"></asp:Label>
        <br />
        <br />
        <h2>Transformation</h2>
        <b>Description:</b> Service to transform the XML using the provided XSL.<br />
        <b>Service URL:</b> <a href="http://localhost:1028/Service1.svc">http://localhost:1028/Service1.svc</a><br/>
        <b>Method:</b>ApplyXSL(string xslURL, String xmlURL)<br/>
        <b>Parameters:</b> URL of the XML and XSL files<br/>
        <b>Output:</b> Transformed XML (HTML). File is stored under App_Data<br/>
        <p>URL for the XML:
            <asp:TextBox ID="XMLUrl1" runat="server" Width="652px"></asp:TextBox>
        </p>
        <p>URL for the XSL:&nbsp;
            <asp:TextBox ID="XSLUrl" runat="server" Width="647px"></asp:TextBox>
        </p>
        <asp:Button ID="transformButton" runat="server" OnClick="transformButton_Click" Text="Invoke" Width="88px" />
        <br />
        <br />
        HTML text<br />
        </div>
        <asp:Label ID="plainhtml" runat="server"></asp:Label>
        <br />
        <br />
        Rendered HTML<br />
        <asp:Label ID="htmltext" runat="server"></asp:Label>
    </form>
</body>
</html>
