using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CityArrayDAL.Model
{
    public class Country : IIdKey
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }
        public virtual List<Person> People { get; set; }

        
    }

}
