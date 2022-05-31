using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.ApiServices;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly OrderDetailsApi _orderDetailsApi;
        public IActionResult OrderList()
        {
            return View();
        }
        public IActionResult OrderUpdate(string status, int orderId)
        {
            var orderupdate = _orderDetailsApi.GetOderDetails().Where(x => x.id.Equals(orderId)).FirstOrDefault();

            orderupdate.status = (DomainLayer.Orders.OrderStatus)(int)(Status)Enum.Parse(typeof(Status), status);
            _orderDetailsApi.OrderDetailsEdit(orderupdate);
            return RedirectToAction("OrderList");
        }
        [HttpGet]
        public IActionResult OrderStatus()
        {
            return new JsonResult(EnumConvertion.EnumToString<Status>());
        }
        public IActionResult OrderDetails(int id)
        {
            if (id == 0)
            {
                return View("Index");
            }
            var orderDetailsList = _orderDetailsApi.OrderDetailsGetById(id);


            return View(orderDetailsList);


        }
    }
}
