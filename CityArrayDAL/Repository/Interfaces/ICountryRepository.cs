﻿using System.Collections.Generic;
using CityArrayDAL.Model;

namespace CityArrayDAL.Repository.Interfaces
{
    public interface ICountryRepository: IBaseRepository<Country>
    {
        Dictionary<string,int> GetDictionary();

        Country GetByName(string Name);
    }
}
