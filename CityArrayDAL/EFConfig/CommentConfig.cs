using System.Data.Entity.ModelConfiguration;
using CityArrayDAL.Model;

namespace CityArrayDAL.EFConfig
{
    public class CommentConfig : EntityTypeConfiguration<Comment>
    {
        public CommentConfig()
        {      
            HasKey(p => p.Id);
            Property(p => p.Message).IsRequired().HasMaxLength(500);
        }       
    }
}