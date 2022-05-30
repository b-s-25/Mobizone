using DomainLayer;
using Repository;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Orders.Admin
{
    public class Orderdetailsoperations: GenericRepositoryOperation<UserOrders>,IOrderdetailsoperations
    {
        private readonly IGenericRepositoryOperation<UserOrders> _repo;
        private readonly ProductDbContext _dbContext;
        public Orderdetailsoperations(ProductDbContext dbContext, IGenericRepositoryOperation<UserOrders> repo) :base(dbContext)
        {
            _repo = repo;
            _dbContext = dbContext;

        }
        public async Task<IEnumerable<UserOrders>> GetAll()
        {
            return await _repo.GetAll(x => x.users, x => x.product);
        }
        public async Task Add(UserOrders data)
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
        public async Task Edit(UserOrders entity)
        {
            _repo.Update(entity);
            _repo.Save();
        }
        public async Task Delete(UserOrders entity)
        {
            _repo.Delete(entity);
            _repo.Save();
        }
    }
}
