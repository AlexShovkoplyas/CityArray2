using System.Data.Entity.ModelConfiguration;
using CityArrayDAL.Model;

namespace CityArrayDAL.EFConfig
{
    public class ReviewConfig : EntityTypeConfiguration<Review>
    {
        public ReviewConfig()
        {
            HasKey(p => p.Id);
            HasIndex(p => new {p.CityId, p.PersonId}).IsUnique(true);
            Property(p => p.CreationDate).IsRequired();
            Property(p => p.Rating).IsRequired();
            Property(p => p.CityDescription).IsOptional().HasMaxLength(500);
            Property(p => p.CityFeatures).IsOptional().HasMaxLength(500);
            Property(p => p.CityBags).IsOptional().HasMaxLength(500);

            HasMany(p => p.Comments).WithRequired(p => p.Review).HasForeignKey(p => p.ReviewId);//.WillCascadeOnDelete(true);
        }        
    }
}