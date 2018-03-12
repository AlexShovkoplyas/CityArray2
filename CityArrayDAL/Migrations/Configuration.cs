namespace CityArrayDAL.Migrations
{
    using CityArrayDAL.EF;
    using CityArrayDAL.Identity;
    using CityArrayDAL.Model;
    using CityArrayDAL.SeedDataBase;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<CityArrayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CityArrayContext context)
        {
            
        }

    }
}
