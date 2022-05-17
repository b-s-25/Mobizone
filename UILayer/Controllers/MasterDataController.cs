using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Controllers
{
    public class MasterDataController : Controller
    {
        public IActionResult MasterData()
        {
            return View();
        }
    }
}
