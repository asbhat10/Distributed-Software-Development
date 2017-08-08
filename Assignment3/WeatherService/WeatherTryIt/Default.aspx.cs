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
        WeatherServiceReference.Service1Client client = new WeatherServiceReference.Service1Client();
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
}