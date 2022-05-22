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

namespace UILayer.Controllers
{
    public class UserController : Controller
    {
        private UserApi _userApi;
        private IConfiguration _configuration;
        private Registration _registration;
        public UserController(IConfiguration configuration)
        {
            _userApi = new UserApi(_configuration);
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserRegister()
        
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegister(Registration registrationView)
        {
            _userApi.UserRegister(registrationView);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["LoginUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login loginView , string ReturnUrl)
        {
            AdminApi admin = new AdminApi();
            if (ReturnUrl == "/admin")
            {
                if (admin.AdminLogin(loginView))
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim("password", loginView.password));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, loginView.username));
                    claims.Add(new Claim(ClaimTypes.Name, loginView.username));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return Redirect("/admin/Index");
                }
            }
            Login userLogin = new Login();
            //Login userLogin = new Login();
            _registration = _userApi.GetUserInfo().Where(register => register.email == loginView.username).FirstOrDefault();
            userLogin = loginView;
            bool check = _userApi.UserLogin(loginView);
            if (_registration !=null)
            {
                var claims = new List<Claim>();

                claims.Add(new Claim("password", loginView.password));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, loginView.username));
                claims.Add(new Claim(ClaimTypes.Name, _registration.firstName +" " + _registration.lastName));
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
    }
}
