using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CryptoLibrary;
using System.Web.Security;

public partial class MembersLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie userCookies = Request.Cookies["userInfo"];
        if (userCookies == null || userCookies["id"] == "")
        {
            userLbl.Text = "new user";
        }
        else
        {
            userLbl.Text = userCookies["id"];
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        try
        {
            CryptoClass crypto = new CryptoClass();
            String id = userIdTb.Text;
            String password = crypto.Encrypt(PasswordTb.Text);

            Assignment5ServiceRefs.Service1Client serviceRef = new Assignment5ServiceRefs.Service1Client();
            if (serviceRef.checkUserCredentials(id, password))
            {
                HttpCookie userCookies = new HttpCookie("userInfo");
                userCookies["id"] = userIdTb.Text;
                userCookies.Expires = DateTime.Now.AddMonths(6);
                Response.Cookies.Add(userCookies);
                FormsAuthentication.RedirectFromLoginPage(userIdTb.Text, Persistent.Checked);
                Session["type"] = "member";
                userCookies["type"] = "member";
                Response.Redirect("~/MemberPages/Member.aspx");
            }
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

    protected void HomeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void SignOutButton_Click(object sender, EventArgs e)
    {
        HttpCookie myCookie = new HttpCookie("userInfo");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);
        Session["type"] = "";
        FormsAuthentication.SignOut();
        Response.Redirect("~/Default.aspx");
    }
}