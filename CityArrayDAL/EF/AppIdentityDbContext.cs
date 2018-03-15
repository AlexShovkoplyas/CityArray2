using CityArrayDAL.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CityArrayDAL.EF
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>, IDisposable
    {
        public AppIdentityDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
    }
}
