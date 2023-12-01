using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles ="admin")] //bu validation giriş yapmış kullanıcıları içeri almamıza yarayan kontroldür. controller seviyesindede verebiliriz.
        public IActionResult Index()
        {
            return View();
        }
    }
}
