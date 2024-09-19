using ITIMVCD1.Models;

namespace ITIMVCD1.IRepository
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Create(Department department);
        public void Update(Department department);
        public void Delete(int id);
    }
}
