using DomainLayer.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class UserCheckOut
    {
        [Key]
        public int id { get; set; }
        public int orderId { get; set; }
        public int userId { get; set; }
        public Registration user { get; set; }
        public int quantity { get; set; }

        [ForeignKey("Products")]
        public int productId { get; set; }
        public Products product { get; set; }
        public int price { get; set; }
        public int paymentModeId { get; set; }

        [ForeignKey("Address")]
        public int addressId { get; set; }
        public Address address { get; set; }
        public OrderStatus status { get; set; }
        public RoleType? cancelRequested { get; set; }
    }
}
