using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffPage1_AdmnPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Get the userId from the cookie
        HttpCookie userCookies = Request.Cookies["userInfo"];
        String type = "";
        if (Session["type"] != null)
        {
            type = Session["type"].ToString();
        }
        //Redirect to login page if the id is empty
        if (userCookies == null || userCookies["id"] == "" || userCookies["type"] == "member" || userCookies["type"] == "staff" || userCookies["type"] == "")
        {
            Response.Redirect("~/StaffLogin.aspx");
        }
        //Redirect to login page if the role is incorrect
        else if (type.Equals("member") || type.Equals("staff"))
        {
            Response.Redirect("~/StaffLogin.aspx");
        }
        else
        {
            userlbl.Text = userCookies["id"];
        }
    }

    protected void AddBookButton_Click(object sender, EventArgs e)
    {
        try
        {
            //Create service reference object
            Assignment5ServiceRefs.Service1Client serviceRef = new Assignment5ServiceRefs.Service1Client();
            //Check if any of the fields are empty
            if (TitleTb.Text.Equals("") || IsbnTb.Text.Equals("") || DescriptionTb.Text.Equals(""))
            {
                ErrorLbl.Text = "All the fields are required.";
            }
            else
            {
                //Call the AddBooks operation from the service
                string status = serviceRef.AddBooks(IsbnTb.Text, TitleTb.Text, DescriptionTb.Text);
                if (status.Equals("true"))
                {
                    ErrorLbl.Text = "Book added succesfully";
                }
                else
                {
                    ErrorLbl.Text = "Unexpected error occured!";
                }

            }
        }
        catch
        {
            ErrorLbl.Text = "Unexpected error occured!";
        }
        
        
    }

    protected void signoutButton_Click(object sender, EventArgs e)
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