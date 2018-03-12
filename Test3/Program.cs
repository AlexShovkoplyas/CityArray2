using CityArrayDAL.EF;
using CityArrayDAL.Identity;
using CityArrayDAL.Model;
using CityArrayDAL.UnitOfWork;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityArrayDAL;

namespace Test3
{
    public class Review
    {
        //public int Id { get; set; }
        //public string CityName { get; set; }
        public string Person { get; set; }
        public int Rating { get; set; }
        //public DateTime CreationDate { get; set; }
        //public string CityDescription { get; set; }
    }
    enum MyEnum
    {
        Person,
        Rating
    }


    class Program
    {
        static void Main(string[] args)
        {
            var s = "Person";
            var e = new MyEnum();
            var b = Enum.TryParse(s,out e);

            var d = MyEnum.Person;
            var f = d.ToString();

            Console.ReadLine();


        }
    }


}
