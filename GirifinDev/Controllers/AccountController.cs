using GirifinDev.Application.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GirifinDev.Application.DTO;

namespace GirifinDev.Controllers
{
    public class AccountController : Controller
    {
        IUserServices _userService;
        public AccountController(IUserServices userService)
        {
            _userService = userService;
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginUserDTO login)
        {
            if (!ModelState.IsValid)
                return View(login);
            var user = _userService.IsExistUser(login.Email, login.Password);
            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری با این اطلاعات یافت نشد");
                return View(login);
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var prancipal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };
            HttpContext.SignInAsync(prancipal, properties);
            return Redirect("/Admin");
        }
        public IActionResult Loguot()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
