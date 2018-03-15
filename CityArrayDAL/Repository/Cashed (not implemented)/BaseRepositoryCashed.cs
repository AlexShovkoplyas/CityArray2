using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CityArrayDAL.EF;
using CityArrayDAL.Model;
using CityArrayDAL.Repository.Interfaces;
using log4net;

namespace CityArrayDAL.Repository.Cashed
{
//IRepository<T>
    public class BaseRepositoryCashed<T>: IBaseRepository<T> where T :  class, IIdKey, new()
    {
        protected DbSet<T> DbSet;
        protected ILog Logger;

        public BaseRepositoryCashed(CityArrayContext context)
        {
            Logger = LogManager.GetLogger(this.GetType());
            Context = context;
            DbSet = Context.Set<T>();
        }

        public CityArrayContext Context { get; } 
        
        public T Add(T entity)
        {
            Logger.Debug($"Adding entity {typeof(T).Name}");
            return DbSet.Add(entity);
        }

        public void AddRange(List<T> entity)
        {
            Logger.Debug($"Adding range of entities {typeof(T).Name}");
            DbSet.AddRange(entity);
        }

        public void Delete(T entity)
        {
            Logger.Debug($"Deleting entity {typeof(T).Name} with Id : {entity.Id}");
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(int id)
        {
            Logger.Debug($"Deleting entity {typeof(T).Name} with Id : {id}");
            Context.Entry(new T { Id = id }).State = EntityState.Deleted;
        }

        public T GetOne(int id)
        {
            Logger.Debug($"Retrieve entity {typeof(T).Name} with Id : {id}");
            return DbSet.Find(id);
        }

        public List<T> GetAll()
        {
            Logger.Debug($"Provide all entities {typeof(T).Name}");
            return DbSet.ToList();
        }

        public void Update(T entity)
        {
            Logger.Debug($"Update entity {typeof(T).Name} with Id : {entity.Id}");
            Context.Entry(entity).State = EntityState.Modified;
        }

        public List<T> Find(Func<T, bool> pred)
        {
            Logger.Debug($"Retrive entity {typeof(T).Name} with predicate");
            return DbSet.Where(pred).ToList();
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

        ~BaseRepositoryCashed()
        {
            Dispose(false);
        }
    }
}