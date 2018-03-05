using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo_Nmm_Xml.Models;

namespace Demo_Nmm_Xml.DAL
{
    public class BreweryRepository : IBreweryRespository, IDisposable
    {

        private List<Brewery> _breweries;

        public BreweryRepository()
        {
            BreweryXmlDataService breweryXmlDataService = new BreweryXmlDataService();

            using (breweryXmlDataService)
            {
                _breweries = breweryXmlDataService.Read() as List<Brewery>;
            }
        }

        public void Update(Brewery UpdateBrewery)
        {
            var oldBrewery = _breweries.Where(b => b.Id == UpdateBrewery.Id).FirstOrDefault();

            if (oldBrewery != null)
            {
                _breweries.Remove(oldBrewery);
                _breweries.Add(UpdateBrewery);
            }

            Save();
        }

        public IEnumerable<Brewery> SelectAll()
        {
            return _breweries;
        }

        public Brewery SelectOne(int id)
        {
            //Brewery selectedBrewery =
            //(from brewery in _breweries
            //where vrewery.Id == id
            //select brewery).FirstOrDefault();

            Brewery selectedbrewery = _breweries.Where(p => p.Id == id).FirstOrDefault();

            return selectedbrewery;
        }

        public void Insert(Brewery brewery)
        {
            brewery.Id = NextIdValue();
            _breweries.Add(brewery);

            Save();

        }

        private int NextIdValue()
        {
            int currentMaxId = _breweries.OrderByDescending(b => b.Id).FirstOrDefault().Id;
            return currentMaxId + 1;
        }

        public void Delete(int id)
        {
            var brewery = _breweries.Where(b => b.Id == id).FirstOrDefault();

            if (brewery != null)
            {
                _breweries.Remove(brewery);
            }

            Save();
        }

        public void Save()
        {
            BreweryXmlDataService breweryXmlDataService = new BreweryXmlDataService();

            using (breweryXmlDataService)
            {
                breweryXmlDataService.Write(_breweries);
            }


        }
        public void Dispose()
        {
            _breweries = null;
        }
    }
}