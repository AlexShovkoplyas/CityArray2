using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityArrayDAL.Model;

namespace CityArrayDAL.Identity
{
    public class ClientManager : IClientManager
    {
        //public AppContext Database { get; set; }
        //public ClientManager(AppContext db)
        //{
        //    Database = db;
        //}

        //public void Create(Person item)
        //{
        //    Database.ClientProfiles.Add(item);
        //    Database.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    Database.Dispose();
        //}
        public void Create(Person item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
