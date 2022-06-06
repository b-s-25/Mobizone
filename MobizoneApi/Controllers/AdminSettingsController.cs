using BussinessLogic.AdminSettings;
using BussinessLogic.Settings;
using DomainLayer.AdminSettings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobizoneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminSettingsController : ControllerBase
    {
        IAboutOperations _aboutOperations;
        IContactOperations _contactOperations;

        public AdminSettingsController(IAboutOperations aboutOperations, IContactOperations contactOperations)

        {
            _aboutOperations = aboutOperations;
            _contactOperations = contactOperations;
        }



        [HttpPost("AboutPost")]
        public IActionResult AboutPost([FromBody] About about)
        {

            try
            {
                _aboutOperations.Add(about);
                string message = "Content Added" + ", Response Message : " + new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string message = "Exception occured" + ", Response Message : " + new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                return BadRequest(message);
            }

        }
        [HttpGet("AboutGet")]
        public IEnumerable<About> AboutGet()
        {

            try
            {
                var about = _aboutOperations.Get();
                if (about == null)
                {
                    return null;
                }
                else
                {
                    return about;
                }

            }
            catch (Exception ex)
            {

                return null;
            }

        }

        // Update Method for About
        [HttpPut("AboutPut")]
        public IActionResult AboutPut([FromBody] About about)
        {

            try
            {
                _aboutOperations.Edit(about);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        


        [HttpPost("ContactPost")]
        public IActionResult ContactPost([FromBody] Contact contact)
        {

            try
            {
                _contactOperations.Add(contact);


                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        [HttpGet("ContactGet")]
        public IEnumerable<Contact> ContactGet()
        {

            try
            {
                var contact = _contactOperations.Get();
                if (contact == null)
                {

                    return null;
                }
                else
                {

                    return contact;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #region Update Method for Contact
        [HttpPut("ContactPut")]
        public IActionResult ContactPut([FromBody] Contact contact)
        {

            try
            {
                _contactOperations.Edit(contact);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        #endregion

    }
}