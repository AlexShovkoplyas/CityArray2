using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityArrayWeb.ModelView
{
    public class PersonReviewCoord
    {
        public string CityName { get; set; }
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class PersonWishCoord
    {
        public string CityName { get; set; }
        public int CityId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class CityCoord
    {
        public int CityId { get; set; }
        public string CityName { get; set; }        
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}