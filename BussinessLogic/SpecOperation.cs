using BusinesLogic.Interface;
using DomainLayer;
using Repository;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic
{
    public class SpecOperation : ISpecOperation
    {
        ProductDbContext _Context;
        IRepositryOperation<Specification> _repo;

        public SpecOperation(ProductDbContext Context)
        {
            _Context = Context;
            _repo = new RepositryOperation<Specification>(_Context);
        }

        public void Create(Specification entity)
        {
            _repo.Create(entity);
            _repo.Save();
        }


        public void Delete(Specification entity)
        {
            _repo.Delete(entity);
            _repo.Save();
        }

        public Specification Details(int id)
        {
            return _repo.Details(id);
        }

        public IEnumerable<Specification> Index()
        {
            return _repo.Index();
        }

        public void Save()
        {
            _repo.Save();
        }

        public void Update(Specification entity)
        {
            _repo.Update(entity);
            _repo.Save();
        }
    }
}
