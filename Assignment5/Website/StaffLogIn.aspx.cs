using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffLogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check the cookie if the user id is present.
        HttpCookie userCookies = Request.Cookies["userInfo"];
        //if not present, print new user
        if (userCookies == null || userCookies["id"] == "")
        {
            userLbl.Text = "new user";
        }
        else
        {
            //Print user id
            userLbl.Text = userCookies["id"];
        }
    }

    protected void LogInButton_Click(object sender, EventArgs e)
    {
        try
        {
            //Create object of Crypto class
            CryptoClass crypto = new CryptoClass();
            String id = UserNameTb.Text;
            //Encrypt the password
            String password = crypto.Encrypt(PasswordTb.Text);

            //Create object of reference class
            Assignment5ServiceRefs.Service1Client serviceRef = new Assignment5ServiceRefs.Service1Client();
            //get the role from the Staff.xml
            string role = serviceRef.checkUserCredentialsForStaff(id, password);
            //if the role is not empty
            if (!role.Equals(""))
            {
                //Create a cookie and store the user id
                HttpCookie userCookies = new HttpCookie("userInfo");
                userCookies["id"] = UserNameTb.Text;
                //Cookie expires in 6 months
                userCookies.Expires = DateTime.Now.AddMonths(6);
                Response.Cookies.Add(userCookies);
                //Redirect to the staff page after authentication
                FormsAuthentication.RedirectFromLoginPage(UserNameTb.Text, Persistent.Checked);
                //Store the role in the session
                Session["type"] = role;
                userCookies["type"] = role;
                //If the role is staff, redirect to the staff page
                if (role.Equals("staff"))
                {
                    Response.Redirect("~/StaffPage2/StaffPage.aspx");
                }
                //else if the role is admin, redirect to the admin page
                else if (role.Equals("admin"))
                {
                    Response.Redirect("~/StaffPage1/AdminPage.aspx");
                }
                //else redirect to the public default page
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

            }
            //Print error message if the credentials are invalid
            else
            {
                LoginErrorLbl.Text = "Invalid credentials!";
            }
        }
        catch
        {
            LoginErrorLbl.Text = "Invalid credentials!";
        }
    }

    protected void SignOutButton_Click(object sender, EventArgs e)
    {
        //Set the expiry of the cookie to previous day
        HttpCookie myCookie = new HttpCookie("userInfo");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);
        //Set session to empty string
        Session["type"] = "";
        //Signout of FormsAuthentication
        FormsAuthentication.SignOut();
        //Redirect to public default page
        Response.Redirect("~/Default.aspx");
    }

    protected void HomeButton_Click(object sender, EventArgs e)
    {
        //Redirect to public default page
        Response.Redirect("~/Default.aspx");
    }
}