using CityArrayDAL.EF;
using CityArrayDAL.Repository.Interfaces;
using CityArrayDAL.Model;

namespace CityArrayDAL.Repository.Base
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(CityArrayContext context) : base(context) { }
    }
}
