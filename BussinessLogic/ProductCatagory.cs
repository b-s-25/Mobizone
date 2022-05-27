using BusinesLogic.Interface;
using DomainLayer;
using Repository;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic
{
    public class ProductCatagory : IProductCatagory
    {

        ProductDbContext _Context;
        IRepositryOperation<Products> _repo;
        public ProductCatagory(ProductDbContext Context)
        {
            _Context = Context;
            _repo = new RepositryOperation<Products>(_Context);
        }

        public void Create(Products entity)
        {
            _repo.Create(entity);
            _repo.Save();
        }


        public void Delete(Products entity)
        {
            _repo.Delete(entity);
            _repo.Save();
        }

        public Products Details(int id)
        {
            return _repo.Details(id);
        }

        public async  Task<IEnumerable<Products>> index()
        {
            return await _repo.GetAll(n1=> n1.specification);
        }

        public void Save()
        {
            _repo.Save();
        }

        public void Update(Products entity)
        {
            _repo.Update(entity);
            _repo.Save();
        }
    }
}

