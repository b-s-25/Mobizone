using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.ApiServices;

namespace UILayer.Controllers
{
    public class MasterDataController : Controller
    {
        IConfiguration _configuration;
        private readonly Masterdataapi _masterdataapi;
        public MasterDataController(IConfiguration configuration)
        {
            _configuration = configuration;
            _masterdataapi = new Masterdataapi(_configuration);
        }
        public IActionResult MasterData()
        {
            var masterdata = _masterdataapi.MasterDatas();
            return View(masterdata);
        }
    }
}
