using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void convertedLabel_Click(object sender, EventArgs e)
        {

        }

        //Event listener to convert Fahrenheit to celsius
        private void FahToCelsius_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Creating an instance of Temperature conversion service
                TemperatureConversionService.Service1Client tempConversionService = new TemperatureConversionService.Service1Client();
                //Converting the temperature from Fahrenheit to celcius
                int coverted = tempConversionService.convertFToC(int.Parse(temptextBox.Text));
                //Setting the label to the converted temperature
                convertedLabel.Text = coverted.ToString();
            }
            //Catching the exception if an invalid value is entered
            catch (Exception ex)
            {
                convertedLabel.Text = "Please enter an integer value";
            }
        }

        //Event listener to convert Celcius to Fahrenheit
        private void CelToFah_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating an instance of Temperature conversion service
                TemperatureConversionService.Service1Client tempConversionService = new TemperatureConversionService.Service1Client();
                //Converting the temperature from Celcius to Fahrenheit
                int coverted = tempConversionService.convertCToF(int.Parse(temptextBox.Text));
                //Setting the label to the converted temperature
                convertedLabel.Text = coverted.ToString();
            }
            //Catching the exception if an invalid value is entered
            catch (Exception ex)
            {
                convertedLabel.Text = "Please enter an integer value";
            }
        }
    }
}
