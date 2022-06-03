using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UILayer.Datas.Apiservices;
using Microsoft.AspNetCore.Authorization;
using DomainLayer;
using UILayer.ApiServices;
using Microsoft.AspNetCore.Http;
using DomainLayer.EmailService;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.Win32;

namespace UILayer.Controllers
{
    public class UserController : Controller
    {
        private UserApi _userApi;
        private readonly ProductApi _productApi;
        private IConfiguration _configuration;
        private Registration _registration;
        private readonly INotyfService _notyf;
        public UserController(IConfiguration configuration, INotyfService notyf)
        {
            _configuration = configuration;
            _userApi = new UserApi(_configuration);
            _productApi = new ProductApi(_configuration);
            _notyf = notyf;
        }
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View(_productApi.GetProduct());
        }

        [HttpGet]
        public IActionResult UserRegister()

        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegister(Registration registrationView)
        {
            var check = _userApi.UserRegister(registrationView);
            if (check)
            {
                _notyf.Success("Registration Successfully Completed");
            }
            else
            {
                _notyf.Error("Registration Failed, You are already Registered");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["LoginUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login loginView, string ReturnUrl)
        {
            AdminApi admin = new AdminApi();
            if (ReturnUrl == "/admin")
            {
                if (admin.AdminLogin(loginView))
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim("password", loginView.password));
                    claims.Add(new Claim("email", loginView.username));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, loginView.username));
                    claims.Add(new Claim(ClaimTypes.Name, loginView.username));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return Redirect("/admin/Index");
                }
            }
            Login userLogin = new Login();
            bool check = _userApi.UserLogin(loginView);
<<<<<<< HEAD
=======
            //_registration = _userApi.GetUserInfo().Where(register => register.email == loginView.username && register.password.Equals(loginView.password)).FirstOrDefault();

>>>>>>> 318fad8dccc6ac168fd132dea98a6483f07d6e7e
            if (check)
            {
                _registration = _userApi.GetUserInfo().Where(register => register.email == loginView.username && loginView.password.Equals(loginView.password)).FirstOrDefault();
                var claims = new List<Claim>();

                claims.Add(new Claim("password", loginView.password));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, loginView.username));
                claims.Add(new Claim("email", loginView.username));
                claims.Add(new Claim(ClaimTypes.Name, _registration.firstName + " " + _registration.lastName));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index");
            }
            TempData["Error"] = "*Invalid Email or Password";
            return View("Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("Login");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPassword forgotPassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpContext.Session.SetString("key", "value");
                    var data = HttpContext.Session.Id;

                    ModelState.Clear();
                    var userDetails = _userApi.GetUserInfo().Where(check => check.email.Equals(forgotPassword.email)).FirstOrDefault();
                    if (userDetails != null)
                    {
                        forgotPassword.emailSent = true;
                        Email email = new Email();
                        email.body = "<a href='https://localhost:44328/user/ResetPassword/" + forgotPassword.email + "/" + data + "'>Click here to reset your password</a>";
                        email.toEmail = forgotPassword.email;
                        email.subject = "reset password";
                        _userApi.Email(email);
                        return View("ForgotPassword", forgotPassword);
                    }
                }
                return View(forgotPassword);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("/user/ResetPassword/{email}/{sessionId}")]
        public ActionResult ResetPassword(string email, string sessionId)
        {
            if (sessionId == HttpContext.Session.Id)
            {
                var userDetails = _userApi.GetUserInfo().Where(check => check.email.Equals(email)).FirstOrDefault();
                ResetPassword reset = new ResetPassword();
                reset.user = userDetails;
                return View(reset);
            }
            return RedirectToAction("ForgotPassword");
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                Registration register = new Registration();
                register = _userApi.GetUserInfo().Where(c => c.email.Equals(resetPassword.user.email)).FirstOrDefault();
                register.password = resetPassword.newPassword;
                var result = _userApi.ForgotPassword(register);
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("filter")]
        public IActionResult filter(string brandName)
        {

            var data = _productApi.GetProduct().Where(x => x.specification.productBrand.Equals(brandName));


            //IEnumerable<ProductView> filteredData = (IEnumerable<ProductView>)_productApi.GetProduct().Where(c => c.productStatus.Equals(Status.enable));
            //if (filteredData != null)
            //{
            //    if (brandName != null)
            //    {
            //        filteredData = (IEnumerable<ProductView>)_productApi.Filter(brandName).Result;
            //    }
            //    int count = 0;
            //    var productCount = filteredData.Count();
            //    int cout = 0;
            //    for (int i = 0; i <= 0; i++)
            //    {
            //        if (productCount > 10)
            //        {
            //            cout += 1;
            //        }
            //        productCount = productCount - 10;
            //    }
            //    var result = filteredData.Skip((int)count * 10).Take(10);
            //    ViewBag.count = cout;
            //    return View("Index", result);
            //}

            return View("Index",data);
        }

    }
}
