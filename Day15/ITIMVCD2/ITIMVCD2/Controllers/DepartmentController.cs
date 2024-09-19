using ITIMVCD1.Data;
using ITIMVCD1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITIMVCD1.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext _context = new ITIContext();

        [Authorize]
        public JsonResult Index()
        {
            var res = _context.Department.ToList();
            return Json(res);
        }

        public string Create(int deptid , string name , int capacity)
        {
            Department department = new Department();
            department.Name = name;
            department.Capacity = capacity;
            department.Id = deptid;
            _context.Department.Add(department);
            _context.SaveChanges();
            return "Department Added Successfully!!";
        }

        public IActionResult Details(int deptid)
        {
            Department dept = _context.Department.SingleOrDefault(d => d.Id == deptid);
            //return $"Department ID: {dept.Id}, Department Name: {dept.Name}, Department Capacity: {dept.Capacity}";
            return View(dept);
        }

        public string Delete(int id)
        {
            Department dept = _context.Department.SingleOrDefault(d => d.Id == id);
            _context.Department.Remove(dept);
            _context.SaveChanges();
            return $"Department {dept.Id} Deleted Successfully!!";
        }

        public string Update(int id, string name, int capacity)
        {
            Department department= _context.Department.SingleOrDefault(d => d.Id==id);
            if (department != null)
            {
                department.Name = name;
                department.Capacity = capacity;
                _context.SaveChanges();

                return $"Department Updated Successfully!!";
            }
            return $"Department Of ID = {department.Id} Is Not Found";
        }

        public IActionResult AddName()
        {
            int Id = 3;
            string Name = "Ali";
            Response.Cookies.Append("fname", Name , new CookieOptions { Expires = DateTime.Now.AddDays(1)});
            Response.Cookies.Append("Id", Id.ToString());
            return View();
        }

        public IActionResult GetName() {
            int Id = int.Parse(Request.Cookies["Id"]);
            string Name = Request.Cookies["fname"];
            return Content($"{Id}: {Name}");
        }

        public IActionResult AddId()
        {
            HttpContext.Session.SetInt32("Id", 100);
            HttpContext.Session.SetString("Name", "Rahma");
            return View("AddName");
        }

        public IActionResult GetId()
        {
            int? Id = HttpContext.Session.GetInt32("Id");
            string Name = HttpContext.Session.GetString("Name");
            return Content($"{Id}: {Name}");
        }
    }
}
