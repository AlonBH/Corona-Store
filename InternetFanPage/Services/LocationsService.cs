using InternetFanPage.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace InternetFanPage.Services
{
    public class LocationsService
    {
        public IList<Location> SearchLocations(string name, int? population)
        {
            using (var context = new FanPageContext())
            {
                IQueryable<Location> locations = context.Locations.Where(p => p.City.ToLower().Contains(name.ToLower()));

                if (population != null)
                {
                    locations = locations.Where(p => p.Population <= population);
                }

                return locations.ToList();
            }
        }


    }
}