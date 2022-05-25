using DomainLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class RepositryOperation <T> : IRepositryOperation<T> where T :class
    {
        DbContext _Context;
        readonly DbSet<T> _dbset;
        public RepositryOperation(DbContext product)
        {
            _Context = product;
            _dbset = _Context.Set<T>();
        }



        public IEnumerable<T> Index()
        {
            return _dbset.ToList();
        }

        public void Create(T entity)
        {
            _dbset.Add(entity);
            _Context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
            _Context.SaveChanges();
        }

        public void Delete(T id)
        {
            _dbset.Remove(id);
            _Context.SaveChanges();
        }

        public T Details(int Id)
        {
            return _dbset.Find(Id);
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

    }
}

