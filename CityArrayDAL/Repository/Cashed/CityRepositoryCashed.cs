using CityArrayDAL.EF;
using CityArrayDAL.Repository.Base;

namespace CityArrayDAL.Repository.Cashed
{
    public class CityRepositoryCashed : CityRepository
    {
        public CityRepositoryCashed(CityArrayContext context) : base(context)
        {
                
        }

    }
}
