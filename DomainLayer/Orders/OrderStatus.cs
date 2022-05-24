using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Orders
{
    public enum OrderStatus
    {
        orderPlaced = 1,
        delivered,
        dispatched,
        cancelled
    }
}
