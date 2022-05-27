using APILayer.Models;
using BusinesLogic.Interface;
using BussinessLogic;
using BussinessLogic.Orders;
using BussinessLogic.Orders.Admin;
using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobizoneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderdetailsController : ControllerBase
    {
        private readonly IOrderdetailsoperations _orderdetailsoperations;
        private readonly IProductCatagory _productCatagory;
        private readonly IUserOperations _userOperations;
        private readonly ILogger<OrderdetailsController> _logger;
        private readonly IAddressOperations _addressOperations;
        private readonly ProductDbContext _Context;
        IEnumerable<UserOrders> _order;
        public OrderdetailsController(ProductDbContext Context, IOrderdetailsoperations orderdetailsoperations)
        {
            _Context = Context;
            _orderdetailsoperations = orderdetailsoperations;

        }
        [HttpPost("Orderdetails")]
        public IActionResult Orderdetails([FromBody] UserOrders userOrders)
        {
            Response<string> _response = new Response<string>();
            try
            {
                userOrders.Address = _addressOperations.GetAddress().Result.Where(x => x.id.Equals(userOrders.addressid)).FirstOrDefault();
                userOrders.product = _productCatagory.index().Where(x => x.id.Equals(userOrders.productId)).FirstOrDefault();
                userOrders.users = _userOperations.GetUser().Result.Where(x => x.registrationId.Equals(userOrders.registrationId)).FirstOrDefault();
                _orderdetailsoperations.Add(userOrders);
                string message = "added" + ", Response Message : " + new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                _response.AddResponse(true, 0, "", message);
                var data = Newtonsoft.Json.JsonConvert.SerializeObject(_response);
                return new JsonResult(_response);

            }
            catch (Exception ex)
            {
                string message = "error occured" + ", Response Message : " + new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                _response.AddResponse(false, 0, null, message);
                _logger.LogError("error", ex);
                return new JsonResult(_response);

            }

        }
        [HttpGet("Orderdetails")]
        public Response<IEnumerable<UserOrders>> Orderdetails(int id)
        {
            Response<IEnumerable<UserOrders>> _response = new Response<IEnumerable<UserOrders>>();
            try
            {
                _order = _orderdetailsoperations.GetAll().Result;
                if (_order == null)
                {
                    string message = " null data" + " , " + new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    _response.AddResponse(true, 0, null, message);
                    return _response;
                }
                else
                {
                    string message = "" + new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    _response.AddResponse(true, 0, _order, message);
                    return _response;
                }
               
            }
            catch (Exception ex)
            {
                string message = " exception occured" + new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                _response.AddResponse(false, 0, null, message);
                _logger.LogError("error", ex);
                return _response;

            }


        }
        [HttpPut("OrderPut")]
        public IActionResult OrderPut([FromBody]UserOrders orderPut)
        {
            Response<string> _response = new Response<string>();
            try
            {
                _orderdetailsoperations.Edit(orderPut);
                string message = "Updated" + new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                _response.AddResponse(true, 0, null, message);
                return new JsonResult(_response);
            }
            catch (Exception ex)
            {
                string message = "Error occured" + new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                _response.AddResponse(false, 0, null, message);
                _logger.LogError("error", ex);
                return new JsonResult(_response);
            }
        }
    }
}
