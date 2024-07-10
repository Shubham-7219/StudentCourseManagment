using StudentCourseManagment.DataContext;
using StudentCourseManagment.Models;
using StudentCourseManagment.Repository.GeneralRepository;

namespace StudentCourseManagment.Repository.StudentRepository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {

        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
        public void Save()
        {
           _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }
    }
}
