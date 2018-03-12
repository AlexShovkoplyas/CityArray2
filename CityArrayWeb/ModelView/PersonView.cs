using CityArrayDAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityArrayWeb.ModelView
{
    public class PersonView
    {
        public int Id { get; set; }

        [Display(Name ="Name")]
        public string NickName { get; set; }

        [Display(Name = "Nationality")]
        [DisplayFormat(NullDisplayText = "No nationality")]
        public string CountryName { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown")]
        public int Age { get; set; }

        public List<ReviewInfo> Reviews { get; set; }
        public List<WishedCityView> WishedCities { get; set; }

        public string CoverPictureUrl() => "~/Images/Person/" + Id + "/1.jpg";
    }

    public class PersonInfo
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string NickName { get; set; }

        [Display(Name = "Nationality")]
        [DisplayFormat(NullDisplayText = "No nationality")]
        public string CountryName { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown")]
        public int Age { get; set; }

        [Display(Name = "Reviews Count")]
        public int ReviewsCount { get; set; }
        [Display(Name = "Wishes Count")]
        public int WishesCount { get; set; }

        public string CoverPictureUrl() => "~/Images/Person/" + Id + "/1.jpg";
    }
}