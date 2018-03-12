using CityArrayDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityArrayDAL.Identity
{
    public interface IClientManager : IDisposable
    {
        void Create(Person item);
    }
}
