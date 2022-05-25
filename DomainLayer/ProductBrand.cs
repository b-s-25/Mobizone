using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ProductBrand
    {
        public int id { get; set; }
        public string brandName { get; set; }
        public DateTime modifiedOn { get; set; }
        public DateTime createdOn { get; set; }
        public string modifiedBy { get; set; }
        public string createdBy { get; set; }
    }
}
