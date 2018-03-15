using System.Collections.Generic;
using CityArrayDAL.Model;

namespace CityArrayDAL.Repository.Interfaces
{
    public interface ICityRepository : IBaseRepository<City>
    {
        IEnumerable<City> MostReviewedCities(int count);

        City GetByName(string City, int CountryId);

        Dictionary<string, int> GetDictionary();
    }
}
