using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CityArrayDAL.Model;

namespace CityArrayDAL.EFConfig
{
    public class CityConfig:EntityTypeConfiguration<City>
    {
        public CityConfig()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasIndex(p => new { p.Name, p.CountryId }).IsUnique(true);            
            Property(p => p.Name).IsRequired().HasMaxLength(30);
            
            HasMany(p => p.Reviews).WithRequired(p => p.City).HasForeignKey(p => p.CityId);//.WillCascadeOnDelete(true);
        }
    }
}