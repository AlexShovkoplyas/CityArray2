using CityArrayDAL.EF;
using CityArrayDAL.Repository.Base;

namespace CityArrayDAL.Repository.Cashed
{
    public class CountryRepositoryCashed : CountryRepository
    {
        public CountryRepositoryCashed(CityArrayContext context) : base(context) { }

        
    }
}
