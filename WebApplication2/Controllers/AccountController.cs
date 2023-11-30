using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // login işlemleri
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
