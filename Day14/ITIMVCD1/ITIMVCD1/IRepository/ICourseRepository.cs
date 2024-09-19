using ITIMVCD1.Models;

namespace ITIMVCD1.IRepository
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();
        public Course GetById(int id);
        public void Create(Course course);
        public void Update(Course course);
        public void Delete(Course course);
    }
}
