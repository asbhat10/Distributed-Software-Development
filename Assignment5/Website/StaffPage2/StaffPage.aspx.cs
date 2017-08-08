using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffPage2_StaffPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //check if the user id is in the cookie
            HttpCookie userCookies = Request.Cookies["userInfo"];
            //Get the role of the user from the cookie
            String type = "";
            if (Session["type"] != null)
            {
                type = Session["type"].ToString();
            }
            //Redirect to login page if the id is absent
            if (userCookies == null || userCookies["id"] == "" || userCookies["type"] == "member" || userCookies["type"] == "admin" || userCookies["type"] == "")
            {
                Response.Redirect("~/StaffLogin.aspx");
            }
            //Redirect to login page if the role is incorrect
            else if (type.Equals("member") || type.Equals("admin"))
            {
                Response.Redirect("~/StaffLogin.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    if (!(userCookies == null) && !(userCookies["id"] == ""))
                    {
                        idLbl.Text = userCookies["id"];
                    }
                    //Create an object of service reference
                    Assignment5ServiceRefs.Service1Client client = new Assignment5ServiceRefs.Service1Client();
                    //Transform the user and the book xml files
                    UsersInfoLbl.Text = client.transformationMembers();
                    BooksInfoLbl.Text = client.transformationBooks();
                }
            }
        }
        catch
        {}   
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