using CityArrayDAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityArrayWeb.ModelView
{
    public class CityModify
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "City")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Country id")]
        public int CountryId { get; set; }
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
        [Display(Name = "Is Capital?")]
        public bool IsCapital { get; set; }        

        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }

        //public HttpPostedFileBase Picture { get; set; } 
        public string CoverPictureUrl() => "~/Images/City/" + Id + "/1.jpg";

    }

    public class CityView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Country")]
        public string CountryName { get; set; }
        public bool IsCapital { get; set; }
        public int? Rating { get; set; }

        [Display(Name = "Reviews Count")]
        public int ReviewsCount { get; set; }
        [Display(Name = "Wishes Count")]
        public int WishesCount { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual List<ReviewInfo> Reviews { get; set; }
        public virtual List<WishedCityInfo> WishedCities { get; set; }

        public string CoverPictureUrl() => "~/Images/City/" + Id + "/1.jpg";
    }

    public class CityIndex
    {
        public string CoordinatesJson { get; set; }
    }

    public class CityInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public bool IsCapital { get; set; }

        [Display(Name = "Reviews Count")]
        public int ReviewsCount { get; set; }
        [Display(Name = "Wishes Count")]
        public int WishesCount { get; set; }

        public int? Rating { get; set; }

        public string CoverPictureUrl() => "~/Images/City/" + Id + "/1.jpg";
    }


}