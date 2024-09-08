using ITIMVCD1.Models;
namespace ITIMVCD1.Repository
{
    public interface IStudent
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Create(Student student);    
        public void Update(Student student);
        public void Delete(Student student);
    }
}
