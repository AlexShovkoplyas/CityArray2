
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CityArrayDAL.Model
{
    public class City : IIdKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public bool? IsCapital { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        
        public virtual Country Country { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<WishedCity> WishedCities { get; set; }
    }
}