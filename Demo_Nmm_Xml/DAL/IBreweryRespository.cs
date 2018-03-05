using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo_Nmm_Xml.Models;

namespace Demo_Nmm_Xml.DAL
{
    public class IBreweryRespository
    {
        public interface IBreweryRepository
        {
            IEnumerable<Brewery> SelectAll();
            Brewery SelectOne(int id);
            void Insert(Brewery brewery);
            void Update(Brewery brewery);
            void Delete(int d);
        }
    }
}