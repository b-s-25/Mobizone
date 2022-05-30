using DomainLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Orders.Admin
{
   public  interface IOrderdetailsoperations: IGenericRepositoryOperation<UserOrders>
    {
        Task<IEnumerable<UserOrders>> GetAll();
        Task Add(UserOrders data);
        Task Edit(UserOrders entity);
        Task Delete(UserOrders entity);
    }
}
