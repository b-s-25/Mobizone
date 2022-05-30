using DomainLayer.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class UserOrders
    {
        public int id { get; set; }
        public int orderId { get; set; }

        [ForeignKey("Products")]
        public int productId { get; set; }
        public ProductsModel product { get; set; }

        [ForeignKey("Registration")]
        public int registrationId { get; set; }
        public Registration users { get; set; }
        [ForeignKey("Address")]
        public int addressid { get; set; }
        public Address Address { get; set; }
        public int status { get; set; }
        public int paymentId { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }
}
