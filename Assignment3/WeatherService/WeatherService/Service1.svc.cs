using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] getWeather5day(string zipcode)
        {
            String[] weatherData = new String[10];
            String[] maxTemp = new String[5];
            String[] minTemp = new String[5];

            //An arraylist of parameters to be extracted from the XML
            ArrayList requiredData = new ArrayList();
            requiredData.Add("Daily Maximum Temperature");
            requiredData.Add("Daily Minimum Temperature");

            try
            {
                //Create proxy object of the ndfdXML class
                WeatherServiceReference.ndfdXML proxy = new WeatherServiceReference.ndfdXML();

                //Get the latitude and longitude from the zipcode from the service in XML format
                var latlongXML = proxy.LatLonListZipCode(zipcode);

                //Put the latitude and longitude in the decimal array
                decimal[] latlong = new decimal[2];
                latlong = getLatLong(latlongXML);

                //Get weather data for the next 5 days in the XML format
                int index = 0;
                var weatherDataStr = proxy.NDFDgenByDay(latlong[0], latlong[1], DateTime.Now.AddDays(1), "5", "e", "24 hourly");

                //Load the XML into XmlDocument object
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(weatherDataStr);

                //Get the parameters tag from the XML
                XmlNodeList paramNode = doc.GetElementsByTagName("parameters");

                //Navigate to the child node which contains the data
                foreach (XmlNode child in paramNode)
                {
                    XmlNodeList paramChildNode = child.ChildNodes;
                    foreach (XmlNode pchild in paramChildNode)
                    {
                        XmlNodeList dataNodeList = pchild.ChildNodes;
                        String nameStr = "";
                        Boolean name = true;
                        index = 0;
                        foreach (XmlNode dataNode in dataNodeList)
                        {
                            // the first node will be the name of the property
                            //check if the property is either minimum temperature or maximum temperature
                            //Add it accordingly to the minTemp or maxTemp array
                            if (name)
                            {
                                nameStr = dataNode.InnerText;
                                name = false;
                            }
                            else if (requiredData.Contains(nameStr))
                            {
                                if (nameStr.Equals("Daily Maximum Temperature"))
                                {
                                    maxTemp[index] = dataNode.InnerText;

                                }
                                else
                                {
                                    minTemp[index] = dataNode.InnerText;

                                }
                                index++;
                            }
                            
                        }
                        
                    }
                }
                //Combine the minTemp and maxTemp array into weatherData and return it
                for (int i=0;i<5;i++)
                {
                    weatherData[i] = maxTemp[i];
                }
                for (int i=0;i<5;i++)
                {
                    weatherData[5+i] = minTemp[i];
                }

            }
            //return error message if an exception is caught
            catch(Exception e)
            {
                weatherData[0] = "error";
                weatherData[1] = e.Message;
            }
            return weatherData;
            
        }

        //Extract the latitude and longitude from the XML data
        public static decimal[] getLatLong(String locationXML)
        {
            try
            {
                decimal[] latlong = new decimal[2];
                //Load the latitude and longitude XML into the XmlDocument object
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(locationXML);
                //Split the data into decimal array and return it 
                String[] latlongStr = doc.InnerText.Split(',');
                latlong[0] = decimal.Parse(latlongStr[0]);
                latlong[1] = decimal.Parse(latlongStr[1]);

                return latlong;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}
