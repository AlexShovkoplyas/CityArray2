using CityArrayDAL.EF;
using CityArrayDAL.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CityArrayDAL.Identity
{
    public class AppRoleStore : RoleStore<AppRole, int, AppUserRole>
    {
        public AppRoleStore(AppIdentityDbContext context) : base(context)
        {

        }
    }
}
