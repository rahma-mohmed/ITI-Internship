using ITIMVCD1.Models;
using Microsoft.EntityFrameworkCore;
using ITIMVCD2.Models;

namespace ITIMVCD1.Data
{
    public class ITIContext : DbContext
    {
        public DbSet<Student>  Students { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MVCST1;Integrated Security=True;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ITIMVCD2.Models.LoginViewModel> LoginViewModel { get; set; } = default!;
    }
}
