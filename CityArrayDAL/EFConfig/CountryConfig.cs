using System.Data.Entity.ModelConfiguration;
using CityArrayDAL.Model;

namespace CityArrayDAL.EFConfig
{
    public class CountryConfig:EntityTypeConfiguration<Country>
    {
        public CountryConfig()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(30);
            HasIndex(p => p.Name).IsUnique(true);

            HasMany(p => p.Cities).WithRequired(p => p.Country).HasForeignKey(p => p.CountryId);//.WillCascadeOnDelete(true);
            HasMany(p => p.People).WithOptional(p => p.Nationality).HasForeignKey(p => p.CountryId);//.WillCascadeOnDelete(true);
        }
    }
}