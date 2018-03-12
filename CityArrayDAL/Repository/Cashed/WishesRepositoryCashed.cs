using CityArrayDAL.EF;
using CityArrayDAL.Repository.Base;
using CityArrayDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityArrayDAL.Repository.Cashed
{
    class WishesRepositoryCashed: WishesRepository
    {
        public WishesRepositoryCashed(CityArrayContext context) : base(context) { }
    }
}
