using System.Data.Entity.ModelConfiguration;
using CityArrayDAL.Model;

namespace CityArrayDAL.EFConfig
{
    public class VisitedPlaceConfig : EntityTypeConfiguration<VisitedPlace>
    {
        public VisitedPlaceConfig()
        {
            HasKey(p => p.Id);
            Property(p => p.Name).IsRequired();
            Property(p => p.Name).HasMaxLength(50);
        }        
    }
}