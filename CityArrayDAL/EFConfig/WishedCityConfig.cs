using System.Data.Entity.ModelConfiguration;
using CityArrayDAL.Model;

namespace CityArrayDAL.EFConfig
{
    public class WishedCityConfig : EntityTypeConfiguration<WishedCity>
    {
        public WishedCityConfig()
        {
            HasKey(p => p.Id);
            HasIndex(p => new {p.CityId, p.PersonId}).IsUnique(true);
        }        
    }
}