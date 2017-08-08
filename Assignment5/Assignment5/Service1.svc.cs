using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Assignment5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public bool checkUserCredentials(string id, string password)
        {
            //File where the user info is stored
            String fileName = "Members.xml";
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
                    string savedUser = userNode["id"].InnerText;
                    //Check if the username entered in the textbox is same as the username in the file
                    if (savedUser.Equals(id))
                    {
                        string encryptPass = userNode["password"].InnerText;
                        if (encryptPass.Equals(password))
                        {
                            status = true;
                            break;
                        }
                        else
                        {
                            status = false;
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

        public string[] getLatLong(string zipcode)
        {
            String[] latlongStr = new String[2];

            try
            {
                //Create proxy object of the ndfdXML class
                WeatherServiceReference.ndfdXML proxy = new WeatherServiceReference.ndfdXML();

                //Get the latitude and longitude from the zipcode from the service in XML format
                var latlongXML = proxy.LatLonListZipCode(zipcode);
                //Load the latitude and longitude XML into the XmlDocument object
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(latlongXML);
                //Split the data into decimal array and return it 
                latlongStr = doc.InnerText.Split(',');
                
            }
            catch (Exception e)
            {
                latlongStr[0] = "false";
                latlongStr[1] = e.Message;
            }
            return latlongStr;
        }

        public String SignUpMembers(string id, string password, string name, string cardNo)
        {
            //Name of the XML file to store the users
            String fileName = "Members.xml";
            //Return value
            String status = "true";
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
                    XmlDeclaration xmldecl;
                    xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    rootNode = xmlDoc.CreateElement("users");
                    xmlDoc.AppendChild(rootNode);
                    xmlDoc.InsertBefore(xmldecl, rootNode);
                }
                else
                {
                    //load the XML file from the location
                    xmlDoc.Load(fLocation);
                    rootNode = xmlDoc.DocumentElement;
                }
                if (!isUserTaken(id))
                {
                    //Create the new node with the input value
                    XmlNode userNode = xmlDoc.CreateElement("user");
                    XmlNode nameNode = xmlDoc.CreateElement("name");
                    XmlNode passNode = xmlDoc.CreateElement("password");
                    XmlNode idNode = xmlDoc.CreateElement("id");
                    XmlNode cardNode = xmlDoc.CreateElement("card");
                    nameNode.InnerText = name;
                    passNode.InnerText = password;
                    idNode.InnerText = id;
                    cardNode.InnerText = cardNo;

                    //Append the nodes to the parent user Node
                    userNode.AppendChild(nameNode);
                    userNode.AppendChild(passNode);
                    userNode.AppendChild(idNode);
                    userNode.AppendChild(cardNode);

                    rootNode.AppendChild(userNode);
                    //Save the XML file
                    xmlDoc.Save(fLocation);
                }
                else
                {
                    return "UserIdTaken";
                }
                
            }
            catch
            {
                status = "false";
            }
            return status;
        }

        private bool isUserTaken(string id)
        {
            //File where the user info is stored
            String fileName = "Members.xml";
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
                    string savedUser = userNode["id"].InnerText;
                    //Check if the username entered in the textbox is same as the username in the file
                    if (savedUser.Equals(id))
                    {
                        status = true;
                    }
                }
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public String AddBooks(String isbn, String title, String description)
        {
            //Name of the XML file to store the users
            String fileName = "Books.xml";
            //Return value
            String status = "true";
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
                    XmlDeclaration xmldecl;
                    xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    rootNode = xmlDoc.CreateElement("books");
                    xmlDoc.AppendChild(rootNode);
                    xmlDoc.InsertBefore(xmldecl, rootNode);
                }
                else
                {
                    //load the XML file from the location
                    xmlDoc.Load(fLocation);
                    rootNode = xmlDoc.DocumentElement;
                }
                //Create the new node with the input value
                XmlNode bookNode = xmlDoc.CreateElement("book");
                XmlNode isbnNode = xmlDoc.CreateElement("isbn");
                XmlNode titleNode = xmlDoc.CreateElement("title");
                XmlNode descNode = xmlDoc.CreateElement("description");
                isbnNode.InnerText = isbn;
                titleNode.InnerText = title;
                descNode.InnerText = description;

                //Append the nodes to the parent user Node
                bookNode.AppendChild(isbnNode);
                bookNode.AppendChild(titleNode);
                bookNode.AppendChild(descNode);

                rootNode.AppendChild(bookNode);
                //Save the XML file
                xmlDoc.Save(fLocation);
            }
            catch
            {
                status = "false";
            }
            return status;
        }

        public ArrayList getAllBooks()
        {
            ArrayList bookList = new ArrayList();
            //File where the user info is stored
            String fileName = "Books.xml";

            //Location of the file in the server
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            //Combine the path and the filename
            fLocation = Path.Combine(fLocation, fileName);
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode;
            if (!File.Exists(fLocation))
            {
                //Return false, if there are no books
                return bookList;
            }

            try
            {
                //Load the XML file from the location
                xmlDoc.Load(fLocation);
                rootNode = xmlDoc.DocumentElement;
                //Get the book nodes
                XmlNodeList booksNodes = xmlDoc.SelectNodes("//books/book");
                //iterate over each book node
                foreach (XmlNode bookNode in booksNodes)
                {
                    //Read the title from the file
                    bookList.Add(bookNode["title"].InnerText);
                }
            }
            catch
            {
                return bookList;
            }
            return bookList;
        }

        public String[] getBookDetails(String name)
        {
            String[] details = new String[2];
            //File where the user info is stored
            String fileName = "Books.xml";

            //Location of the file in the server
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            //Combine the path and the filename
            fLocation = Path.Combine(fLocation, fileName);
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode;
            if (!File.Exists(fLocation))
            {
                //Return false, if there are no books
                return details;
            }

            try
            {
                //Load the XML file from the location
                xmlDoc.Load(fLocation);
                rootNode = xmlDoc.DocumentElement;
                //Get the book nodes
                XmlNodeList booksNodes = xmlDoc.SelectNodes("//books/book");
                //iterate over each book node
                foreach (XmlNode bookNode in booksNodes)
                {
                    string title = bookNode["title"].InnerText;
                    if (title.Equals(name))
                    {
                        details[0] = bookNode["isbn"].InnerText;
                        details[1] = bookNode["description"].InnerText;
                    }
                    
                }
            }
            catch
            {
                return details;
            }
            return details;
        }


        public Boolean addBorrowed(String title,String userId)
        {
            Boolean status = true;
            //File where the user info is stored
            String fileName = "Members.xml";

            //Location of the file in the server
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            //Combine the path and the filename
            fLocation = Path.Combine(fLocation, fileName);
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode;
            if (!File.Exists(fLocation))
            {
                //Return false, if there are no books
                status = false;
                return status;
            }

            try
            {
                //Load the XML file from the location
                xmlDoc.Load(fLocation);
                rootNode = xmlDoc.DocumentElement;
                //Get the book nodes
                XmlNodeList usersNodes = xmlDoc.SelectNodes("//users/user");
                //iterate over each book node
                foreach (XmlNode userNode in usersNodes)
                {
                    string id = userNode["id"].InnerText;
                    if (id.Equals(userId))
                    {
                        XmlNode bookNode = xmlDoc.CreateElement("book");
                        XmlNode titleNode = xmlDoc.CreateElement("title");
                        titleNode.InnerText = title;
                        bookNode.AppendChild(titleNode);
                        userNode.AppendChild(bookNode);
                        xmlDoc.Save(fLocation);
                        break;
                    }
                }
            }
            catch
            {
                return false;
            }
            return status;
        }

        public string transformationMembers()
        {
            String transformed = "";
            //File where the user info is stored
            String xmlfileName = "Members.xml";
            String xslfileName = "Members.xsl";
            //Location of the file in the server
            string location = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");

            //Combine the path and the filename
            string xmlLocation = Path.Combine(location, xmlfileName);
            //Combine the path and the filename
            string xslLocation = Path.Combine(location, xslfileName);
            try
            {
                //Create an XPathDocument object
                XPathDocument doc = new XPathDocument(xmlLocation);
                //Create XslCompiledTransform object
                XslCompiledTransform xt = new XslCompiledTransform();
                //Load the XSL into the object
                xt.Load(xslLocation);
                //Create a StringWriter object to return the html as a string
                using (StringWriter sw = new StringWriter())
                // use OutputSettings of xsl, so it can be output as HTML
                using (XmlWriter xwo = XmlWriter.Create(sw, xt.OutputSettings))
                {
                    //Transform the given XML into HTML
                    xt.Transform(doc, xwo);
                    //return the HTML as a string
                    transformed = sw.ToString();
                }
            }
            catch (Exception e)
            {
                transformed = e.Message;
            }
            return transformed;
        }

        public string transformationBooks()
        {
            String transformed = "";
            //File where the user info is stored
            String xmlfileName = "Books.xml";
            String xslfileName = "Books.xsl";
            //Location of the file in the server
            string location = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");

            //Combine the path and the filename
            string xmlLocation = Path.Combine(location, xmlfileName);
            //Combine the path and the filename
            string xslLocation = Path.Combine(location, xslfileName);
            try
            {
                //Create an XPathDocument object
                XPathDocument doc = new XPathDocument(xmlLocation);
                //Create XslCompiledTransform object
                XslCompiledTransform xt = new XslCompiledTransform();
                //Load the XSL into the object
                xt.Load(xslLocation);
                //Create a StringWriter object to return the html as a string
                using (StringWriter sw = new StringWriter())
                // use OutputSettings of xsl, so it can be output as HTML
                using (XmlWriter xwo = XmlWriter.Create(sw, xt.OutputSettings))
                {
                    //Transform the given XML into HTML
                    xt.Transform(doc, xwo);
                    //return the HTML as a string
                    transformed = sw.ToString();
                }
            }
            catch (Exception e)
            {
                transformed = e.Message;
            }
            return transformed;
        }

        public string checkUserCredentialsForStaff(string id, string password)
        {
            //File where the user info is stored
            String fileName = "Staff.xml";
            string role = "";

            //Location of the file in the server
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            //Combine the path and the filename
            fLocation = Path.Combine(fLocation, fileName);
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode;
            if (!File.Exists(fLocation))
            {
                //Return false, if there are no users
                return "";
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
                    string savedUser = userNode["id"].InnerText;
                    //Check if the username entered in the textbox is same as the username in the file
                    if (savedUser.Equals(id))
                    {
                        string encryptPass = userNode["password"].InnerText;
                        if (encryptPass.Equals(password))
                        {
                            role = userNode["role"].InnerText;
                            break;
                        }
                        else
                        {
                            role = "";
                            break;
                        }
                    }
                }
            }
            catch
            {
                role = "";
            }
            return role;
        }
    }
}
