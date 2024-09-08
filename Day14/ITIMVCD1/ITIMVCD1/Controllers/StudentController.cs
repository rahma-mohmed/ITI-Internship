using ITIMVCD1.Data;
using ITIMVCD1.Models;
using ITIMVCD1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITIMVCD1.Controllers
{
    public class StudentController : Controller
    {
        ITIContext _context = new ITIContext();
        IStudent studentRepo = new StudentRepository();
        IDepartment departmentRepo = new DepartmentRepo();

        public IActionResult Index()
        {
            //var res = _context.Students.Include(s => s.Department).ToList();
            var res = studentRepo.GetAll();
            return View(res);
        }

        public IActionResult Create()
        {
            //ViewBag.Departments =_context.Department.ToList();
            ViewBag.Departments = departmentRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                //_context.Students.Add(student);
                //_context.SaveChanges();
                studentRepo.Create(student);
                return RedirectToAction("Index");
            }
            else
            {
                //ViewBag.Departments = _context.Department.ToList();
                ViewBag.Departments = departmentRepo.GetAll();
                return View(student);
            }
        }

        public IActionResult Details(int stdid)
        {
            //Student std = _context.Students.Include(s => s.Department).SingleOrDefault(s => s.Id == stdid);
            Student std = studentRepo.GetById(stdid);
            return View(std);
        }

        public IActionResult Delete(int id)
        {
            //Student std = _context.Students.SingleOrDefault(s => s.Id == id);
            Student std = studentRepo.GetById(id);
            return View(std);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            //Student std = _context.Students.SingleOrDefault(s => s.Id == id);
            //_context.Students.Remove(std);
            //_context.SaveChanges();
            Student std = studentRepo.GetById(id);
            studentRepo.Delete(std);   
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            //Student std = _context.Students.Include(s => s.Department).SingleOrDefault(s => s.Id == id);
            //ViewBag.Departments = _context.Department.ToList();
            Student std = studentRepo.GetById(id);
            ViewBag.Departments = departmentRepo.GetAll();
            return View(std);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            Student std = studentRepo.GetById(student.Id);
            ViewBag.Departments = departmentRepo.GetAll();
            if (ModelState.IsValid)
            {
                studentRepo.Update(student);
                return RedirectToAction("Index");
            }
           else
           {
                return View(student);
           }
        }

        public IActionResult EmailCheck(string email)
        {
            var emailexist = _context.Students.Any(s => s.Email == email);
            return Json(!emailexist);
        }
    }
}
