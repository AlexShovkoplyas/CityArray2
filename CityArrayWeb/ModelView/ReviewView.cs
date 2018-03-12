using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityArrayWeb.ModelView
{
    public class ReviewView
    {
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string PersonName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
        [Required]
        [Range(0, 10)]
        public int Rating { get; set; }

        public string CityDescription { get; set; }
        public string CityFeatures { get; set; }
        public string CityBags { get; set; }

        public string CoverPictureUrl() => "~/Images/Review/" + Id + "/1.jpg";
    }

    public class ReviewModify
    {
        public int Id { get; set; }

        [Required]
        public string CityId { get; set; }

        [Required]
        [Range(0, 10)]
        public int Rating { get; set; }

        [Required]
        [StringLength(500)]
        public string CityDescription { get; set; }
        [StringLength(500)]
        public string CityFeatures { get; set; }
        [StringLength(500)]
        public string CityBags { get; set; }
    }

    public class ReviewInfo
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string PersonName { get; set; }
        public int Rating { get; set; }
        public DateTime CreationDate { get; set; }
        public string CityDescription { get; set; }

        public string CoverPictureUrl() => "~/Images/City/" + Id + "/1.jpg";
    }


}