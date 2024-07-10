using Microsoft.EntityFrameworkCore;
using StudentCourseManagment.Models;

namespace StudentCourseManagment.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollement> Enrollements { get; set;}
    }
}
