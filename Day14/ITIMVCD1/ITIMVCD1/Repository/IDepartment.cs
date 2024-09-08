using ITIMVCD1.Models;

namespace ITIMVCD1.Repository
{
    public interface IDepartment
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Create(Department department);
        public void Update(Department department);
        public void Delete(int id);
    }
}
