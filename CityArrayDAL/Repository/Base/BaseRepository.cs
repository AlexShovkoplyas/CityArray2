using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CityArrayDAL.EF;
using CityArrayDAL.Model;
using CityArrayDAL.Repository.Interfaces;
using log4net;

namespace CityArrayDAL.Repository.Base
{
//IRepository<T>
    public class BaseRepository<T>: IBaseRepository<T> where T :  class, IIdKey, new()
    {
        protected DbSet<T> dbSet;
        protected ILog logger;

        public BaseRepository(CityArrayContext context)
        {
            logger = LogManager.GetLogger(this.GetType());
            Context = context;
            dbSet = Context.Set<T>();
        }

        public CityArrayContext Context { get; } 
        
        public T Add(T entity)
        {
            logger.Debug($"Adding entity {typeof(T).Name}");
            return dbSet.Add(entity);
        }

        public void AddRange(List<T> entity)
        {
            logger.Debug($"Adding range of entities {typeof(T).Name}");
            dbSet.AddRange(entity);
        }

        public void Delete(T entity)
        {
            logger.Debug($"Deleting entity {typeof(T).Name} with Id : {entity.Id}");
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(int id)
        {
            logger.Debug($"Deleting entity {typeof(T).Name} with Id : {id}");
            Context.Entry(new T { Id = id }).State = EntityState.Deleted;
        }

        public T GetOne(int id)
        {
            logger.Debug($"Retrieve entity {typeof(T).Name} with Id : {id}");
            return dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            logger.Debug($"Provide all entities {typeof(T).Name}");
            return dbSet.ToList();
        }

        public void Update(T entity)
        {
            logger.Debug($"Update entity {typeof(T).Name} with Id : {entity.Id}");
            Context.Entry(entity).State = EntityState.Modified;
        }

        public List<T> Find(Func<T, bool> pred)
        {
            logger.Debug($"Retrive entity {typeof(T).Name} with predicate");
            return dbSet.Where(pred).ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            Context.Dispose();
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseRepository()
        {
            Dispose(false);
        }
    }
}