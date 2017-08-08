using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace StoreLocatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //API key for the google web service
        const string API_KEY = "AIzaSyDxZP13vkCLE6Np3x7fsW7QUHn0FRs4OoE";
        public string getStoreLocation(string zipcode, string storeName)
        {
            try
            {
                //Create a web client for the http get operation
                WebClient client = new WebClient();
                String address = "";
                StringBuilder addsb = new StringBuilder();

                //ndfdXML object to retrive the latitude and longitude from the zipcode
                LocationService.ndfdXML proxy = new LocationService.ndfdXML();
                //Get the latitude and longitude in XML data
                var latlongXML = proxy.LatLonListZipCode(zipcode);

                //Convert the XML data into String array
                String[] latlong = getLatLongLocation(latlongXML);

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

        public static String[] getLatLongLocation(String locationXML)
        {
            //Extract the latitude and longitude from the XML data
            try
            {
                //Load the XML into XmlDocument object
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(locationXML);
                //Split the child element to get the latitude and longitude
                String[] latlongStr = doc.InnerText.Split(',');
                return latlongStr;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
