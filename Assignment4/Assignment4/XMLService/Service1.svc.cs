using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XMLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static String resultXSD = "No Error";
        public string verification(string xsdURL, string xmlURL)
        {
            try {
                resultXSD = "No Error";
                // Create the XmlSchemaSet object.
                XmlSchemaSet sc = new XmlSchemaSet();
                // Add the schema to the collection before performing validation
                sc.Add(null, xsdURL);
                // Define the validation settings.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                //Set the schema to the uploaded file
                settings.Schemas = sc;
                //Add a handler to trigger it when a validation error occurs
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
                // Create the XmlReader object.
                XmlReader reader = XmlReader.Create(xmlURL, settings);
                // Parse the file. 
                // will call event handler if invalid
                while (reader.Read()) ;
                //return the result
                return resultXSD;
            }
            catch (Exception e)
            {
                //return the exception message if an invalid input is given
                resultXSD = e.Message;
                return resultXSD;
            }
            

        }

        // Display any validation errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            resultXSD = e.Message;
        }

        public string transformation(string xslURL, string xmlURL)
        {
            String xsdHtml = String.Empty;
            String fileName = "transform.html";
            try {
                string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
                fLocation = Path.Combine(fLocation, fileName);
                //Create an XPathDocument object
                XPathDocument doc = new XPathDocument(xmlURL);
                //Create XslCompiledTransform object
                XslCompiledTransform xt = new XslCompiledTransform();
                //Load the XSL into the object
                xt.Load(xslURL);
                //Create a StringWriter object to return the html as a string
                using (StringWriter sw = new StringWriter())
                // use OutputSettings of xsl, so it can be output as HTML
                using (XmlWriter xwo = XmlWriter.Create(sw, xt.OutputSettings))
                {
                    //Transform the given XML into HTML
                    xt.Transform(doc, xwo);
                    //return the HTML as a string
                    xsdHtml = sw.ToString();
                    File.WriteAllText(fLocation, xsdHtml);
                }
            }
            catch (Exception e)
            {
                xsdHtml = e.Message;
            }
            return xsdHtml;
        }
    }
}
