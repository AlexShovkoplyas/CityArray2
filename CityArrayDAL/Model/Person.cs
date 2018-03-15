using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CityArrayDAL.Model
{
    public partial class Person : IIdKey
    {
        //[Key, ForeignKey("AppUser")]
        public int Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CountryId { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime AddDay { get; set; }

        public virtual Country Nationality { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual List<Review> Reviews { get; set; }
        public virtual List<WishedCity> WishedCities { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public string FullName() => FirstName + " " + LastName;

        public int? Age()
        {
            if (BirthDay.HasValue)
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDay.Value.Year;
                if (BirthDay > today.AddYears(-age)) age--;
                return age;
            }
            return null;
        }

        //public decimal[][] VisitedCitiesCoordinated() =>
        //    Reviews.Select(p => new[] { p.City.Latitude, p.City.Longitude }).ToArray();

        //public decimal[][] WishedCitiesCoordinated() =>
        //    WishedCities.Select(p => new[] { p.City.Latitude, p.City.Longitude }).ToArray();
        
    }
}