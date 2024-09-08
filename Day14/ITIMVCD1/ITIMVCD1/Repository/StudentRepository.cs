using ITIMVCD1.Data;
using ITIMVCD1.Models;
using Microsoft.EntityFrameworkCore;
namespace ITIMVCD1.Repository
{
    public class StudentRepository : IStudent
    {
        ITIContext _context = new ITIContext();
        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Delete(Student student)
        {
            Student std = _context.Students.FirstOrDefault(x => x.Id == student.Id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            List<Student> students = _context.Students.Include(s => s.Department).ToList();
            return students;
        }

        public Student GetById(int id)
        {
            Student student = _context.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            return student;
        }

        public void Update(Student student)
        {
            var std = _context.Students.FirstOrDefault(student => student.Id == student.Id);
            std.Name = student.Name;
            std.Age = student.Age;
            std.DeptId = student.DeptId;
            _context.SaveChanges();
        }
    }
}
