using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //API key for the google web service
        const string API_KEY = "AIzaSyDxZP13vkCLE6Np3x7fsW7QUHn0FRs4OoE";
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
                for (int i = 0; i < 5; i++)
                {
                    weatherData[i] = maxTemp[i];
                }
                for (int i = 0; i < 5; i++)
                {
                    weatherData[5 + i] = minTemp[i];
                }

            }
            //return error message if an exception is caught
            catch (Exception e)
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
            catch (Exception e)
            {
                throw e;
            }

        }

        public string getStoreLocation(string zipcode, string storeName)
        {
            try
            {
                //Create a web client for the http get operation
                WebClient client = new WebClient();
                String address = "";
                StringBuilder addsb = new StringBuilder();

                //ndfdXML object to retrive the latitude and longitude from the zipcode
                WeatherServiceReference.ndfdXML proxy = new WeatherServiceReference.ndfdXML();
                //Get the latitude and longitude in XML data
                var latlongXML = proxy.LatLonListZipCode(zipcode);

                //Convert the XML data into String array
                decimal[] latlong = getLatLong(latlongXML);

                //Construct the query to get the nearby stores using google places api
                string locationIdQuery = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + latlong[0] + "," + latlong[1]
                    + "&rankby=distance&name=" + storeName + "&key=" + API_KEY;

                //Get the result in JSON format
                string response = client.DownloadString(locationIdQuery);
                dynamic jsonReader = JObject.Parse(response);

                //Retrieve the first result as it is the nearest store
                String retStoreName = jsonReader.results[0].name;
                //if the result store name matches the queried store name , continue parsing the JSON
                if (retStoreName.ToLower().Contains(storeName.ToLower()))
                {
                    //Start constructing the address string
                    addsb.Append(retStoreName);
                    addsb.Append(",");

                    //Get the store id from the JSON
                    String storeId = jsonReader.results[0].place_id;
                    //Construct a query to obtain the address from the store id
                    string addressQuery = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + storeId + "&key=" + API_KEY;

                    //Get the address in JSON format
                    string addResponse = client.DownloadString(addressQuery);
                    dynamic addJson = JObject.Parse(addResponse);

                    int count = addJson.result.address_components.Count;
                    //If the JSON is empty then there are no stores in the vicinity
                    if (count == 0)
                    {
                        address = "No stores within 30 miles";
                    }
                    //Iterate over the JSON elements to construct the address string
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            addsb.Append(addJson.result.address_components[i].long_name);
                            if (i < count - 1)
                            {
                                addsb.Append(",");
                            }
                        }
                    }


                }
                else
                {
                    address = "No stores within 30 miles";
                }
                address = addsb.ToString();
                return address;
            }
            catch
            {
                return "No stores within 30 miles";
            }
        }

        public bool PutUsersToFile(string user, string password)
        {
            //Name of the XML file to store the users
            String fileName = "Users.xml";
            //Return value
            bool done = true;
            //Location of the file irrespective of the machine
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fLocation = Path.Combine(fLocation, fileName);
            //create a XmlDocument object
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode;
            try
            {
                //if the file doesn't exist, create the root node
                if (!File.Exists(fLocation))
                {

                    rootNode = xmlDoc.CreateElement("users");
                    xmlDoc.AppendChild(rootNode);
                }
                else
                {
                    //load the XML file from the location
                    xmlDoc.Load(fLocation);
                    rootNode = xmlDoc.DocumentElement;
                }
                //Create the new node with the input value
                XmlNode userNode = xmlDoc.CreateElement("user");
                XmlNode nameNode = xmlDoc.CreateElement("username");
                XmlNode passNode = xmlDoc.CreateElement("password");
                nameNode.InnerText = user;
                passNode.InnerText = password;

                //Append the nodes to the parent user Node
                userNode.AppendChild(nameNode);
                userNode.AppendChild(passNode);

                rootNode.AppendChild(userNode);
                //Save the XML file
                xmlDoc.Save(fLocation);
            }
            catch
            {
                done = false;
            }
            return done;

        }

        public bool PutPlaceToFile(string place, string username)
        {
            //Name of the XML file to store the address
            String fileName = "Users.xml";
            bool status = true;
            //location of App data folder
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fLocation = Path.Combine(fLocation, fileName);
            //Create XML document object
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode;
            //Check if the file exists. If there is no file, then the user is not logged in
            if (!File.Exists(fLocation))
            {
                //Return false, if there are no users
                return false;
            }

            try
            {
                //Load the users.xml file
                xmlDoc.Load(fLocation);
                rootNode = xmlDoc.DocumentElement;

                //Create a place node and store the value
                XmlNode placeNode = xmlDoc.CreateElement("place");
                placeNode.InnerText = place;

                //Iterate through the nodes to find the current user
                XmlNodeList userNodes = xmlDoc.SelectNodes("//users/user");
                foreach (XmlNode userNode in userNodes)
                {
                    //Search for the user
                    string savedUser = userNode["username"].InnerText;
                    //Check if the current user is the logged in user
                    if (savedUser.Equals(username))
                    {
                        //Append the place node if the user is found
                        userNode.AppendChild(placeNode);
                        break;
                    }
                }
                //Save the XML file
                xmlDoc.Save(fLocation);
            }
            catch
            {
                status = false;
            }

            return status;
        }

        //Check if the user is registered
        public bool GetUserFromFile(string user, string password)
        {
            //File where the user info is stored
            String fileName = "Users.xml";
            bool status = false;

            //Location of the file in the server
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            //Combine the path and the filename
            fLocation = Path.Combine(fLocation, fileName);
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode;
            if (!File.Exists(fLocation))
            {
                //Return false, if there are no users
                return false;
            }

            try
            {
                //Load the XML file from the location
                xmlDoc.Load(fLocation);
                rootNode = xmlDoc.DocumentElement;
                //Get the user nodes
                XmlNodeList userNodes = xmlDoc.SelectNodes("//users/user");
                //iterate over each user node
                foreach (XmlNode userNode in userNodes)
                {
                    //Read the uername from the file
                    string savedUser = userNode["username"].InnerText;
                    //Check if the username entered in the textbox is same as the username in the file
                    if (savedUser.Equals(user))
                    {
                        //Read the password from the file
                        string savedPass = userNode["password"].InnerText;
                        //If the password in file matches with the one entered in the textbox
                        if (savedPass.Equals(password))
                        {
                            //return true if a match is found
                            status = true;
                            break;
                        }

                    }
                }
            }
            catch
            {
                status = false;
            }
            return status;
        }
    }
}
