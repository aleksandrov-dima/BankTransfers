using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BankTransfers.Data;
using BankTransfers.Data.Models.Security;
using BankTransfers.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankTransfers.Controllers
{
    public class UserAccountController : Controller
    {
        private ApplicationDbContext _context;

        public UserAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    //получаем хэш пароля
                    var hashedPassword = PasswordHelper.GetSaltedHashedPassword(model.Password, out string salt);

                    // добавляем пользователя в бд
                    user = new User
                    {
                        Email = model.Email,
                        Salt = salt,
                        Password = hashedPassword
                    };
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
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
                //получаем пользователя по введенному логину (email). Думаем, что логины уникальны,
                //и поэтому при регистрации по хорошему надо добавить проверку на уникальность логина

                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user != null && PasswordHelper.CheckPassword(model.Password, user.Password, user.Salt))
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<RedirectResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}