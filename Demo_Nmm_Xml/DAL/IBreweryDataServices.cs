using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo_Nmm_Xml.Models;

namespace Demo_Nmm_Xml.DAL
{
    /// <summary>
    /// data server interface to read and write an entire based on the Brewery class
    /// </summary>
    public interface IBreweryDataServices
    {
        List<Brewery> Read();
        void Write(List<Brewery> Breweries);
    }
}