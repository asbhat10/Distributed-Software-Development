using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void validateButton_Click(object sender, EventArgs e)
    {
        XMLServiceReference.Service1Client client = new XMLServiceReference.Service1Client();
        errorLabel.Text = client.verification(xsdURLText.Text.ToString(), xmlURLText.Text.ToString());
    }

    protected void transformButton_Click(object sender, EventArgs e)
    {
        XMLServiceReference.Service1Client client = new XMLServiceReference.Service1Client();
        string html = client.transformation(XSLUrl.Text.ToString(), XMLUrl1.Text.ToString());
        plainhtml.Text = Server.HtmlEncode(html);
        htmltext.Text = html;
    }
}