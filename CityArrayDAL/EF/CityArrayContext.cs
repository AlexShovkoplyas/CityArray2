using System;
using System.Data.Entity;
using CityArrayDAL.EFConfig;
using CityArrayDAL.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using Person = CityArrayDAL.Model;

namespace CityArrayDAL.EF
{
    public class CityArrayContext : AppIdentityDbContext
    {
        public CityArrayContext() : base("CityArrayDataSql")//
        {                                 
           //Configuration.
        }
        
        static CityArrayContext()
        {
            //Database.SetInitializer<CityArrayContext>(new ContextInitializer());
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Person.Person> People { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<WishedCity> WishedCities { get; set; }
        public DbSet<VisitedPlace> Places { get; set; }

        public static CityArrayContext Create()
        {
            return new CityArrayContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(p => p.Name == "Latitude").Configure(p => p.HasPrecision(8, 6));
            modelBuilder.Properties().Where(p => p.Name == "Longitude").Configure(p => p.HasPrecision(8, 6));

            modelBuilder.Configurations.Add(new AppUserConfig());
            modelBuilder.Configurations.Add(new CityConfig());
            modelBuilder.Configurations.Add(new CommentConfig());
            modelBuilder.Configurations.Add(new CountryConfig());
            modelBuilder.Configurations.Add(new PersonConfig());
            modelBuilder.Configurations.Add(new ReviewConfig());
            modelBuilder.Configurations.Add(new VisitedPlaceConfig());
            modelBuilder.Configurations.Add(new WishedCityConfig());

            base.OnModelCreating(modelBuilder);


        }

        public new void Dispose()
        {
            base.Dispose();
        }

        
    }


}