using System.Collections.Generic;
using System.Linq;
using CityArrayDAL.EF;
using CityArrayDAL.Model;
using CityArrayDAL.Repository.Interfaces;

namespace CityArrayDAL.Repository.Base
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(CityArrayContext context) : base(context) { }

        public City GetByName(string city, string country)
        {
            return dbSet.FirstOrDefault(c=>c.Name==city && c.Country.Name == country);
        }

        public City GetByName(string city, int countryId)
        {
            return dbSet.FirstOrDefault(c => c.Name == city && c.CountryId == countryId);
        }

        public IEnumerable<City> MostReviewedCities(int count)
        {
            return dbSet.OrderByDescending(c => c.Reviews.Count).Take(count).ToList();
        }

        public Dictionary<string, int> CityDictionary()
        {
            var dictionary = new Dictionary<string,int>(dbSet.Count());
            foreach (var item in dbSet)
            {
                dictionary.Add(item.Name, item.Id);
            }
            return dictionary;
        }

    }
}
