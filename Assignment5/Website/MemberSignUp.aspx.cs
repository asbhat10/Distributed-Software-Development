using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CryptoLibrary;
public partial class MemberSignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
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
        }
        catch { }
        
        
    }

    protected void signUpButton_Click(object sender, EventArgs e)
    {
        try
        {
            CryptoClass crypto = new CryptoClass();
            Assignment5ServiceRefs.Service1Client serviceRef = new Assignment5ServiceRefs.Service1Client();
            
                if (!UserIdTb.Text.ToString().Equals("") && !NameTb.Text.ToString().Equals("") && !PasswordTb.Text.ToString().Equals("") && !CardNoTb.Text.ToString().Equals(""))
                {
                    String status = serviceRef.SignUpMembers(UserIdTb.Text, crypto.Encrypt(PasswordTb.Text), NameTb.Text, CardNoTb.Text);
                    if (status.Equals("UserIdTaken"))
                    {
                        UserIdErrorLbl.Text = "User Id is already taken";
                    }
                    else if (status.Equals("false"))
                    {
                        UserIdErrorLbl.Text = "An exception occured during sign up.";
                    }
                    else
                    {
                        Session["name"] = NameTb.Text;
                        FormsAuthentication.RedirectFromLoginPage(NameTb.Text, true);
                        Response.Redirect("~/MemberPages/Member");
                    }
                }
                else
                {
                    if (UserIdTb.Text.ToString().Equals(""))
                    {
                        UserIdErrorLbl.Text = "User Id is required";
                    }
                    if (NameTb.Text.ToString().Equals(""))
                    {
                        NameErrorLbl.Text = "Name is required";
                    }
                    if (PasswordTb.Text.ToString().Equals(""))
                    {
                        PasswordErrorLbl.Text = "Password is required";
                    }
                    if (CardNoTb.Text.ToString().Equals(""))
                    {
                        CardErrorLbl.Text = "Card Number is required";
                    }
                }
           
        }
        catch
        {
            UserIdErrorLbl.Text = "An exception occured during sign up.";
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