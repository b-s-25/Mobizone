using DomainLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLogic.Orders
{
    public interface ICheckOutOperations
    {
        Task<IEnumerable<UserCheckOut>> GetOrderList();
        Task<UserCheckOut> GetOrderListById(int id);
        Task AddOrderList(UserCheckOut userCheckOut);
        Task UpdateOrderList(UserCheckOut userCheckOut);
        Task DeleteOrderList(UserCheckOut userCheckOut);
    }
}