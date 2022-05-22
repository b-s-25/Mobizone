using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class SendEmailController : Controller
    {
        const string sessionName = "_name";
        const string sessionAge = "_age";
        public IActionResult Index()
        {
            HttpContext.Session.SetString(sessionName, "Jarvik");
            HttpContext.Session.SetInt32(sessionAge, 24);
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Name = HttpContext.Session.GetString(sessionName);
            ViewBag.Age = HttpContext.Session.GetInt32(sessionAge);
            ViewData["Message"] = "Asp.Net Core !!!.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
