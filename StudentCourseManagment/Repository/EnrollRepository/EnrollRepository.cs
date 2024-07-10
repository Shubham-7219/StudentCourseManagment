using Microsoft.EntityFrameworkCore;
using StudentCourseManagment.DataContext;
using StudentCourseManagment.Models;
using StudentCourseManagment.Repository.GeneralRepository;

namespace StudentCourseManagment.Repository.EnrollRepository
{
    public class EnrollRepository : Repository<Enrollement>, IEnrollRepository
    {
        private readonly ApplicationDbContext _context;
        public EnrollRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Enrollement enrollement)
        {
            _context.Enrollements.Update(enrollement);
        }

        public override IEnumerable<Enrollement> GetAll()
        {
            return _context.Enrollements
                          .Include(e => e.Student)
                          .Include(e => e.Course)
                          .ToList();
        }

    }
}

