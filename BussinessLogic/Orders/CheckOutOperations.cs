using DomainLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Orders
{
    public class CheckOutOperations : ICheckOutOperations
    {
        private readonly IGenericRepositoryOperation<UserCheckOut> _checkOutOperations;
        public CheckOutOperations(IGenericRepositoryOperation<UserCheckOut> checkOutOperations)
        {
            _checkOutOperations = checkOutOperations;
        }

        public async Task AddOrderList(UserCheckOut userCheckOut)
        {
            _checkOutOperations.Add(userCheckOut);
        }

        public async Task DeleteOrderList(UserCheckOut userCheckOut)
        {
            _checkOutOperations.Delete(userCheckOut);
        }

        public async Task<IEnumerable<UserCheckOut>> GetOrderList()
        {
            return _checkOutOperations.GetAll();
        }

        public async Task<UserCheckOut> GetOrderListById(int id)
        {
            return _checkOutOperations.GetById(id);
        }

        public async Task UpdateOrderList(UserCheckOut userCheckOut)
        {
            _checkOutOperations.Update(userCheckOut);
        }
    }    
}

