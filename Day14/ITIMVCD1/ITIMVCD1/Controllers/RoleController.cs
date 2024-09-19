using ITIMVCD1.Data;
using ITIMVCD1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIMVCD1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        ITIContext _context;

        public RoleController(ITIContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Role> roles = _context.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            _context.Roles.Add(role);   
            _context.SaveChanges();
            return View();
        }
/*
        public IActionResult Delete(Role role)
        {

        }*/
    }
}
