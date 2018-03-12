using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityArrayDAL.EF;
using CityArrayDAL.Model;

namespace CityArrayDAL
{
    class Program
    {
        public static void Main()
        {
            //Console.WriteLine(AppDomain.CurrentDomain.GetData("DataDirectory"));
            //Console.ReadKey();

            using (var context = new CityArrayContext())
            {
                var country = new Country() { Name = "Ukraine" };
                context.Countries.Add(country);
                context.SaveChanges();
            }
        }
    }
}
