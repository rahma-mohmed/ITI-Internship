using ITIMVCD1.Data;
using ITIMVCD1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITIMVCD1.Controllers
{
    public class StudentController : Controller
    {
        ITIContext _context = new ITIContext();

        public JsonResult Index()
        {
            var res = _context.Students.ToList();
            return Json(res);
        }

        public string Create(string name, int age , int deptid)
        {
            Student student = new Student();
            student.Name = name;
            student.Age = age;
            student.DeptId = deptid;
            _context.Students.Add(student);
            _context.SaveChanges();
            return "Student Added Successfully!!";
        }

        public IActionResult Details(int stdid)
        {
            Student std = _context.Students.SingleOrDefault(s => s.Id == stdid);
            std.Department = _context.Department.Find(std.DeptId);
            return View(std);
        }

        public string Delete(int id)
        {
            Student std = _context.Students.SingleOrDefault(s => s.Id == id);
            _context.Students.Remove(std);
            _context.SaveChanges();
            return $"Student {std.Id} Deleted Successfully!!";
        }

        public string Update(int id, string name, int age)
        {
            Student std = _context.Students.SingleOrDefault(s => s.Id == id);
            if (std != null)
            {
                std.Name = name;
                std.Age = age;
                _context.SaveChanges();

                return $"Student Updated Successfully!!";
            }
            return $"Student Of ID = {std.Id} Is Not Found";
        }

    }
}
