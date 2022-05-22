using APILayer.Controllers;
using BussinessLogic.Orders;
using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobizoneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IAddressOperations _addressOperations;
        private readonly ICheckOutOperations _checkOutOperations;
        private readonly ILogger<UserController> _logger;
        public OrdersController(IAddressOperations addressOperations, ICheckOutOperations checkOutOperations, ILogger<UserController> logger)
        {
            _addressOperations = addressOperations;
            _checkOutOperations = checkOutOperations;
            _logger = logger;
        }

        [HttpGet("GetUserAddress")]
        public async Task<IEnumerable<Address>> GetUserAddress()
        {
            try
            {
                return await _addressOperations.GetAddress();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                return null;
            }
        }

        [HttpPost("AddUserAddress")]
        public IActionResult AddUserAddress(Address address)
        {
            try
            {
                var data = _addressOperations.AddAddress(address);
                if (data != null)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                return null;
            }
        }

        [HttpGet("UpdateUserAddress/{id}")]
        public async Task<Address> UpdateUserAddress(int id)
        {
            try
            {
                return await _addressOperations.GetAddressById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                return null;
            }
        }

        [HttpPut("UpdateUserAddress")]
        public IActionResult UpdateUserAddress(Address address)
        {
            try
            {
                
                    _addressOperations.UpdateAddress(address);
                    return StatusCode(StatusCodes.Status200OK);
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                return null;
            }
        }


        [HttpDelete("DeleteUserAddress")]
        public IActionResult DeleteUserAddress(int id)
        {
            try
            {
                var data = _addressOperations.GetAddressById(id).Result;
                _addressOperations.DeleteAddress(data);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUserCheckOutList")]
        public async Task<IEnumerable<UserCheckOut>> GetUserCheckOutList()
        {
            try
            {
                return await _checkOutOperations.GetOrderList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                return null;
            }
        }

        [HttpPost("AddUserCheckOutList")]
        public IActionResult AddUserCheckOutList(UserCheckOut userCheckOut)
        {
            try
            {
                var data = _checkOutOperations.AddOrderList(userCheckOut);
                if (data != null)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                return null;
            }
        }

        [HttpPut("UpdateUserCheckOutList")]
        public IActionResult UpdateUserCheckOutList(UserCheckOut userCheckOut)
        {
            try
            {
                var data = _addressOperations.GetAddressById(userCheckOut.id);
                if (data != null)
                {
                    _checkOutOperations.UpdateOrderList(userCheckOut);
                    return StatusCode(StatusCodes.Status200OK);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                return null;
            }
        }

        [HttpDelete("DeleteUserCheckOutList")]
        public IActionResult DeleteUserCheckOutList(int id)
        {
            try
            {
                var data = _checkOutOperations.GetOrderListById(id).Result;
                _checkOutOperations.DeleteOrderList(data);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error");
                return BadRequest(ex.Message);
            }
        }
    }
}
