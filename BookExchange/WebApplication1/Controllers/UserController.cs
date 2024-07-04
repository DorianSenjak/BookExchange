using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.ViewModels;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Security;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _context;
        public UserController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            var loginVm = new LoginVM { ReturnURL = returnUrl };

            return View();

        }
        [HttpPost]
        public IActionResult Login(LoginVM loginVm)
        {
            // Try to get a user from database
            var existingUser = _context.Accounts.FirstOrDefault(x => x.Username == loginVm.Username);
            if (existingUser == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }

            // Check is password hash matches
            //var  = _context.Accounts.FirstOrDefault(x => x.PasswordHash == existingUser.PasswordHash);
            if (existingUser.PasswordHash != loginVm.Password)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
            // Create proper cookie with claims
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, loginVm.Username),
                new Claim(ClaimTypes.Role, "User"),
                new Claim("UserId",existingUser.Idaccount.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();

            Task.Run(async () =>
              await HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(claimsIdentity),
                  authProperties)
            ).GetAwaiter().GetResult();

            if (string.IsNullOrEmpty(loginVm.ReturnURL))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            Task.Run(async () =>
                await HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme)
            ).GetAwaiter().GetResult();

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserVM userVM)
        {
            try
            {
                // Check if there is such a username in the database already
                var trimmedUsername = userVM.Email.Trim();
                if (_context.Accounts.Any(x => x.Username.Equals(trimmedUsername)))
                {
                    ModelState.AddModelError("", "Username already taken");
                    return View();
                }

                // Hash the password
                var b64salt = PasswordHashProvider.GetSalt();
                var b64hash = PasswordHashProvider.GetHash(userVM.Password, b64salt);

                // Create user from DTO and hashed password
                var user = new Account
                {
                   Username = userVM.Username,
                   PasswordHash = userVM.Password,
                };

                // Add user and save changes to database
                _context.Add(user);
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


            return RedirectToAction("Login");
        }
    }
}
