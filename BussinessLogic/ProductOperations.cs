using DomainLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class ProductOperations : IProductOperations
    {
        private readonly IGenericRepositoryOperation<Product> _products;
        public ProductOperations(IGenericRepositoryOperation<Product> products)
        {
            _products = products;
        }
        public async Task AddProduct(Product products)
        {
            _products.Add(products);
        }

        public async Task DeleteProduct(Product products)
        {
            _products.Delete(products);
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            return _products.GetAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return _products.GetById(id);
        }

        public async Task UpdateProduct(Product products)
        {
            _products.Update(products);
        }
    }
}
