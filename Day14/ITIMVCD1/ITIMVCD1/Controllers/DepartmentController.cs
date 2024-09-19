using ITIMVCD1.Data;
using ITIMVCD1.IRepository;
using ITIMVCD1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIMVCD1.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext _context;
        IDepartmentRepository deptRepository;

        public DepartmentController(ITIContext context, IDepartmentRepository deptRepository)
        {
            _context = context;
            this.deptRepository = deptRepository;
        }

        public IActionResult Index()
        {
            //var res = _context.Department.ToList();
            var res = deptRepository.GetAll();
            return View(res);
        }

        [Authorize(Roles = "Admin")]
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
                deptRepository.Create(dept);
                return RedirectToAction("Index");
            }
            else
            {
                return View(dept);
            }
        }

        [Authorize]
        public IActionResult Details(int? deptid)
        {
            if(deptid == null)
            {
                return BadRequest();
            }
            //Department dept = _context.Department.SingleOrDefault(d => d.Id == deptid);
            Department dept = deptRepository.GetById(deptid.Value);
            if(dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            //Department dept = _context.Department.SingleOrDefault(d => d.Id == id);
            Department dept = deptRepository.GetById(id);
            return View(dept);
        }

        [HttpPost , ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            /*Department dept = _context.Department.SingleOrDefault(d => d.Id == id);
            _context.Department.Remove(dept);
            _context.SaveChanges();*/
            deptRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id) {
            //Department dept = _context.Department.SingleOrDefault(d => d.Id == id);
            Department dept = deptRepository.GetById(id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            //Department dept = _context.Department.SingleOrDefault(s => s.Id == department.Id);
            Department dept = deptRepository.GetById(department.Id);
            if (dept != null)
            {
                if (ModelState.IsValid)
                {
                    //dept.Id = department.Id;
                    //dept.Name = department.Name;
                    //dept.Capacity = department.Capacity;
                    //_context.SaveChanges();
                    deptRepository.Update(department);
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
