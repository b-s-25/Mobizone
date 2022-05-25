using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ProductColor
    {
        public int id { get; set; }
        public string productColor { get; set; }
        public DateTime modifiedOn { get; set; }
        public DateTime createdOn { get; set; }
        public string modifiedBy { get; set; }
        public string createdBy { get; set; }
    }
}
