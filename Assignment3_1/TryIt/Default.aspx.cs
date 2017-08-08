using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Weather_Click(object sender, EventArgs e)
    {
        AssignmentRefs.Service1Client client = new AssignmentRefs.Service1Client();
        string zipCode = zipText.Value.ToString();
        string[] forecast = client.getWeather5day(zipCode);

        Label4.Text = forecast[0];
        Label6.Text = forecast[1];
        Label8.Text = forecast[2];
        Label10.Text = forecast[3];
        Label12.Text = forecast[4];

        Label5.Text = forecast[5];
        Label7.Text = forecast[6];
        Label9.Text = forecast[7];
        Label11.Text = forecast[8];
        Label13.Text = forecast[9];
    }


    protected void StoreButton_Click(object sender, EventArgs e)
    {
        AssignmentRefs.Service1Client client = new AssignmentRefs.Service1Client();
        string zipCode = zipText.Value.ToString();
        String address = client.getStoreLocation(Text1.Value.ToString(), Text2.Value.ToString());
        String[] splitAddress = address.Split(',');
        nameLabel.Text = splitAddress[0] + ", ";
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

    protected void encrypt_Click(object sender, EventArgs e)
    {
        WebClient wclient = new WebClient();
        string ptext = plaintext.Value.ToString();
        Uri baseUri = new Uri("http://webstrar7.fulton.asu.edu/page0/Service1.svc");
        UriTemplate myTemplate = new UriTemplate("encrypt/{text}");
        Uri completeUri = myTemplate.BindByPosition(baseUri, ptext);
        encryptLabel.Text = wclient.DownloadString(completeUri);
    }

    protected void decrypt_Click(object sender, EventArgs e)
    {
        WebClient wclient = new WebClient();
        string ctext = ciphertext.Value.ToString();
        string restQuery = "http://webstrar7.fulton.asu.edu/page0/Service1.svc/decrypt?cipherText=" + HttpUtility.UrlEncode(ctext);
        decryptlabel.Text = wclient.DownloadString(restQuery);
    }

    protected void SignUpButton_Click(object sender, EventArgs e)
    {
        AssignmentRefs.Service1Client client = new AssignmentRefs.Service1Client();
        string usernameStr = userText.Value.ToString();
        string password = passText.Value.ToString();
        bool status = client.PutUsersToFile(usernameStr, password);
        Session["username"] = usernameStr;
        if (status)
        {
            StatusLabel.Text = "Success!";
            loggedinuser.Text = Session["username"].ToString();
            username.Text = Session["username"].ToString();
        }
        else
        {
            StatusLabel.Text = "An error occured while registering. :(";
        }
    }



    protected void SignInButton_Click(object sender, EventArgs e)
    {
        AssignmentRefs.Service1Client client = new AssignmentRefs.Service1Client();
        string usernameStr = userTextin.Value.ToString();
        string password = passTextin.Value.ToString();
        bool status = client.GetUserFromFile(usernameStr, password);

        if (status)
        {
            Session["username"] = usernameStr;
            StatusLabel0.Text = "Login Successful!";
            loggedinuser.Text = Session["username"].ToString();
            username.Text = Session["username"].ToString();
        }
        else
        {
            Session["username"] = String.Empty;
            StatusLabel0.Text = "Login failed :(";
            username.Text = String.Empty;
        }

    }

    protected void checkButton_Click(object sender, EventArgs e)
    {
        AssignmentRefs.Service1Client client = new AssignmentRefs.Service1Client();
        String addressstr = client.getStoreLocation(zipcheck.Value.ToString(), placecheck.Value.ToString());
        if (null == Session["username"])
        {
            statustext.Text = "Failed to checkin";
            username.Text = "Please log in first to checkin";
        }
        else
        {
            String user = Session["username"].ToString();
            username.Text = user;
            if (user.Equals("") || String.IsNullOrEmpty(user))
            {

                username.Text = "Please log in first to checkin";
                statustext.Text = "Failed to checkin";
            }
            else if (user.Equals("No stores within 30 miles"))
            {
                statustext.Text = "Failed to checkin as no place was found nearby!";
            }
            else
            {

                address.Text = addressstr;
                bool status = client.PutPlaceToFile(addressstr, user);
                if (status)
                {
                    statustext.Text = "Check in successful!";
                }
                else
                {
                    statustext.Text = "Check in failed :(";
                }
            }
        }
        
    }


    protected void Signout_Click(object sender, EventArgs e)
    {
        Session["username"] = String.Empty;
        StatusLabel0.Text = "Successfully signed out!";
        loggedinuser.Text = Session["username"].ToString();
        username.Text = Session["username"].ToString();
    }
}