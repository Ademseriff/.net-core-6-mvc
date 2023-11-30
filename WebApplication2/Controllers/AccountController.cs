using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using WebApplication2.Entities;
using WebApplication2.Models;
using static WebApplication2.Entities.User;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly IConfiguration _IConfiguration;

        
        public AccountController(DataBaseContext dataBaseContext , IConfiguration ıConfiguration)
        {
            _dataBaseContext = dataBaseContext;
            _IConfiguration = ıConfiguration;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                String md5salt = _IConfiguration.GetValue<string>("AppSettings:MD5Salt");
                String saltedpassword = model.Password + md5salt;
                string hashedpassword = saltedpassword.MD5();
                User user = _dataBaseContext.Users.FirstOrDefault(x => x.Username.ToLower() == model.Username.ToLower() && x.Password == hashedpassword);
                if(user != null)
                {
                    if (user.Locked)
                    {
                        ModelState.AddModelError(model.Username, "this acount is locked");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "username or password is false");
                }

            }
            return View(model);
        }
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(_dataBaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower() ))
                {
                    Console.WriteLine("kullanıcı var ");
                    return View(model);
                }
                String md5salt = _IConfiguration.GetValue<string>("AppSettings:MD5Salt");
                String saltedpassword = model.Password + md5salt;
                string hashedpassword = saltedpassword.MD5();

                User user = new()
                {
                    Username = model.Username,
                    Password = hashedpassword
                };
                _dataBaseContext.Add(user);
               int count= _dataBaseContext.SaveChanges();//save changes değeri eğer başarılı olursa bir döndürür.

                if (count == 0)
                {
                    Console.WriteLine("işlem başarı ile tamamlanamadı.");
                }
                else
                {
                    RedirectToAction(nameof(Login));
                }
                
             }
            return View(model);

           
        }


    }
}
