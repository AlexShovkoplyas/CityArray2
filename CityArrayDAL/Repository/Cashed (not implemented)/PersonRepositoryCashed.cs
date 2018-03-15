using CityArrayDAL.EF;
using CityArrayDAL.Repository.Base;

namespace CityArrayDAL.Repository.Cashed
{
    public class PersonRepositoryCashed : PersonRepository
    {
        public PersonRepositoryCashed(CityArrayContext context) : base(context) { }
    }
}
