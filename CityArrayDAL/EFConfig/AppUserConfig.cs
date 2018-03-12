using System.Data.Entity.ModelConfiguration;
using CityArrayDAL.Model;

namespace CityArrayDAL.EFConfig
{
    public class AppUserConfig : EntityTypeConfiguration<AppUser>
    {
        public AppUserConfig()
        {
            HasIndex(p => p.Email).IsUnique(true);

            HasOptional(p => p.Person).WithRequired(p => p.AppUser);
        }
    }
}