using DomainLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Orders.Admin
{
<<<<<<< HEAD

   public  interface IOrderDetailsOperations : IGenericRepositoryOperation<UserCheckOut>
    { 

=======
   public  interface IOrderDetailsOperations : IGenericRepositoryOperation<UserCheckOut>
    {
>>>>>>> cdfcb3eb63021181477374f6d4508bfdc40ceb14
        Task<IEnumerable<UserCheckOut>> GetAll();
        Task Add(UserCheckOut data);
        Task Edit(UserCheckOut entity);
        Task Delete(UserCheckOut entity);
    }
}
