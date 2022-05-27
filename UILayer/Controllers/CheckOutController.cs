﻿using AspNetCoreHero.ToastNotification.Abstractions;
using DomainLayer;
using DomainLayer.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.ApiServices;
using UILayer.Datas.Apiservices;

namespace UILayer.Controllers
{
    public class CheckOutController : Controller
    {
        IConfiguration _configuration;
        private readonly OrdersApi _ordersApi;
        private readonly UserApi _userApi;
        private readonly AddressApi _addressApi;
        private readonly INotyfService _notyf;
        private readonly Masterdataapi _masterApi;

        public CheckOutController(INotyfService notyf,IConfiguration configuration)
        {
            _configuration = configuration;
            _ordersApi = new OrdersApi(_configuration);
            _userApi = new UserApi(_configuration);
            _addressApi = new AddressApi(_configuration);
            _notyf = notyf;
            _masterApi = new Masterdataapi(_configuration);
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

        [Authorize]
        [HttpGet("/checkout/address")]
        public IActionResult Address()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAddress(Address userAddress)
        {
            try
            {
                var data = _addressApi.AddAddress(userAddress);
                if (data)
                {
                    return View("checkout");
                }
                return RedirectToAction("/Index");
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

        [HttpPost]
        public IActionResult OrderConfirmed()
        {
            return View("OrderPlaced");
        }
        [HttpGet]
        public IActionResult BuyNow()
        {

            var addresses = _addressApi.GetAddress();
            var user = _userApi.GetUserInfo().Where(x => x.email.Equals(User.Claims?.FirstOrDefault(x => x.Type.Equals("email", StringComparison.OrdinalIgnoreCase))?.Value)).FirstOrDefault();
            ViewData["UserAddress"] = user.address.FirstOrDefault();
            return View();
        }
       /* [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult MyOrders(int id)
        {
            var list = ProductApi.index();
            ViewData["ProductList"] = list;
            Registration user = new Registration();
            user = _userApi.GetUserInfo().Where(val => val.email.Equals(User.Claims?.FirstOrDefault(x => x.Type.Equals("email", StringComparison.OrdinalIgnoreCase))?.Value)).FirstOrDefault();
            ViewData["UserData"] = user;
            _masterApi.MasterDatas();
            return View();
        }*/

        [HttpPost]
        public IActionResult MyOrders(UserCheckOut checkOut)
        {
            if (checkOut == null)
            {
                _notyf.Error("No orders placed");
                ViewBag.BrandList = _ordersApi.GetCheckOutList();
                return RedirectToAction("Index");
            }
            else
            {
                var data = ProductApi.GetById(checkOut.productId);
                data.quantity = data.quantity - checkOut.quantity;
                if (data.quantity == 0)
                {
                    data.productStatus= Status.disable;
                }
                //data.
                //ProductApi.Edit(checkOut);
                Random random = new Random();
                checkOut.orderId = random.Next();
                checkOut.status = OrderStatus.orderPlaced;
                checkOut.price = checkOut.quantity * data.productPrice;
                bool result = _ordersApi.AddCheckOutList(checkOut);
                ViewBag.orderId = checkOut.orderId;
                _notyf.Success("Successfully Ordered");
                 _masterApi.MasterDatas();
                return View("OrderPlaced");
            }
        }

        [Authorize(Roles = "User")]
        public IActionResult Orderplaced()
        {
            _masterApi.MasterDatas();
            return View();
        }
    }
}
