using BusinesLogic.Interface;
using DomainLayer.Product;
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
        IGenericRepositoryOperation<ProductsModel> _repo;
        public ProductCatagory(IGenericRepositoryOperation<ProductsModel> repo)
        {
            _repo = repo;
        }

        public void Create(ProductsModel entity)
        {
            _repo.Add(entity);
            _repo.Save();
        }


        public void Delete(ProductsModel entity)
        {
            _repo.Delete(entity);
            _repo.Save();
        }

        public ProductsModel Details(int id)
        {
            return _repo.GetById(id);
        }

        public async  Task<IEnumerable<ProductsModel>> GetProducts()
        {
            return await _repo.GetAll(n1=> n1.specification);
        }
        public async Task<IEnumerable<ProductsModel>> Search(string name)
        {
            var data = _repo.GetAll().Where(x => x.productName.StartsWith(name));
            return data;
        }

        public void Save()
        {
            _repo.Save();
        }

        public void Update(ProductsModel entity)
        {
            _repo.Update(entity);
            _repo.Save();
        }
    }
}

