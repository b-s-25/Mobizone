using AspNetCoreHero.ToastNotification.Abstractions;
using DomainLayer;
using DomainLayer.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.ApiServices;
using UILayer.Datas.Apiservices;

namespace UILayer.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersApi _ordersApi;
        private readonly UserApi _userApi;
        private readonly AddressApi _addressApi;
        private readonly INotyfService _notyf;
        private readonly Masterdataapi _masterApi;
        public OrdersController(OrdersApi ordersApi, UserApi userApi, AddressApi addressApi, INotyfService notyf, Masterdataapi masterApi)
        {
            _ordersApi = ordersApi;
            _userApi = userApi;
            _addressApi = addressApi;
            _notyf = notyf;
            _masterApi = masterApi;
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
            catch (Exception ex)
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

        [HttpGet]
        public IActionResult GetAddress()
        {
            try
            {
                var data = _addressApi.GetAddress();
                return View(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddAddress(Address userAddress)
        {
            try
            {
                var data = _addressApi.AddAddress(userAddress);
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
        public IActionResult UpdateAddress(Address userAddress)
        {
            try
            {
                var data = _addressApi.EditAddress(userAddress);
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

        [HttpGet]
        public IActionResult CheckOut()
        {
            return View("Orderplaced");
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Order(int id)
        {
            //var data = _ordersApi.(id);
            //var data = _productApi.GetProductList(id).Result;
            //ViewData["ProductDetails"] = data;
            Registration user = new Registration();
            user = _userApi.GetUserInfo().Where(val => val.email.Equals(User.Claims?.FirstOrDefault(x => x.Type.Equals("email", StringComparison.OrdinalIgnoreCase))?.Value)).FirstOrDefault();
            ViewData["userData"] = user;
            //ViewBag.BrandList = _masterApi.GetList((int)Master.Brand);
            return View();
        }
        /*[HttpPost]
        public IActionResult Order(UserCheckOut checkout)
        {
            if (checkout == null)
            {
                _notyf.Error("Not Added");
                ViewBag.BrandList = _ordersApi.GetCheckOutList();
                return RedirectToAction("Index");
            }
            else
            {
                var data = _opApi.GetProduct(checkout.productId).Result;
                data.quantity = data.quantity - checkout.quantity;
                if (data.quantity == 0)
                {
                    data.status = ProductStatus.disable;
                }
                var mappedData = (ProductViewModel)_mapper.Map<ProductViewModel>(data);
                _opApi.EditProduct(mappedData);
                Random rnd = new Random();
                checkout.orderId = rnd.Next();
                checkout.status = OrderStatus.orderplaced;
                checkout.price = checkout.quantity * data.price;
                bool result = userApi.CreateCheckOut(checkout);
                ViewBag.orderId = checkout.orderId;
                _notyf.Success("succesfully orderd");
                ViewBag.BrandList = _masterApi.GetList((int)Master.Brand);
                return View("Orderplaced");
            }

        }*/
        [Authorize(Roles = "User")]
        public IActionResult Orderplaced()
        {
            ViewBag.BrandList = _masterApi.GetList((int)Master.Brand);
            return View();
        }
    }
}
