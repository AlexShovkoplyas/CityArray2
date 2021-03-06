﻿using System;


namespace CityArrayDAL.Model
{
    public class WishedCity : IIdKey
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int PersonId { get; set; }
        public DateTime Date { get; set; }

        public virtual City City { get; set; }
        public virtual Person Person { get; set; }
    }
}
