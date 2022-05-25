using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Interface
{
    public interface IProductCatagory
    {
        IEnumerable<Products> index();
        void Create(Products entity);
        void Update(Products entity);
        void Delete(Products entity);
        Products Details(int id);
        void Save();
    }
}
