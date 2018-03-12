using System;
using System.Collections.Generic;

namespace CityArrayDAL.Repository.Interfaces
{
    public interface IBaseRepository<T> :IDisposable
    {
        T Add(T entity);
        void AddRange(List<T> entity);
        void Delete(T entity);
        void Delete(int id);
        T GetOne(int id);
        List<T> GetAll();
        void Update(T entity);
    }
}