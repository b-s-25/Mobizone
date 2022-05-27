using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace RepositoryLayer.Interface
{
    public interface IRepositryOperation <T>
    {
        IEnumerable<T> Index();
        Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Details(int id);
        void Save();
    }
}
