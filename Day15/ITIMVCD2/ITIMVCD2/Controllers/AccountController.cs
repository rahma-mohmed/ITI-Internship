using ITIMVCD2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ITIMVCD2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid) {
                if(user.Name == "Rahma" && user.Password == "12345")
                {
                    Claim c1 = new Claim(ClaimTypes.Name, user.Name);
                    Claim c2 = new Claim(ClaimTypes.Email , $"{user.Name}@gmsil.com");
                    Claim c3 = new Claim(ClaimTypes.Role, "Student");

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    claimsIdentity.AddClaim(c1);
                    claimsIdentity.AddClaim(c2);
                    claimsIdentity.AddClaim(c3);

                    ClaimsPrincipal cp = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(cp);

                    return RedirectToAction("Index" , "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
