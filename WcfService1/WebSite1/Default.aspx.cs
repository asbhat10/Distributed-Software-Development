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

    //Event handler on click of celcius to Fahrenheit button 
    protected void ctofButton_Click(object sender, EventArgs e)
    {
        try
        {
            //Creating an instance of temperature conversion service
            TemperatureConversionService.Service1Client tempConversionService = new TemperatureConversionService.Service1Client();
            //Getting the converted Service value from the service method
            int coverted = tempConversionService.convertCToF(int.Parse(inputText.Value.ToString()));
            //Setting the label to the converted value
            convertedTemp.Text = coverted.ToString();
        }
        //Catching the exception when an invalid value is entered
        catch (Exception ex)
        {
            convertedTemp.Text = "Enter Integer Values";
        }
        
    }

    //Event handler on click of fahrenheit to celcius button
    protected void ftocButton_Click(object sender, EventArgs e)
    {
        try
        {
            //Creating an instance of temperature conversion service
            TemperatureConversionService.Service1Client tempConversionService = new TemperatureConversionService.Service1Client();
            //Getting the converted Service value from the service method
            int coverted = tempConversionService.convertFToC(int.Parse(inputText.Value.ToString()));
            //Setting the label to the converted value
            convertedTemp.Text = coverted.ToString();
        }
        //Catching the exception when an invalid value is entered
        catch (Exception ex)
        {
            convertedTemp.Text = "Enter Integer Values";
        }
        
    }
}