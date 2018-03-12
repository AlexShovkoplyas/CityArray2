using CityArrayDAL.EF;
using CityArrayDAL.Repository.Base;

namespace CityArrayDAL.Repository.Cashed
{
    public class ReviewRepositoryCashed : ReviewRepository
    {
        public ReviewRepositoryCashed(CityArrayContext context) : base(context) { }
    }
}
