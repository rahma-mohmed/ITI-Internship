using ITIMVCD1.IRepository;
using ITIMVCD1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITIMVCD1.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository _courseRepo;

        public CourseController(ICourseRepository repository) {
            _courseRepo = repository;
        }

        public IActionResult Index()
        {
            List<Course> crslis = _courseRepo.GetAll();
            return View(crslis);
        }

        public IActionResult Details(int id)
        {
            Course crs = _courseRepo.GetById(id);
            return View(crs);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int Id)
        {
            Course crs = _courseRepo.GetById(Id);
            return View(crs);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            Course crs = _courseRepo.GetById(Id);
            _courseRepo.Delete(crs);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Create(Course crs)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.Create(crs);
                return RedirectToAction("Index");   
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            Course crs = _courseRepo.GetById(id);
            return View(crs);
        }

        [HttpPost]
        public IActionResult Update(Course crs)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.Update(crs);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
