using DomainLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UILayer.Datas.Apiservices;
using UILayer.Controllers;

namespace UILayer.Controllers
{
    public class ProductController : Controller
    {
        Products Data = null;
        ProductView Storage = null;
        /*Specification Spec = null;*/
        private IWebHostEnvironment _webHostEnvironment;

        public ProductController(IWebHostEnvironment hostEnvironment)
        {
            Data = new Products();

            _webHostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            IEnumerable<Products> products = ProductApi.index();
            return View(products);
        }



        public IActionResult Details(int id)
        {
            Products products = ProductApi.GetById(id);
            return View(products);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Storage = new ProductView();
            Products product = ProductApi.GetById(id);
            Storage.productName = product.productName;
            Storage.productPrice = product.productPrice;
            Storage.productModel = product.productModel;
            Storage.quantity = product.quantity;
            Storage.description = product.description;
            return View("Create", Storage);
        }

        public ActionResult Delete(int id)
        {
            bool result = ProductApi.Delete(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductView product)
        {
            if (product.id == 0)
            {
                string stringFileName = UploadFile(product);
                var Product = new Products
                {
                    productName = product.productName,
                    productPrice = product.productPrice,
                    productModel = product.productModel,
                    image = stringFileName,
                    quantity = product.quantity,
                    description = product.description
                };

                bool result = ProductApi.Create(Product);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                return Content("Failed");
            }
            else
            {
                string stringFileName = UploadFile(product);
                var Product = new Products
                {
                    id = product.id,
                    productName = product.productName,
                    productPrice = product.productPrice,
                    productModel = product.productModel,
                    image = stringFileName,
                    quantity = product.quantity,
                    description = product.description
                };
                bool result = ProductApi.Edit(Product);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                return Content("Failed");
            }
        }

        private string UploadFile(ProductView product)
        {
            string fileName = null;
            if (product.image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + product.image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.image.CopyTo(fileStream);
                }
            }

            return fileName;
        }
        public IEnumerable<Products> GetList()
        {
            IEnumerable<Products> products = ProductApi.index();
            return products;
        }
    } 
}
