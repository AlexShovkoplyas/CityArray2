using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CityArrayDAL.Model;

namespace CityArrayDAL.EFConfig
{
    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            //HasKey(p => p.Id);
            //Property(p => p.IdIdentity).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //HasIndex(p => p.Id).IsUnique(true);
            //Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.NickName).IsRequired().HasMaxLength(30);
            //HasIndex(p => p.NickName).IsUnique(true);
            Property(p => p.FirstName).IsOptional().HasMaxLength(30);
            Property(p => p.LastName).IsOptional().HasMaxLength(30);            
            //Ignore(p => p.FullName)
            ;

            HasMany(p => p.Reviews).WithRequired(p => p.Person).HasForeignKey(p => p.PersonId).WillCascadeOnDelete(false);
            HasMany(p => p.WishedCities).WithRequired(p => p.Person).HasForeignKey(p => p.PersonId);//.WillCascadeOnDelete(true);
            HasMany(p => p.Comments).WithRequired(p => p.Person).HasForeignKey(p => p.PersonId);//.WillCascadeOnDelete(true);

        }
    }
}