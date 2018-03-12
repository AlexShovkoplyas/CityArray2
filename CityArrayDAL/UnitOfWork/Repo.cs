using System;
using System.Data.Entity;
using CityArrayDAL.EF;
//using CityArrayDAL.Identity;
using CityArrayDAL.Model;
using CityArrayDAL.Repository;
using CityArrayDAL.Repository.Base;
using CityArrayDAL.Repository.Interfaces;
using log4net;

namespace CityArrayDAL.UnitOfWork
{
    public class Repo : IRepo
    {
        private readonly CityArrayContext _context;

        public Repo()
        {
            var logger = LogManager.GetLogger(this.GetType());
            //_context.Database.Log = Console.WriteLine;
            logger.Debug("Repo class was created");

            _context = new CityArrayContext();
            People = new PersonRepository(_context);
            Cities = new CityRepository(_context);
            Countries = new CountryRepository(_context);
            Reviews = new ReviewRepository(_context);
            Wishes = new WishesRepository(_context);
        }

        public IPersonRepository People { get; }
        public ICityRepository Cities { get; }
        public ICountryRepository Countries { get; }
        public IReviewRepository Reviews { get; }
        public IWishesRepository Wishes { get; }

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

        ~Repo()
        {
            _context.Dispose();
        }
    }
}