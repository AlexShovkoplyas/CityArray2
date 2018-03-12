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

        public Dictionary<string, int> CountryDictionary() => DictionaryIdName(dbSet.ToList().Select(c => Tuple.Create(c.Name, c.Id)));

        private Dictionary<T1, T2> DictionaryIdName<T1, T2>(IEnumerable<Tuple<T1, T2>> list)
        {
            var res = new Dictionary<T1, T2>();
            foreach (var tuple in list)
            {
                res.Add(tuple.Item1, tuple.Item2);
            }
            return res;
        }
    }
}
