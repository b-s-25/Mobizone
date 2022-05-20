using AspNetCoreHero.ToastNotification.Abstractions;
using DomainLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using UILayer.ApiServices;

namespace UILayer.Controllers
{
    public class MasterDataController : Controller
    {
        
        IConfiguration _configuration;
        private readonly INotyfService _notyf;
        private readonly Masterdataapi _masterdataapi;
        public MasterDataController(IConfiguration configuration, INotyfService notyf)
        {
            _configuration = configuration;
            _masterdataapi = new Masterdataapi(_configuration);
            _notyf = notyf;
        }
        [HttpGet("MasterData")]
        [Authorize]
        public IActionResult MasterData()
        {
            //var datas= new MasterData();
            var masterdata = _masterdataapi.MasterDatas();
            var data = masterdata.Where(c => c.id.Equals(c.parentId));
            return View(masterdata);
        }
        [HttpGet]
        [Authorize]
        public IActionResult AddMasterData()
        {
            return View();
        }
     
        public IActionResult AddMasterdata(MasterData master)
        {
            IEnumerable<MasterData> masterDatas = _masterdataapi.MasterDatas();
            if (masterDatas.Any(c => c.masterData.Equals(master.masterData)))
            {
                _notyf.Error("Already exists");             
            }
            else
            {
                bool data = _masterdataapi.MasterDataAdd(master);
                if (data)
                {
                    _notyf.Success(_configuration.GetSection("Master")["MasterAdded"].ToString());
                }
                else
                {
                    _notyf.Error(_configuration.GetSection("Master")["MasterAddedError"].ToString());
                }
               
            }
            ModelState.Clear();
            return View();

        }
     
    
    }
}
