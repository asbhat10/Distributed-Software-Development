using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberPages_Default : System.Web.UI.Page
{

    //API key for the google web service
    const string API_KEY = "AIzaSyDxZP13vkCLE6Np3x7fsW7QUHn0FRs4OoE";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check if the user id is present in the cookie
        try {
            HttpCookie userCookies = Request.Cookies["userInfo"];
            String type = "";
            //Get the role of the user from the session
            if (Session["type"] != null)
            {
                type = Session["type"].ToString();
            }
            //If there are no cookies, then redirect to Login page
            if (userCookies == null || userCookies["id"] == "" || userCookies["type"] == "staff" || userCookies["type"] == "admin" || userCookies["type"] == "")
            {
                Response.Redirect("~/MembersLogin.aspx");
            }
            //Redirect to login page if the user's role is admin or staff
            else if (type.Equals("staff") || type.Equals("admin"))
            {
                Response.Redirect("~/MembersLogin.aspx");
            }
            else {
                if (!Page.IsPostBack)
                {
                    if (!(userCookies == null) && !(userCookies["id"] == ""))
                    {
                        idLbl.Text = userCookies["id"];
                    }
                    //Get all the books from the Books.xml
                    Assignment5ServiceRefs.Service1Client client = new Assignment5ServiceRefs.Service1Client();
                    ArrayList bookList = new ArrayList(client.getAllBooks());
                    foreach (string title in bookList)
                    {
                        BookList.Items.Add(title);
                    }
                }
            }
        }
        catch
        {

        }
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        try
        {
            //Get the latitude and longitude from the given zipcode
            Assignment5ServiceRefs.Service1Client serviceRefs = new Assignment5ServiceRefs.Service1Client();
            String zipCode = zipCodeTB.Text;
            String[] latLong = serviceRefs.getLatLong(zipCode);
            if (latLong[0].Equals("false"))
            {
                LibrariesLabel.Text = "Invalid Zipcode";
            }
            else
            {
                //Get the place id of athe nearby libraries
                String locationIdQuery = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + latLong[0] + "," + latLong[1] + "&type=library&rankby=distance&key=" + API_KEY;
                //Create a web client for the http get operation
                WebClient client = new WebClient();
                //Get the result in JSON format
                string response = client.DownloadString(locationIdQuery);
                StringBuilder addsb = new StringBuilder();
                dynamic jsonReader = JObject.Parse(response);
                int length = jsonReader.results.Count < 5 ? jsonReader.results.Count : 5;
                //If the count is zero, theer are no libraries in the vicinity
                if (length == 0)
                {
                    LibrariesLabel.Text = "No Libraries within 30 miles.";
                }
                else
                {

                    for (int i = 0; i < length; i++)
                    {
                        //Get the store id from the JSON
                        String placeId = jsonReader.results[i].place_id;
                        //Construct a query to obtain the address from the place id
                        string addressQuery = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + placeId + "&key=" + API_KEY;

                        //Get the address in JSON format
                        string addResponse = client.DownloadString(addressQuery);
                        dynamic addJson = JObject.Parse(addResponse);
                        String libraryName = jsonReader.results[i].name;
                        addsb.Append(libraryName);
                        addsb.Append(",");
                        addsb.Append(addJson.result.adr_address);
                        addsb.Append("<br/><br/>");
                    }
                    LibrariesLabel.Text = addsb.ToString();
                }
            }
        }
        catch (Exception exc)
        {
            LibrariesLabel.Text = exc.Message;
        }        
    }


    protected void DetailButton_Click(object sender, EventArgs e)
    {
        try {
            //Get the details of the book from the title
            Assignment5ServiceRefs.Service1Client client = new Assignment5ServiceRefs.Service1Client();
            String name = BookList.SelectedItem.Text;
            String[] details = client.getBookDetails(name);
            TitleLbl.Text = name;
            IsbnLbl.Text = details[0];
            DescLbl.Text = details[1];
            }
        catch
        {
            TitleLbl.Text = "Unexpected error occured!";
        }
        
    }
    //Add the current title to the book tag in the user.xml
    protected void BorrowButton_Click(object sender, EventArgs e)
    {
        try {
            //Create a service reference object
            Assignment5ServiceRefs.Service1Client client = new Assignment5ServiceRefs.Service1Client();
            //Get the user id from the cookie
            HttpCookie userCookies = Request.Cookies["userInfo"];
            String userId = "";
            if (!(userCookies == null) && !(userCookies["id"] == ""))
            {
                userId = userCookies["id"];
                String title = BookList.SelectedItem.Text;
                //call the opearation in the service to add the book tag
                if (client.addBorrowed(title, userId))
                {
                    BorrowStatusLbl.Text = "Book borrowed successfully!";
                }
                else
                {
                    BorrowStatusLbl.Text = "Unexpected Error Occured!";
                }
            }
            else
            {
                BorrowStatusLbl.Text = "Unexpected Error Occured!";
            }
        } catch
        {
            BorrowStatusLbl.Text = "Unexpected Error Occured!";
        }
        
        
    }

    protected void signOutButton_Click(object sender, EventArgs e)
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