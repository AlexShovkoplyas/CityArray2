using CityArrayDAL.EF;
using CityArrayDAL.Model;
using CityArrayDAL.Repository.Interfaces;

namespace CityArrayDAL.Repository.Base
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(CityArrayContext context) : base(context) { }
    }
}
