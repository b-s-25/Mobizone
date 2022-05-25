using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace RepositoryLayer.Interface
{
    public interface IRepositryOperation <T>
    {
        IEnumerable<T> Index();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Details(int id);
        void Save();
    }
}
