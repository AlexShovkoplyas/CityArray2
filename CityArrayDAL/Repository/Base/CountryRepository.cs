using System;
using System.Collections.Generic;
using System.Linq;
using CityArrayDAL.EF;
using CityArrayDAL.Model;
using CityArrayDAL.Repository.Interfaces;

namespace CityArrayDAL.Repository.Base
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(CityArrayContext context) : base(context) { }

        public Country GetByName(string Name)
        {
            return dbSet.FirstOrDefault(c => c.Name == Name);
        }

        public Dictionary<string, int> GetDictionary()
        {
            var dictionary = new Dictionary<string, int>(dbSet.Count());
            foreach (var item in dbSet)
            {
                dictionary.Add(item.Name, item.Id);
            }
            return dictionary;
        }
    }
}
