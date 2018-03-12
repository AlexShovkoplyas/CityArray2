using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityArrayWeb.ModelView
{
    public class WishedCityView
    {
        public int Id { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public DateTime Date { get; set; }
    }

    public class WishedCityModify
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string PersonName { get; set; }
        public DateTime Date { get; set; }
    }

    public class WishedCityInfo
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string PersonName { get; set; }
        public DateTime Date { get; set; }
    }
}