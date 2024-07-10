using StudentCourseManagment.DataContext;
using StudentCourseManagment.Models;
using StudentCourseManagment.Repository.GeneralRepository;

namespace StudentCourseManagment.Repository.CourseRepository
{
    public class CourseRepository : Repository<Course>,ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
        }
    }
}
