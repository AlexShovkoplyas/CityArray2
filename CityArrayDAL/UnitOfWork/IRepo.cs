using System;
//using CityArrayDAL.Identity;
using CityArrayDAL.Model;
using CityArrayDAL.Repository;
using CityArrayDAL.Repository.Interfaces;

//using Microsoft.AspNet.Identity;

namespace CityArrayDAL.UnitOfWork
{
    public interface IRepo : IDisposable
    {
        IPersonRepository People { get; } 
        ICityRepository Cities { get; }
        ICountryRepository Countries { get; }
        IReviewRepository Reviews { get; }
        IWishesRepository Wishes { get; }

        //AppUserManager UserManager { get; }
        //AppRoleManager RoleManager { get; }
        void Save();
    }
}