using System;
using System.Data.Entity;
using CityArrayDAL.EF;
//using CityArrayDAL.Identity;
using CityArrayDAL.Model;
using CityArrayDAL.Repository;
using CityArrayDAL.Repository.Cashed;
using CityArrayDAL.Repository.Interfaces;
using log4net;

namespace CityArrayDAL.UnitOfWork
{
    public class RepoCashed : IRepo
    {
        private readonly CityArrayContext _context;

        public RepoCashed()
        {
            var logger = LogManager.GetLogger(this.GetType());
            //_context.Database.Log = Console.WriteLine;
            logger.Debug("Repo class was created");

            _context = new CityArrayContext();            
            People= new PersonRepositoryCashed(_context);
            Cities=new CityRepositoryCashed(_context);
            Countries= new CountryRepositoryCashed(_context);
            Reviews= new ReviewRepositoryCashed(_context);
            Wishes = new WishesRepositoryCashed(_context);
        }

        public IPersonRepository People { get; } 
        public ICityRepository Cities { get; }
        public ICountryRepository Countries { get; }
        public IReviewRepository Reviews { get; }
        public IWishesRepository Wishes { get; }

        //public AppUserManager UserManager => throw new NotImplementedException();

        //public AppRoleManager RoleManager => throw new NotImplementedException();

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        ~RepoCashed()
        {
            _context.Dispose();
        }
    }
}