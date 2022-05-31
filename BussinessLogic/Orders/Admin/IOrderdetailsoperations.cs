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
=======
   public  interface IOrderDetailsOperations: IGenericRepositoryOperation<UserCheckOut>
>>>>>>> cadfa2b97c6047b14e6a49b564b8a593c5472d9a
    {
        Task<IEnumerable<UserCheckOut>> GetAll();
        Task Add(UserCheckOut data);
        Task Edit(UserCheckOut entity);
        Task Delete(UserCheckOut entity);
    }
}
