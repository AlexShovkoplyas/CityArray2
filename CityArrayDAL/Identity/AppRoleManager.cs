using CityArrayDAL.Model;
using Microsoft.AspNet.Identity;

namespace CityArrayDAL.Identity
{
    public class AppRoleManager : RoleManager<AppRole, int> 
    {
        public AppRoleManager(IRoleStore<AppRole,int> store)
                    : base(store)
        { }
    }
}
