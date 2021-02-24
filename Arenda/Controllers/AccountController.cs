using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Arenda.Models;
using Arenda.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arenda.Controllers
{
    public class AccountController : Controller
    {
        private ShelkContext db;
        public AccountController(ShelkContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.Include(u => u.RoleFkNavigation).FirstOrDefaultAsync(u => u.UserLogin == model.Login && u.UserPassword == model.Password);
                //User user = await db.Users.FirstOrDefaultAsync(u => u.UserLogin == model.Login && u.UserPassword == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
 //       public async Task<IActionResult> Register(RegisterModel model)
 //       {
 //           if (ModelState.IsValid)
 //           {
 //               User user = await db.Users.FirstOrDefaultAsync(u => u.UserLogin == model.Login);
 //               if (user == null)
 //               {
                    // добавляем пользователя в бд
 //                   db.Users.Add(new User { UserLogin = model.Login, UserName = model.Name, UserPassword = model.Password });
 //                   await db.SaveChangesAsync();

   //                 await Authenticate(model.Login); // аутентификация

     //               return RedirectToAction("Index", "Home");
       //         }
        //        else
       //             ModelState.AddModelError("", "Некорректные логин и(или) пароль");
         //   }
           // return View(model);
        //}

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserLogin),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleFkNavigation.RoleName),
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
