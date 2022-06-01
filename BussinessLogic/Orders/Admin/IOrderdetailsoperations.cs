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
   public  interface IOrderDetailsOperations: IGenericRepositoryOperation<UserCheckOut>
=======

   public  interface IOrderDetailsOperations : IGenericRepositoryOperation<UserCheckOut>

>>>>>>> ae3e2d92446c463247c65daf230ae3d0c294e19b
    {
        Task<IEnumerable<UserCheckOut>> GetAll();
        Task Add(UserCheckOut data);
        Task Edit(UserCheckOut entity);
        Task Delete(UserCheckOut entity);
    }
}
