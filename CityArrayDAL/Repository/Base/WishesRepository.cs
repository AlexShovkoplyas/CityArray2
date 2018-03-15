using CityArrayDAL.EF;
using CityArrayDAL.Model;
using CityArrayDAL.Repository.Interfaces;

namespace CityArrayDAL.Repository.Base
{
    public class WishesRepository : BaseRepository<WishedCity>, IWishesRepository
    {
        public WishesRepository(CityArrayContext context) : base(context) { }
        
    }
}
