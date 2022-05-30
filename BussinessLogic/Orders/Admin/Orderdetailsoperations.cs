using DomainLayer;
using Repository;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Orders.Admin
{
<<<<<<< HEAD
    public class OrderDetailsOperations: GenericRepositoryOperation<UserCheckOut>,IOrderDetailsOperations
=======


    public class OrderDetailsOperations: GenericRepositoryOperation<UserCheckOut>,IOrderDetailsOperations

>>>>>>> cadfa2b97c6047b14e6a49b564b8a593c5472d9a
    {
        private readonly IGenericRepositoryOperation<UserCheckOut> _repo;
        private readonly ProductDbContext _dbContext;
        public OrderDetailsOperations(ProductDbContext dbContext, IGenericRepositoryOperation<UserCheckOut> repo) :base(dbContext)
        {
            _repo = repo;
            _dbContext = dbContext;

        }
        public async Task<IEnumerable<UserCheckOut>> GetAll()
        {
<<<<<<< HEAD
         
            return await _repo.GetAll(x => x.user, x => x.product, x => x.address);
=======
            return await _repo.GetAll(x => x.user, x => x.product);
>>>>>>> cadfa2b97c6047b14e6a49b564b8a593c5472d9a
        }
        public async Task Add(UserCheckOut data)
        {
            try
            {
                _repo.Add(data);
                _repo.Save();
            }
            catch (Exception ex)
            {

            }
        }
        public async Task Edit(UserCheckOut entity)
        {
            _repo.Update(entity);
            _repo.Save();
        }
        public async Task Delete(UserCheckOut entity)
        {
            _repo.Delete(entity);
            _repo.Save();
        }

       
    }
}
