using AspNetCoreHero.ToastNotification.Abstractions;
using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.ApiServices;

namespace UILayer.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersApi _ordersApi;
        private readonly INotyfService _notyf;
        public OrdersController(OrdersApi ordersApi)
        {
            _ordersApi = ordersApi;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OrdersList()
        {
            try
            {
                var data = _ordersApi.GetCheckOutList();
                return View(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddOrders(UserCheckOut userCheckOut)
        {
            try
            {
                var data = _ordersApi.AddCheckOutList(userCheckOut);
                if (data)
                {
                    return View();
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateOrders(UserCheckOut userCheckOut)
        {
            try
            {
                var data = _ordersApi.EditCheckOutList(userCheckOut);
                if (data)
                {
                    return View();
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
