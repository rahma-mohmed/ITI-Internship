using ITIMVCD1.Data;
using ITIMVCD1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITIMVCD1.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext _context = new ITIContext();

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

    }
}
