using ITIMVCD1.Data;
using ITIMVCD1.Models;

namespace ITIMVCD1.Repository
{
    public class DepartmentRepo : IDepartment
    {
        ITIContext _context = new ITIContext();

        public void Create(Department department)
        {
            department.Statuse = true;
            _context.Add(department);
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            Department dp = _context.Department.FirstOrDefault(a => a.Id == id);
            dp.Statuse = false;
            //_context.Department.Remove(dp);
            _context.SaveChanges();
        }

        public List<Department> GetAll()
        {
            return _context.Department.Where(a => a.Statuse==true).ToList();
        }

        public Department GetById(int id)
        {
            return _context.Department.FirstOrDefault(d => d.Id == id);
        }

        public void Update(Department department)
        {
            Department dept = _context.Department.SingleOrDefault(a => a.Id == department.Id);
            dept.Id = department.Id;
            dept.Name = department.Name;
            dept.Capacity = department.Capacity;
            _context.SaveChanges();
        }
    }
}
