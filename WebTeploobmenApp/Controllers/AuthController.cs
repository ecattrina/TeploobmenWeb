using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;
using WebTeploobmenApp.Data;
using Microsoft.AspNetCore.Authentication;

namespace WebTeploobmenApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly TeploobmenContext _context;
        public AuthController(TeploobmenContext context)
        {
      
            _context = context;
        }
        public async Task<IActionResult> Logout(string login, string password)
        {
          
                await HttpContext.SignOutAsync();
                return RedirectToAction("Index", "Home");
 
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null) {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name,login) };
                // создаем объект ClaimsIdentity
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                // установка аутентификационных куки
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
