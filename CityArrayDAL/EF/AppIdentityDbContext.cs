using CityArrayDAL.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityArrayDAL.EF
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>, IDisposable
    {
        public AppIdentityDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
    }
}
