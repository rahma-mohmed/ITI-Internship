using ITIMVCD1.Data;
using ITIMVCD1.IRepository;
using ITIMVCD1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITIMVCD1.Controllers
{
    public class StudentController : Controller
    {
        ITIContext _context;
        IStudentRepository _studentRepo;
        IDepartmentRepository _departmentRepo;

        public StudentController(ITIContext context,IStudentRepository studentRepo,IDepartmentRepository departmentRepo)
        {
            _context = context;
            _studentRepo = studentRepo;
            _departmentRepo = departmentRepo;
        }

        public IActionResult Index()
        {
            //var res = _context.Students.Include(s => s.Department).ToList();
            var res = _studentRepo.GetAll();
            return View(res);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            //ViewBag.Departments =_context.Department.ToList();
            ViewBag.Departments = _departmentRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                //_context.Students.Add(student);
                //_context.SaveChanges();
                _studentRepo.Create(student);
                return RedirectToAction("Index");
            }
            else
            {
                //ViewBag.Departments = _context.Department.ToList();
                ViewBag.Departments = _departmentRepo.GetAll();
                return View(student);
            }
        }

        [Authorize]
        public IActionResult Details(int stdid)
        {
            //Student std = _context.Students.Include(s => s.Department).SingleOrDefault(s => s.Id == stdid);
            Student std = _studentRepo.GetById(stdid);
            return View(std);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            //Student std = _context.Students.SingleOrDefault(s => s.Id == id);
            Student std = _studentRepo.GetById(id);
            return View(std);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            //Student std = _context.Students.SingleOrDefault(s => s.Id == id);
            //_context.Students.Remove(std);
            //_context.SaveChanges();
            Student std = _studentRepo.GetById(id);
            _studentRepo.Delete(std);   
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            //Student std = _context.Students.Include(s => s.Department).SingleOrDefault(s => s.Id == id);
            //ViewBag.Departments = _context.Department.ToList();
            Student std = _studentRepo.GetById(id);
            ViewBag.Departments = _departmentRepo.GetAll();
            return View(std);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            Student std = _studentRepo.GetById(student.Id);
            ViewBag.Departments = _departmentRepo.GetAll();
            if (ModelState.IsValid)
            {
                _studentRepo.Update(student);
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
