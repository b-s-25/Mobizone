using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Specification
    {
        public int id { get; set; }
        public string productStorage { get; set; }
        public string productBrand { get; set; }
        public string productSim { get; set; }
        public string productColor { get; set; }
        public string productRam { get; set; }
        public string productProcessor { get; set; }
        public DateTime modified_on { get; set; }
        public DateTime created_on { get; set; }
        public string modified_by { get; set; }
        public string created_by { get; set; }

    }
}
