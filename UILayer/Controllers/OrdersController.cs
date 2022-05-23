using AspNetCoreHero.ToastNotification.Abstractions;
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

        /*public IActionResult OrdersList()
        {
            try
            {
                var data = _ordersApi.GetCheckOutList();
                 
            }
        }*/
    }
}
