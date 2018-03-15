namespace CityArrayDAL.Migrations
{
    using CityArrayDAL.EF;
    using System.Data.Entity.Migrations;


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
