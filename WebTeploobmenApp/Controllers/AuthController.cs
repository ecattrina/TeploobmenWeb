using Microsoft.AspNetCore.Mvc;

namespace WebTeploobmenApp.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Index(string login, string password)
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
