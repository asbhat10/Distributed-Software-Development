using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CryptoLibrary;
using System.Web.Security;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie userCookies = Request.Cookies["userInfo"];
        if (userCookies == null || userCookies["id"] == "")
        {
            LoggedInLbl.Text = "Welcome new user, Please log in to continue.";
        }
        else
        {
            LoggedInLbl.Text = "Welcome, " + userCookies["id"];
        }
        
    }

    protected void MLoginButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MembersLogin.aspx");
    }

    protected void MsignupButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Verify.aspx");
    }

    protected void MemPageButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MemberPages/Member.aspx");
    }

    protected void SLoginButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/StaffLogIn.aspx");
    }

    protected void SPageButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/StaffPage2/StaffPage.aspx");
    }

    protected void APageButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/StaffPage1/AdminPage.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie myCookie = new HttpCookie("userInfo");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);
        Session["type"] = "";
        FormsAuthentication.SignOut();
        Response.Redirect("~/Default.aspx");
    }
}