using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Xml.Serialization;
using Demo_Nmm_Xml.Models;

namespace Demo_Nmm_Xml.DAL
{
    public class BreweryXmlDataService : IBreweryDataServices, IDisposable
    {
        public List<Brewery> Read()
        {
            // a breweries model is defined to pass a type to the xmlSerializer object
            Breweries breweriesObject;

            // initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamReader sReader = new StreamReader(xmlFilePath);

            // initialize an XML serializer object
            XmlSerializer deserializer = new XmlSerializer(typeof(Breweries));

            using (sReader)
            {
                // deserialize the XML data set into a generic object
                object xmlObject = deserializer.Deserialize(sReader);

                //cast the generic object to the list class
                breweriesObject = (Breweries)xmlObject;

            }

            return breweriesObject.breweries;

        }

        public void Write(List<Brewery> breweries)
        {
            // intitialize a FileStream object for reading

            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamWriter sWriter = new StreamWriter(xmlFilePath, false);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Brewery>), new XmlRootAttribute("Breweries"));

            using (sWriter)
            {
                serializer.Serialize(sWriter, breweries);
            }


        }

        public void Dispose()
        {
            // set resources to be cleaned up
        }


    }
}