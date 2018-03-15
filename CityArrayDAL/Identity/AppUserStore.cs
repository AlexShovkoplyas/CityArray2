using CityArrayDAL.EF;
using CityArrayDAL.Model;
using Microsoft.AspNet.Identity.EntityFramework;


namespace CityArrayDAL.Identity
{
    public class AppUserStore : UserStore<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public AppUserStore(AppIdentityDbContext context) : base(context)
        {
        }
    }
}