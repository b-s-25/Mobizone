using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UILayer.ApiServices;

namespace UILayer.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly AdminApi _adminApi;
        public AdminController()
        {
            _adminApi = new AdminApi();
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("Login");
        }
        [Authorize]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Userdata()
        {
            var _userlist = _adminApi.GetUserData();

            return View(_userlist);
        }
    }


}
