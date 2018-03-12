using CityArrayDAL.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityArrayDAL.Identity
{
    public class AppRoleManager : RoleManager<AppRole, int> 
    {
        public AppRoleManager(IRoleStore<AppRole,int> store)
                    : base(store)
        { }
    }
}
