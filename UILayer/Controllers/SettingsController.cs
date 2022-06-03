using DomainLayer.AdminSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.ApiServices;

namespace UILayer.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SettingsApi _settingsApi;
        public SettingsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _settingsApi = new SettingsApi(_configuration);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            var contactData = _settingsApi.GetContact().FirstOrDefault();
            return View(contactData);
        }

        [HttpGet]
        public IActionResult About()
        {

            var aboutData = _settingsApi.GetAbout().FirstOrDefault();
            return View(aboutData);
        }

        [HttpPost("CreateAbout")]
        private IActionResult CreateAbout(About about)
        {
            var createAbout = _settingsApi.CreateAbout(about);
            if (createAbout)
            {
                return View("About");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAbout()
        {
             var aboutData = _settingsApi.GetAbout().FirstOrDefault();
            return View(aboutData);
        }

        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            var createAbout = _settingsApi.EditAbout(about);
            if (createAbout)
            {
                return View("About", _settingsApi.GetAbout().FirstOrDefault());
            }
            return RedirectToAction("Index");
        }

        [HttpPost("CreateContact")]
        public  IActionResult CreateContact(Contact contact)
        {
            var createContact = _settingsApi.CreateContact(contact);
            if (createContact)
            {
                return View("Contact");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditContact()
        {
            var contactData = _settingsApi.GetContact().FirstOrDefault();
            return View(contactData);
        }

        [HttpPut("EditContact")]
        private IActionResult EditContact(Contact contact)
        {
            var editContact = _settingsApi.EditContact(contact);
            if (editContact)
            {
                return View("Contact");
            }
            return RedirectToAction("Index");
        }
    }
}
