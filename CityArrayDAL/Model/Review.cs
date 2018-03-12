using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityArrayDAL.Model
{
    public class Review : IIdKey
    {
        public int Id { get; set; }
        public int CityId { get; set; }        
        public int PersonId { get; set; }             
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public string CityDescription { get; set; }
        public string CityFeatures { get; set; }
        public string CityBags { get; set; }

        public virtual City City { get; set; }
        public virtual Person Person { get; set; }
        public virtual List<Comment> Comments { get; set; }

    }
}