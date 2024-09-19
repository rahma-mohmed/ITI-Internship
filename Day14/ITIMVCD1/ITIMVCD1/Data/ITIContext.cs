using ITIMVCD1.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIMVCD1.Data
{
    public class ITIContext : DbContext
    {
        public DbSet<Student>  Students { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; } 

        public ITIContext(DbContextOptions options) : base(options)
        {
            
        }

        public ITIContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MVCST1;Integrated Security=True;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
