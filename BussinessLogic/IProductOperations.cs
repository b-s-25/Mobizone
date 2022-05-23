using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public interface IProductOperations
    {
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product products);
        Task UpdateProduct(Product products);
        Task DeleteProduct(Product products);
    }
}
