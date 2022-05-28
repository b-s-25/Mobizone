using APILayer.Models;
using BusinesLogic;
using BusinesLogic.Interface;
using DomainLayer.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatagoryController : ControllerBase
    {
        
            private readonly ILogger<ProductCatagoryController> _logger;
            IProductCatagory _catalog;

        public ProductCatagoryController(ILogger<ProductCatagoryController> logger, IProductCatagory catalog)
            {
                _logger = logger;
                _catalog = catalog;
        }
            [HttpGet("Index")]
            public Task<IEnumerable<ProductsModel>> Index()
            {
                try
                {
                    var products = _catalog.GetProducts();
                    return products;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error message", ex);
                    return null;
                }
            }


        [HttpGet]
        [Route("ProductCatagory/Details/{id}")]
            public IActionResult Details(int id)
            {
                try
                {
                    var data = _catalog.Details(id);
                    return Ok(data);
                }
                catch(Exception ex)
                {
                    _logger.LogError("Error In Post", ex);
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }


            [HttpPost("ProductPost")]
            public async Task<IActionResult> ProductPost(ProductsModel products)
            {
                try
                {
                    _catalog.Create(products);
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error In Post", ex);
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            [HttpPut("ProductPut")]
            public  IActionResult ProductPut([FromBody] ProductsModel product)
            {
                try
                {
                    _catalog.Update(product);
                    return StatusCode(StatusCodes.Status200OK);

                }
                catch (Exception ex)
                {
                    _logger.LogError("Error In Put", ex);
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }

        [HttpDelete("ProductDelete/{id}")]
            public IActionResult ProductDelete(int id)
            {
                try
                {
                    var product = _catalog.Details(id);
                    _catalog.Delete(product);
                    return StatusCode(StatusCodes.Status200OK);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error In Put", ex);
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
    }
}
