using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        StoreLocationServiceReference.Service1Client client = new StoreLocationServiceReference.Service1Client();
        String address = client.getStoreLocation(Text1.Value.ToString(), Text2.Value.ToString());
        String[] splitAddress = address.Split(',');
        nameLabel.Text = splitAddress[0]+", ";
        if (splitAddress.Length > 1)
        {
            aptLabel.Text = splitAddress[1] + ", ";
        }
        else
        {
            aptLabel.Text = "";
        }
        if (splitAddress.Length > 2)
        {
            streetLabel.Text = splitAddress[2] + ", ";
        }
        else
        {
            streetLabel.Text = "";
        }
        if (splitAddress.Length > 3)
        {
            cityLabel.Text = splitAddress[3] + ", ";
        }
        else
        {
            cityLabel.Text = "";
        }
        if (splitAddress.Length > 4)
        {
            countyLabel.Text = splitAddress[4] + ", ";
        }
        else
        {
            countyLabel.Text = "";
        }
        if (splitAddress.Length > 5)
        {
            stateLabel.Text = splitAddress[5] + ", ";
        }
        else
        {
            stateLabel.Text = "";
        }
        if (splitAddress.Length > 6)
        {
            countryLabel.Text = splitAddress[6] + ", ";
        }
        else
        {
            countryLabel.Text = "";
        }
        if (splitAddress.Length > 7)
        {
            zipLabel.Text = splitAddress[7];
        }
        else
        {
            zipLabel.Text = "";
        }
        if (splitAddress.Length > 8)
        {
            zipCode1.Text = "-" + splitAddress[8];
        }
        else
        {
            zipCode1.Text = "";
        }
    }
}