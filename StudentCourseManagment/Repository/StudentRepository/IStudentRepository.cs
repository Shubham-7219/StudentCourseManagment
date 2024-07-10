using StudentCourseManagment.Models;
using StudentCourseManagment.Repository.GeneralRepository;

namespace StudentCourseManagment.Repository.StudentRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Update(Student student);
        void Save();
    }
}
