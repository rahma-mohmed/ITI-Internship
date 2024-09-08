using ITIMVCD1.Data;
using ITIMVCD1.Models;
using ITIMVCD1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIMVCD1.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext _context = new ITIContext();
        IDepartment studentRepository = new DepartmentRepo();

        public IActionResult Index()
        {
            //var res = _context.Department.ToList();
            var res = studentRepository.GetAll();
            return View(res);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                /*_context.Department.Add(dept);
                _context.SaveChanges();*/
                studentRepository.Create(dept);
                return RedirectToAction("Index");
            }
            else
            {
                return View(dept);
            }
        }

        public IActionResult Details(int? deptid)
        {
            if(deptid == null)
            {
                return BadRequest();
            }
            //Department dept = _context.Department.SingleOrDefault(d => d.Id == deptid);
            Department dept = studentRepository.GetById(deptid.Value);
            if(dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        public IActionResult Delete(int id)
        {
            //Department dept = _context.Department.SingleOrDefault(d => d.Id == id);
            Department dept = studentRepository.GetById(id);
            return View(dept);
        }

        [HttpPost , ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            /*Department dept = _context.Department.SingleOrDefault(d => d.Id == id);
            _context.Department.Remove(dept);
            _context.SaveChanges();*/
            studentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) {
            //Department dept = _context.Department.SingleOrDefault(d => d.Id == id);
            Department dept = studentRepository.GetById(id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            //Department dept = _context.Department.SingleOrDefault(s => s.Id == department.Id);
            Department dept = studentRepository.GetById(department.Id);
            if (dept != null)
            {
                if (ModelState.IsValid)
                {
                    //dept.Id = department.Id;
                    //dept.Name = department.Name;
                    //dept.Capacity = department.Capacity;
                    //_context.SaveChanges();
                    studentRepository.Update(department);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(dept);
                }
            }
            return BadRequest();
        }

    }
}
