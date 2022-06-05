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

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            var contactData = _settingsApi.GetContact().FirstOrDefault();
            return View(contactData);

        }

        [HttpGet("About")]
        public IActionResult About()
        {

            var aboutData = _settingsApi.GetAbout().FirstOrDefault();
            return View();
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

        [HttpPut("EditAbout")]
        private IActionResult EditAbout(About about)
        {
            var createAbout = _settingsApi.EditAbout(about);
            if (createAbout)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost("CreateContact")]
        private IActionResult CreateContact(Contact contact)
        {
            var createContact = _settingsApi.CreateContact(contact);
            if (createContact)
            {
                return View("Contact");
            }
            return RedirectToAction("Index");
        }

        [HttpPut("EditContact")]
        private IActionResult EditContact(Contact contact)
        {
            var editContact = _settingsApi.EditContact(contact);
            if (editContact)
            {
                return View("ContactEdit");
            }
            return RedirectToAction("Index");
        }
    }
}
