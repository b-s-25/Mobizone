using DomainLayer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RepositoryLayer
{

    public class RepositryOperation<T> : IRepositryOperation<T> where T : class
    {
        IQueryable<T> query;
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
        public async Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> result = _dbset;
                query = includes.Aggregate(result, (current, includeProperty) => current.Include(includeProperty));
            }
            catch (SqlException ex)
            {

            }
            return query;
        }

    }
}

