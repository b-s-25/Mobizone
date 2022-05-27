using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Interface
{
    public interface ISpecOperation
    {
        IEnumerable<Specification> Index();
        void Create(Specification entity);
        void Update(Specification entity);
        void Delete(Specification entity);
        Specification Details(int id);
        void Save();
    }
}
