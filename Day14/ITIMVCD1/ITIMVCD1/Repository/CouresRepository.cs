using ITIMVCD1.Data;
using ITIMVCD1.IRepository;
using ITIMVCD1.Models;

namespace ITIMVCD1.Repository
{
    public class CouresRepository : ICourseRepository
    {
        ITIContext _context;

        public CouresRepository(ITIContext context)
        {
            _context = context;
        }

        public void Create(Course course)
        {
            _context.courses.Add(course);
            _context.SaveChanges();
        }

        public void Delete(Course course)
        {
            _context?.courses.Remove(course);
            _context?.SaveChanges();
        }

        public List<Course> GetAll()
        {
            List<Course> coures = _context.courses.ToList();
            return coures;
        }

        public Course GetById(int id)
        {
            Course course = _context.courses.Find(id);
            return course;
        }

        public void Update(Course course)
        {
            _context.courses.Update(course);
            _context.SaveChanges();
        }
    }
}
