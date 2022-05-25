using APILayer.Models;
using BusinesLogic;
using BusinesLogic.Interface;
using DomainLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using RepositoryLayer;
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
            ProductDbContext _context;
            IProductCatagory _catalog;
            /*ISpecOperation _spec;*/


            public ProductCatagoryController(ProductDbContext context/*,ISpecOperation specification*/, ILogger<ProductCatagoryController> logger)
            {
                _logger = logger;
                _context = context;
                _catalog = new ProductCatagory(_context);
                /*_spec = specification;*/
            }
            [HttpGet("Index")]
            public IEnumerable<Products> Index()
            {
                try
                {
                    var products = _catalog.index();
                    return products;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error message");
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
            public async Task<IActionResult> ProductPost([FromBody] Products product)
            {
                try
                {
                _catalog.Create(product);
                    return Ok("success");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error In Post", ex);
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            [HttpPut("ProductPut")]
            public  IActionResult ProductPut([FromBody] Products product)
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
                    Products product = new Products();
                    product = _catalog.Details(id);
                    _catalog.Delete(product);
                    return StatusCode(StatusCodes.Status200OK);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error In Put", ex);
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }


       /* [HttpGet("Get")]
        public IEnumerable<Specification> Get()
        {
            try
            {
                var specific = _spec.Index();
                return specific;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error message");
                return null;
            }
        }


        [HttpGet]
        [Route("SpecOperation/Details/{id}")]
        public IActionResult SpecDetails(int id)
        {
            try
            {
                var data = _spec.Details(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error In Post", ex);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }


        [HttpPost("SpecPost")]
        public async Task<IActionResult> SpecPost([FromBody] Specification specification)
        {
            try
            {
                _spec.Create(specification);
                return Ok("success");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error In Post", ex);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut("SpectPut")]
        public IActionResult SpecPut([FromBody] Specification specification)
        {
            try
            {
                _spec.Update(specification);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error In Put", ex);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("SpecDelete/{id}")]
        public IActionResult SpecDelete(int id)
        {
            try
            {
                Specification specification = new Specification();
                specification = _spec.Details(id);
                _spec.Delete(specification);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error In Put", ex);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }*/
    }
}
