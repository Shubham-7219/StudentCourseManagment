using StudentCourseManagment.Models;
using StudentCourseManagment.Repository.GeneralRepository;

namespace StudentCourseManagment.Repository.CourseRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        void Update(Course course);
        void Save();
    }
}
