using ITIMVCD1.Data;
using ITIMVCD1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Immutable;
using System.Security.Claims;

namespace ITIMVCD1.Controllers
{
    public class AccountController : Controller
    {
        ITIContext _context;

        public AccountController(ITIContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<User> lis = _context.users.ToList();    
            return View(lis);
        }

        public IActionResult Register()
        {
            ViewBag.SelectList = _context.Roles.Select(a => new SelectListItem() { Text = a.RoleName, Value = a.RoleName }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserRole = "User";
                _context.users.Add(user);
                await _context.SaveChangesAsync();

                UserRoles role = new UserRoles();
                role.UserId = user.Id;
                role.RoleId = _context.Roles.FirstOrDefault(r => r.RoleName == user.UserRole).Id;

                _context.UserRoles.Add(role);
                await _context.SaveChangesAsync();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.Role, user.UserRole)
                };
                ClaimsIdentity CI = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal CP = new ClaimsPrincipal(CI);

                await HttpContext.SignInAsync(CP);

                return RedirectToAction("Index" , "Student");
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult RegisterUser()
        {
            ViewBag.SelectList = _context.Roles.Select(a => new SelectListItem() { Text = a.RoleName, Value = a.RoleName }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                _context.users.Add(user);
                await _context.SaveChangesAsync();

                UserRoles role = new UserRoles();
                role.UserId = user.Id;
                role.RoleId = _context.Roles.FirstOrDefault(r => r.RoleName == user.UserRole).Id;

                _context.UserRoles.Add(role);
                await _context.SaveChangesAsync();

                return View("Index");
            }
            return View();
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if(ModelState.IsValid)
            {

                User res = _context.users.SingleOrDefault(u => (u.Name == user.Name && u.Password == u.Password));

                if (res == null)
                {
                    ModelState.AddModelError("", "You Dont Have Account");
                }
                else
                {
                    Claim c1 = new Claim(ClaimTypes.Name, res.Name);
                    Claim c2 = new Claim(ClaimTypes.Email, res.Email);
                    Claim c3 = new Claim(ClaimTypes.MobilePhone, res.PhoneNumber);
                    Claim c4 = new Claim(ClaimTypes.Role, res.UserRole);

                    ClaimsIdentity CI = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    CI.AddClaim(c1);
                    CI.AddClaim(c2);
                    CI.AddClaim(c3);
                    CI.AddClaim(c4);

                    ClaimsPrincipal CP = new ClaimsPrincipal(CI);

                    await HttpContext.SignInAsync(CP);

                    return RedirectToAction("Index", "Student");
                }
            }
            ModelState.AddModelError("", "Invalid username or Password");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EmailCheck(string email)
        {
            var check = _context.users.Any(u => u.Email == email);
            return Json(!check);
        }
    }
}
